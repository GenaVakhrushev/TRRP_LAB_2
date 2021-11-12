using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRRP_Lab_2
{
    public partial class Form1 : Form
    {
        Client client = new Client();

        public Form1()
        {
            InitializeComponent();
        }
        private void changeFileButton_Click(object sender, EventArgs e)
        {
            openFileDb.Filter = @"SQLite DB files (*.sqlite)|*.sqlite";
            openFileDb.Multiselect = false;
            openFileDb.InitialDirectory = Directory.GetCurrentDirectory();;
            openFileDb.ShowDialog();
            pathText.Text = openFileDb.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var records = client.Records(pathText.Text);
            if (records == null)
                return;
            try
            {
                client.SendSocket(records, IpTextBox.Text, int.Parse(PortTextBox.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var records = client.Records(pathText.Text);
            if (records == null)
                return;
            try
            {
                client.SendMQ(records, IpMQTextBox.Text, LoginTextBox.Text, PassTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }
    }
}
