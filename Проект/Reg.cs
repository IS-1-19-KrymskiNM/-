using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            entry1 en = new entry1();
            en.Show();
            Hide();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }

        bool IsValid(string line, string request)
        {
            return new Regex(@request).IsMatch(line);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(password.Text == password_2.Text && (IsValid(email.Text, @"^[\w\.\-]+@[\w\-]+\.[a-z]+$") && IsValid(number.Text, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"))) 
            {
            //Формируем строку запроса на удаление строк
            string sql_new = ($"INSERT INTO Users (name, number, email, login, password) " +
                                             $"VALUES ('{name.Text}','{number.Text}','{email.Text}',@un,@up)");
            //Посылаем запрос на обновление данных
            MySqlCommand newrec = new MySqlCommand(sql_new, Classes.DBConn.conn);
            Classes.DBConn.conn.Open();
            newrec.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            newrec.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            //Присваиваем параметрам значение
            newrec.Parameters["@un"].Value = login.Text;
            newrec.Parameters["@up"].Value = Classes.Encryption.Sha256(password.Text);
            newrec.ExecuteNonQuery();
            Classes.DBConn.conn.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные телефона или почты, либо не верный повторный пароль");
            }
        }

        private void Reg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
