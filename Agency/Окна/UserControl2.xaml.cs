using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Syncfusion.DocIO.DLS;

namespace Agency.Окна
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(stat.Text=="Новый")
            {


                string connstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            MySqlConnection conn2 = new MySqlConnection();
            conn2.ConnectionString = connstring;
            conn2.Open();
            string n = number.Text;

            string sql = $"SELECT users.Surname, users.Name, users.Patronymic,purhase_status_title, purchase_and_sale_agreement.id_purchase, Email FROM users INNER JOIN purchase_and_sale_agreement INNER JOIN buyer INNER JOIN purhase_status ON buyers_id=buyer_id and User_id=users_Id and purchase_and_sale_agreement.status=purhase_status.idpurhase_status where id_purchase={n};";
            string sql2 = $"SELECT users.Surname, users.Name, users.Patronymic,purchase_and_sale_agreement.real_estate_id, real_estate.address, real_estate.cost, real_estate.area, real_estate.number_of_rooms, Email FROM users INNER JOIN purchase_and_sale_agreement INNER JOIN seller INNER JOIN  real_estate  ON seller.seller_id=purchase_and_sale_agreement.real_estate_id and users.User_id=seller.user_id and seller.seller_id=real_estate.seller_id where id_purchase={n};";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            string fio = "";
            string dom = "";
            string room = "";
            string area = "";
            string email = "";
            string idi = "";
            while (reader.Read() && reader2.Read())
            {
                fio= reader["Surname"].ToString() + " " + reader["Name"].ToString() + " " + reader["Patronymic"].ToString();
                dom = reader2["address"].ToString();
                room = reader2["number_of_rooms"].ToString();
                area= reader2["area"].ToString();
                email= reader["Email"].ToString();
                idi = reader2["real_estate_id"].ToString();
            }
            conn.Close();
            conn2.Close();










           // var finalString = new String(stringChars);
            WordDocument document = new WordDocument();
            //Adding a new section to the document.
            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            //Set page size of the section
            section.PageSetup.PageSize = new System.Drawing.SizeF(612, 792);

            WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Times New Roman";
            style.CharacterFormat.FontSize = 14f;
            style.ParagraphFormat.BeforeSpacing = 0;
            style.ParagraphFormat.AfterSpacing = 8;
            style.ParagraphFormat.LineSpacing = 13.8f;

            style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
            style.ApplyBaseStyle("Normal");
            style.CharacterFormat.FontName = "Times New Roman";
            style.CharacterFormat.FontSize = 14f;
            style.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(46, 116, 181);
            style.ParagraphFormat.BeforeSpacing = 12;
            style.ParagraphFormat.AfterSpacing = 0;
            style.ParagraphFormat.Keep = true;
            style.ParagraphFormat.KeepFollow = true;
            //style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;

            IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
            WTextRange textRange = paragraph.AppendText("") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("ДОГОВОР КУПЛИ-ПРОДАЖИ КВАРТИРЫ") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Серийный номер договора купли-продажи: " + "85647368278") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Я " + fio + " подтверждаю что сведения, содержащиеся в договоре, достоверны и соответствуют представленным документам.") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Мне известно, что в случае представления недостоверных сведений, я несу ответственность, установленную законодательством Российской Федерации.") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("1.ПРЕДМЕТ ДОГОВОРА") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("1.1 Продавец продал, а Покупатель приобрёл в собственность квартру по улице " + dom) as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("1.2 На момент заключения настоящего договра указанная квартира принадлежит Продавцу на праве собственности, что подтверждается ____________________________________________(подпись и инициалы)") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange
            = paragraph.AppendText("1.3 Квартира, казанная в п. 1.1 настоящего договора, состоит из " + room + "(количество) жилых комнат, имеет общую площадь " + area + " кв.м") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("1.4 До подписания настоящего договора квартира осмотрена Покупателем.Недостатки или дефекты, препятствующие использованию квартиры по назначению, на момент осмотра Покупателем не обнаружены.") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("1.5. До заключения настоящего договора квартира, являющаяся его предметом, никому не отчуждена, не заложена, не обещана, в споре не состоит, в доверительное управление, в аренду, в качестве вклада в уставный капитал юридических лиц не передана, иными правами третьих лиц не обременена.") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Примечание. В соответствии со ст. 558 ГК РФ существенным условием договора продажи квартиры (части квартиры), в которой проживают лица,сохраняющие в соответствии с законом право пользования этим жилым помещением после его приобретения покупателем, является перечень таких лиц с указанием их прав на пользование продаваемой квартирой (частью квартиры). Поэтому в таких случаях необходимо включить в договор соответствующие правила.") as WTextRange;
            textRange.CharacterFormat.FontSize = 14f;

            section.AddParagraph();

            document.Save("Заявление.docx");
              
                document.Close();
            MessageBox.Show("Заявление успешно заполнено");

            /*

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                //MessageBox.Show("ok");

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("saifullin.ai@yandex.ru", "saifullin.ai");
                // кому отправляем
                string myAdress = "dewsaqy@gmail.com";  //email; //"dewsaqy@gmail.com";
                MailAddress to = new MailAddress(myAdress);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "saifullin.ai@yandex.ru-"+ myAdress;
                // текст письма
                m.Body = "Договор";
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Users\sajfu\OneDrive\Рабочий стол\Agency\Agency\bin\Debug\Заявление.docx");
                m.Attachments.Add(attachment);
                // письмо представляет код html
                // m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("saifullin.ai@yandex.ru", "aidir102");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("успешно"+" "+email);
            }
            else
            {

                MessageBox.Show("Отсетстует подключение к интернету");
            }



            */


            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                //MessageBox.Show("ok");

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("saifullin.ai@yandex.ru", "saifullin.ai");
                // кому отправляем
                string myAdress = email;
                MailAddress to = new MailAddress(myAdress);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "saifullin.ai@yandex.ru-dewsaqy@gmail.com";
                // текст письма
                m.Body = "Договор";
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"Заявление.docx");
                //System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Users\dewsa\OneDrive\Рабочий стол\proverka.docx");
                m.Attachments.Add(attachment);
                // письмо представляет код html
                // m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("saifullin.ai@yandex.ru", "aidir102");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("успешно");
            }
            else
            {

                MessageBox.Show("Отсетстует подключение к интернету");
            }




           
            MySqlConnection conn3 = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string s = number.Text;
            //MessageBox.Show("_"+s+"_");

            string sql3 = $"UPDATE `purchase_and_sale_agreement` SET `status` = '2' WHERE (`id_purchase` = '{s}')";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            int value = cmd3.ExecuteNonQuery();
            conn.Close();
            stat.Text = "Завершен";




            MySqlConnection conn4 = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            //string s = number.Text;
            //MessageBox.Show("_"+s+"_");
            MessageBox.Show(idi.ToString());
            string sql4 = $"UPDATE `real_estate` SET `status` = '2' WHERE (`seller_id` = '{idi}')";
            MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
            int value4 = cmd4.ExecuteNonQuery();
            conn.Close();
            }

            else
            {
                MessageBox.Show("Сделка уже состоялась");
            }
        }
    }
}
