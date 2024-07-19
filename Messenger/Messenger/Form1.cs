using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private List<TcpClient> connectedClients;
        private Dictionary<TcpClient, (int userId, string userInfo)> clientDetails;

        public Form1()
        {
            InitializeComponent();
            connectedClients = new List<TcpClient>();
            clientDetails = new Dictionary<TcpClient, (int userId, string userInfo)>();
        }

        private async void StartServer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(port.Text, out int portNumber))
            {
                MessageBox.Show("Невірний номер порту");
                return;
            }

            server = new TcpListener(IPAddress.Any, portNumber);
            server.Start();
            UpdateHistory("Сервер запущено...", "Всі");

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                connectedClients.Add(client);
                HandleClientAsync(client);
            }
        }

        private async void HandleClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            var buffer = new byte[1024];

            // Отримуємо перше повідомлення від клієнта 
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            var initialMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            var parts = initialMessage.Split('|');
            int userId = int.Parse(parts[0]);
            string userInfo = parts[1];

            clientDetails[client] = (userId, userInfo);
            UpdateClientsList();

            while (true)
            {
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        connectedClients.Remove(client);
                        clientDetails.Remove(client);
                        UpdateClientsList();
                        break;
                    }

                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var messageParts = receivedMessage.Split('|');
                    var messageType = messageParts[0];
                    var messageText = messageParts[1];

                    UpdateHistory($"{userInfo} (ID: {userId}) [{messageType}]: {messageText}", messageType);
                    BroadcastMessage($"{userInfo} (ID: {userId}) [{messageType}]: {messageText}", client);
                }
                catch (Exception ex)
                {
                    connectedClients.Remove(client);
                    clientDetails.Remove(client);
                    UpdateClientsList();
                    UpdateHistory($"Клієнт {userInfo} (ID: {userId}) відключився.");
                    break;
                }
            }
        }

        private void BroadcastMessage(string message, TcpClient senderClient)
        {
            var buffer = Encoding.UTF8.GetBytes(message);

            foreach (var client in connectedClients)
            {
                if (client == senderClient) continue;

                var stream = client.GetStream();
                stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            var messageText = message.Text;
            var messageType = type.SelectedItem?.ToString() ?? "Звичайне";

            if (string.IsNullOrEmpty(messageText))
            {
                MessageBox.Show("Введіть повідомлення для надсилання.");
                return;
            }

            var selectedClients = clients.CheckedItems;

            if (selectedClients.Count == 0)
            {
                BroadcastMessage($"{messageType}|{messageText}", null);
            }
            else
            {
                foreach (var selectedClient in selectedClients)
                {
                    var clientInfo = selectedClient.ToString();
                    var client = connectedClients.Find(c => $"{clientDetails[c].userInfo} (ID: {clientDetails[c].userId})" == clientInfo);
                    if (client != null)
                    {
                        var buffer = Encoding.UTF8.GetBytes($"{messageType}|{messageText}");
                        var stream = client.GetStream();
                        stream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }
            }

            UpdateHistory($"Надіслано: {messageText}", messageType);
            message.Clear();
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                foreach (var client in connectedClients)
                {
                    client.Close();
                }
                connectedClients.Clear();
                clientDetails.Clear();
                UpdateClientsList();
                UpdateHistory("Сервер зупинено...", "Всі");
            }
        }

        private void UpdateClientsList()
        {
            Invoke((MethodInvoker)delegate
            {
                clients.Items.Clear();
                foreach (var client in connectedClients)
                {
                    if (clientDetails.ContainsKey(client))
                    {
                        var details = clientDetails[client];
                        clients.Items.Add($"{details.userInfo} (ID: {details.userId})");
                    }
                    else
                    {
                        clients.Items.Add(client.Client?.RemoteEndPoint?.ToString() ?? "Unknown Client");
                    }
                }
            });
        }

        private void UpdateHistory(string message, string messageType = "Звичайне")
        {
            Invoke((MethodInvoker)delegate
            {
                Color color;
                switch (messageType)
                {
                    case "Термінове":
                        color = Color.Red;
                        break;
                    case "Новини":
                        color = Color.Blue;
                        break;
                    case "Інформаційне":
                        color = Color.DarkGreen;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }

                history.SelectionStart = history.TextLength;
                history.SelectionLength = 0;

                history.SelectionColor = color;
                history.AppendText(message + Environment.NewLine);
                history.SelectionColor = history.ForeColor; 
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
