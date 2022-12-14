using MySql.Data.MySqlClient;
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

namespace Agency.Окна
{
    /// <summary>
    /// Логика взаимодействия для UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistration()
        {
            InitializeComponent();
            this.SurnameR.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.NameR.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.PatronymicR.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.NumberR.PreviewTextInput += new TextCompositionEventHandler(textBox1_PreviewTextInput);
            
        }

        public void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void GoLikeAuthorizUserTomenu(object sender, RoutedEventArgs e)
        {
            int rol=0;

            string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.ConnectionString = connstring;
            conn.Open();
            string sql2 = "select * from users";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            //Clipboard.Clear();
            
                


                    if (SurnameR.Text != "" && NameR.Text != "" && PatronymicR.Text != "" && NumberR.Text != "" && EmailR.Text != "" && BirthdayR.SelectedDate != null && PasswordR.Text != "" && SecondPasswordR.Text != ""&&(rad1.IsChecked == true||rad2.IsChecked==true))
            {
                int i = 0;


                while (reader2.Read())
                {
                    if (reader2["Email"].ToString() == EmailR.Text)
                    {
                        prov.Content = "Пользователь с такой почтой уже есть";
                        i = 1;
                    }

                }
                conn.Close();


                if (PasswordR.Text != SecondPasswordR.Text)
                {
                    prov.Content = "Пароли не совпадают";
                    i += 1;
                }
                
                
                try
                {
                    string[] mas = EmailR.Text.Split('@'); //    @GMAIL.COM 
                    if ((mas[1] != "gmail.com" && mas[1] != "mail.ru" && mas[1]!="yandex.ru") || EmailR.Text.Any(wordByte => wordByte > 127) || (mas[0] == "" && mas[3] != ""))
                    {
                        prov.Content = "Неверный формат почты";
                        i += 1;

                    }
                  
                }
                catch
                {
                    prov.Content = "Неверный формат почты";
                  
                }
                if (NumberR.Text.Length != 11)
                {
                    prov.Content = "Неверный номер телефона";
                    i += 1;
                }
               

                

                if (i==0)
                {


                    if (rad1.IsChecked == true)
                    {
                        rol = 2;
                        conn.Open();
                        string query = "INSERT INTO `users` (`Surname`, `Name`, `Patronymic`, `Birthday`, `Phone`, `Password`, `Role_ID`, `Email`) VALUES ('" + SurnameR.Text + "','" + NameR.Text + "','" + PatronymicR.Text + "', '" + BirthdayR.Text + "','" + NumberR.Text + "','" + PasswordR.Text + "','" + rol + "','" + EmailR.Text + "');";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int value = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (rad2.IsChecked == true)
                    {
                        rol = 1;
                        conn.Open();
                        string query = "INSERT INTO `users` (`Surname`, `Name`, `Patronymic`, `Birthday`, `Phone`, `Password`, `Role_ID`, `Email`) VALUES ('" + SurnameR.Text + "','" + NameR.Text + "','" + PatronymicR.Text + "', '" + BirthdayR.Text + "','" + NumberR.Text + "','" + PasswordR.Text + "','" + rol + "','" + EmailR.Text + "');";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int value = cmd.ExecuteNonQuery();
                        conn.Close();
                       
                    }
                    prov.Content = "";

                    string id="";


                conn.ConnectionString = connstring;
                conn.Open();
                string sql1 = "select * from users";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                        id = reader["User_id"].ToString();
                }
                    conn.Close();
                    //int RoleID = 1;
                    conn.Open();
                   
                    if (rad1.IsChecked == true)
                    {
                        string query = "INSERT INTO `seller` (`user_id`) VALUES ('" + id + "');";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int value = cmd.ExecuteNonQuery();
                        conn.Close();
                        Login sellApartments = new Login();
                        sellApartments.Show();
                        this.Close();
                    }
                    if (rad2.IsChecked == true)
                    {
                        string query = "INSERT INTO `buyer` (`users_Id`) VALUES ('" + id + "');";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int value = cmd.ExecuteNonQuery();
                        conn.Close();
                        Login GoToMenu = new Login();
                        GoToMenu.Show();
                        this.Close();
                    }

                }
               

            }
            else
            {

                MessageBox.Show("Все поля обязательны для заполнения");

            }
        }
        private void GoBackToAuthorizMenu(object sender, RoutedEventArgs e)
        {
            Login GoToLogin = new Login();
            GoToLogin.Show();
            this.Close();
        }

        private void rad1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rad2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

