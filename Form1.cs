using System.Diagnostics;
using Microsoft.Win32;
using Dark.Net;
using System.Runtime.InteropServices;

namespace TheUltiKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.90;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize"))
            {
                if (key != null)
                {
                    string temp = key.GetValue("AppsUseLightTheme").ToString();
                    int darkmode = int.Parse(temp);
                    if (darkmode == 0)
                    {
                        this.BackColor = Color.Black; 
                        this.ForeColor = Color.White;
                        button1.ForeColor = Color.Black;
                        tabPage1.BackColor = Color.Black;
                        tabPage1.ForeColor = Color.White;
                        tabPage2.BackColor = Color.Black;
                        tabPage2.ForeColor = Color.White;
                        
                    }
                }
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/Endeade/AppInstaller/releases");
        }
    }
}