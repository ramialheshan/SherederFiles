namespace SherederFiles
{
    partial class FormShreder
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShreder));
            this.StartRecycle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PathFolder = new System.Windows.Forms.TextBox();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProcessShrederFiles = new System.Windows.Forms.ToolStripProgressBar();
            this.CountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CountOfFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.CountClearedFilesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CountClearedFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.StateRemove = new System.Windows.Forms.CheckBox();
            this.NideTurnOffChecked = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartRecycle
            // 
            this.StartRecycle.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartRecycle.Location = new System.Drawing.Point(451, 18);
            this.StartRecycle.Name = "StartRecycle";
            this.StartRecycle.Size = new System.Drawing.Size(122, 34);
            this.StartRecycle.TabIndex = 0;
            this.StartRecycle.Text = "Старт очистки";
            this.StartRecycle.UseVisualStyleBackColor = true;
            this.StartRecycle.Click += new System.EventHandler(this.StartRecycle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Каталог очистки:";
            // 
            // PathFolder
            // 
            this.PathFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathFolder.Location = new System.Drawing.Point(0, 0);
            this.PathFolder.Margin = new System.Windows.Forms.Padding(0);
            this.PathFolder.Name = "PathFolder";
            this.PathFolder.Size = new System.Drawing.Size(393, 20);
            this.PathFolder.TabIndex = 2;
            // 
            // OpenFolder
            // 
            this.OpenFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.OpenFolder.Location = new System.Drawing.Point(393, 0);
            this.OpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(25, 20);
            this.OpenFolder.TabIndex = 0;
            this.OpenFolder.Text = "...";
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PathFolder);
            this.panel1.Controls.Add(this.OpenFolder);
            this.panel1.Location = new System.Drawing.Point(15, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 20);
            this.panel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StateLabel,
            this.ProcessShrederFiles,
            this.CountLabel,
            this.CountOfFile,
            this.CountClearedFilesLabel,
            this.CountClearedFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 73);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(585, 23);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StateLabel
            // 
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(109, 18);
            this.StateLabel.Text = "Состояние очистки:";
            // 
            // ProcessShrederFiles
            // 
            this.ProcessShrederFiles.Margin = new System.Windows.Forms.Padding(1, 5, 1, 3);
            this.ProcessShrederFiles.Name = "ProcessShrederFiles";
            this.ProcessShrederFiles.Size = new System.Drawing.Size(100, 15);
            this.ProcessShrederFiles.Step = 1;
            // 
            // CountLabel
            // 
            this.CountLabel.Margin = new System.Windows.Forms.Padding(25, 3, 0, 2);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(112, 18);
            this.CountLabel.Text = "Количество файлов:";
            // 
            // CountOfFile
            // 
            this.CountOfFile.Name = "CountOfFile";
            this.CountOfFile.Size = new System.Drawing.Size(0, 18);
            // 
            // CountClearedFilesLabel
            // 
            this.CountClearedFilesLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.CountClearedFilesLabel.Name = "CountClearedFilesLabel";
            this.CountClearedFilesLabel.Size = new System.Drawing.Size(58, 18);
            this.CountClearedFilesLabel.Text = "Очищено:";
            // 
            // CountClearedFiles
            // 
            this.CountClearedFiles.Name = "CountClearedFiles";
            this.CountClearedFiles.Size = new System.Drawing.Size(0, 18);
            // 
            // StateRemove
            // 
            this.StateRemove.AutoSize = true;
            this.StateRemove.Location = new System.Drawing.Point(15, 49);
            this.StateRemove.Name = "StateRemove";
            this.StateRemove.Size = new System.Drawing.Size(182, 17);
            this.StateRemove.TabIndex = 5;
            this.StateRemove.Text = "Удалять файлы после очистки";
            this.StateRemove.UseVisualStyleBackColor = true;
            // 
            // NideTurnOffChecked
            // 
            this.NideTurnOffChecked.AutoSize = true;
            this.NideTurnOffChecked.Location = new System.Drawing.Point(203, 49);
            this.NideTurnOffChecked.Name = "NideTurnOffChecked";
            this.NideTurnOffChecked.Size = new System.Drawing.Size(143, 17);
            this.NideTurnOffChecked.TabIndex = 5;
            this.NideTurnOffChecked.Text = "Выключить компьютер";
            this.NideTurnOffChecked.UseVisualStyleBackColor = true;
            // 
            // FormShreder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 96);
            this.Controls.Add(this.NideTurnOffChecked);
            this.Controls.Add(this.StateRemove);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartRecycle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShreder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "_";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartRecycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathFolder;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StateLabel;
        private System.Windows.Forms.ToolStripProgressBar ProcessShrederFiles;
        private System.Windows.Forms.ToolStripStatusLabel CountLabel;
        private System.Windows.Forms.ToolStripStatusLabel CountOfFile;
        private System.Windows.Forms.ToolStripStatusLabel CountClearedFilesLabel;
        private System.Windows.Forms.ToolStripStatusLabel CountClearedFiles;
        private System.Windows.Forms.CheckBox StateRemove;
        private System.Windows.Forms.CheckBox NideTurnOffChecked;
    }
}

