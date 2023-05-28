using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace dor
{
    public partial class Form4 : Form
    {

        // PILIH KATEGORI KURSI
        private string selectedValue;
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        string sqlquery;
        DataTable dtConcert = new DataTable();
        string connection = "server=localhost;uid=root;pwd=ujinujin;database=db_concert";

        public Form4(string selectedValue)
        {
            InitializeComponent();
            this.selectedValue = selectedValue;
            sqlConnection = new MySqlConnection(connection);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string query = "SELECT desc_concert FROM concert WHERE nama_concert = @selectedValue";
            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                    sqlConnection.Open();
                    using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            string columnName = sqlDataReader["desc_concert"].ToString();
                            labeldesc.Text = columnName;
                        }
                    }
                }
            }

            query = "SELECT j.date_jadwal FROM jadwal j, concert c WHERE j.id_concert = c.id_concert AND c.nama_concert = @selectedValue";
            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                    sqlConnection.Open();
                    using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        int buttonY = 100;

                        while (sqlDataReader.Read())
                        {
                            string date = sqlDataReader["date_jadwal"].ToString();

                            Button button = new Button();
                            button.Text = date;
                            button.ForeColor = Color.Black;
                            button.BackColor = Color.White;
                            button.Location = new Point(10, buttonY);
                            button.Click += button_Click;
                            Controls.Add(button);

                            buttonY += 30;
                        }
                    }
                }
            }




        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string selectedDate = button.Text;

            DateTime date;
            if (DateTime.TryParse(selectedDate, out date))
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                labelSelectedDate.Text = "Selected Date: " + formattedDate;


                panelSeats.Controls.Clear();

                string query = @"SELECT c.nama_concert AS concert_name,
    k.nama_kategori AS category_name,
    k.harga,
    k.maxcapacity,
    k.maxcapacity - COALESCE(SUM(t.totalkursi), 0) AS remaining_seats
FROM concert c
INNER JOIN jadwal j ON c.id_concert = j.id_concert
INNER JOIN kategori_kursi k ON c.id_concert = k.id_concert
LEFT JOIN transaksi t ON k.id_kategori = t.id_kategori AND j.id_jadwal = t.id_jadwal
WHERE c.nama_concert = @selectedValue
    AND j.date_jadwal = @selectedDate
GROUP BY c.nama_concert, k.nama_kategori, k.harga, k.maxcapacity;
";

                


                using (MySqlConnection sqlConnection = new MySqlConnection(connection))
                {
                    using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                        sqlCommand.Parameters.AddWithValue("@selectedDate", formattedDate);
                        sqlConnection.Open();
                        using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            int labelY = 50;
                            int labelyy = 50;
                            while (sqlDataReader.Read())
                            {
                                string categoryName = sqlDataReader["category_name"].ToString();
                                string price = sqlDataReader["harga"].ToString();
                                string maxCapacity = sqlDataReader["maxcapacity"].ToString();
                                string remainingSeats = sqlDataReader["remaining_seats"].ToString();

                                Label labelCategoryName = new Label();
                                labelCategoryName.Location = new Point(50, labelY);
                                labelCategoryName.Size = new Size(200, 20);
                                labelCategoryName.Text = "Category: " + categoryName;
                                labelCategoryName.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelCategoryName);

                                Label labelPrice = new Label();
                                labelPrice.Location = new Point(50, labelY + 30);
                                labelPrice.Size = new Size(200, 20);
                                labelPrice.Text = "Price: " + price;
                                labelPrice.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelPrice);

                                Label labelMaxCapacity = new Label();
                                labelMaxCapacity.Location = new Point(50, labelY + 60);
                                labelMaxCapacity.Size = new Size(200, 20);
                                labelMaxCapacity.Text = "Max Capacity: " + maxCapacity;
                                labelMaxCapacity.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelMaxCapacity);

                                Label labelRemainingSeats = new Label();
                                labelRemainingSeats.Location = new Point(50, labelY + 90);
                                labelRemainingSeats.Size = new Size(200, 20);
                                labelRemainingSeats.Text = "Remaining Seats: " + remainingSeats;
                                labelRemainingSeats.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelRemainingSeats);

                                labelY += 150;

                                Button button1 = new Button();
                                button1.Text = "Buy";
                                button1.Name = categoryName;
                                button1.Location = new Point(260, labelyy);
                                button1.Click += button1_click;
                                button1.BackColor = Color.White;
                                panelSeats.Controls.Add(button1);

                                labelyy += 150;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid date format: " + selectedDate);
                return;
            }
        }


        private void button1_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string categoryName = button.Name;
            this.Hide();
            Form5 form5 = new Form5(categoryName);
            form5.Show();
        }


    }

}
