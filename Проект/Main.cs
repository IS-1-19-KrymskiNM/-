using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект
{
    public partial class Main : Form
    {
        bool expectation;
        public Main()
        {
            InitializeComponent();
        }
        public static string request = "SELECT id_car AS 'Код', stamp AS 'Марка', model AS 'Модель машины', power AS 'Мощность', collor AS 'Цвет', number AS 'Номера', price 'Цена за день' FROM Car";
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содержит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        public static string id_selected_rows = "0";


        private void Main_Load(object sender, EventArgs e)
        {

            car.DataSource = Classes.DBConn.GetListUsers(request);
            //Видимость полей в гриде
            for (int i = 0; i < car.Columns.Count; i++)
            {
                car.Columns[i].Visible = true;
            }
            //Ширина полей
            car.Columns[0].FillWeight = 5;
            car.Columns[1].FillWeight = 10;
            car.Columns[2].FillWeight = 10;
            car.Columns[3].FillWeight = 10;
            car.Columns[4].FillWeight = 20;
            car.Columns[5].FillWeight = 15;
            car.Columns[6].FillWeight = 15;
            //Режим для полей "Только для чтения"
            for (int i = 0; i < car.Columns.Count; i++)
            {
                car.Columns[i].ReadOnly = true;
            }
            //Растягивание полей грида
            for (int i = 0; i < car.Columns.Count; i++)
            {
                car.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //Убираем заголовки строк
            car.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            car.ColumnHeadersVisible = true;
        }

        //Метод обновления DataGreed
        public void Reload()
        {
            //Чистим виртуальную таблицу внутри класса
            Classes.DBConn.ReloadList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            car.DataSource = Classes.DBConn.GetListUsers(request);
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = car.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = car.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }
        private void car_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                car.CurrentCell = car[e.ColumnIndex, e.RowIndex];
                //car.CurrentRow.Selected = true;
                car.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }

        private void car_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && car.CurrentCell != null)
            {
                //Магические строки
                car.CurrentCell = car[e.ColumnIndex, e.RowIndex];
                car.CurrentRow.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
    }
} 


