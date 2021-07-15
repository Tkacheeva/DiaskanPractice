
namespace WinForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хешированиеФайловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архивироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.хешированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архивацияФайловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 15);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 468);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Задача";
            this.columnHeader1.Width = 257;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЗадачуToolStripMenuItem,
            this.удалитьЗадачуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 52);
            // 
            // добавитьЗадачуToolStripMenuItem
            // 
            this.добавитьЗадачуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хешированиеФайловToolStripMenuItem,
            this.архивироватьToolStripMenuItem});
            this.добавитьЗадачуToolStripMenuItem.Name = "добавитьЗадачуToolStripMenuItem";
            this.добавитьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.добавитьЗадачуToolStripMenuItem.Text = "Добавить задачу";
            // 
            // хешированиеФайловToolStripMenuItem
            // 
            this.хешированиеФайловToolStripMenuItem.Name = "хешированиеФайловToolStripMenuItem";
            this.хешированиеФайловToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.хешированиеФайловToolStripMenuItem.Text = "Хеширование файлов";
            this.хешированиеФайловToolStripMenuItem.Click += new System.EventHandler(this.хешированиеToolStripMenuItem_Click);
            // 
            // архивироватьToolStripMenuItem
            // 
            this.архивироватьToolStripMenuItem.Name = "архивироватьToolStripMenuItem";
            this.архивироватьToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.архивироватьToolStripMenuItem.Text = "Архивировать";
            this.архивироватьToolStripMenuItem.Click += new System.EventHandler(this.архивацияФайловToolStripMenuItem_Click);
            // 
            // удалитьЗадачуToolStripMenuItem
            // 
            this.удалитьЗадачуToolStripMenuItem.Enabled = false;
            this.удалитьЗадачуToolStripMenuItem.Name = "удалитьЗадачуToolStripMenuItem";
            this.удалитьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.удалитьЗадачуToolStripMenuItem.Text = "Удалить задачу";
            this.удалитьЗадачуToolStripMenuItem.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(19, 0, 1, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(519, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Enabled = false;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(119, 24);
            this.toolStripDropDownButton1.Text = "Удалить задачу";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хешированиеToolStripMenuItem,
            this.архивацияФайловToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(145, 24);
            this.toolStripSplitButton1.Text = "Добавить задачу";
            // 
            // хешированиеToolStripMenuItem
            // 
            this.хешированиеToolStripMenuItem.Name = "хешированиеToolStripMenuItem";
            this.хешированиеToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.хешированиеToolStripMenuItem.Text = "Хеширование";
            this.хешированиеToolStripMenuItem.Click += new System.EventHandler(this.хешированиеToolStripMenuItem_Click);
            // 
            // архивацияФайловToolStripMenuItem
            // 
            this.архивацияФайловToolStripMenuItem.Name = "архивацияФайловToolStripMenuItem";
            this.архивацияФайловToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.архивацияФайловToolStripMenuItem.Text = "Архивация файлов";
            this.архивацияФайловToolStripMenuItem.Click += new System.EventHandler(this.архивацияФайловToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Менеджер задач";
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗадачуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хешированиеФайловToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem архивироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗадачуToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem архивацияФайловToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хешированиеToolStripMenuItem;
        public System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
    }
}

