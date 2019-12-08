using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Contoh1_Console_
{
    class Program
    {
        static void Main(string[] args)
        {
            string nim, nama, noHp;
            SqlConnection conn = new SqlConnection("Server = localhost; Data Source = localhost; Database = BPagi4; Integrated Security = SSPI");
            conn.Open();

            Console.Write("NIM = ");
            nim = Console.ReadLine();
            Console.Write("Nama = ");
            nama = Console.ReadLine();
            Console.Write("No HP = ");
            noHp = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("Insert into Table_Mhs values('{0}','{1}','{2}')",nim, nama, noHp);
            cmd.Connection = conn;
            int eksekusi = cmd.ExecuteNonQuery();

            Console.WriteLine("{0} data berhasil di simpan", eksekusi);
            Console.ReadKey();
        }
    }
}
