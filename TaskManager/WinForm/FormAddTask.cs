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
    public partial class FormAddTask : Form
    {
        private Assembly asm;
        private Type[] arrTypes;

        public FormAddTask()
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

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (PathDll.Text == "" || NameTask.Text == "" || CBType.SelectedIndex == -1 || CBMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Данные введены не полностью");
                return;
            }

            Program.mainForm.taskInfo.Add(
                Program.mainForm.tsSplitExecTask.DropDownItems.Count,
                new TaskList(NameTask.Text, PathDll.Text, CBType.Items[CBType.SelectedIndex].ToString(), CBMethod.Items[CBMethod.SelectedIndex].ToString(), null, null, null, 0)
                );
            Program.mainForm.tsSplitExecTask.DropDownItems.Add(NameTask.Text);
            Program.mainForm.tsSplitExecTask.DropDownItems[Program.mainForm.tsSplitExecTask.DropDownItems.Count - 1].Click += new EventHandler(Program.mainForm.ComputeTask);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
