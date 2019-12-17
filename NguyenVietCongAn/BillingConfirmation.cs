using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace NguyenVietCongAn
{
    public partial class BillingConfirmation : Form
    {
        SqlConnection conn;
        List<Tickets> listTicket = new List<Tickets>();
        
        public BillingConfirmation()
        {
            InitializeComponent();
            
        }
        private void BillingConfirmation_Load(object sender, EventArgs e)
        {
            listTicket = BookingComfirmation.ListPassenger;
            total.Text = ((Search.outboundPrice + Search.returnPrice)*BookingComfirmation.numberPassengers).ToString("C0");
            radioButton1.Checked = true;
        }
        
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string GetBookingReference()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomNumber(10, 99));
            builder.Append(RandomString(4, false));
            return builder.ToString();
        }
        private void Issue_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["ketnoi"].ToString();
            conn = new SqlConnection(conString);
            conn.Open();
            string bookingReference = GetBookingReference();
            foreach (Tickets t in listTicket)
            {
                int user_id = 0;
                string insert_user = "insert into Users values(@roleId,@officeId,@email,@password,@firstname,@lastname,@birthday,@active)";
                SqlCommand cmdU = new SqlCommand(insert_user, conn);
                cmdU.Parameters.AddWithValue("roleId", 2);
                cmdU.Parameters.AddWithValue("officeId", 3);
                cmdU.Parameters.AddWithValue("email", "anonymous@mail.com");
                cmdU.Parameters.AddWithValue("password", "123456aA@");
                cmdU.Parameters.AddWithValue("firstname", t.Firstname);
                cmdU.Parameters.AddWithValue("lastname", t.Lastname);
                cmdU.Parameters.AddWithValue("birthday", t.Birthdate);
                cmdU.Parameters.AddWithValue("active", "True");
                cmdU.ExecuteNonQuery();

                string queryFindMaxUser = "select max(id) as 'userId' from Users";
                SqlCommand cmd = new SqlCommand(queryFindMaxUser, conn);
                SqlDataReader dr_id = cmd.ExecuteReader();
                if (dr_id.Read())
                    user_id += int.Parse(dr_id["userId"].ToString());
                string insertOutbound = 
                "insert into Tickets values(@userId,@scheduleId,@cabinTypeId,@firstname,@lastname" +
                ",@email,@phone,@passportnumber,@passportcountry,@bookingReference,@confirmed)";
                SqlCommand cmdT = new SqlCommand(insertOutbound, conn);
                cmdT.Parameters.AddWithValue("userId", user_id);
                cmdT.Parameters.AddWithValue("scheduleId", Search.outboundScheduleId);
                cmdT.Parameters.AddWithValue("cabinTypeId", Search.cabinTypeId);
                cmdT.Parameters.AddWithValue("firstname", t.Firstname);
                cmdT.Parameters.AddWithValue("lastname", t.Lastname);
                cmdT.Parameters.AddWithValue("email", "anonymous@mail.com");
                cmdT.Parameters.AddWithValue("phone", t.Phone);
                cmdT.Parameters.AddWithValue("passportnumber", t.Passport_number);
                cmdT.Parameters.AddWithValue("passportcountry", t.Country.ID);
                cmdT.Parameters.AddWithValue("bookingReference", bookingReference);
                cmdT.Parameters.AddWithValue("confirmed", "True");
                cmdT.ExecuteNonQuery();

                if (Search.twoWay)
                {
                    string insertReturn =
                        "insert into Tickets values(@userId,@scheduleId,@cabinTypeId,@firstname,@lastname" +
                ",@email,@phone,@passportnumber,@passportcountry,@bookingReference,@confirmed)";
                    SqlCommand cmdR = new SqlCommand(insertReturn, conn);
                    cmdR.Parameters.AddWithValue("userId", user_id);
                    cmdR.Parameters.AddWithValue("scheduleId", Search.outboundScheduleId);
                    cmdR.Parameters.AddWithValue("cabinTypeId", Search.cabinTypeId);
                    cmdR.Parameters.AddWithValue("firstname", t.Firstname);
                    cmdR.Parameters.AddWithValue("lastname", t.Lastname);
                    cmdR.Parameters.AddWithValue("email", "anonymous@mail.com");
                    cmdR.Parameters.AddWithValue("phone", t.Phone);
                    cmdR.Parameters.AddWithValue("passportnumber", t.Passport_number);
                    cmdR.Parameters.AddWithValue("passportcountry", t.Country.ID);
                    cmdR.Parameters.AddWithValue("bookingReference", bookingReference);
                    cmdR.Parameters.AddWithValue("confirmed", "True");
                    cmdR.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Booking completed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
