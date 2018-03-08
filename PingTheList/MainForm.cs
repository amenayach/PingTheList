using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingTheList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbIps.Text = Config.Get();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save(tbIps.Text);
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            var ips = tbIps.Lines;

            try
            {
                using (var pingSender = new Ping())
                {
                    foreach (var ip in ips)
                    {
                        try
                        {
                            var reply = pingSender.Send(ip.Trim());

                            tbStatus.AppendText($"Pinging {ip}: {reply.Status}{Environment.NewLine}");

                            Application.DoEvents();
                        }
                        catch (Exception ex)
                        {
                            tbStatus.AppendText($"Pinging {ip}: {ex.Message}{Environment.NewLine}");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
