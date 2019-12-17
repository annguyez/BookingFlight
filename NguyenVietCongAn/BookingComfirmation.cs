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

namespace NguyenVietCongAn
{
    public partial class BookingComfirmation : Form
    {
        public static int numberPassengers;
        SqlConnection con;
        List<Tickets> listTicket = new List<Tickets>();
        private static List<Tickets> listPassenger;

        internal static List<Tickets> ListPassenger { get => listPassenger; set => listPassenger = value; }

        public BookingComfirmation()
        {
            InitializeComponent();
        }
        
        private void BookingComfirmation_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["ketnoi"].ToString();

            con = new SqlConnection(conString);
            con.Open();
            string sql= "select * from Countries";
            SqlCommand cmd_country = new SqlCommand(sql, con);
            SqlDataReader dr_country = cmd_country.ExecuteReader();
            DataTable dt_country = new DataTable();
            dt_country.Load(dr_country);
            pc.DataSource = dt_country;
            pc.DisplayMember = "Name";
            pc.ValueMember = "ID";
            pc.SelectedIndex = -1;
            label2.Text = Search.From;
            label4.Text = Search.To;
            label6.Text = Search.CabinType;
            label8.Text = Search.outboundDate;
            label10.Text = Search.outboundFlightNumber;
            if (Search.twoWay)
            {
                label12.Text = Search.To;
                label14.Text = Search.From;
                label16.Text = Search.CabinType;
                label18.Text = Search.returnDate;
                label20.Text = Search.returnFlightNumber;
            }
            else
            {
                label12.Hide();
                label14.Hide();
                label16.Hide();
                label18.Hide();
                label20.Hide();
            }
            con.Close();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Return to Search?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                Search search = new Search();
                search.Show();
            }
            
        }
        private void ClearText()
        {
            fn.Text = "";
            ln.Text = "";
            bd.Text = "";
            pn.Text = "";
            pc.SelectedIndex = -1;
            p.Text = "";
            fn.Focus();
        }
        private void ViewPassenger()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Lastname");
            dt.Columns.Add("Birthday");
            dt.Columns.Add("Passport number");
            dt.Columns.Add("Passport Country");
            dt.Columns.Add("Phone");
            foreach(Tickets t in listTicket)
            {
                dt.Rows.Add(t.Firstname, t.Lastname, t.Birthdate, t.Passport_number, t.Country.Name, t.Phone);
            }
            dataGridView1.DataSource = dt;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listTicket.Count >= Search.numberPassengers)
            {
                MessageBox.Show("Limited of passenger", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fn.Text == "")
                MessageBox.Show("Please enter firstname", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ln.Text == "")
                MessageBox.Show("Please enter lastname", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pn.Text == "")
                MessageBox.Show("Please enter passport number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (p.Text == "")
                MessageBox.Show("Please enter phone", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pc.SelectedIndex == -1)
                MessageBox.Show("Please enter passport country", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                
                string firstname = fn.Text;
                string lastname = ln.Text;
                string birthday = bd.Text;
                string passportNumber = pn.Text;
                Countries country = new Countries(int.Parse(pc.SelectedValue.ToString()), pc.Text);
                string phone = p.Text;
                Tickets t = new Tickets(firstname, lastname, birthday, passportNumber, country, phone);
                listTicket.Add(t);
                ViewPassenger();
                ClearText();
            }
        }

        private void comfirm_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (listTicket.Count < Search.numberPassengers)
            {
                dr = MessageBox.Show("The number of passengers is not enough, forward?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    numberPassengers = listTicket.Count;
                    ListPassenger = listTicket;
                    BillingConfirmation billingConfirmation = new BillingConfirmation();
                    billingConfirmation.ShowDialog();
                }
            }
            else
            {
                numberPassengers = listTicket.Count;
                ListPassenger = listTicket;
                BillingConfirmation billingConfirmation = new BillingConfirmation();
                billingConfirmation.ShowDialog();
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Do you want to remove passenger?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    string firstname = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    string lastname = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    string birthdate = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    string passportNumber = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    string passportCountry = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    string phone = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    for (int i = 0; i < listTicket.Count; i++)
                    {
                        if (listTicket[i].Firstname == firstname && listTicket[i].Lastname == lastname
                            && listTicket[i].Birthdate == birthdate && listTicket[i].Passport_number == passportNumber
                            && listTicket[i].Country.Name == passportCountry && listTicket[i].Phone == phone)
                            listTicket.Remove(listTicket[i]);
                    }
                    ViewPassenger();
                }
            }
            else
            {
                MessageBox.Show("Please select passenger!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
