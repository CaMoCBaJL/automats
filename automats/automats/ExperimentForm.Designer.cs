namespace PresentationLayer
{
    partial class ExperimentForm
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
            this.startConditionsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelExperimentType = new System.Windows.Forms.Label();
            this.radioButtonDiagnExp = new System.Windows.Forms.RadioButton();
            this.radioButtonSetExp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // startConditionsTextBox
            // 
            this.startConditionsTextBox.Location = new System.Drawing.Point(686, 127);
            this.startConditionsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startConditionsTextBox.Name = "startConditionsTextBox";
            this.startConditionsTextBox.Size = new System.Drawing.Size(194, 22);
            this.startConditionsTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(623, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите начальные состояния";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(714, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // labelExperimentType
            // 
            this.labelExperimentType.AutoSize = true;
            this.labelExperimentType.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold);
            this.labelExperimentType.Location = new System.Drawing.Point(627, 283);
            this.labelExperimentType.Name = "labelExperimentType";
            this.labelExperimentType.Size = new System.Drawing.Size(314, 27);
            this.labelExperimentType.TabIndex = 24;
            this.labelExperimentType.Text = "Выберите тип эксперимента";
            // 
            // radioButtonDiagnExp
            // 
            this.radioButtonDiagnExp.AutoSize = true;
            this.radioButtonDiagnExp.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonDiagnExp.Location = new System.Drawing.Point(632, 331);
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
            this.radioButtonSetExp.Location = new System.Drawing.Point(632, 373);
            this.radioButtonSetExp.Name = "radioButtonSetExp";
            this.radioButtonSetExp.Size = new System.Drawing.Size(310, 27);
            this.radioButtonSetExp.TabIndex = 26;
            this.radioButtonSetExp.TabStop = true;
            this.radioButtonSetExp.Text = "Установочный эксперимент";
            this.radioButtonSetExp.UseVisualStyleBackColor = true;
            // 
            // ExperimentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 557);
            this.Controls.Add(this.radioButtonSetExp);
            this.Controls.Add(this.radioButtonDiagnExp);
            this.Controls.Add(this.labelExperimentType);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startConditionsTextBox);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExperimentForm";
            this.Text = "Один автомат";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.startConditionsTextBox, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.labelExperimentType, 0);
            this.Controls.SetChildIndex(this.radioButtonDiagnExp, 0);
            this.Controls.SetChildIndex(this.radioButtonSetExp, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox startConditionsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelExperimentType;
        private System.Windows.Forms.RadioButton radioButtonDiagnExp;
        private System.Windows.Forms.RadioButton radioButtonSetExp;
    }
}

