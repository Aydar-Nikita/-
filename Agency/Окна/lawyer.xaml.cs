using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
 

namespace Agency.Окна
{
    /// <summary>
    /// Логика взаимодействия для lawyer.xaml
    /// </summary>
    public partial class lawyer : Window
    {
        public lawyer()
        {
            InitializeComponent();
            nedvi_info();
        }
        string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        UserControl2 userControl1 = new UserControl2();
        private void nedvi_info()
        {
            
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            MySqlConnection conn2 = new MySqlConnection();
            conn2.ConnectionString = connstring;
            conn2.Open();

            string sql = "SELECT users.Surname, users.Name, users.Patronymic,purhase_status_title, purchase_and_sale_agreement.id_purchase FROM users INNER JOIN purchase_and_sale_agreement INNER JOIN buyer INNER JOIN purhase_status ON buyers_id=buyer_id and User_id=users_Id and purchase_and_sale_agreement.status=purhase_status.idpurhase_status;";
            string sql2 = "SELECT users.Surname, users.Name, users.Patronymic, real_estate.address, real_estate.cost FROM users INNER JOIN purchase_and_sale_agreement INNER JOIN seller INNER JOIN  real_estate  ON seller.seller_id=purchase_and_sale_agreement.real_estate_id and users.User_id=seller.user_id and seller.seller_id=real_estate.seller_id;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
        

            while (reader.Read()&& reader2.Read())
            {
                userControl1 = new UserControl2();
                userControl1.stat.Text = reader["purhase_status_title"].ToString();
                userControl1.fio1.Text = reader["Surname"].ToString()+" " + reader["Name"].ToString()+" "+ reader["Patronymic"].ToString();
                userControl1.fio2.Text= reader2["Surname"].ToString() + " " + reader2["Name"].ToString() + " " + reader2["Patronymic"].ToString();
                userControl1.number.Text = reader["id_purchase"].ToString();
                userControl1.nedv.Text= "Недвижимость: "+reader2["address"].ToString()+"\n"+ "Стоимость: "+reader2["cost"].ToString()+" рублей";
                li.Items.Add(userControl1);
            }
            conn.Close();
            conn2.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
