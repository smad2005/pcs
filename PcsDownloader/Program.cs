﻿using System;

using System.Windows.Forms;

namespace PcsDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Main());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
