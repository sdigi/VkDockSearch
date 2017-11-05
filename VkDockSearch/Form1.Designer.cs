namespace VkDockSearch
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
            this.tUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tDocIDStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tDocIDEnd = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.progressDoc = new System.Windows.Forms.ProgressBar();
            this.rLog = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tUserId
            // 
            this.tUserId.Location = new System.Drawing.Point(123, 12);
            this.tUserId.Name = "tUserId";
            this.tUserId.Size = new System.Drawing.Size(170, 20);
            this.tUserId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Начальный ID дока";
            // 
            // tDocIDStart
            // 
            this.tDocIDStart.Location = new System.Drawing.Point(123, 38);
            this.tDocIDStart.Name = "tDocIDStart";
            this.tDocIDStart.Size = new System.Drawing.Size(170, 20);
            this.tDocIDStart.TabIndex = 2;
            this.tDocIDStart.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Конечный ID дока";
            // 
            // tDocIDEnd
            // 
            this.tDocIDEnd.Location = new System.Drawing.Point(123, 64);
            this.tDocIDEnd.Name = "tDocIDEnd";
            this.tDocIDEnd.Size = new System.Drawing.Size(170, 20);
            this.tDocIDEnd.TabIndex = 4;
            this.tDocIDEnd.Text = "999999";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(399, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // progressDoc
            // 
            this.progressDoc.Location = new System.Drawing.Point(12, 119);
            this.progressDoc.Name = "progressDoc";
            this.progressDoc.Size = new System.Drawing.Size(399, 23);
            this.progressDoc.Step = 1;
            this.progressDoc.TabIndex = 7;
            // 
            // rLog
            // 
            this.rLog.Location = new System.Drawing.Point(12, 168);
            this.rLog.Name = "rLog";
            this.rLog.ReadOnly = true;
            this.rLog.Size = new System.Drawing.Size(399, 105);
            this.rLog.TabIndex = 8;
            this.rLog.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Лог";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Количество потоков";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(304, 39);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(107, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 285);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rLog);
            this.Controls.Add(this.progressDoc);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tDocIDEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tDocIDStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tUserId);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "VkDockSearch";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tDocIDStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tDocIDEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressDoc;
        private System.Windows.Forms.RichTextBox rLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

