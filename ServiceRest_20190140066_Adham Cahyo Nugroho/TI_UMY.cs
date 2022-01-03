using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ServiceRest_20190140066_Adham_Cahyo_Nugroho.TI_UMY;

namespace ServiceRest_20190140066_Adham_Cahyo_Nugroho
{
    public string CreateMahasiswa(Mahasiswa mhs)
    {
        string msg = "GAGAL";
        SqlConnection sqlcon = new SqlConnection("Data Source=E3-SENTRY;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=bariskartalii737aewc");
        string query = String.Format("insert into dbo.Mahasiswa values ('{0}', '{1}','{2}','{3}')", mhs.nama, mhs.nim, mhs.prodi, mhs.angkatan);
        //NIM = '{0}'", nim
        //string query = "insert into dbo.Mahasiswa values {'"+mhs.nama+"', '"+mhs.nim+"', '"+'"+mhs.prodi+"', '"+mhs.angkatan+"')";
        SqlCommand sqlcom = new SqlCommand(query, sqlcon); //yg dikirim ke sql

        try
        {
            sqlcon.Open();
            Console.WriteLine(query);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            msg = "Sukses";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(query);
            msg = "GAGAL";
        }
        return msg;
    }

    public List<Mahasiswa> GetAllMahasiswa()
    {
        List<Mahasiswa> mahas = new List<Mahasiswa>();

        SqlConnection con = new SqlConnection("Data Source=E3-SENTRY;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=bariskartalii737aewc");
        string query = "select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa";
        SqlCommand com = new SqlCommand(query, con); //yg dikirim ke sql

        try
        {
            con.Open();
            SqlDataReader reader = com.ExecuteReader(); //mendapatkan data yg telah dieksekusi, dari select, hasil query ditaruh di reader

            while (reader.Read())
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.nama = reader.GetString(0); //) itu array pertama // in diambil dari IService
                mhs.nim = reader.GetString(1);
                mhs.prodi = reader.GetString(2);
                mhs.angkatan = reader.GetString(3);

                mahas.Add(mhs);
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(query);
        }
        return mahas; //output      
    }

    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }
    public Mahasiswa GetMahasiswaByNIM(string nim)
    {
        Mahasiswa mhs = new Mahasiswa();
        SqlConnection con = new SqlConnection("Data Source=E3-SENTRY;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=bariskartalii737aewc");
        string query = String.Format("select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
        SqlCommand com = new SqlCommand(query, con);

        try
        {
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                mhs.nama = reader.GetString(0); //) e itu array pertama // ni diambil dar iservice
                mhs.nim = reader.GetString(1);
                mhs.prodi = reader.GetString(2);
                mhs.angkatan = reader.GetString(3);
            }
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(query);
        }
        return mhs;
    }

    internal class SqlDataReader
    {
        internal string GetString(int v)
        {
            throw new NotImplementedException();
        }

        internal bool Read()
        {
            throw new NotImplementedException();
        }
    }

    internal class SqlCommand
    {
        private string query;
        private SqlConnection con;

        public SqlCommand(string query, SqlConnection con)
        {
            this.query = query;
            this.con = con;
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }
    }

    internal class SqlConnection
    {
        private string v;

        public SqlConnection(string v)
        {
            this.v = v;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}