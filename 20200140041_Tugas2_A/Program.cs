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

                SqlCommand cm = new SqlCommand("create table Penyewa (id_penyewa int not null primary key, " +
                    "nama_penyewa varchar(30) not null, alamat varchar(100), notelp_penyewa char(12)) " +
                    "" +
                    "create table Pemilik (id_pemilik int not null primary key, nama_pemilik varchar(30), notelp_pemilik char(12)) " +
                    "" +
                    "create table Kios_mall (id_kios int primary key, id_pemilik int foreign key references Pemilik(id_pemilik), " +
                    "nama_kios varchar(30), ukuran varchar(6), harga_perbulan money)" +
                    "" +
                    "create table Transaksi (id_transaksi int primary key, id_penyewa int foreign key references Penyewa(id_penyewa), " +
                    "id_kios int foreign key references Kios_mall (id_kios), tanggal datetime, jenis_pembayaran varchar(6), bayar money, kembalian money) ", con);
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
            new Program().CreateTable();
        }
    }
}
