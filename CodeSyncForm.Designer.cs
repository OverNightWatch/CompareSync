namespace CodeSync
{
    partial class CodeSyncForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.SyncEngineToRender = new System.Windows.Forms.Button();
			this.SyncRenderToEngine = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.RenderPathButton = new System.Windows.Forms.Button();
			this.EnginePathButton = new System.Windows.Forms.Button();
			this.EnginePath = new System.Windows.Forms.TextBox();
			this.RenderPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Debug = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SyncEngineToRender
			// 
			this.SyncEngineToRender.Location = new System.Drawing.Point(0, 77);
			this.SyncEngineToRender.Name = "SyncEngineToRender";
			this.SyncEngineToRender.Size = new System.Drawing.Size(146, 29);
			this.SyncEngineToRender.TabIndex = 3;
			this.SyncEngineToRender.Text = "Engine->Render";
			this.SyncEngineToRender.UseVisualStyleBackColor = true;
			// 
			// SyncRenderToEngine
			// 
			this.SyncRenderToEngine.Location = new System.Drawing.Point(152, 77);
			this.SyncRenderToEngine.Name = "SyncRenderToEngine";
			this.SyncRenderToEngine.Size = new System.Drawing.Size(152, 29);
			this.SyncRenderToEngine.TabIndex = 2;
			this.SyncRenderToEngine.Text = "Render->Engine";
			this.SyncRenderToEngine.UseVisualStyleBackColor = true;
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(1090, 78);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(135, 29);
			this.RefreshButton.TabIndex = 1;
			this.RefreshButton.Text = "Refesh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 941F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.RenderPathButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.EnginePathButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.EnginePath, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.RenderPath, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1228, 61);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(5, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cloud Render Path";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RenderPathButton
			// 
			this.RenderPathButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderPathButton.Location = new System.Drawing.Point(1118, 5);
			this.RenderPathButton.Name = "RenderPathButton";
			this.RenderPathButton.Size = new System.Drawing.Size(105, 22);
			this.RenderPathButton.TabIndex = 1;
			this.RenderPathButton.Text = "Choose";
			this.RenderPathButton.UseVisualStyleBackColor = true;
			this.RenderPathButton.Click += new System.EventHandler(this.RenderPathButton_Click);
			// 
			// EnginePathButton
			// 
			this.EnginePathButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EnginePathButton.Location = new System.Drawing.Point(1118, 33);
			this.EnginePathButton.Name = "EnginePathButton";
			this.EnginePathButton.Size = new System.Drawing.Size(105, 23);
			this.EnginePathButton.TabIndex = 2;
			this.EnginePathButton.Text = "Choose";
			this.EnginePathButton.UseVisualStyleBackColor = true;
			this.EnginePathButton.Click += new System.EventHandler(this.EnginePathButton_Click);
			// 
			// EnginePath
			// 
			this.EnginePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EnginePath.Location = new System.Drawing.Point(177, 33);
			this.EnginePath.Name = "EnginePath";
			this.EnginePath.Size = new System.Drawing.Size(935, 23);
			this.EnginePath.TabIndex = 5;
			// 
			// RenderPath
			// 
			this.RenderPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RenderPath.Location = new System.Drawing.Point(177, 5);
			this.RenderPath.Name = "RenderPath";
			this.RenderPath.Size = new System.Drawing.Size(935, 23);
			this.RenderPath.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(5, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(166, 29);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cloud Engine Path";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Debug
			// 
			this.Debug.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Debug.Location = new System.Drawing.Point(0, 121);
			this.Debug.Name = "Debug";
			this.Debug.ReadOnly = true;
			this.Debug.Size = new System.Drawing.Size(1228, 585);
			this.Debug.TabIndex = 1;
			this.Debug.Text = "Console:";
			// 
			// CodeSyncForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1228, 706);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.SyncEngineToRender);
			this.Controls.Add(this.SyncRenderToEngine);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.Debug);
			this.Name = "CodeSyncForm";
			this.Text = "CodeSyncForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button RenderPathButton;
        private Button EnginePathButton;
        private Label label2;
        private TextBox RenderPath;
        private TextBox EnginePath;
        private Button SyncEngineToRender;
        private Button SyncRenderToEngine;
        private Button RefreshButton;
        private RichTextBox Debug;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}