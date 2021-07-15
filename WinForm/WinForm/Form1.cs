using System;
using System.IO;
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

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Launcher act;
        public Form1()
        {          
            InitializeComponent();
            act = new Launcher();            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (act.Launch())
                listView1.Items.Remove(listView1.Items[0]);
        
            timer1.Enabled = true;
            }

        private void хешированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                    listView1.Items.Add("Хеширование");
                    act.msgQ.Add(new Msg(0, files));
                }
            }
        }

        private void архивацияФайловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Add("Архивация");
            act.msgQ.Add(new Msg(1, new string[] { "ZIP" }));
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
                удалитьЗадачуToolStripMenuItem.Enabled = toolStripDropDownButton1.Enabled = true;
            else
                удалитьЗадачуToolStripMenuItem.Enabled = toolStripDropDownButton1.Enabled = false;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            act.msgQ.RemoveAt(listView1.SelectedIndices[0]);
            listView1.Items.Remove(listView1.SelectedItems[0]);
            listView1_SelectedIndexChanged(sender, e);
        }
    }
}
