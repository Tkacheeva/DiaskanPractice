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

namespace WinForm
{
    public partial class Form1 : Form
    {
        public static Launcher act;
        private Form2 Forms2cs = new Form2();
        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();

            act = new Launcher();            
        }

        public void ComputeTask(object sender, EventArgs e)
        {
            ToolStripMenuItem senderButton = (ToolStripMenuItem)sender;
            int index = toolStripSplitButton1.DropDownItems.IndexOf(senderButton);
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    listView1.Items.Add(senderButton.Text);
                    act.AddTask(index, fbd.SelectedPath);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (act.Launch())
            {
                MessageBox.Show("Task complete!");
                listView1.Items.Remove(listView1.Items[0]);
            }
        
            timer1.Enabled = true;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
                toolStripDropDownButton1.Enabled = true;
            else
               toolStripDropDownButton1.Enabled = false;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            act.RemoveTask(listView1.SelectedIndices[0]);
            listView1.Items.Remove(listView1.SelectedItems[0]);
            ListView1_SelectedIndexChanged(sender, e);
        }

        private void AddNewTask_Click(object sender, EventArgs e)
        {
            Forms2cs.ShowDialog();
        }
    }
}
