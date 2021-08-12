
namespace PresentationLayer
{
    partial class TestSettingsForm
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
            this.choosenModeLabel = new System.Windows.Forms.Label();
            this.restrictionMode1 = new System.Windows.Forms.RadioButton();
            this.restrictionMode2 = new System.Windows.Forms.RadioButton();
            this.restrictionMode3 = new System.Windows.Forms.RadioButton();
            this.restrictionMode5 = new System.Windows.Forms.RadioButton();
            this.restrictionMode4 = new System.Windows.Forms.RadioButton();
            this.chooseRestrictionType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // choosenModeLabel
            // 
            this.choosenModeLabel.AutoSize = true;
            this.choosenModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.choosenModeLabel.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.choosenModeLabel.Location = new System.Drawing.Point(7, 281);
            this.choosenModeLabel.Name = "choosenModeLabel";
            this.choosenModeLabel.Size = new System.Drawing.Size(412, 25);
            this.choosenModeLabel.TabIndex = 1;
            this.choosenModeLabel.Text = "Current restriction mode:";
            // 
            // restrictionMode1
            // 
            this.restrictionMode1.AutoSize = true;
            this.restrictionMode1.BackColor = System.Drawing.Color.Transparent;
            this.restrictionMode1.Checked = true;
            this.restrictionMode1.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.restrictionMode1.Location = new System.Drawing.Point(12, 207);
            this.restrictionMode1.Name = "restrictionMode1";
            this.restrictionMode1.Size = new System.Drawing.Size(145, 29);
            this.restrictionMode1.TabIndex = 3;
            this.restrictionMode1.TabStop = true;
            this.restrictionMode1.Text = "Minimum";
            this.restrictionMode1.UseVisualStyleBackColor = false;
            this.restrictionMode1.CheckedChanged += new System.EventHandler(this.radioButton_ValueChanged);
            // 
            // restrictionMode2
            // 
            this.restrictionMode2.AutoSize = true;
            this.restrictionMode2.BackColor = System.Drawing.Color.Transparent;
            this.restrictionMode2.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.restrictionMode2.Location = new System.Drawing.Point(191, 207);
            this.restrictionMode2.Name = "restrictionMode2";
            this.restrictionMode2.Size = new System.Drawing.Size(97, 29);
            this.restrictionMode2.TabIndex = 4;
            this.restrictionMode2.Text = "Weak";
            this.restrictionMode2.UseVisualStyleBackColor = false;
            this.restrictionMode2.CheckedChanged += new System.EventHandler(this.radioButton_ValueChanged);
            // 
            // restrictionMode3
            // 
            this.restrictionMode3.AutoSize = true;
            this.restrictionMode3.BackColor = System.Drawing.Color.Transparent;
            this.restrictionMode3.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.restrictionMode3.Location = new System.Drawing.Point(317, 207);
            this.restrictionMode3.Name = "restrictionMode3";
            this.restrictionMode3.Size = new System.Drawing.Size(145, 29);
            this.restrictionMode3.TabIndex = 5;
            this.restrictionMode3.Text = "Average";
            this.restrictionMode3.UseVisualStyleBackColor = false;
            this.restrictionMode3.CheckedChanged += new System.EventHandler(this.radioButton_ValueChanged);
            // 
            // restrictionMode5
            // 
            this.restrictionMode5.AutoSize = true;
            this.restrictionMode5.BackColor = System.Drawing.Color.Transparent;
            this.restrictionMode5.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.restrictionMode5.Location = new System.Drawing.Point(643, 207);
            this.restrictionMode5.Name = "restrictionMode5";
            this.restrictionMode5.Size = new System.Drawing.Size(145, 29);
            this.restrictionMode5.TabIndex = 7;
            this.restrictionMode5.Text = "Maximum";
            this.restrictionMode5.UseVisualStyleBackColor = false;
            this.restrictionMode5.CheckedChanged += new System.EventHandler(this.radioButton_ValueChanged);
            // 
            // restrictionMode4
            // 
            this.restrictionMode4.AutoSize = true;
            this.restrictionMode4.BackColor = System.Drawing.Color.Transparent;
            this.restrictionMode4.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.restrictionMode4.Location = new System.Drawing.Point(487, 207);
            this.restrictionMode4.Name = "restrictionMode4";
            this.restrictionMode4.Size = new System.Drawing.Size(129, 29);
            this.restrictionMode4.TabIndex = 6;
            this.restrictionMode4.Text = "Strong";
            this.restrictionMode4.UseVisualStyleBackColor = false;
            this.restrictionMode4.CheckedChanged += new System.EventHandler(this.radioButton_ValueChanged);
            // 
            // chooseRestrictionType
            // 
            this.chooseRestrictionType.AutoSize = true;
            this.chooseRestrictionType.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.chooseRestrictionType.Location = new System.Drawing.Point(7, 130);
            this.chooseRestrictionType.Name = "chooseRestrictionType";
            this.chooseRestrictionType.Size = new System.Drawing.Size(476, 25);
            this.chooseRestrictionType.TabIndex = 8;
            this.chooseRestrictionType.Text = "Choose test restriction mode:";
            // 
            // TestSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chooseRestrictionType);
            this.Controls.Add(this.restrictionMode5);
            this.Controls.Add(this.restrictionMode4);
            this.Controls.Add(this.restrictionMode3);
            this.Controls.Add(this.restrictionMode2);
            this.Controls.Add(this.restrictionMode1);
            this.Controls.Add(this.choosenModeLabel);
            this.Name = "TestSettingsForm";
            this.Text = "TestSettingsForm";
            this.Load += new System.EventHandler(this.TestSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label choosenModeLabel;
        private System.Windows.Forms.RadioButton restrictionMode1;
        private System.Windows.Forms.RadioButton restrictionMode2;
        private System.Windows.Forms.RadioButton restrictionMode3;
        private System.Windows.Forms.RadioButton restrictionMode5;
        private System.Windows.Forms.RadioButton restrictionMode4;
        private System.Windows.Forms.Label chooseRestrictionType;
    }
}