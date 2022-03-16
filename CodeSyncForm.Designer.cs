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
            this.RenderPath = new System.Windows.Forms.TextBox();
            this.EnginePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SyncEngineToRender
            // 
            this.SyncEngineToRender.Location = new System.Drawing.Point(0, 87);
            this.SyncEngineToRender.Name = "SyncEngineToRender";
            this.SyncEngineToRender.Size = new System.Drawing.Size(146, 33);
            this.SyncEngineToRender.TabIndex = 3;
            this.SyncEngineToRender.Text = "Engine->Render";
            this.SyncEngineToRender.UseVisualStyleBackColor = true;
            // 
            // SyncRenderToEngine
            // 
            this.SyncRenderToEngine.Location = new System.Drawing.Point(152, 87);
            this.SyncRenderToEngine.Name = "SyncRenderToEngine";
            this.SyncRenderToEngine.Size = new System.Drawing.Size(152, 33);
            this.SyncRenderToEngine.TabIndex = 2;
            this.SyncRenderToEngine.Text = "Render->Engine";
            this.SyncRenderToEngine.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(310, 87);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(135, 33);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refesh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 941F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RenderPathButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.EnginePathButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EnginePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RenderPath, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1228, 69);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cloud Render Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RenderPathButton
            // 
            this.RenderPathButton.Location = new System.Drawing.Point(1118, 5);
            this.RenderPathButton.Name = "RenderPathButton";
            this.RenderPathButton.Size = new System.Drawing.Size(75, 23);
            this.RenderPathButton.TabIndex = 1;
            this.RenderPathButton.Text = "Choose";
            this.RenderPathButton.UseVisualStyleBackColor = true;
            this.RenderPathButton.Click += new System.EventHandler(this.RenderPathButton_Click);
            // 
            // EnginePathButton
            // 
            this.EnginePathButton.Location = new System.Drawing.Point(1118, 37);
            this.EnginePathButton.Name = "EnginePathButton";
            this.EnginePathButton.Size = new System.Drawing.Size(75, 23);
            this.EnginePathButton.TabIndex = 2;
            this.EnginePathButton.Text = "Choose";
            this.EnginePathButton.UseVisualStyleBackColor = true;
            this.EnginePathButton.Click += new System.EventHandler(this.EnginePathButton_Click);
            // 
            // RenderPath
            // 
            this.RenderPath.Location = new System.Drawing.Point(177, 37);
            this.RenderPath.Name = "RenderPath";
            this.RenderPath.Size = new System.Drawing.Size(935, 23);
            this.RenderPath.TabIndex = 4;
            // 
            // EnginePath
            // 
            this.EnginePath.Location = new System.Drawing.Point(177, 5);
            this.EnginePath.Name = "EnginePath";
            this.EnginePath.Size = new System.Drawing.Size(935, 23);
            this.EnginePath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cloud Engine Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Console
            // 
            this.Console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Console.Location = new System.Drawing.Point(0, 126);
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            this.Console.Size = new System.Drawing.Size(1242, 662);
            this.Console.TabIndex = 1;
            this.Console.Text = "Console:";
            // 
            // CodeSyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 788);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SyncEngineToRender);
            this.Controls.Add(this.SyncRenderToEngine);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Console);
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
        private RichTextBox Console;
    }
}