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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Agency.Окна
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.ConnectionString = connstring;


            conn.Open();
            //string c = CHouseStatus.Text;
            string n = "";
            string b = Clipboard.GetText();
            string sql0 = $"select * from buyer INNER JOIN purchase_and_sale_agreement where users_Id={b}";
            //MessageBox.Show("_"  + "_");
            MySqlCommand cmd0 = new MySqlCommand(sql0, conn);
            MySqlDataReader reader0= cmd0.ExecuteReader();
            while (reader0.Read())
            {
                n=  reader0["real_estate_id"].ToString();
            }
            conn.Close();
            if (n == "")
            {

           
            string id = "";
            conn.Open();
            string c = CHouseStatus.Text;
            string sql1 = $"select * from real_estate where real_estate_id={c}";
            MessageBox.Show("_"+c+"_");
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                id = reader["seller_id"].ToString();
            }
            conn.Close();
            

            //String result = Clipboard.GetText();

            conn.Open();
            String result = Clipboard.GetText();
            string user_id = "";
            string sql2 = $"select * from buyer where users_Id={result}";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                user_id = reader2["buyers_id"].ToString();
            }

            conn.Close();

            conn.Open();
            string query = "INSERT INTO `purchase_and_sale_agreement` (`buyer_id`, `real_estate_id`, `date`) VALUES ('" + user_id + "','" + id + "','" + DateTime.Now.ToString("yyy.MM.dd") + "');";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int value = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("ожидайте");
            }
            else
            {
                MessageBox.Show("У вас уже есть покупка");
            }
        }
    }
}
