
namespace PresentationLayer
{
    partial class InputAutomat
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
            this.insertAut = new System.Windows.Forms.Button();
            this.tableLabel = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // insertAut
            // 
            this.insertAut.BackColor = System.Drawing.Color.LimeGreen;
            this.insertAut.Font = new System.Drawing.Font("Verdana", 11F);
            this.insertAut.Location = new System.Drawing.Point(9, 65);
            this.insertAut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertAut.Name = "insertAut";
            this.insertAut.Size = new System.Drawing.Size(114, 104);
            this.insertAut.TabIndex = 21;
            this.insertAut.Text = "Ввести автомат";
            this.insertAut.UseVisualStyleBackColor = false;
            this.insertAut.Click += new System.EventHandler(this.insertAut_Click);
            // 
            // tableLabel
            // 
            this.tableLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 15F, System.Drawing.FontStyle.Bold);
            this.tableLabel.Location = new System.Drawing.Point(129, 22);
            this.tableLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(301, 67);
            this.tableLabel.TabIndex = 20;
            this.tableLabel.Text = "Таблица переходов\\выходов";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox4.Font = new System.Drawing.Font("Verdana", 28F);
            this.richTextBox4.Location = new System.Drawing.Point(129, 108);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(301, 61);
            this.richTextBox4.TabIndex = 19;
            this.richTextBox4.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox3.Font = new System.Drawing.Font("Verdana", 28F);
            this.richTextBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox3.Location = new System.Drawing.Point(71, 186);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(374, 102);
            this.richTextBox3.TabIndex = 18;
            this.richTextBox3.Text = "";
            // 
            // InputAutomat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.insertAut);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Name = "InputAutomat";
            this.Text = "InputAutomat";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button insertAut;
        protected System.Windows.Forms.Label tableLabel;
        protected System.Windows.Forms.RichTextBox richTextBox4;
        protected System.Windows.Forms.RichTextBox richTextBox3;
    }
}