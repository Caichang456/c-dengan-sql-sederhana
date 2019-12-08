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

namespace Contoh2_Form_
{
    public partial class Form1 : Form
    {
        SqlConnection koneksi;
        SqlDataAdapter da;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();

            ds = new DataSet();
            lv_data.View = View.Details;
            lv_data.Columns.Add("No", 50);
            lv_data.Columns.Add("NIM", 150, HorizontalAlignment.Center);
            lv_data.Columns.Add("Nama", 250, HorizontalAlignment.Center);
            lv_data.Columns.Add("No HP", 150, HorizontalAlignment.Center);

            koneksi = new SqlConnection("Server = localhost; Data Source = localhost; Database = BPagi4; Integrated Security = SSPI");
            koneksi.Open();

            da = new SqlDataAdapter("Select * from Table_Mhs", koneksi);
            da.Fill(ds, "Terserah");

            DataRowCollection dr = ds.Tables["Terserah"].Rows;
            for (int i = 0; i < dr.Count; i++)
            {
                lv_data.Items.Add((i + 1).ToString());
                lv_data.Items[i].SubItems.Add(dr[i][0].ToString());
                lv_data.Items[i].SubItems.Add(dr[i][1].ToString());
                lv_data.Items[i].SubItems.Add(dr[i][2].ToString());
            }

            Form2 frm = new Form2();
            frm.Show();

        }
    }
}
