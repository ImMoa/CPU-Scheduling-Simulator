using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Schd
{
    public partial class Scheduling : Form
    {
        string[] readText;
        private bool readFile = false;
        List<Process> pList, pView;
        List<Result> resultList;

        public Scheduling()
        {
            InitializeComponent();            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            pView.Clear();
            pList.Clear();

            //파일 오픈
            string path = SelectFilePath();
            if (path == null) return;

            readText = File.ReadAllLines(path);

            //토큰 분리
            for (int i = 0; i < readText.Length; i++)
            {
                string[] token = readText[i].Split(' ');
                Process p = new Process(int.Parse(token[1]), int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4]));
                pList.Add(p);
            }

            //arriveTime으로 정렬
            pList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                return 0;
            });

            //Grid에 process 출력
            dataGridView1.Rows.Clear();
            string[] row = { "", "", "", "" };
            foreach (Process p in pList)
            {
                row[0] = p.processID.ToString();
                row[1] = p.arriveTime.ToString();
                row[2] = p.burstTime.ToString();
                row[3] = p.priority.ToString();

                dataGridView1.Rows.Add(row);
            }

            readFile = true;
        }

        private string SelectFilePath()
        {
            openFileDialog1.Filter = "텍스트파일|*.txt";
            return (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : null;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (!readFile)
            {
                MessageBox.Show("파일을 선택하십시오.", "File Choose Error!");
                return;
            }

            //스케쥴러 실행
            if (FCFS.Checked == true)
                resultList = SchedulingAlgorithm_FCFS.Run(pList, resultList);
            else if (SJF.Checked == true)
                resultList = SchedulingAlgorithm_SJF.Run(pList, resultList);
            else if (SRTF.Checked == true)
                resultList = SchedulingAlgorithm_SRTF.Run(pList, resultList);
            else if (priority.Checked == true)
                resultList = SchedulingAlgorithm_Priority.Run(pList, resultList);
            else if (RR.Checked == true)
                resultList = SchedulingAlgorithm_RoundRobin.Run(pList, resultList, Int32.Parse(setSlice.Text));


            //결과출력
            dataGridView2.Rows.Clear();
            string[] row = { "", "", "", "" };

            double watingTime = 0.0;
            foreach (Result r in resultList)
            {
                row[0] = r.processID.ToString();
                row[1] = r.burstTime.ToString();
                row[2] = r.waitingTime.ToString();
                watingTime += r.waitingTime;

                dataGridView2.Rows.Add(row);
            }

            TRTime.Text = "전체 실행시간: " + (resultList[resultList.Count - 1].startP + resultList[resultList.Count - 1].burstTime).ToString();
            avgRT.Text = "평균 대기시간: " + (watingTime / resultList.Count).ToString();
            panel1.Invalidate();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int startPosition = 10;
            int runTime = 0;
           
            int resultListPosition = 0;
            //if (RR.Checked == true)
            //{
                foreach (Result r in resultList)
                {
                    e.Graphics.DrawString("p" + r.processID.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition);
                    e.Graphics.DrawRectangle(Pens.Red, startPosition + (r.startP * 17), resultListPosition + 20, r.burstTime * 17, 30);
                    e.Graphics.DrawString(r.burstTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition + 60);
                    e.Graphics.DrawString(runTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition + 80);
                    runTime += r.burstTime;
                }
            //}
            //else
            //{
                //foreach (Result r in resultList)
                //{
                //    e.Graphics.DrawString("p" + r.processID.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition);
                //    e.Graphics.DrawRectangle(Pens.Red, startPosition + (r.startP * 17), resultListPosition + 20, r.burstTime * 17, 30);
                //    e.Graphics.DrawString(r.burstTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition + 60);
                //    e.Graphics.DrawString(r.waitingTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 17), resultListPosition + 80);
                //    waitingTime += (double)r.waitingTime;
                //}
            //}
        }

        private void TRTime_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pList = new List<Process>();
            pView = new List<Process>();
            resultList = new List<Result>();

            //입력창
            DataGridViewTextBoxColumn processColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn arriveTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn burstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn priorityColumn = new DataGridViewTextBoxColumn();

            processColumn.HeaderText = "Process";
            processColumn.Name = "process";
            arriveTimeColumn.HeaderText = "ArriveTime";
            arriveTimeColumn.Name = "arriveTime";
            burstTimeColumn.HeaderText = "BurstTime";
            burstTimeColumn.Name = "burstTime";
            priorityColumn.HeaderText = "Priority";
            priorityColumn.Name = "priority";

            dataGridView1.Columns.Add(processColumn);
            dataGridView1.Columns.Add(arriveTimeColumn);
            dataGridView1.Columns.Add(burstTimeColumn);
            dataGridView1.Columns.Add(priorityColumn);



            //결과창
            DataGridViewTextBoxColumn resultProcessColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultBurstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultWaitingTimeColumn = new DataGridViewTextBoxColumn();


            resultProcessColumn.HeaderText = "Process";
            resultProcessColumn.Name = "process";
            resultBurstTimeColumn.HeaderText = "BurstTime";
            resultBurstTimeColumn.Name = "resultBurstTimeColumn";
            resultWaitingTimeColumn.HeaderText = "WaitingTime";
            resultWaitingTimeColumn.Name = "waitingTime";

            dataGridView2.Columns.Add(resultProcessColumn);
            dataGridView2.Columns.Add(resultBurstTimeColumn);
            dataGridView2.Columns.Add(resultWaitingTimeColumn);
        }
    }
}