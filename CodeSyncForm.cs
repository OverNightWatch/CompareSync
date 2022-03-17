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
        private List<string> _renderModifiedFiles = new List<string>();

        private List<string> _engineNewFiles = new List<string>();
        private List<string> _engineModifiedFiles = new List<string>();

        public CodeSyncForm()
        {
            InitializeComponent();
        }

        public void Log(string msg)
        {
            Console.Text += string.Format("\n{0} : {1}", DateTime.Now, msg);
        }

        private void RenderPathButton_Click(object sender, EventArgs e)
        {
            ChooseFolderPath((string s) => RenderPath.Text = s);
        }
        

        private void EnginePathButton_Click(object sender, EventArgs e)
        {
            ChooseFolderPath((string s) => EnginePath.Text = s);
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

        private List<string> GetAllFilteredFilesInPath(string path)
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
                    Log(ex.ToString());
                }
                try
                {
                    foreach (var ext in Exts)
                    {
                        filteredFiles.AddRange(Array.ConvertAll(Directory.GetFiles(path, ext), x => x.Replace(path, "")));
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
            return filteredFiles;
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
                using (var stream = File.OpenRead(filePath))
                {
                    byte[]? hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash, 0, hash.Length).ToLowerInvariant();
                }
            }
        }

        private void OnWorkerDoWork(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(RenderPath.Text) || string.IsNullOrEmpty(EnginePath.Text))
                return;

            _allRenderFiles = GetAllFilteredFilesInPath(RenderPath.Text).ToList();
            _allEngineFiles = GetAllFilteredFilesInPath(EnginePath.Text).ToList();

            _allEngineFiles.Sort((l, r) => l.CompareTo(r));
            _allRenderFiles.Sort((l, r) => l.CompareTo(r));

            int renderCount = _allRenderFiles.Count;
            int engineCount = _allEngineFiles.Count;

            _renderNewFiles.Clear();
            _renderModifiedFiles.Clear();

            _engineNewFiles.Clear();
            _engineModifiedFiles.Clear();

            int engineIndex = 0;
            for (int i = 0; i < renderCount; i++)
            {
                if (i >= engineCount)
                {
                    _renderNewFiles.Add(_allRenderFiles[i]);
                    continue;
                }

                string renderFullPath = _allRenderFiles[i];
                string engineFullPath = _allEngineFiles[engineIndex];

                if (renderFullPath.CompareTo(engineFullPath) == 0)
                {
                    if (GetFileMD5(_allRenderFiles[i]) == GetFileMD5(_allEngineFiles[engineIndex]))
                    {
                    }
                    else
                    {
                        _renderModifiedFiles.Add(_allRenderFiles[i]);
                        _engineModifiedFiles.Add(_allEngineFiles[engineIndex]);
                    }
                    engineIndex++;
                    continue;
                }
                else if (renderFullPath.CompareTo(engineFullPath) < 0)
                {
                    _renderNewFiles.Add(_allRenderFiles[i]);
                    continue;
                }
                else
                {
                    _engineNewFiles.Add(_allEngineFiles[engineIndex]);
                    engineIndex++;
                    i--;
                    continue;
                }
            }

            if (engineIndex < engineCount - 1)
            {
                _engineNewFiles.AddRange(_allEngineFiles.GetRange(engineIndex, engineCount - engineIndex));
            }
        }

        private void OnWorkerCompleted(object sender, EventArgs e)
        {
            Log("RenderNewFiles");
            foreach (var file in _renderNewFiles)
            {
                Log(file);
            }
            Log("RenderModFile");
            foreach (var file in _renderModifiedFiles)
            {
                Log(file);
            }

            Log("EngineNewFiles");
            foreach (var file in _engineNewFiles)
            {
                Log(file);
            }
            Log("EngineModFile");
            foreach (var file in _engineModifiedFiles)
            {
                Log(file);
            }

            _worker.DoWork -= OnWorkerDoWork;
            _worker.RunWorkerCompleted -= OnWorkerCompleted;
        }
    }
}
