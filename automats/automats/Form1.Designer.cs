namespace PresentationLayer
{
    partial class Form1
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
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelExperimentType = new System.Windows.Forms.Label();
            this.radioButtonDiagnExp = new System.Windows.Forms.RadioButton();
            this.radioButtonSetExp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // richTextBox3
            // 
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox3.Font = new System.Drawing.Font("Verdana", 28F);
            this.richTextBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox3.Location = new System.Drawing.Point(61, 165);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(374, 102);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "";
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(681, 214);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 22);
            this.textBox2.TabIndex = 7;
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
            // richTextBox4
            // 
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox4.Font = new System.Drawing.Font("Verdana", 28F);
            this.richTextBox4.Location = new System.Drawing.Point(119, 87);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox4.Multiline = false;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(301, 61);
            this.richTextBox4.TabIndex = 8;
            this.richTextBox4.Text = "";
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(681, 72);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(194, 78);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // tableLabel
            // 
            this.tableLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 15F, System.Drawing.FontStyle.Bold);
            this.tableLabel.Location = new System.Drawing.Point(119, 1);
            this.tableLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(301, 67);
            this.tableLabel.TabIndex = 13;
            this.tableLabel.Text = "Таблица переходов\\выходов";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.Font = new System.Drawing.Font("Verdana", 11F);
            this.button2.Location = new System.Drawing.Point(-1, 44);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 104);
            this.button2.TabIndex = 17;
            this.button2.Text = "Ввести автомат";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(470, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Число итераций";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelExperimentType
            // 
            this.labelExperimentType.AutoSize = true;
            this.labelExperimentType.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold);
            this.labelExperimentType.Location = new System.Drawing.Point(56, 364);
            this.labelExperimentType.Name = "labelExperimentType";
            this.labelExperimentType.Size = new System.Drawing.Size(314, 27);
            this.labelExperimentType.TabIndex = 24;
            this.labelExperimentType.Text = "Выберите тип эксперимента";
            // 
            // radioButtonDiagnExp
            // 
            this.radioButtonDiagnExp.AutoSize = true;
            this.radioButtonDiagnExp.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonDiagnExp.Location = new System.Drawing.Point(61, 412);
            this.radioButtonDiagnExp.Name = "radioButtonDiagnExp";
            this.radioButtonDiagnExp.Size = new System.Drawing.Size(341, 27);
            this.radioButtonDiagnExp.TabIndex = 25;
            this.radioButtonDiagnExp.TabStop = true;
            this.radioButtonDiagnExp.Text = "Диагностический эксперимент";
            this.radioButtonDiagnExp.UseVisualStyleBackColor = true;
            // 
            // radioButtonSetExp
            // 
            this.radioButtonSetExp.AutoSize = true;
            this.radioButtonSetExp.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonSetExp.Location = new System.Drawing.Point(61, 454);
            this.radioButtonSetExp.Name = "radioButtonSetExp";
            this.radioButtonSetExp.Size = new System.Drawing.Size(310, 27);
            this.radioButtonSetExp.TabIndex = 26;
            this.radioButtonSetExp.TabStop = true;
            this.radioButtonSetExp.Text = "Установочный эксперимент";
            this.radioButtonSetExp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 557);
            this.Controls.Add(this.radioButtonSetExp);
            this.Controls.Add(this.radioButtonDiagnExp);
            this.Controls.Add(this.labelExperimentType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox3);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Один автомат";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label tableLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label labelExperimentType;
        private System.Windows.Forms.RadioButton radioButtonDiagnExp;
        private System.Windows.Forms.RadioButton radioButtonSetExp;
    }
}

