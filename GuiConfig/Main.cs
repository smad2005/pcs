using System;
using System.Diagnostics;
using System.Windows.Forms;
using formatenum = Pcs.Pcs.FormatEnum;
namespace GuiConfig
{
    public partial class Main : Form
    {
        private readonly Pcs.Option opt = new Pcs.Option();
        public Main()
        {
            InitializeComponent();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            opt.Cookievalue = t_cookie.Text.Trim();
            opt.SaveFormat = (formatenum)Enum.Parse(typeof(formatenum), c_format.Text);
            opt.IsPublic = ch_public.Checked;
            opt.Save();
            Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            t_cookie.Text = opt.Cookievalue;
            ValidateLlEnterInAcount();
            var list = Enum.GetNames(typeof(formatenum));
            c_format.Items.AddRange(list);
            c_format.SelectedIndex = 0;
            c_format.Text = opt.SaveFormat.ToString();
            ch_public.Checked = opt.IsPublic;

        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var reg = new Pcs.Register();
                reg.RemoveFromContextMenu();
                MessageBox.Show("Удалено", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Требуются права администратора", "Для добавления удаления из контексное меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          

        }

        private void llEnterInAcount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cookie = t_cookie.Text;
            if (!string.IsNullOrEmpty(cookie))
                Process.Start(String.Format("{0}/setc.php?s={1}", Pcs.Pcs.Domen, cookie));
        }

        private void t_cookie_TextChanged(object sender, EventArgs e)
        {
            ValidateLlEnterInAcount();
        }

        private void ValidateLlEnterInAcount()
        {
            llEnterInAcoount.Enabled = !string.IsNullOrEmpty(t_cookie.Text);
        }
    }
}
