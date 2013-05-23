namespace WindowsFormsApplication1
{
    partial class SBTK3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewPicBox = new System.Windows.Forms.PictureBox();
            this.composePnl = new System.Windows.Forms.Panel();
            this.loadImgDialog = new System.Windows.Forms.OpenFileDialog();
            this.imagePnl = new System.Windows.Forms.FlowLayoutPanel();
            this.previewPnl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicBox)).BeginInit();
            this.previewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1187, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.loadImageToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.clearToolStripMenuItem.Text = "New";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // previewPicBox
            // 
            this.previewPicBox.BackColor = System.Drawing.SystemColors.Control;
            this.previewPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewPicBox.Location = new System.Drawing.Point(0, 0);
            this.previewPicBox.Name = "previewPicBox";
            this.previewPicBox.Size = new System.Drawing.Size(433, 55);
            this.previewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPicBox.TabIndex = 3;
            this.previewPicBox.TabStop = false;
            // 
            // composePnl
            // 
            this.composePnl.AutoScroll = true;
            this.composePnl.BackColor = System.Drawing.Color.White;
            this.composePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.composePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.composePnl.Location = new System.Drawing.Point(653, 25);
            this.composePnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.composePnl.Name = "composePnl";
            this.composePnl.Size = new System.Drawing.Size(534, 729);
            this.composePnl.TabIndex = 4;
            // 
            // loadImgDialog
            // 
            this.loadImgDialog.FileName = "openFileDialog1";
            // 
            // imagePnl
            // 
            this.imagePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imagePnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.imagePnl.Location = new System.Drawing.Point(0, 25);
            this.imagePnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imagePnl.Name = "imagePnl";
            this.imagePnl.Size = new System.Drawing.Size(265, 729);
            this.imagePnl.TabIndex = 5;
            // 
            // previewPnl
            // 
            this.previewPnl.AutoScroll = true;
            this.previewPnl.BackColor = System.Drawing.SystemColors.Control;
            this.previewPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewPnl.Controls.Add(this.previewPicBox);
            this.previewPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.previewPnl.Location = new System.Drawing.Point(265, 25);
            this.previewPnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.previewPnl.Name = "previewPnl";
            this.previewPnl.Size = new System.Drawing.Size(388, 729);
            this.previewPnl.TabIndex = 0;
            // 
            // SBTK3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 754);
            this.Controls.Add(this.composePnl);
            this.Controls.Add(this.previewPnl);
            this.Controls.Add(this.imagePnl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SBTK3";
            this.Text = "Shiny-Bear ToolKit";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicBox)).EndInit();
            this.previewPnl.ResumeLayout(false);
            this.previewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.PictureBox previewPicBox;
        private System.Windows.Forms.Panel composePnl;
        private System.Windows.Forms.OpenFileDialog loadImgDialog;
        private System.Windows.Forms.FlowLayoutPanel imagePnl;
        private System.Windows.Forms.Panel previewPnl;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

