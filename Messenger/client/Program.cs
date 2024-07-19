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

            // ��������� ���� �����������
            using (Autoris authForm = new Autoris())
            {
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    // �������� userInfo �� userId � ����� �����������
                    (string userInfo, int userId) = authForm.GetUserInfoAndId();

                    // ���� ����������� ������, ��������� ������� ����� �볺���
                    Application.Run(new Form1(userInfo, userId));
                }
            }
        }
    }
}
