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
using System.Reflection;

namespace WinForm
{
    public partial class Form2 : Form
    {
        private Assembly asm;
        private Type[] arrTypes;
        public Form2()
        {
            InitializeComponent();        
        }
        private void btnAddPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CBType.Items.Clear();
                CBMethod.Items.Clear();
                PathDll.Text = openFileDialog1.FileName;
                asm = Assembly.LoadFrom(PathDll.Text);
                arrTypes = asm.GetTypes();
                for (int i = 0; i < arrTypes.Length; i++)
                    CBType.Items.Add(arrTypes[i].FullName);
                CBType.Enabled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PathDll.Text == "" || NameTask.Text == "" || CBType.SelectedIndex == -1 || CBMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Данные введены не полностью");
                return;
            }

            Program.f1.taskInfo.Add(
                Program.f1.toolStripSplitButton1.DropDownItems.Count, 
                new TaskList(NameTask.Text, PathDll.Text, CBType.Items[CBType.SelectedIndex].ToString(), CBMethod.Items[CBMethod.SelectedIndex].ToString(), null, null, null, 0)
                );
            Program.f1.toolStripSplitButton1.DropDownItems.Add(NameTask.Text);
            Program.f1.toolStripSplitButton1.DropDownItems[Program.f1.toolStripSplitButton1.DropDownItems.Count - 1].Click += new EventHandler(Program.f1.ComputeTask);
            this.Close();
        }

        private void CBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBType.SelectedIndex != -1)
            {
                MethodInfo[] arrMethods = arrTypes[CBType.SelectedIndex].GetMethods(BindingFlags.Public | BindingFlags.Static);
                for (int i = 0; i < arrMethods.Length; i++)
                    CBMethod.Items.Add(arrMethods[i].Name);
                CBMethod.Enabled = true;
            }
        }
    }
}
