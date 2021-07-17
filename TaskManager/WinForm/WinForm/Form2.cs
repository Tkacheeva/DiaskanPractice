using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActivatorLib;

namespace WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PathDll.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PathDll.Text == "" || NameTask.Text == "" )
            {
                MessageBox.Show("Данные введены не полностью");
                return;
            }

            Form1.act.AddNewTask(NameTask.Text, PathDll.Text);
            Program.f1.toolStripSplitButton1.DropDownItems.Add(NameTask.Text);
            Program.f1.toolStripSplitButton1.DropDownItems[Program.f1.toolStripSplitButton1.DropDownItems.Count - 1].Click += new EventHandler(Program.f1.ComputeTask);
            this.Close();
        }

    }
}
