namespace Schd
{
    partial class Scheduling
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFile = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TRTime = new System.Windows.Forms.Label();
            this.avgRT = new System.Windows.Forms.Label();
            this.FCFS = new System.Windows.Forms.RadioButton();
            this.SJF = new System.Windows.Forms.RadioButton();
            this.priority = new System.Windows.Forms.RadioButton();
            this.RR = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SRTF = new System.Windows.Forms.RadioButton();
            this.setSlice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(12, 728);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "OpenFile";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(95, 728);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 1;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(24, 619);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 103);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(747, 139);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(24, 259);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(747, 309);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // TRTime
            // 
            this.TRTime.AutoSize = true;
            this.TRTime.Location = new System.Drawing.Point(24, 576);
            this.TRTime.Name = "TRTime";
            this.TRTime.Size = new System.Drawing.Size(89, 12);
            this.TRTime.TabIndex = 8;
            this.TRTime.Text = "Total Process Time :";
            this.TRTime.Click += new System.EventHandler(this.TRTime_Click);
            // 
            // avgRT
            // 
            this.avgRT.AutoSize = true;
            this.avgRT.Location = new System.Drawing.Point(24, 597);
            this.avgRT.Name = "avgRT";
            this.avgRT.Size = new System.Drawing.Size(89, 12);
            this.avgRT.TabIndex = 9;
            this.avgRT.Text = "Average Wating Time :";
            // 
            // FCFS
            // 
            this.FCFS.AutoSize = true;
            this.FCFS.Checked = true;
            this.FCFS.Location = new System.Drawing.Point(23, 20);
            this.FCFS.Name = "FCFS";
            this.FCFS.Size = new System.Drawing.Size(54, 16);
            this.FCFS.TabIndex = 10;
            this.FCFS.TabStop = true;
            this.FCFS.Text = "FCFS";
            this.FCFS.UseVisualStyleBackColor = true;
            this.FCFS.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // SJF
            // 
            this.SJF.AutoSize = true;
            this.SJF.Location = new System.Drawing.Point(83, 20);
            this.SJF.Name = "SJF";
            this.SJF.Size = new System.Drawing.Size(93, 16);
            this.SJF.TabIndex = 11;
            this.SJF.TabStop = true;
            this.SJF.Text = "Shortest Job";
            this.SJF.UseVisualStyleBackColor = true;
            this.SJF.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // priority
            // 
            this.priority.AutoSize = true;
            this.priority.Location = new System.Drawing.Point(243, 20);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(62, 16);
            this.priority.TabIndex = 12;
            this.priority.TabStop = true;
            this.priority.Text = "Priority";
            this.priority.UseVisualStyleBackColor = true;
            this.priority.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // RR
            // 
            this.RR.AutoSize = true;
            this.RR.Location = new System.Drawing.Point(311, 20);
            this.RR.Name = "RR";
            this.RR.Size = new System.Drawing.Size(149, 16);
            this.RR.TabIndex = 13;
            this.RR.TabStop = true;
            this.RR.Text = "Round Robin   Slice = ";
            this.RR.UseVisualStyleBackColor = true;
            this.RR.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SRTF);
            this.groupBox1.Controls.Add(this.setSlice);
            this.groupBox1.Controls.Add(this.RR);
            this.groupBox1.Controls.Add(this.FCFS);
            this.groupBox1.Controls.Add(this.priority);
            this.groupBox1.Controls.Add(this.SJF);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 50);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Algorithm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SRTF
            // 
            this.SRTF.AutoSize = true;
            this.SRTF.Location = new System.Drawing.Point(183, 20);
            this.SRTF.Name = "SRTF";
            this.SRTF.Size = new System.Drawing.Size(54, 16);
            this.SRTF.TabIndex = 15;
            this.SRTF.TabStop = true;
            this.SRTF.Text = "SRTF";
            this.SRTF.UseVisualStyleBackColor = true;
            // 
            // setSlice
            // 
            this.setSlice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setSlice.Location = new System.Drawing.Point(456, 18);
            this.setSlice.Name = "setSlice";
            this.setSlice.Size = new System.Drawing.Size(22, 23);
            this.setSlice.TabIndex = 14;
            this.setSlice.Text = "4";
            this.setSlice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setSlice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Scheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 763);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.avgRT);
            this.Controls.Add(this.TRTime);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.OpenFile);
            this.Name = "Scheduling";
            this.Text = "Scheduling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FCFS;
        private System.Windows.Forms.RadioButton SJF;
        private System.Windows.Forms.RadioButton priority;
        private System.Windows.Forms.RadioButton RR;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label TRTime;
        private System.Windows.Forms.Label avgRT;
        private System.Windows.Forms.TextBox setSlice;
        private System.Windows.Forms.RadioButton SRTF;
    }
}

