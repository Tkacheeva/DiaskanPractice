
namespace WinForm
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsDDBtnDeleteTask = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSplitExecTask = new System.Windows.Forms.ToolStripSplitButton();
            this.AddNewTask = new System.Windows.Forms.ToolStripDropDownButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listViewTasks
            // 
            this.listViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnStatus});
            this.listViewTasks.GridLines = true;
            this.listViewTasks.HideSelection = false;
            this.listViewTasks.Location = new System.Drawing.Point(16, 15);
            this.listViewTasks.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTasks.MultiSelect = false;
            this.listViewTasks.Name = "listViewTasks";
            this.listViewTasks.Size = new System.Drawing.Size(485, 468);
            this.listViewTasks.TabIndex = 0;
            this.listViewTasks.UseCompatibleStateImageBehavior = false;
            this.listViewTasks.View = System.Windows.Forms.View.Details;
            this.listViewTasks.SelectedIndexChanged += new System.EventHandler(this.listViewTasks_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Задача";
            this.columnHeader1.Width = 257;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Статус";
            this.columnStatus.Width = 120;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDDBtnDeleteTask,
            this.tsSplitExecTask,
            this.AddNewTask});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(19, 0, 1, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(519, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsDDBtnDeleteTask
            // 
            this.tsDDBtnDeleteTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDDBtnDeleteTask.Enabled = false;
            this.tsDDBtnDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDDBtnDeleteTask.Name = "tsDDBtnDeleteTask";
            this.tsDDBtnDeleteTask.ShowDropDownArrow = false;
            this.tsDDBtnDeleteTask.Size = new System.Drawing.Size(119, 24);
            this.tsDDBtnDeleteTask.Text = "Удалить задачу";
            this.tsDDBtnDeleteTask.Click += new System.EventHandler(this.tsDDBtnDeleteTask_Click);
            // 
            // tsSplitExecTask
            // 
            this.tsSplitExecTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSplitExecTask.Image = ((System.Drawing.Image)(resources.GetObject("tsSplitExecTask.Image")));
            this.tsSplitExecTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSplitExecTask.Name = "tsSplitExecTask";
            this.tsSplitExecTask.Size = new System.Drawing.Size(156, 24);
            this.tsSplitExecTask.Text = "Выполнить задачу";
            // 
            // AddNewTask
            // 
            this.AddNewTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddNewTask.Image = ((System.Drawing.Image)(resources.GetObject("AddNewTask.Image")));
            this.AddNewTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewTask.Name = "AddNewTask";
            this.AddNewTask.Size = new System.Drawing.Size(189, 24);
            this.AddNewTask.Text = "Добавить новую задачу";
            this.AddNewTask.Click += new System.EventHandler(this.AddNewTask_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listViewTasks);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Менеджер задач";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listViewTasks;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripDropDownButton tsDDBtnDeleteTask;
        public System.Windows.Forms.ToolStripSplitButton tsSplitExecTask;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripDropDownButton AddNewTask;
        private System.Windows.Forms.ColumnHeader columnStatus;
    }
}

