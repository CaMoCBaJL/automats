
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
            this.testStart = new System.Windows.Forms.Button();
            this.hashFunctionParser = new System.Windows.Forms.Button();
            this.hashFunctionConstructor = new System.Windows.Forms.Button();
            this.testSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLabel
            // 
            this.tableLabel.Location = new System.Drawing.Point(129, 21);
            // 
            // strengthTestInputString
            // 
            this.strengthTestInputString.Location = new System.Drawing.Point(514, 76);
            this.strengthTestInputString.Name = "strengthTestInputString";
            this.strengthTestInputString.ReadOnly = true;
            this.strengthTestInputString.Size = new System.Drawing.Size(247, 225);
            this.strengthTestInputString.TabIndex = 22;
            this.strengthTestInputString.Text = "";
            // 
            // strengthTestLabel
            // 
            this.strengthTestLabel.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strengthTestLabel.Location = new System.Drawing.Point(490, 21);
            this.strengthTestLabel.Name = "strengthTestLabel";
            this.strengthTestLabel.Size = new System.Drawing.Size(287, 40);
            this.strengthTestLabel.TabIndex = 23;
            this.strengthTestLabel.Text = "Input string";
            this.strengthTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputFile
            // 
            this.inputFile.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFile.Location = new System.Drawing.Point(495, 320);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(277, 109);
            this.inputFile.TabIndex = 24;
            this.inputFile.Text = "Choose file to test the automat";
            this.inputFile.UseVisualStyleBackColor = true;
            this.inputFile.Click += new System.EventHandler(this.inputFile_Click);
            // 
            // testStart
            // 
            this.testStart.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testStart.Location = new System.Drawing.Point(802, 21);
            this.testStart.Name = "testStart";
            this.testStart.Size = new System.Drawing.Size(111, 109);
            this.testStart.TabIndex = 25;
            this.testStart.Text = "Start test";
            this.testStart.UseVisualStyleBackColor = true;
            this.testStart.Click += new System.EventHandler(this.testStart_Click);
            // 
            // hashFunctionParser
            // 
            this.hashFunctionParser.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashFunctionParser.Location = new System.Drawing.Point(802, 174);
            this.hashFunctionParser.Name = "hashFunctionParser";
            this.hashFunctionParser.Size = new System.Drawing.Size(277, 109);
            this.hashFunctionParser.TabIndex = 26;
            this.hashFunctionParser.Text = "Hash-function parser";
            this.hashFunctionParser.UseVisualStyleBackColor = true;
            // 
            // hashFunctionConstructor
            // 
            this.hashFunctionConstructor.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashFunctionConstructor.Location = new System.Drawing.Point(802, 320);
            this.hashFunctionConstructor.Name = "hashFunctionConstructor";
            this.hashFunctionConstructor.Size = new System.Drawing.Size(277, 109);
            this.hashFunctionConstructor.TabIndex = 27;
            this.hashFunctionConstructor.Text = "Hash-function constructor";
            this.hashFunctionConstructor.UseVisualStyleBackColor = true;
            // 
            // testSettings
            // 
            this.testSettings.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSettings.Location = new System.Drawing.Point(931, 21);
            this.testSettings.Name = "testSettings";
            this.testSettings.Size = new System.Drawing.Size(148, 109);
            this.testSettings.TabIndex = 28;
            this.testSettings.Text = "Test settings";
            this.testSettings.UseVisualStyleBackColor = true;
            this.testSettings.Click += new System.EventHandler(this.testSettings_Click);
            // 
            // AutomatCryptoStrengthTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 442);
            this.Controls.Add(this.testSettings);
            this.Controls.Add(this.hashFunctionConstructor);
            this.Controls.Add(this.hashFunctionParser);
            this.Controls.Add(this.testStart);
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
            this.Controls.SetChildIndex(this.testStart, 0);
            this.Controls.SetChildIndex(this.hashFunctionParser, 0);
            this.Controls.SetChildIndex(this.hashFunctionConstructor, 0);
            this.Controls.SetChildIndex(this.testSettings, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox strengthTestInputString;
        private System.Windows.Forms.Label strengthTestLabel;
        private System.Windows.Forms.Button inputFile;
        private System.Windows.Forms.Button testStart;
        private System.Windows.Forms.Button hashFunctionParser;
        private System.Windows.Forms.Button hashFunctionConstructor;
        private System.Windows.Forms.Button testSettings;
    }
}