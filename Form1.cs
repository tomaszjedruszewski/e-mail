using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace e_mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.richTextBox1, "Poszczególne adresy mailowe rozdziel średnikiem.");
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.textBox1, "Podaj temat wiadomości.");
            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.SetToolTip(this.textBox2, "Podaj treść wiadomości.");
            System.Windows.Forms.ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip4.SetToolTip(this.button1, "Po naciśnięciu przyciusku wiadomość zostanie wysłana.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                MailMessage wiadomosc = new MailMessage();
                wiadomosc.From = new MailAddress(textBox3.Text);
                wiadomosc.Subject = textBox1.Text;
                wiadomosc.Body = textBox2.Text;
                foreach (string mail in richTextBox1.Text.Split(';'))
                {
                    wiadomosc.To.Add(mail);
                }

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(textBox3.Text, textBox4.Text);
                client.Host = textBox5.Text;
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(wiadomosc);
                MessageBox.Show(this, "Wiadomość została wysłana", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Coś poszło nie tak jak powinno!", "BŁĄD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
 
            }
            
        }
        
    }
}
