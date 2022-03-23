using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace _20200140041_Tugas2_A
{
    class Program
    {
        public void Connecting()
        {
            using (//perubahan
                SqlConnection con = new SqlConnection("data source=DESKTOP-KVHUS77\\RIDWANAM;database=Ridwan;User ID=sa;Password=riamima")
            )
            {
                con.Open();
                Console.WriteLine("Berhasil terhubung ke database!");
            }
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-KVHUS77\\RIDWANAM;database=Ridwan;Integrated Security = True");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Mahasiswa_Coba (NIM char(12) not null primary key, " +
                    "Nama varchar(50), Alamat varchar(255), Jenis_kelamin char(1))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel suskes dibuat");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah." + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }

        static void Main(string[] args)
        {
            new Program().Connecting();
        }
    }
}
