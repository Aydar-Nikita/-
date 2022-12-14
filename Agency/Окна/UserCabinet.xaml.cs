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
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Window
    {
        public UserCabinet()
        {
            InitializeComponent();
            nedvi_info();
        }

        UserControl11 userControl1 = new UserControl11();
        string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private void nedvi_info()
        {


            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string s = Clipboard.GetText();
            
            string sql = $"SELECT address, cost, comment, floor, number_of_rooms, area,image FROM real_estate INNER JOIN users INNER JOIN buyer where User_id={s}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userControl1 = new UserControl11();
                try
                {
                    userControl1.CHouseImage.Source = BitmapFrame.Create(new Uri(reader["image"].ToString(), UriKind.RelativeOrAbsolute));
                }
                catch
                {

                }
                userControl1.CHouseStreet.Content = reader["address"];
                userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                userControl1.description.Text = reader["comment"].ToString();
                userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
               // userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                Mylist.Items.Add(userControl1);
            }
        }

        private void GoBackToMenu(object sender, RoutedEventArgs e)
        {
           Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string s = Clipboard.GetText();
            string sql = $"SELECT address, cost, comment, floor, number_of_rooms, area,image FROM real_estate INNER JOIN users INNER JOIN buyer where User_id={s}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SellApartments sellApartments = new SellApartments();
                sellApartments.save.Visibility = Visibility.Visible;
                sellApartments.SellBut.Visibility = Visibility.Hidden;
                sellApartments.WriteStreet.Text = reader["address"].ToString();
                sellApartments.WriteCost.Text = reader["cost"].ToString();
                sellApartments.WriteComment.Text = reader["comment"].ToString();
                sellApartments.WriteFloor.Text = reader["floor"].ToString();
                sellApartments.WriteRoomsCount.Text = reader["number_of_rooms"].ToString();
                sellApartments.WriteSquare.Text = reader["area"].ToString();
                try
                {
                    sellApartments.image1.Source = BitmapFrame.Create(new Uri(reader["image"].ToString(), UriKind.RelativeOrAbsolute));
                }
                catch
                {

                }

                sellApartments.Show();
                this.Close();
            }

           


        }
    }
}
