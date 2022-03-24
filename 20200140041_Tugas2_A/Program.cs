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

        public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-KVHUS77\\RIDWANAM;database=Ridwan;Integrated Security = True");
                con.Open();

                SqlCommand cm = new SqlCommand("" +
                    "insert into Penyewa(id_penyewa, nama_penyewa, alamat, notelp_penyewa) values (1, 'Ira', 'Jl. Gatot Subroto', '089758631945')"
                    + "insert into Penyewa(id_penyewa, nama_penyewa, alamat, notelp_penyewa) values (2, 'Ishaq', 'Jl. Ahmad Yani', '089853638976')"
                    + "insert into Penyewa(id_penyewa, nama_penyewa, alamat, notelp_penyewa) values (3, 'Ami', 'Jl. Rahadi Oesman', '088758838945')"
                    + "insert into Penyewa(id_penyewa, nama_penyewa, alamat, notelp_penyewa) values (4, 'Yudha', 'Jl. Toronto', '089808901978')"
                    + "insert into Penyewa(id_penyewa, nama_penyewa, alamat, notelp_penyewa) values (5, 'Zymeth', 'Jl. Ottawa', '089201912973')" +
                    ""
                    + "insert into Pemilik(id_pemilik, nama_pemilik, notelp_pemilik) values (1, 'Seyas', '089878631945')"
                    + "insert into Pemilik(id_pemilik, nama_pemilik, notelp_pemilik) values (2, 'Ilma', '089853100076')"
                    + "insert into Pemilik(id_pemilik, nama_pemilik, notelp_pemilik) values (3, 'Ulquiorra', '088740820045')"
                    + "insert into Pemilik(id_pemilik, nama_pemilik, notelp_pemilik) values (4, 'Grimmjow',  '089808501077')"
                    + "insert into Pemilik(id_pemilik, nama_pemilik, notelp_pemilik) values (5, 'Anglin',  '089881992453')" +
                    ""
                    + "insert into Kios_mall(id_kios, id_pemilik, nama_kios, ukuran, harga_perbulan) values (1, 1,'Gramedia', '7 x 12', 7000000)"
                    + "insert into Kios_mall(id_kios, id_pemilik, nama_kios, ukuran, harga_perbulan) values (2, 2,'Sushienak', '6 x 5', 4000000)"
                    + "insert into Kios_mall(id_kios, id_pemilik, nama_kios, ukuran, harga_perbulan) values (3, 3,'Ramen', '8 x 4', 6000000)"
                    + "insert into Kios_mall(id_kios, id_pemilik, nama_kios, ukuran, harga_perbulan) values (4, 4,'Fashionstar', '6 x 9', 5000000)"
                    + "insert into Kios_mall(id_kios, id_pemilik, nama_kios, ukuran, harga_perbulan) values (5, 5,'Indhira', '6 x 10', 6000000)" +
                    ""
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (1, 1, 1, '2022-01-18 18:54:00.000', 'online', 7000000, 0)"
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (2, 1, 1, '2022-02-18 17:20:00.000', 'online', 7000000, 0)"
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (3, 2, 2, '2022-03-05 05:55:00.000', 'online', 4000000, 0)"
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (4, 2, 2, '2022-04-05 10:06:00.000', 'online', 4000000, 0)"
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (5, 3, 3, '2022-06-18 11:04:00.000', 'online', 6000000, 0)"
                    + "insert into Transaksi(id_transaksi, id_penyewa, id_kios, tanggal, jenis_pembayaran, bayar, kembalian) values (6, 3, 3, '2022-07-18 12:30:00.000', 'online', 6000000, 0)", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Berhasil Menambahkan Data");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal menambahkan data" + e);
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
            new Program().InsertData();
        }
    }
}
