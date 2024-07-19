using System;
using System.Windows.Forms;

namespace client
{
    public partial class Registr : Form
    {
        private DatabaseService _databaseService;

        public Registr()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            string username = Login.Text;
            string password1 = Pass1.Text;
            string password2 = Pass2.Text;
            string info = Info.Text;

            if (password1 != password2)
            {
                MessageBox.Show("Паролі не співпадають!");
                return;
            }

            if (_databaseService.CreateUser(username, password1, info, "", "", out string errorMessage))
            {
                MessageBox.Show("Реєстрація успішна!");
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void Registr_Load(object sender, EventArgs e)
        {

        }
    }
}
