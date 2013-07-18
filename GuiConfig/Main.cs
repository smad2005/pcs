using System;
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
            opt.SaveFormat = (formatenum)Enum.Parse(typeof(formatenum),c_format.Text);
            opt.IsPublic = ch_public.Checked;
            opt.Save();
            Close();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            t_cookie.Text = opt.Cookievalue;
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
            var reg = new Pcs.Register();
            reg.RemoveFromContextMenu();
            MessageBox.Show("Удалено", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
