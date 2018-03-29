using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            string myConnectionString = "server=localhost;user=root;" +
"database=mydb; port=3306; password=";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            int role = 0;
            try
            {
                conn.Open();
                string sql = "SELECT Роль FROM пользователь WHERE Логин = \""
                + txt_login.Text + "\" AND Пароль = \""
                + txt_password.Text + "\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    role = Convert.ToInt32(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            switch (role)
            {
                case 1:
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
                    this.Show();
                    break;
                case 2:

                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}
