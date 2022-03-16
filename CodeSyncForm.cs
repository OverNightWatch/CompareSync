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
                        filteredFiles.AddRange(Directory.GetFiles(path, ext));
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
            if (string.IsNullOrEmpty(RenderPath.Text) || string.IsNullOrEmpty(EnginePath.Text))
                return;

            _allRenderFiles = GetAllFilteredFilesInPath(RenderPath.Text).ToList();
            _allEngineFiles = GetAllFilteredFilesInPath(EnginePath.Text).ToList();

            _allEngineFiles.Sort((l, r) => l.CompareTo(r));
            _allRenderFiles.Sort((l, r) => l.CompareTo(r));

            int renderCount = _allRenderFiles.Count;
            int engineCount = _allEngineFiles.Count;

            //int maxCount = Math.Max(renderCount, engineCount);

            List<string> renderNewFiles = new List<string>();
            List<string> renderModifiedFiles = new List<string>();

            List<string> engineNewFiles = new List<string>();
            List<string> engineModifiedFiles = new List<string>();


            int engineIndex = 0;
            for (int i = 0; i < renderCount; i++)
            {
                if (i >= engineCount)
                {
                    renderNewFiles.Add(_allRenderFiles[i]);
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
                        renderModifiedFiles.Add(_allRenderFiles[i]);
                        engineModifiedFiles.Add(_allEngineFiles[engineIndex]);
                    }
                    engineIndex++;
                    continue;
                }
                else if(renderFullPath.CompareTo(engineFullPath) < 0)
                {
                    renderNewFiles.Add(_allRenderFiles[i]);
                    continue;
                }
                else
                {
                    engineNewFiles.Add(_allEngineFiles[engineIndex]);
                    engineIndex++;
                    i--;
                    continue;
                }
            }

            if (engineIndex < engineCount - 1)
            {
                engineNewFiles.AddRange(_allEngineFiles.GetRange(engineIndex, engineCount - engineIndex));
            }

            Log("RenderNewFiles");
            foreach(var file in renderNewFiles)
            {
                Log(file);
            }
            Log("RenderModFile");
            foreach (var file in renderModifiedFiles)
            {
                Log(file);
            }

            Log("EngineNewFiles");
            foreach (var file in engineNewFiles)
            {
                Log(file);
            }
            Log("EngineModFile");
            foreach (var file in engineModifiedFiles)
            {
                Log(file);
            }
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
    }
}
