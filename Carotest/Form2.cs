using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carotest
{
    public partial class Form2 : Form
    {
        private List<Account> accounts = new List<Account>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                // Kiểm tra xem tài khoản và mật khẩu có tồn tại trong danh sách không
                if (IsLoginValid(username, password))
                {
                    MessageBox.Show("Login successfully!");

                    // Mở Form1 và ẩn Form2
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your account and password again.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Kiểm tra xem tên người dùng đã tồn tại chưa
            if (IsUsernameAvailable(username))
            {
                // Tạo một tài khoản mới và thêm vào danh sách
                Account newAccount = new Account { Username = username, Password = password };
                accounts.Add(newAccount);
                MessageBox.Show("Register successfully!");
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose another name.");
            }
        }
        private bool IsUsernameAvailable(string username)
        {
            foreach (var account in accounts)
            {
                if (account.Username == username)
                {
                    return false;
                }
            }
            return true;
        }

        // Phương thức để kiểm tra xem tài khoản và mật khẩu có tồn tại hay không
        private bool IsLoginValid(string username, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

    }
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
