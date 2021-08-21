
namespace PresentationLayer
{
    partial class StrengthTestResults
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
            this.testProgressBar = new System.Windows.Forms.ProgressBar();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.messagePanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // testProgressBar
            // 
            this.testProgressBar.Location = new System.Drawing.Point(13, 396);
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(775, 23);
            this.testProgressBar.TabIndex = 0;
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            // 
            // messagePanel
            // 
            this.messagePanel.AutoScroll = true;
            this.messagePanel.Location = new System.Drawing.Point(38, 37);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(436, 223);
            this.messagePanel.TabIndex = 1;
            // 
            // StrengthTestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.testProgressBar);
            this.Name = "StrengthTestResults";
            this.Text = "StrengthTestResults";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StrengthTestResults_FormClosed);
            this.Load += new System.EventHandler(this.StrengthTestResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar testProgressBar;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.FlowLayoutPanel messagePanel;
    }
}