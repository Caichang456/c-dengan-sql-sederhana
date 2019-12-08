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
    public partial class Form2 : Form
    {
        SqlConnection koneksi;
        SqlDataAdapter da;
        DataSet ds;
        public Form2()
        {

            InitializeComponent();
            ds = new DataSet();
            koneksi = new SqlConnection("Server = localhost; Data Source = localhost; Database = Northwind; Integrated Security = SSPI");
            koneksi.Open();

            da = new SqlDataAdapter("SELECT ContactName, OrderDate, Quantity, ProductName FROM Customers c INNER JOIN Orders o INNER JOIN QuantityPerUnit q INNER JOIN Products p ON c.CustomerID = o.CustomerID = q.ProductID = p.ProductID", koneksi);
            da.Fill(ds, "Terserah");


            dgv_data.ReadOnly = true;
            dgv_data.AllowUserToAddRows = false;
            dgv_data.AllowUserToDeleteRows = false;
            dgv_data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_data.DataSource = ds.Tables["Terserah"];

        }
    }
}
