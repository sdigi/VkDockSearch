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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lPercent = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
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
            this.btnSearch.Location = new System.Drawing.Point(123, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(170, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // progressDoc
            // 
            this.progressDoc.Location = new System.Drawing.Point(15, 119);
            this.progressDoc.Name = "progressDoc";
            this.progressDoc.Size = new System.Drawing.Size(278, 25);
            this.progressDoc.Step = 1;
            this.progressDoc.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(303, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lPercent
            // 
            this.lPercent.AutoSize = true;
            this.lPercent.BackColor = System.Drawing.Color.Transparent;
            this.lPercent.Location = new System.Drawing.Point(134, 125);
            this.lPercent.Name = "lPercent";
            this.lPercent.Size = new System.Drawing.Size(0, 13);
            this.lPercent.TabIndex = 9;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 182);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lPercent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressDoc);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tDocIDEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tDocIDStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tUserId);
            this.Name = "Form1";
            this.Text = "VkDockSearch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lPercent;
        private System.Windows.Forms.Button btnStop;
    }
}

