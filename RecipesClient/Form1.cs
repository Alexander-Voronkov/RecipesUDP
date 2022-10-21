using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllClass;
namespace RecipesClient
{
    public partial class Form1 : Form
    {
        UdpClient udpClient;
        MainClient mainClient;
        TempPoint server;
        bool CloseMain = true;
        public Form1(MainClient form,UdpClient client,TempPoint server)
        {
            InitializeComponent();
            mainClient = form;
            udpClient = client;
            this.server = server;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            int port;

            if (IPAddress.TryParse(IpTB.Text, out ip) == false)
            {
                MessageBox.Show("Wrong ip!");
                return;
            }

            if (int.TryParse(PortTB.Text, out port) == false)
            {
                MessageBox.Show("Wrong port!");
                return;
            }

            if (string.IsNullOrEmpty(LoginTB.Text) || LoginTB.TextLength < 4)
            {
                MessageBox.Show("Login is at least 4 characters!");
                return;
            }

            if (string.IsNullOrEmpty(PassTB.Text) || PassTB.TextLength < 8)
            {
                MessageBox.Show("Password is at least 8 characters!");
                return;
            }
            server.Address = ip;
            server.Port = port;
            byte[] bytes = Encoding.UTF8.GetBytes($"SIGNUP\n{LoginTB.Text}\n{PassTB.Text}");
            try
            {
                udpClient.Send(bytes, bytes.Length, new IPEndPoint(server.Address,server.Port));
                IPEndPoint serv = null;
                byte[] result = udpClient.Receive(ref serv);
                string q = Encoding.UTF8.GetString(result);
                MessageBox.Show(q);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IPAddress ip;
            int port;
            if (IPAddress.TryParse(IpTB.Text, out ip) == false)
            {
                MessageBox.Show("Wrong ip!");
                return;
            }

            if (int.TryParse(PortTB.Text, out port) == false)
            {
                MessageBox.Show("Wrong port!");
                return;
            }

            if (string.IsNullOrEmpty(LoginTB.Text) || LoginTB.TextLength < 4)
            {
                MessageBox.Show("Login is at least 4 characters!");
                return;
            }

            if (string.IsNullOrEmpty(PassTB.Text) || PassTB.TextLength < 8)
            {
                MessageBox.Show("Password is at least 8 characters!");
                return;
            }

            server.Address= ip;
            server.Port= port;

            byte[] bytes = Encoding.UTF8.GetBytes($"SIGNIN\n{LoginTB.Text}\n{PassTB.Text}");
            try
            {
                udpClient.Send(bytes, bytes.Length, new IPEndPoint(ip, port));
                IPEndPoint serv = null;
                byte[] result = udpClient.Receive(ref serv);
                string q = Encoding.UTF8.GetString(result);
                MessageBox.Show(q);
                if (q == "Access granted!")
                {
                    CloseMain = false;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainClient.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseMain)
                mainClient.Close();
        }
    }
}
