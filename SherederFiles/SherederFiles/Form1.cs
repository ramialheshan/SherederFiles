using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Management;
using System.Diagnostics;


  

namespace SherederFiles
{
    public partial class FormShreder : Form
    {
        //Блок инициализации 

        #region Описание переменных формы 

        BackgroundWorker BackgroundWorker1;
        bool freeBackgroundWorker1 = true;
        BackgroundWorker BackgroundWorker2;
        bool freeBackgroundWorker2 = true;
        BackgroundWorker BackgroundWorker3;
        bool freeBackgroundWorker3 = true;
        BackgroundWorker BackgroundWorkerMain;
        bool Working;
        string[] filePaths;
        int countDeletedFiles;

        DateTime StartClear;


        #endregion

        #region Блок инициализации 
        
        public FormShreder()
        {
            InitializeComponent();

            BackgroundWorker1 = new BackgroundWorker();
            BackgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            BackgroundWorker1.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
            BackgroundWorker2 = new BackgroundWorker();
            BackgroundWorker2.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            BackgroundWorker2.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(BackgroundWorker2_RunWorkerCompleted);
            BackgroundWorker3 = new BackgroundWorker();
            BackgroundWorker3.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            BackgroundWorker3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker3_RunWorkerCompleted);
            BackgroundWorkerMain = new BackgroundWorker();
            BackgroundWorkerMain.DoWork += new DoWorkEventHandler(BackgroundWorkerMain_DoWork);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------

        //Методы формы 

        #region Метод: Выключить компьютер 
        
        void Shutdown()
        {
            Process.Start("shutdown.exe", "-s -t 0");
        }

        void ShutdownVer2()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------

        //События 

        #region Событие: Запуск основного потока 
        
        void BackgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Working)
            {
                Application.DoEvents();
                if (countDeletedFiles == filePaths.Length){ break; }
                if (freeBackgroundWorker1 && !BackgroundWorker1.IsBusy)
                {
                    try
                    {
                        BackgroundWorker1.RunWorkerAsync(filePaths[countDeletedFiles]);
                        countDeletedFiles += 1;
                    }
                    catch (Exception) { }
                }
                if (freeBackgroundWorker2 && !BackgroundWorker2.IsBusy)
                {
                    try
                    {
                        BackgroundWorker2.RunWorkerAsync(filePaths[countDeletedFiles]);
                        countDeletedFiles += 1;
                    }
                    catch (Exception) { }
                }
                if (freeBackgroundWorker3 && !BackgroundWorker3.IsBusy)
                {
                    try
                    {
                        BackgroundWorker3.RunWorkerAsync(filePaths[countDeletedFiles]);
                        countDeletedFiles += 1;
                    }
                    catch (Exception) { }
                }
                Thread.Sleep(500);
            }

            #region Запись в LOG файл результатов очистки 

            System.IO.FileStream fileLog = new FileStream(Application.StartupPath + "\\" + "LogFile_DateTime_" + DateTime.Now.ToString(), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);
            
            StreamWriter m_streamWriter = new StreamWriter(fileLog);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine("Количество файлов для очистки: " + filePaths.Length.ToString());
            m_streamWriter.WriteLine("Количество очищенных файлов: " + countDeletedFiles.ToString());
            m_streamWriter.WriteLine("Время запуска очистки: " + StartClear.ToString());
            m_streamWriter.WriteLine("Время остановки очистки: " + DateTime.Now.ToString());

            #endregion

            #region Проверка на выключение компа 

            switch (NideTurnOffChecked.Checked)
            {
                case true:
                    m_streamWriter.WriteLine("Время выключения ПК: " + DateTime.Now.ToString());
                    m_streamWriter.Flush();
                    fileLog.Flush();
                    fileLog.Close();
                    Shutdown(); break;
                case false:
                    m_streamWriter.Flush();
                    fileLog.Flush();
                    fileLog.Close();
                    break;
            }

            #endregion

            this.Invoke(new EventHandler(delegate { StartRecycle.Text = "Старт очистки"; }));
            this.Invoke(new EventHandler(delegate { ProcessShrederFiles.Value = 0; }));
            this.Invoke(new EventHandler(delegate { CountOfFile.Text = string.Empty; }));
            this.Invoke(new EventHandler(delegate { CountClearedFiles.Text = string.Empty; })); 
            this.Invoke(new EventHandler(delegate { PathFolder.Text = string.Empty; }));
            this.Invoke(new EventHandler(delegate { StateRemove.Enabled = true; }));

            MessageBox.Show("Очистка файлов завершена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
        
        #region Событие: Запуск вспомогательной очистки 

        void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileClear((string)e.Argument);
        }

        #endregion

        #region Событие: Закончилась обработка файла в потоке 

        void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            freeBackgroundWorker1 = true;
        }
        void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            freeBackgroundWorker2 = true;
        }
        void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            freeBackgroundWorker3 = true;
        }

        #endregion
      
        #region Событие: Начало очистки 

        private void StartRecycle_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(PathFolder.Text.Trim()))
            {
                filePaths = Directory.GetFiles(PathFolder.Text.Trim(), "*.*", SearchOption.AllDirectories);
                CountOfFile.Text = filePaths.Length.ToString();
                ProcessShrederFiles.Maximum = filePaths.Length;
                countDeletedFiles = 0;

                switch (Working)
                {
                    case true: 
                        Working = false;
                        StartRecycle.Text = "Старт очистки";
                        StateRemove.Enabled = true;
                        NideTurnOffChecked.Enabled = true;
                        break;
                               
                    case false:
                        StartClear = DateTime.Now;
                        Working = true;
                        StartRecycle.Text = "Остановить";
                        StateRemove.Enabled = false;
                        NideTurnOffChecked.Enabled = false;
                        BackgroundWorkerMain.RunWorkerAsync();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Заданый каталог не существует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }

        #endregion

        #region Событие: Выбор каталога 
        
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            switch (folderBrowserDialog.ShowDialog())
            {
                case DialogResult.OK: PathFolder.Text = folderBrowserDialog.SelectedPath;
                    break;
            } 
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------


        //Методы 

        #region Метод: Очистка файла в потоке 

        protected void FileClear(string PathFileForDelete)
        {
            FileStream streamCurrent = null;
            try
            {
                streamCurrent = new FileStream(PathFileForDelete, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                streamCurrent.Position = 0;
                for (int q = 0; q < streamCurrent.Length; q++)
                {
                    streamCurrent.Position = q;
                    streamCurrent.WriteByte(Convert.ToByte(0));
                }

                Thread.Sleep(100);
                streamCurrent.Close();

                if (StateRemove.Checked)
                {
                    try
                    {
                        System.IO.File.Delete(PathFileForDelete);
                    }
                    catch (Exception) { }
                }

                this.Invoke(new EventHandler(delegate { ProcessShrederFiles.Value += 1; }));
                CountClearedFiles.Text = countDeletedFiles.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------
    }
}
