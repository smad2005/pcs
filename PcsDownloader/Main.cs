using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Pcs;

namespace PcsDownloader
{
    public partial class Main : Form
    {
        public Main()
        {
            Visible = false;
            InitializeComponent();
        }


        [STAThread]
        private void Main_Load(object sender, EventArgs e)
        {
            string[] arg = Environment.GetCommandLineArgs();
            var reg = new Register(Application.ExecutablePath);

            reg.AddToContextMenu();
            if (arg.Length == 3 && arg[1] == "-a")
            {
                string curdir = Path.GetDirectoryName(Application.ExecutablePath);

                Visible = true;
                Action<object> f = (y) =>
                    {
                        const string gui = "Guiconfig.exe";
                        try
                        {
                            // модифицированній путь для конфига
                            string opturl = string.Format("{0}/config.xml", curdir);
                            //для настроек
                            var opt = new Option(opturl);

                            //Если пустые куки может стоит заполнить
                            CheckCookieValue(gui, ref opt, opturl);

                            // для доступа к апи
                            var pcs = new Pcs.Pcs(opt.Cookievalue);

                            //залитие картинки
                            Resultstruct result = pcs.SendPicture(arg[2], opt.SaveFormat, opt.IsPublic);
                            Action<Main> tunnel = u =>
                                {
                                    Clipboard.SetText(result.DirectAdress);
                                    opt.Cookievalue = pcs.GetCookie;
                                    opt.Save();
                                };
                            BeginInvoke(tunnel, this);
                        }
                        catch (Win32Exception ex)
                        {
                            MessageBox.Show(String.Format("Не найден {0}", gui));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Application.Exit();
                    };

                var t = new Thread(() => f(null));
                t.Start();
            }
            else
                Close();
        }

        /// <summary>
        ///     Проверят не пустые ли поле с куки
        /// </summary>
        /// <param name="gui">Адрес гуи приложения</param>
        /// <param name="opt"></param>
        /// <param name="opturl">Адрес где хранятся настройки</param>
        private void CheckCookieValue(string gui, ref Option opt, string opturl)
        {
            if (String.IsNullOrEmpty(opt.Cookievalue))
            {
                var pr = new Process();
                pr.StartInfo.FileName = gui;
                pr.StartInfo.ErrorDialog = false;

                pr.StartInfo.WorkingDirectory = Path.GetDirectoryName(opturl);
                pr.Start();
                if (File.Exists(gui))
                {
                    pr.WaitForExit();
                    opt = new Option(opturl);
                }
            }
        }
    }
}