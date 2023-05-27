using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                string formattedDate = date.ToString("yyyy-MM-dd"); // Format the date as 'YYYY-MM-DD'
                labelSelectedDate.Text = "Selected Date: " + formattedDate;

                // Clear existing seat information
                panelSeats.Controls.Clear();

                string query = @"
            SELECT k.nama_kategori, k.harga, k.maxcapacity, k.status,
                CASE
                    WHEN r.remaining_capacity IS NULL THEN 'Full Capacity'
                    WHEN r.remaining_capacity = 0 THEN 'Sold Out'
                    ELSE CONCAT(r.remaining_capacity, ' seats remaining')
                END AS remaining_seats_label
            FROM kategori_kursi k
            INNER JOIN jadwal j ON k.id_concert = j.id_concert
            INNER JOIN concert c ON j.id_concert = c.id_concert
            LEFT JOIN (
                SELECT k.id_kategori, k.maxcapacity - COUNT(q.id_order) AS remaining_capacity
                FROM kategori_kursi k
                LEFT JOIN queue_number q ON k.id_kategori = q.id_kategori
                LEFT JOIN jadwal j2 ON k.id_concert = j2.id_concert
                WHERE DATE(j2.date_jadwal) = @selectedDate
                GROUP BY k.id_kategori
            ) AS r ON k.id_kategori = r.id_kategori
            WHERE c.nama_concert = @selectedValue
                AND DATE(j.date_jadwal) = @selectedDate
            ORDER BY k.id_kategori;";

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
                                // Retrieve seat information for each category
                                string namaKategori = sqlDataReader["nama_kategori"].ToString();
                                string harga = sqlDataReader["harga"].ToString();
                                string maxCapacity = sqlDataReader["maxcapacity"].ToString();
                                string status = sqlDataReader["status"].ToString();
                                string remainingSeatsLabel = sqlDataReader["remaining_seats_label"].ToString();
                                // Create labels dynamically
                                Label labelNamaKategori = new Label();
                                labelNamaKategori.Location = new Point(50, labelY);
                                labelNamaKategori.Size = new Size(200, 20);
                                labelNamaKategori.Text = "Category: " + namaKategori;
                                labelNamaKategori.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelNamaKategori);
                                Label labelHarga = new Label();
                                labelHarga.Location = new Point(50, labelY + 30);
                                labelHarga.Size = new Size(200, 20);
                                labelHarga.Text = "Price: " + harga;
                                labelHarga.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelHarga);
                                Label labelMaxCapacity = new Label();
                                labelMaxCapacity.Location = new Point(50, labelY + 60);
                                labelMaxCapacity.Size = new Size(200, 20);
                                labelMaxCapacity.Text = "Max Capacity: " + maxCapacity;
                                labelMaxCapacity.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelMaxCapacity);
                                Label labelStatus = new Label();
                                labelStatus.Location = new Point(50, labelY + 90);
                                labelStatus.Size = new Size(200, 20);
                                labelStatus.Text = "Status: " + status;
                                labelStatus.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelStatus);
                                Label labelRemainingSeats = new Label();
                                labelRemainingSeats.Location = new Point(50, labelY + 120);
                                labelRemainingSeats.Size = new Size(200, 20);
                                labelRemainingSeats.Text = "Remaining Seats: " + remainingSeatsLabel;
                                labelRemainingSeats.ForeColor = Color.White;
                                panelSeats.Controls.Add(labelRemainingSeats);
                                labelY += 150;

                                Button button1 = new Button();
                                button1.Text = "Buy";
                                button1.Name = namaKategori; 
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
