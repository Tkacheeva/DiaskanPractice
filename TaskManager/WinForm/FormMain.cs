using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using ActivatorLib;
using System.IO;
using Npgsql; 

namespace WinForm
{
    public partial class FormMain : Form
    {
        public static Launcher act;
        public Dictionary<int, TaskList> taskInfo = new Dictionary<int, TaskList>();
        private string connString = "Host=localhost;Username=postgres;Password=a6145415k;Database=TaskManagerDB";
        private NpgsqlConnection conn;
        private bool isConnected = false;

        private FormAddTask FormANTcs = new FormAddTask();

        public FormMain()
        {
            Program.mainForm = this;
            InitializeComponent();

            act = new Launcher();

            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                isConnected = true;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
        }

        public void ComputeTask(object sender, EventArgs e)
        {
            ToolStripMenuItem senderButton = (ToolStripMenuItem)sender;
            int index = tsSplitExecTask.DropDownItems.IndexOf(senderButton);
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    listViewTasks.Items.Add(senderButton.Text);
                    act.AddTask(taskInfo[index], fbd.SelectedPath);
                }
            }
        }

        private void insertInDB(string res)
        {
            using (var command = new NpgsqlCommand("INSERT INTO results (res) VALUES (@p);", conn))
            {
                command.Parameters.AddWithValue("p", res);
                command.ExecuteNonQuery();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            listViewTasks.Items.Clear();
            TaskList[] arrTasks = act.CheckList();
            string res;

            if (arrTasks != null)
            {
                for (int i = 0; i < arrTasks.Length; i++)
                {
                    ListViewItem item = new ListViewItem(arrTasks[i].TaskName);         
                    switch (arrTasks[i].status)
                    {
                        case TaskList.Status.Expectation:       
                            item.SubItems.Add("Ожидание");
                            break;
                        case TaskList.Status.Executing:
                            item.SubItems.Add("Выполняется");
                            break;
                        case TaskList.Status.Success:
                            res = arrTasks[i].TaskName + " Начало: " + arrTasks[i].startTime + " Конец: " + arrTasks[i].endTime + " Success";

                            if (isConnected)
                                insertInDB(res);
                            act.RemoveTask(i);
                            item.SubItems.Add("Успешно");
                            break;
                        case TaskList.Status.Failure:
                            res = arrTasks[i].TaskName + " Начало: " + arrTasks[i].startTime + " Failure";

                            if (isConnected)
                                insertInDB(res);
                            act.RemoveTask(i);
                            item.SubItems.Add("Неуспешно");
                            break;
                    }
                    listViewTasks.Items.Add(item);
                }
            }
        
            timer1.Enabled = true;
        }

        private void AddNewTask_Click(object sender, EventArgs e)
        {
            FormANTcs.ShowDialog();
        }

        private void tsDDBtnDeleteTask_Click(object sender, EventArgs e)
        {
            act.RemoveTask(listViewTasks.SelectedIndices[0]);
            listViewTasks.Items.Remove(listViewTasks.SelectedItems[0]);
            listViewTasks_SelectedIndexChanged(sender, e);
        }

        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedIndices.Count != 0)
                tsDDBtnDeleteTask.Enabled = true;
            else
                tsDDBtnDeleteTask.Enabled = false;
        }
    }
}
