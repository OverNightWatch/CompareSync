using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CodeSync
{
    public partial class CodeSyncForm : Form
    {
        private string[] Exts = { "*.h", "*.cpp", "*.cs" };

        private List<string> _allRenderFiles;
        private List<string> _allEngineFiles;

        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private List<string> _renderNewFiles = new List<string>();
        private List<string> _engineNewFiles = new List<string>();
        private List<string> _modifiedFiles = new List<string>();

        private string _renderPath;
        private string _enginePath;

        public CodeSyncForm()
        {
            InitializeComponent();
        }

        public void Log(string msg)
        {
            Debug.Text += string.Format("\n{0} : {1}", DateTime.Now, msg);
        }

        private void RenderPathButton_Click(object sender, EventArgs e)
        {
            ChooseFolderPath((string s) =>
            {
                RenderPath.Text = s;
                _renderPath = s;
            }
            );
        }


        private void EnginePathButton_Click(object sender, EventArgs e)
        {
            ChooseFolderPath((string s) =>
            {
                EnginePath.Text = s;
                _enginePath = s;
            });
        }

        private void ChooseSuccessAction(string path, TextBox pathBox, List<string> fileInfo, TreeView treeView)
        {
            pathBox.Text = path;
        }

        private void ChooseFolderPath(Action<string> successAction)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                if (string.IsNullOrEmpty(path))
                {
                    Log("Empty Path");
                    return;
                }
                successAction(path);
            }
            else
            {

            }
        }

        private List<string> GetAllFilteredFilesInPath(string path, string prefix)
        {
            List<string> filteredFiles = new List<string>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                try
                {
                    foreach (var ext in Exts)
                    {
                        filteredFiles.AddRange(Array.ConvertAll(Directory.GetFiles(path, ext), x => x.Replace(prefix, "")));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return filteredFiles;
        }

        private List<string> GetAllFilteredDirectory(string rootPath)
		{
            return new List<string>
            {
                Path.Combine(rootPath, "Engine\\Source"),
                Path.Combine(rootPath, "Project\\Source")
            };
		}

        private List<string> GetAllFilteredFiles(string path)
		{
            List<string> allDirs = GetAllFilteredDirectory(path);
            List<string> allFiles = new List<string>();
            foreach (var dir in allDirs)
			{
                allFiles.AddRange(GetAllFilteredFilesInPath(dir, path));
			}
            return allFiles;
		}

        private void SetupTreeView(List<FileInfo> files, TreeView treeView)
        {
            treeView.Nodes.Clear();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _worker.DoWork += OnWorkerDoWork;
            _worker.RunWorkerCompleted += OnWorkerCompleted;

            _worker.RunWorkerAsync();
        }

        private string GetFileMD5(string filePath)
        {
            using (MD5? md5 = MD5.Create())
            {
                try
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        byte[]? hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash, 0, hash.Length).ToLowerInvariant();
                    }
                }
                catch (Exception ex)
                {
                    //Log(ex.ToString().Trim());
                }
            }
            return String.Empty;
        }

        private void OnWorkerDoWork(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_renderPath) || string.IsNullOrEmpty(_enginePath))
                return;

            _allRenderFiles = GetAllFilteredFiles(_renderPath);
            _allEngineFiles = GetAllFilteredFiles(_enginePath);

            _allEngineFiles.Sort((l, r) => l.CompareTo(r));
            _allRenderFiles.Sort((l, r) => l.CompareTo(r));

            int renderCount = _allRenderFiles.Count;
            int engineCount = _allEngineFiles.Count;

            _renderNewFiles.Clear();
            _engineNewFiles.Clear();

            _modifiedFiles.Clear();

            int engineIndex = 0;
            for (int i = 0; i < renderCount; i++)
            {
                if (i >= engineCount)
                {
                    _renderNewFiles.Add(_renderPath + _allRenderFiles[i]);
                    continue;
                }

                string renderFullPath = _renderPath + _allRenderFiles[i];
                string engineFullPath = _enginePath + _allEngineFiles[engineIndex];

                if (_allRenderFiles[i].CompareTo(_allEngineFiles[engineIndex]) == 0)
                {
                    if (GetFileMD5(renderFullPath) == GetFileMD5(engineFullPath))
                    {
                        Console.WriteLine(String.Format("Render : {0}, engine : {1}", _allRenderFiles[i], _allEngineFiles[engineIndex]));
                    }
                    else
                    {
                        _modifiedFiles.Add(_allRenderFiles[i]);
                    }
                    engineIndex++;
                    continue;
                }
                else if (_allRenderFiles[i].CompareTo(_allEngineFiles[engineIndex]) < 0)
                {
                    _renderNewFiles.Add(renderFullPath);
                    continue;
                }
                else
                {
                    _engineNewFiles.Add(engineFullPath);
                    engineIndex++;
                    i--;
                    continue;
                }
            }

            if (engineIndex < engineCount - 1)
            {
                _engineNewFiles.AddRange(_allEngineFiles.GetRange(engineIndex, engineCount - engineIndex).ConvertAll(x => _enginePath + x));
            }
        }

        private void OnWorkerCompleted(object sender, EventArgs e)
        {
            Log("\nModifiedFiles");
            foreach (var file in _modifiedFiles)
            {
                Log(file);
            }

            Log("\nRenderNewFiles");
            foreach (var file in _renderNewFiles)
            {
                Log(file);
            }

            Log("\nEngineNewFiles");
            foreach (var file in _engineNewFiles)
            {
                Log(file);
            }

            _worker.DoWork -= OnWorkerDoWork;
            _worker.RunWorkerCompleted -= OnWorkerCompleted;
        }
    }
}
