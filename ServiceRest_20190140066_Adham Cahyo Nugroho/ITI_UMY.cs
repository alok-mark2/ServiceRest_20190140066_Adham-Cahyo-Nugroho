using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ServiceRest_20190140066_Adham_Cahyo_Nugroho.TI_UMY;

namespace ServiceRest_20190140066_Adham_Cahyo_Nugroho
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        [DataContract]
        public class Mahasiswa
        {
            private string _nama, _nim, _prodi, _angkatan; //adalah konversi atau kesepakatan //variabel lokal
            [DataMember(Order = 1)] // mengirim data utk mengurutkan //
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }
            [DataMember(Order = 2)]
            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }
            [DataMember(Order = 3)]
            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }
            [DataMember(Order = 4)]
            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }
        }

        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface ITI_UMY
        {
            [OperationContract]
            [WebGet(UriTemplate = "Mahasiswa", ResponseFormat = WebMessageFormat.Json)] //utk membuat slash, selalu relative
            List<Mahasiswa> GetAllMahasiswa(); //mendapatkan kumpulan mahasiswa/seluruh datamahasiswa

            [OperationContract] /*nama method*/
            [WebGet(UriTemplate = "Mahasiswa/nim={nim}", ResponseFormat = WebMessageFormat.Json)] //untuk get
            Mahasiswa GetMahasiswaByNIM(string nim); //mengambil data berdasarkan nim

            //void CreateMahasiswa(Mahasiswa mhs); tidak ada pengembalian atau respon

            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "Mahasiswa", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            string CreateMahasiswa(Mahasiswa mhs);

            // TODO: Add your service operations here
        }

        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "_ServiceRest_20190140066_Adham Cahyo.ContractType".
        [DataContract]
        public class CompositeType
        {
            bool boolValue = true;
            string stringValue = "Hello ";

            [DataMember]
            public bool BoolValue
            {
                get { return boolValue; }
                set { boolValue = value; }
            }

            [DataMember]
            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            throw new NotImplementedException();
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            throw new NotImplementedException();
        }

        public string CreateMahasiswa(Mahasiswa mhs)
        {
            throw new NotImplementedException();
        }
    }

    internal class WebGetAttribute : Attribute
    {
        public object ResponseFormat { get; set; }
        public string UriTemplate { get; set; }
    }

    internal class WebMessageFormat
    {
    }

    internal class WebInvokeAttribute : Attribute
    {
        public object RequestFormat;

        public string UriTemplate { get; set; }
        public string Method { get; set; }
        public object ResponseFormat { get; set; }
    }
}