using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenVietCongAn
{
    public partial class Search : Form
    {
        public static string From;
        public static string To;
        public static string CabinType;
        public static string outboundDate;
        public static string returnDate;
        public static string outboundFlightNumber;
        public static string returnFlightNumber;
        public static bool twoWay;
        public static int cabinTypeId;
        public static int numberPassengers;
        public static float outboundPrice = 0;
        public static float returnPrice = 0;
        public static int outboundScheduleId;
        public static int returnScheduleId;
       

        public Search()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void Search_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["ketnoi"].ToString();
            conn = new SqlConnection(conString);
            HienthiFrom();
            HienthiTo();
            HienthiCabinTypes();
            oneway_button.Checked = true;
            
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();
            label9.Text =  bookedSeat(11).ToString();
        }
        public void HienthiFrom()
        {
            conn.Open();
            string sqlFrom = "select * from Airports";
            SqlCommand cmd = new SqlCommand(sqlFrom, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "IATACode";
            comboBox1.ValueMember = "ID";
            conn.Close();
        }
        public void HienthiTo()
        {
            conn.Open();
            string sqlTo = "select * from Airports";
            SqlCommand cmd = new SqlCommand(sqlTo, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "IATACode";
            comboBox2.ValueMember = "ID";
            conn.Close();
        }
        public void HienthiCabinTypes()
        {
            conn.Open();
            string sqlCabin = "select * from CabinTypes";
            SqlCommand cmd = new SqlCommand(sqlCabin, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            
            // Outbound flight details
            List<Schedules> list = new List<Schedules>();
            conn.Open();
            string from = comboBox1.SelectedValue.ToString();
            string to = comboBox2.SelectedValue.ToString();
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Duplicate Location","Invalid!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            string outbound_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string searchFlight = "";
            if (checkBox1.Checked)
            {
                string before = dateTimePicker1.Value.AddDays(-3).ToString("yyyy-MM-dd");
                string after = dateTimePicker2.Value.AddDays(3).ToString("yyyy-MM-dd");
                searchFlight = "select * from Schedules inner join Routes on Schedules.RouteID = Routes.ID " +
                "where Routes.DepartureAirportID = @departure_ai and Routes.ArrivalAirportID = @arrival_ai" +
                " and Date between '" + before + "' and '" + after + "'";
            }
            else
            {
                searchFlight = "select * from Schedules inner join Routes on Schedules.RouteID = Routes.ID" +
                    " where Routes.DepartureAirportID = @departure_ai and Routes.ArrivalAirportID = @arrival_ai" +
                    " and Date = '" + outbound_date + "'";
            }
            SqlCommand cmd = new SqlCommand(searchFlight, conn);
            cmd.Parameters.AddWithValue("departure_ai", from);
            cmd.Parameters.AddWithValue("arrival_ai", to);


            SqlDataReader outbound_dr = cmd.ExecuteReader();
            DataTable outbound_dt = new DataTable();
            outbound_dt.Columns.Add("ID");
            outbound_dt.Columns.Add("From");
            outbound_dt.Columns.Add("To");
            outbound_dt.Columns.Add("Date");
            outbound_dt.Columns.Add("Time");
            outbound_dt.Columns.Add("Flight Number(s)");
            outbound_dt.Columns.Add("Cabin Price");
            outbound_dt.Columns.Add("Number of stops");

            while (outbound_dr.Read())

            {
                int departureid = int.Parse(outbound_dr["DepartureAirportID"].ToString());
                Airports departure = new Airports(departureid);

                int arrivalid = int.Parse(outbound_dr["ArrivalAirportID"].ToString());
                Airports arrival = new Airports(arrivalid);

                int routeid = int.Parse(outbound_dr["RouteID"].ToString());
                Routes route = new Routes(routeid, departure, arrival);

                int schedule_id = int.Parse(outbound_dr["ID"].ToString());
                string date = String.Format("{0:d}", outbound_dr["Date"]);
                string time = outbound_dr["Time"].ToString();
                string flight_number = outbound_dr["FlightNumber"].ToString();
                float price = float.Parse(outbound_dr["EconomyPrice"].ToString());
                bool confirmed = bool.Parse(outbound_dr["Confirmed"].ToString());
                Schedules sc = new Schedules(schedule_id, date, time, flight_number, price, confirmed, route);
                list.Add(sc);
            }

            foreach (Schedules sc in list)
            {
                float price = sc.EconomyPrice;
                    
                if (comboBox3.Text == "Economy")
                {
                    price = (price)*100/100;
                }
                else if(comboBox3.Text == "Business")
                {
                    price = price * 135 / 100;
                }
                else if (comboBox3.Text == "Firstclass")
                {
                    price = (price * 135 / 100) * 130 / 100;
                }
                outbound_dt.Rows.Add(sc.ID, comboBox1.Text, comboBox2.Text, sc.Date, sc.Time, sc.FlightNumber, Convert.ToInt32(price).ToString("C0"), sc.FlightNumber);
            }
            dataGridView1.DataSource = outbound_dt;
            
            dataGridView1.Columns["ID"].Visible = false;

            // Return flight details
            if (return_button.Checked)
            {
                if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Return Day error!!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                List<Schedules> list_return = new List<Schedules>();
                string return_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string searchFlight_return = "";
                if (checkBox2.Checked)
                {
                    string before = dateTimePicker2.Value.AddDays(-3).ToString("yyyy-MM-dd");
                    string after = dateTimePicker2.Value.AddDays(3).ToString("yyyy-MM-dd");
                    searchFlight_return = "select * from Schedules inner join Routes on Schedules.RouteID = Routes.ID" +
                    " where Routes.DepartureAirportID = @departure_ai and Routes.ArrivalAirportID = @arrival_ai" +
                    " and Date between '" + before + "' and '" + after + "'";
                }
                else
                    searchFlight_return = "select * from Schedules inner join Routes on Schedules.RouteID = Routes.ID" +
                    " where Routes.DepartureAirportID = @departure_ai and Routes.ArrivalAirportID = @arrival_ai " +
                    "and Date = '" + return_date + "'";
                SqlCommand cmd_return = new SqlCommand(searchFlight_return, conn);
                cmd_return.Parameters.AddWithValue("departure_ai", to);
                cmd_return.Parameters.AddWithValue("arrival_ai", from);

                SqlDataReader return_dr = cmd_return.ExecuteReader();
                DataTable return_dt = new DataTable();
                return_dt.Columns.Add("ID");
                return_dt.Columns.Add("From");
                return_dt.Columns.Add("To");
                return_dt.Columns.Add("Date");
                return_dt.Columns.Add("Time");
                return_dt.Columns.Add("Flight Number(s)");
                return_dt.Columns.Add("Cabin Price");
                return_dt.Columns.Add("Number of stops");

                while (return_dr.Read())
                {
                    int departureid = int.Parse(return_dr["DepartureAirportID"].ToString());
                    Airports departure = new Airports(departureid);

                    int arrivalid = int.Parse(return_dr["ArrivalAirportID"].ToString());
                    Airports arrival = new Airports(arrivalid);

                    int routeid = int.Parse(return_dr["RouteID"].ToString());
                    Routes route = new Routes(routeid, departure, arrival);

                    int schedule_id = int.Parse(return_dr["ID"].ToString());
                    string date = String.Format("{0:d}", return_dr["Date"]);
                    string time = return_dr["Time"].ToString();
                    string flight_number = return_dr["FlightNumber"].ToString();
                    float price = float.Parse(return_dr["EconomyPrice"].ToString());
                    bool confirmed = bool.Parse(return_dr["Confirmed"].ToString());
                    Schedules schedule = new Schedules(schedule_id, date, time, flight_number, price, confirmed, route);
                    list_return.Add(schedule);
                }
                //tính tiền
                foreach (Schedules sc in list_return)
                {
                    float price = sc.EconomyPrice;
                    if (comboBox3.Text == "Economy")
                    {
                        price = (price) * 100 / 100;
                    }
                    else if (comboBox3.Text == "Business")
                    {
                        price = price * 135 / 100;
                    }
                    else if (comboBox3.Text == "Firstclass")
                    {
                        price = (price * 135 / 100) * 130 / 100;
                    }
                return_dt.Rows.Add(sc.ID, comboBox1.Text, comboBox2.Text, sc.Date, sc.Time, sc.FlightNumber, Convert.ToInt32(price).ToString("C0"), sc.FlightNumber);
                }

                dataGridView2.DataSource = return_dt;
                dataGridView2.Columns["ID"].Visible = false;

            }
            conn.Close();
         }

        private void oneway_button_CheckedChanged(object sender, EventArgs e)
        {
            if (oneway_button.Checked)
            {
                dateTimePicker2.Enabled = false;
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
            }
            else
                dataGridView1.Enabled = true;
        }

        private void return_button_CheckedChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
            
            dataGridView2.Enabled = true;
            dateTimePicker2.Enabled = true;
        }
        public int bookedSeat(int scheduleId)
        {
            conn.Open();
            int booked = 0;
            string sqlcount = "Select count(*) from Tickets where ScheduleID=@scheduleId" +
                " and CabinTypeID=@cabinTypeID";
            SqlCommand cmd = new SqlCommand(sqlcount, conn);
            cmd.Parameters.AddWithValue("scheduleId", scheduleId);
            cmd.Parameters.AddWithValue("cabinTypeID", comboBox3.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                booked = int.Parse(dr[0].ToString());
            }
            conn.Close();
            return booked;
        }
        private List<Aircrafts> searchAircarfts(int scheduleId)
        {
            List<Aircrafts> listAircrafts = new List<Aircrafts>();
            conn.Open();
            string query = "select * from Aircrafts inner join Schedules on Aircrafts.ID=Schedules.AircraftID " +
                "where Schedules.ID=@scheduleId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("scheduleId", scheduleId);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int id = int.Parse(dr["ID"].ToString());
                string name = dr["Name"].ToString();
                string makeModel = dr["MakeModel"].ToString();
                int total = int.Parse(dr["TotalSeats"].ToString());
                int economySeat = int.Parse(dr["EconomySeats"].ToString());
                int businessSeats = int.Parse(dr["BusinessSeats"].ToString());
                Aircrafts aircrafts = new Aircrafts(id, name, makeModel, total, economySeat, businessSeats);
                listAircrafts.Add(aircrafts);
            }
            conn.Close();
            return listAircrafts;
        }

        private void Booking_Flight_Click(object sender, EventArgs e)
        {
            DateTime departDay = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString());
            DateTime returnDay;
            if (return_button.Checked)
            {
                returnDay = DateTime.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString());
            }

            if (passenger.Text == "")
                MessageBox.Show("Please type number of passenger", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (int.Parse(passenger.Text) < 1)
                MessageBox.Show("Number of passenger invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else 
            {

                int seatOutbound = bookedSeat(outboundScheduleId);
                int seatReturn = bookedSeat(returnScheduleId);
                int EmptySeatOutbound = 0;
                int EmptySeatReturn = 0;
                
              
                numberPassengers = int.Parse(passenger.Text);
                From = comboBox1.Text;
                To = comboBox2.Text;
                CabinType = comboBox3.Text;
                cabinTypeId = int.Parse(comboBox3.SelectedValue.ToString());

                outboundDate = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                outboundFlightNumber = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                outboundPrice = float.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString().Replace("$", string.Empty));
                outboundScheduleId = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                List<Aircrafts> list = searchAircarfts(outboundScheduleId);
                
                Aircrafts air = new Aircrafts();
                if (cabinTypeId == 1)
                {
                    EmptySeatOutbound = list[0].EconomySeats - seatOutbound;
                }
                else if (cabinTypeId == 2)
                {
                    EmptySeatOutbound = list[0].BusinessSeats - seatOutbound;
                }
                else
                {
                    EmptySeatOutbound = list[0].TotalSeats - list[0].BusinessSeats - list[0].EconomySeats;
                }

                if (return_button.Checked)
                {
                    returnDate = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    returnFlightNumber = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    twoWay = true;
                    returnPrice = float.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[6].Value.ToString().Replace("$", string.Empty));
                    returnScheduleId = int.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    List<Aircrafts> listAircraftsReturn = searchAircarfts(returnScheduleId);
                    if (cabinTypeId == 1)
                    {
                        EmptySeatReturn = listAircraftsReturn[0].EconomySeats - seatReturn;
                    }
                    else if (cabinTypeId == 2)
                    {
                        EmptySeatReturn = listAircraftsReturn[0].BusinessSeats - seatReturn;
                    }
                    else
                    {
                        EmptySeatReturn = listAircraftsReturn[0].TotalSeats - list[0].BusinessSeats - list[0].EconomySeats;
                    }
                }
                if (numberPassengers > EmptySeatOutbound)
                {
                    MessageBox.Show("Not enough seat outbound" + list.Count, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (return_button.Checked == true && numberPassengers > EmptySeatReturn)
                {
                    MessageBox.Show("Not enough seat return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BookingComfirmation booking = new BookingComfirmation();
                    booking.ShowDialog();
                }
               
            }
            conn.Close();
        }
        
    }
}
