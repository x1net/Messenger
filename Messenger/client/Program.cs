using System;
using System.Windows.Forms;

namespace client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Запускаємо вікно авторизації
            using (Autoris authForm = new Autoris())
            {
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    // Отримуємо userInfo та userId з форми авторизації
                    (string userInfo, int userId) = authForm.GetUserInfoAndId();

                    // Якщо авторизація успішна, запускаємо головну форму клієнта
                    Application.Run(new Form1(userInfo, userId));
                }
            }
        }
    }
}
