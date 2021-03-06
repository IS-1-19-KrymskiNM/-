using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Проект
{
    public partial class entry1 : Form
    {
        public entry1()
        {
            InitializeComponent();
        }


        //Метод запроса данных пользователя по логину для запоминания их в полях класса
        public void GetUserInfo(string login)
        {
            // устанавливаем соединение с БД
            Classes.DBConn.conn.Open();
            // запрос
            var sql = $"SELECT * FROM Users WHERE login='{login}'";
            // объект для выполнения SQL-запроса
            var command = new MySqlCommand(sql, Classes.DBConn.conn);
            // объект для чтения ответа сервера
            var reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Classes.Auth.auth_name = reader[4].ToString();
                Classes.Auth.auth_number = reader[3].ToString();
                Classes.Auth.auth_email = reader[2].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            Classes.DBConn.conn.Close();
        }


        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Reg re = new Reg();
            re.Show();
            Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            {
                //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
                var sql = "SELECT * FROM Users WHERE login = @un and  password= @up";
                //Открытие соединения
                Classes.DBConn.conn.Open();
                //Объявляем таблицу
                var table = new DataTable();
                //Объявляем адаптер
                var adapter = new MySqlDataAdapter();
                //Объявляем команду
                var command = new MySqlCommand(sql, Classes.DBConn.conn);
                //Определяем параметры
                command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
                //Присваиваем параметрам значение
                command.Parameters["@un"].Value = Au_login.Text;
                command.Parameters["@up"].Value = Classes.Encryption.Sha256(Au_password.Text);
                //Заносим команду в адаптер
                adapter.SelectCommand = command;
                //Заполняем таблицу
                adapter.Fill(table);
                //Закрываем соединение
                Classes.DBConn.conn.Close();
                //Если вернулась больше 0 строк, значит такой пользователь существует
                if (table.Rows.Count > 0)
                {
                    //Присваеваем глобальный признак авторизации
                    Classes.Auth.auth = true;
                    //Достаем данные пользователя в случае успеха
                    GetUserInfo(Au_login.Text);
                    //Вызов формы в режиме диалога
                    Hide();
                    Main m = new Main(); 
                    m.Show();
                }
                else
                {
                    //Отобразить сообщение о том, что авторизаия неуспешна
                    MessageBox.Show("Неверные данные авторизации");

                }
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void entry1_Load(object sender, EventArgs e)
        {

        }
    }
}
