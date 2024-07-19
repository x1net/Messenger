using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string userInfo;
        private int userId;

        public Form1(string userInfo, int userId)
        {
            InitializeComponent();
            this.userInfo = userInfo ?? throw new ArgumentNullException(nameof(userInfo));
            this.userId = userId;
        }

        private async void ConnectToServer()
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ip.Text, int.Parse(port.Text));
                stream = client.GetStream();
                UpdateHistory("Підключено до сервера");
                var initialMessage = $"{userId}|{userInfo}";
                var buffer = Encoding.UTF8.GetBytes(initialMessage);
                await stream.WriteAsync(buffer, 0, buffer.Length);

                _ = Task.Run(() => ReceiveMessagesAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        UpdateHistory("Відключено від сервера");
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var messageParts = message.Split('|');
                    var messageType = messageParts[0];
                    var messageText = messageParts[1];

                    UpdateHistory($"Отримано [{messageType}]: {messageText}", messageType);
                }
            }
            catch (Exception ex)
            {
                UpdateHistory($"Помилка отримання повідомлення: {ex.Message}");
            }
        }

        private async void SendMessage(string message)
        {
            if (stream == null)
            {
                MessageBox.Show("Немає підключення до сервера");
                return;
            }

            var selectedType = type.SelectedItem?.ToString();
            if (selectedType == null)
            {
                MessageBox.Show("Виберіть тип повідомлення");
                return;
            }

            var buffer = Encoding.UTF8.GetBytes($"{selectedType}|{message}");
            await stream.WriteAsync(buffer, 0, buffer.Length);
            UpdateHistory($"Надіслано [{selectedType}]: {message}", selectedType);
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

        private void send_Click(object sender, EventArgs e)
        {
            SendMessage(text.Text);
        }

        private void connect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            stream?.Close();
            client?.Close();
        }
    }
}
