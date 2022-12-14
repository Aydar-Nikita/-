using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.IO;
using System.Configuration;

namespace Agency.Окна
{
    /// <summary>
    /// Логика взаимодействия для SellApartments.xaml
    /// </summary>
    public partial class SellApartments : Window
    {
        public SellApartments()
        {
            InitializeComponent();
            this.WriteCost.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.WriteFloor.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.WriteRoomsCount.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.WriteSquare.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);

        }
        string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        //public string RandomGenerator()
        //{
        //    var numbers = "0123456789";
        //    var random = new Random();

        //    var numberResult = new string(Enumerable.Repeat(numbers, 15).Select(s => s[random.Next(s.Length)]).ToArray());

        //    return numberResult;

        //}
        public void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void GoSellMy(object sender, RoutedEventArgs e)
        {
            
        }
        string str = "";
        //string jpg;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Выберите файл";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog1.ShowDialog() == true)
            {
                str += openFileDialog1.FileName;
                image1.Source = BitmapFrame.Create(new Uri(str, UriKind.RelativeOrAbsolute));
            }
            //MessageBox.Show(str);
            //string jpg = str.Replace("//", "////");
        }


     
        

        private void Click_GoSellMy(object sender, RoutedEventArgs e)
        {
            if (WriteStreet.Text != "" && WriteCost.Text != "" && WriteFloor.Text != "" && WriteRoomsCount.Text != "" && WriteSquare.Text != "")
            {
                string connstring = "server=localhost; uid=root; pwd=aidir102; database=real_estate_agency";
                MySqlConnection conn = new MySqlConnection(connstring);
                //var stats = "";
                
                

                string id = "";
                String result = Clipboard.GetText();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql1 = $"select * from seller where user_id={result}";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    id = reader["seller_id"].ToString();
                }
                conn.Close();
                // int seller = 1;
                
                conn.Open();
                //
                string query = "INSERT INTO `real_estate` (`address`, `cost`, `floor`, `number_of_rooms`, `comment`, `area`, `image`,`seller_id`,`status`) VALUES ('" + WriteStreet.Text + "','" + WriteCost.Text + "','" + WriteFloor.Text + "', '" + WriteRoomsCount.Text  + "','" + WriteComment.Text +  "','" + WriteSquare.Text + "','" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(str) + "','" + id +"','"+1+ "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int value = cmd.ExecuteNonQuery();
                conn.Close();
                //MainMenu GoToMenu = new MainMenu();
                //GoToMenu.Show();
                //this.Close();
                MessageBox.Show("Объявление успешно опубликовано, когда будет совершена покупка, на ваше почту придет уведомление");
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {


            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string s2 = Clipboard.GetText();
            string m = "";
            string sql2 = $"SELECT seller_id FROM real_estate INNER JOIN users INNER JOIN buyer where User_id={s2}";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                m = reader2["seller_id"].ToString();
            }
            conn.Close();
               
                if (WriteStreet.Text != "" && WriteCost.Text != "" && WriteFloor.Text != "" && WriteRoomsCount.Text != "" && WriteSquare.Text != "")
            {
               
                
                //var stats = "";




                string id = "";
                String result = Clipboard.GetText();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql1 = $"select * from seller where user_id={result}";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    id = reader["seller_id"].ToString();
                }
                conn.Close();
                // int seller = 1;

                conn.Open();
                //

                string query = $"UPDATE `real_estate_agency`.`real_estate` SET `address` = '{WriteStreet.Text}', `cost` = '{WriteCost.Text}', `floor` = '{WriteFloor.Text}', `number_of_rooms` = '{WriteRoomsCount.Text}', `comment` = '{WriteComment.Text}', `area` = '{WriteSquare.Text}',  `image` = '{MySql.Data.MySqlClient.MySqlHelper.EscapeString(str)}'   WHERE(`seller_id` = '{m}');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int value = cmd.ExecuteNonQuery();
                conn.Close();
                //MainMenu GoToMenu = new MainMenu();
                //GoToMenu.Show();
                //this.Close();
                MessageBox.Show("Успешно");

                UserCabinet userCabinet = new UserCabinet();
                userCabinet.red.Visibility = Visibility.Visible;
                userCabinet.Show();
                this.Close();
            }
                else
            {
                MessageBox.Show("Все поля обязательны для заполнения");
            }
        }
    }
}


