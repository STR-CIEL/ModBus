using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModBus
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private IPEndPoint IPEndPointdest;
        int port = 502;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPointdest = new IPEndPoint(IPAddress.Parse(textBoxAdresseIP.Text), port);
                socket.Connect(IPEndPointdest);
                MessageBox.Show($"Connecte");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }


        }

        private void buttonDeconnexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;
                    
                    textBox1.AppendText("Socket ferme.\r\n");
                }
                else
                {
                    MessageBox.Show("Aucun socket actif à fermer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }
    }
}
