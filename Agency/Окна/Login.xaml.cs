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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordIN.Visibility == Visibility.Visible)
            {
                PasswordIN1.Text = PasswordIN.Password;
                PasswordIN.Visibility = Visibility.Hidden;
                PasswordIN1.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordIN.Password = PasswordIN1.Text;
                PasswordIN.Visibility = Visibility.Visible;
                PasswordIN1.Visibility = Visibility.Hidden;
            }
        }

        private void AuthorizationButt_Click(object sender, RoutedEventArgs e)
        {

           // string stri = "";
            string stri1 = "";
            try
            {
                //stri = PasswordIN1.Text;
                stri1 = PasswordIN.Password;
            }
            catch
            {
                //MessageBox.Show("Поле пароль или логин пустое");
                stri1 = PasswordIN1.Text;
            }
            if (stri1 == "")
            {
                stri1 = PasswordIN1.Text;
            }


            int i = 0;
            if (LoginIN.Text != "" || PasswordIN.Password != "")
            {
                string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "select * from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //Clipboard.Clear();
                while (reader.Read())
                {

                    if ((reader["Email"].ToString() == LoginIN.Text) && (reader["Password"].ToString() == stri1))
                    {
                        i = i + 1;
                       
                        System.Windows.Clipboard.SetText(reader["User_id"].ToString());
                        if (reader["Role_ID"].ToString() == "1")
                        {
                            MainMenu GoToMenu = new MainMenu();
                            GoToMenu.Show();
                            this.Close();
                            break;
                        }
                        if (reader["Role_ID"].ToString() == "3")
                        {
                            lawyer GoToMenu = new lawyer();
                            GoToMenu.Show();
                            this.Close();
                            break;
                        }
                        else
                        {
                            MySqlConnection conn0 = new MySqlConnection(connstring);
                            conn0.ConnectionString = connstring;


                            conn0.Open();
                            //string c = CHouseStatus.Text;
                            string n = "";
                            string b = Clipboard.GetText();
                            string sql0 = $"select * from seller INNER JOIN purchase_and_sale_agreement where user_id={b}";
                            //MessageBox.Show("_"  + "_");
                            MySqlCommand cmd0 = new MySqlCommand(sql0, conn0);
                            MySqlDataReader reader0 = cmd0.ExecuteReader();
                            while (reader0.Read())
                            {
                                n = reader0["real_estate_id"].ToString();
                            }
                            conn.Close();
                            conn0.Close();
                            if (n == "")
                            {
                                SellApartments GoToMenu = new SellApartments();
                                GoToMenu.Show();
                                this.Close();
                                break;
                            }
                            else
                            {
                               
                                UserCabinet userCabinet = new UserCabinet();
                               userCabinet.red.Visibility = Visibility.Visible;
                                userCabinet.Show();
                                this.Close();
                                break;
                                
                            }
                        }
                    }
                    else
                    {
                        
                    }

                }

                conn.Close();


            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения");
            }
            if ((LoginIN.Text != "" || PasswordIN.Password != "") && i == 0)
            {
                MessageBox.Show("Не правильная почта или пароль");
            }
        }
        
        private void GoToRegistr(object sender, RoutedEventArgs e)
        {
            UserRegistration GoToRegistration = new UserRegistration();
            GoToRegistration.Show();
            this.Close();
        }

        private void GuestButt_Click(object sender, RoutedEventArgs e)
        {
            MainMenu GoToRegistration = new MainMenu();
            GoToRegistration.Show();
            this.Close();
        }

       
    }
}
