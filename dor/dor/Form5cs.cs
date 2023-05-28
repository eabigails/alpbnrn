using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dor
{
    public partial class Form5 : Form
    {

        //TRANSAKSI

        // jujur ak jg gatau ak ngapain - ujin T__T

        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        string sqlquery;
        DataTable metodepembayaran = new DataTable();
        DataTable dtConcert = new DataTable();
        private string formattedDate;
        string connection = "server=localhost;uid=root;pwd=ujinujin;database=db_concert";


        private string concertName;
        private string categoryName;
        private decimal price;
        private DateTime selectedDate;
        private int count = 0;

        public Form5(string concertName, string categoryName, decimal price, DateTime selectedDate)
        {
            InitializeComponent();
            this.concertName = concertName;
            this.categoryName = categoryName;
            this.price = price;
            this.selectedDate = selectedDate;
            sqlConnection = new MySqlConnection(connection);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            labelConcertName.Text = concertName;
            labelCategoryName.Text = categoryName;
            labelPrice.Text = price.ToString();
            labelSelectedDate.Text = selectedDate.ToString("yyyy-MM-dd");
            labelCount.Text = count.ToString();


            sqlquery = "select jenis_pembayaran from transaksi where jenis_pembayaran in('BCA', 'MANDIRI','ALFAMART','INDOMART') group by jenis_pembayaran;";
            sqlCommand = new MySqlCommand(sqlquery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(metodepembayaran);
            comboBox_transaksi.DataSource = metodepembayaran;
            comboBox_transaksi.ValueMember = "jenis_pembayaran";
            comboBox_transaksi.DisplayMember = "jenis_pembayaran";

            UpdateTotalLabel();
        }

        private void add_Click(object sender, EventArgs e)
        {
            count++;
            labelCount.Text = count.ToString();
            UpdateTotalLabel();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
                labelCount.Text = count.ToString();
                UpdateTotalLabel();
            }
        }

        private void UpdateTotalLabel()
        {
            decimal total = count * price;
            label_total.Text = total.ToString();
        }

        private void UpdateRemainingSeats()
        {
            //buat id jadwal
            int scheduleId = GetScheduleId();
            int categoryId = GetCategoryId();

            
            string updateQuery = "UPDATE jadwal SET sisa_kursi = sisa_kursi - @totalSeats WHERE id_jadwal = @scheduleId AND id_kategori = @categoryId";

            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@totalSeats", count);
                    sqlCommand.Parameters.AddWithValue("@scheduleId", scheduleId);
                    sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }



        private int GetCustomerId()
        {
            return 1;
        }

        private int GetScheduleId()
        {
            
            return 1;
        }

        private int GetCategoryId()
        {
            
            return 1;
        }


        private string GenerateOrderId()
        {

            return Guid.NewGuid().ToString();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            string selectedPaymentMethod = comboBox_transaksi.SelectedValue.ToString();

            try
            {
            
                string insertQuery = "INSERT INTO transaksi (id_order, totalkursi, jenis_pembayaran, id_cust, id_jadwal, id_kategori) " +
                    "VALUES (@idOrder, @totalSeats, @paymentMethod, @customerId, @scheduleId, @categoryId)";

                using (MySqlConnection sqlConnection = new MySqlConnection(connection))
                {
                    using (MySqlCommand sqlCommand = new MySqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@idOrder", GenerateOrderId()); 
                        sqlCommand.Parameters.AddWithValue("@totalSeats", count);
                        sqlCommand.Parameters.AddWithValue("@paymentMethod", selectedPaymentMethod);
                        sqlCommand.Parameters.AddWithValue("@customerId", GetCustomerId()); 
                        sqlCommand.Parameters.AddWithValue("@scheduleId", GetScheduleId()); 
                        sqlCommand.Parameters.AddWithValue("@categoryId", GetCategoryId()); 

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                UpdateRemainingSeats();

               
                MessageBox.Show("Data inserted into the database successfully and remaining seats updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while inserting data into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
