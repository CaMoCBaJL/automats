
namespace PresentationLayer
{
    partial class AutomatCryptoStrengthTestForm
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
            this.strengthTestInputString = new System.Windows.Forms.RichTextBox();
            this.strengthTestLabel = new System.Windows.Forms.Label();
            this.inputFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLabel
            // 
            this.tableLabel.Location = new System.Drawing.Point(129, 21);
            // 
            // strengthTestInputString
            // 
            this.strengthTestInputString.Location = new System.Drawing.Point(509, 108);
            this.strengthTestInputString.Name = "strengthTestInputString";
            this.strengthTestInputString.ReadOnly = true;
            this.strengthTestInputString.Size = new System.Drawing.Size(247, 223);
            this.strengthTestInputString.TabIndex = 22;
            this.strengthTestInputString.Text = "";
            this.strengthTestInputString.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // strengthTestLabel
            // 
            this.strengthTestLabel.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strengthTestLabel.Location = new System.Drawing.Point(485, 53);
            this.strengthTestLabel.Name = "strengthTestLabel";
            this.strengthTestLabel.Size = new System.Drawing.Size(287, 38);
            this.strengthTestLabel.TabIndex = 23;
            this.strengthTestLabel.Text = "Input string";
            this.strengthTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputFile
            // 
            this.inputFile.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFile.Location = new System.Drawing.Point(495, 337);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(277, 109);
            this.inputFile.TabIndex = 24;
            this.inputFile.Text = "Choose file to test the automat";
            this.inputFile.UseVisualStyleBackColor = true;
            this.inputFile.Click += new System.EventHandler(this.inputFile_Click);
            // 
            // AutomatCryptoStrengthTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputFile);
            this.Controls.Add(this.strengthTestLabel);
            this.Controls.Add(this.strengthTestInputString);
            this.Name = "AutomatCryptoStrengthTestForm";
            this.Text = "AutomatCryptoStrengthTestForm";
            this.Controls.SetChildIndex(this.richTextBox3, 0);
            this.Controls.SetChildIndex(this.richTextBox4, 0);
            this.Controls.SetChildIndex(this.tableLabel, 0);
            this.Controls.SetChildIndex(this.insertAut, 0);
            this.Controls.SetChildIndex(this.strengthTestInputString, 0);
            this.Controls.SetChildIndex(this.strengthTestLabel, 0);
            this.Controls.SetChildIndex(this.inputFile, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox strengthTestInputString;
        private System.Windows.Forms.Label strengthTestLabel;
        private System.Windows.Forms.Button inputFile;
    }
}