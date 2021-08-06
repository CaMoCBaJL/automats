namespace PresentationLayer
{
    partial class ModellingForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.startConditionsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.inputSignalsTextBox = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(592, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите входные сигналы";
            // 
            // startConditionsTextBox
            // 
            this.startConditionsTextBox.Location = new System.Drawing.Point(681, 214);
            this.startConditionsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startConditionsTextBox.Name = "startConditionsTextBox";
            this.startConditionsTextBox.Size = new System.Drawing.Size(194, 22);
            this.startConditionsTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(608, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите начальные состояния";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 259);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputSignalsTextBox
            // 
            this.inputSignalsTextBox.Location = new System.Drawing.Point(681, 72);
            this.inputSignalsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputSignalsTextBox.Name = "inputSignalsTextBox";
            this.inputSignalsTextBox.Size = new System.Drawing.Size(194, 78);
            this.inputSignalsTextBox.TabIndex = 10;
            this.inputSignalsTextBox.Text = "";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Salmon;
            this.button3.Font = new System.Drawing.Font("Verdana", 20F);
            this.button3.Location = new System.Drawing.Point(1074, 437);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 109);
            this.button3.TabIndex = 20;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.retClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(475, 351);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 22);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(470, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 27);
            this.label4.TabIndex = 23;
            this.label4.Text = "Число итераций";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModellingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 557);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.inputSignalsTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startConditionsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ModellingForm";
            this.Text = "Один автомат";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.ModellingForm_Load);
            this.Controls.SetChildIndex(this.richTextBox3, 0);
            this.Controls.SetChildIndex(this.richTextBox4, 0);
            this.Controls.SetChildIndex(this.tableLabel, 0);
            this.Controls.SetChildIndex(this.insertAut, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.startConditionsTextBox, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.inputSignalsTextBox, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startConditionsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox inputSignalsTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}

