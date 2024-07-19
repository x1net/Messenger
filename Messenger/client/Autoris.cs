using System;
using System.Windows.Forms;

namespace client
{
    public partial class Autoris : Form
    {
        private readonly DatabaseService _databaseService;
        private string userInfo;
        private int userId;

        public Autoris()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            string username = Login.Text;
            string password = Pass.Text;

            if (_databaseService.AuthenticateUser(username, password))
            {
                (userInfo, userId) = _databaseService.GetUserInfoAndId(username);

                if (_databaseService.IsUserBlacklisted(userId))
                {
                    MessageBox.Show("Ви знаходитесь у чорному списку!!!.");
                    return;
                }

                MessageBox.Show("Успішний вхід!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль!");
            }
        }

        public (string, int) GetUserInfoAndId()
        {
            return (userInfo, userId);
        }

        private void Autoris_Load(object sender, EventArgs e)
        {

        }

        private void Reg_Click(object sender, EventArgs e)
        {
            Registr regForm = new Registr(); // вікно реєстрації
            regForm.Show();
        }
    }
}
