using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        UserControl1 userControl1 = new UserControl1();

        public MainMenu()
        {
            
            InitializeComponent();
            AllInfoAboutUser.Background = new SolidColorBrush(Color.FromRgb(204, 152, 0));
            BackToAuthoriz.Background = new SolidColorBrush(Color.FromRgb(204, 152, 0));
            //SellButton.Background = new SolidColorBrush(Color.FromRgb(204, 152, 0));
            String result = Clipboard.GetText();
            //MessageBox.Show("Добро пожаловать: "+result);
            nedvi_info();

        }
        string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


        private void nedvi_info()
        {
            
           
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql = "select * from real_estate where status = 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userControl1 = new UserControl1();
                try
                {
                    userControl1.CHouseImage.Source = BitmapFrame.Create(new Uri(reader["image"].ToString(), UriKind.RelativeOrAbsolute));
                }
                catch
                {

                }
                userControl1.CHouseStreet.Content = reader["address"];
                userControl1.CHouseCost.Content = "Стоимость: "+reader["cost"]+" руб.";
                userControl1.CHouseArea.Content= reader["floor"]+" этаж";
                userControl1.description.Text = reader["comment"].ToString();
                userControl1.CCountOfRooms.Content = "Количество комнат:"+reader["number_of_rooms"];
                userControl1.CHouseStatus.Text= reader["real_estate_id"].ToString();
                Mylist.Items.Add(userControl1);
            }
        }
        private void AllInMethod()
        {
            
        }
        
        //private void SellOwnHouse(object sender, RoutedEventArgs e)
       // {
         //   SellApartments GoToSell = new SellApartments();
           // GoToSell.Show();
            //this.Close();
        //}

        private void AllInfoAboutUser_Click(object sender, RoutedEventArgs e)
        {
            UserCabinet GoToCabinet = new UserCabinet();
            GoToCabinet.Show();
        
        }

        private void BackToAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            Login GoToAuthoriz = new Login();
            GoToAuthoriz.Show();
            this.Close();
        }
        /*
        private void BuyApartmentsClick(object sender, RoutedEventArgs e)
        {
            if (Mylist.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали объявление!");
            }
            else
            {
                
                MySqlConnection conn = new MySqlConnection(connstring);
                conn.ConnectionString = connstring;
                
                string id = "";
               
                
                conn.Open();
                int c = Mylist.SelectedIndex + 4;
                string sql1 = $"select * from real_estate where real_estate_id={c}";
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
                string query = "INSERT INTO `purchase_and_sale_agreement` (`buyer_id`, `real_estate_id`, `date`) VALUES ('" + user_id + "','" + id + "','" + DateTime.Now.ToString("yyy.MM.dd") +"');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int value = cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("ожидайте");

                
            }
        }
        */
        private void SearchText(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                Mylist.Items.Clear();
               
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "select * real_estate_agency.real_estate where address like '%" + SearchBlock.Text + "%' where status = 1;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userControl1 = new UserControl1();
                    userControl1.CHouseStreet.Content = reader["address"];
                    userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                    userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                    userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                    userControl1.description.Text=reader["comment"].ToString();
                    userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                    Mylist.Items.Add(userControl1);
                }
            } 
        }

        private void Filtering(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                Mylist.Items.Clear();
               
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                if (Filter.SelectedIndex == 0)
                {
                    string sql = "select * from real_estate_agency.real_estate where status = 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Filter.SelectedIndex == 1)
                {
                    string sql = "select * from real_estate_agency.real_estate where cost between 0 and 1000000 and status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Filter.SelectedIndex == 2)
                {
                    string sql = "select * from real_estate_agency.real_estate where cost between 1000000 and 2500000 and status = 1 ;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Filter.SelectedIndex == 3)
                {
                    string sql = "select * from real_estate_agency.real_estate where cost between 2500001 and 100000000  and status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
            }
        }

        private void Sorting(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                Mylist.Items.Clear();
               
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                if (Sort.SelectedIndex == 0)
                {
                    string sql = "select * from real_estate_agency.real_estate where status = 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 1)
                {
                    string sql = "select * from real_estate_agency.real_estate order by area where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 2)
                {
                    string sql = "select * from real_estate_agency.real_estate order by area desc where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 3)
                {
                    string sql = "select * from real_estate_agency.real_estate order by number_of_rooms where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 4)
                {
                    string sql = "select * from real_estate_agency.real_estate order by number_of_rooms desc where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 5)
                {
                    string sql = "select * from real_estate_agency.real_estate order by floor desc where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text = reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
                if (Sort.SelectedIndex == 6)
                {
                    string sql = "select * from real_estate_agency.real_estate order by floor desc where status = 1;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userControl1 = new UserControl1();
                        userControl1.CHouseStreet.Content = reader["address"];
                        userControl1.CHouseCost.Content = "Стоимость: " + reader["cost"] + " руб.";
                        userControl1.description.Text=reader["comment"].ToString();
                        userControl1.CHouseArea.Content = reader["floor"] + " этаж";
                        userControl1.CCountOfRooms.Content = "Количество комнат:" + reader["number_of_rooms"];
                        userControl1.CHouseStatus.Text = reader["real_estate_id"].ToString();
                        Mylist.Items.Add(userControl1);
                    }
                }
                else
                {

                }
            }
        }

        private void GoToDeleteMenu(object sender, RoutedEventArgs e)
        {

        }
    }
}
