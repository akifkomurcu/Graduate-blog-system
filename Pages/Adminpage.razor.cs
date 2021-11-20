using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;

namespace mvvm1.Pages
{

    public class AdminpageBase : ComponentBase
    {
        static string connectionString = "Data Source=(localdb)\\akifzsche; database=smyodb;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select Id,konu,mesaj,veritut from post";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        public DataSet dsps = new DataSet();
        public List<PersonModel> people = new List<PersonModel>();

        protected override async Task OnInitializedAsync()
        {
            //if(UserID=="akif@gmail.com")

            people.Clear();
            await selectproc();

            peoplea.Clear();
            await selectproca();

            peopleb.Clear();
            await selectprocb();
        }
        public async Task sil(string jj)
        {
            foreach (DataRow row in dsps.Tables[0].Rows)
            {
                if (row["Id"].ToString() == jj)
                    row.Delete();
            }
            daps.Update(dsps, "people");
            cb.Dispose();
            dsps.Tables["people"].Clear();
            await OnInitializedAsync();
        }

        public Task selectproc()
        {
            return Task.Run(() =>
               {

                   try
                   {
                       daps.Fill(dsps, "people");
                       error += dsps.Tables[0].Rows.Count.ToString();
                       for (int i = 0; i < dsps.Tables[0].Rows.Count; i++)
                       {
                           PersonModel pm = new PersonModel();
                           pm.Id = dsps.Tables[0].Rows[i]["Id"].ToString();
                           pm.konu = dsps.Tables[0].Rows[i]["konu"].ToString();
                           pm.Mesaj = dsps.Tables[0].Rows[i]["mesaj"].ToString();
                           pm.veritutiki = dsps.Tables[0].Rows[i]["veritut"].ToString();

                           people.Add(pm);
                       }

                   }
                   catch (Exception ex)
                   {
                       error = ex.ToString();

                   }
               });
        }



        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS





        static string sqll = "select Id,konu,mesaj,veritut from arpost";
        static SqlDataAdapter dapss = new SqlDataAdapter(sqll, conn);
        SqlCommandBuilder cbb = new SqlCommandBuilder(dapss);
        DataSet dspss = new DataSet();

        public List<PersonModel> peoplea = new List<PersonModel>();

        public async Task InsertData(string jja, string jjb, string jjc)
        {

            //SOHBETE VERİYİ GÖNDERİR
            dspss.Tables[0].Rows.Add(null, jjb, jjc, jja);
            dapss.Update(dspss, "peoplea");
            dspss.Tables["peoplea"].Clear();

            //EKLENDİKTEN SONRA SİLİNİR

            foreach (DataRow row in dsps.Tables[0].Rows)
            {
                if (row["Id"].ToString() == jj)
                    row.Delete();
            }
            daps.Update(dsps, "people");
            cb.Dispose();
            dsps.Tables["people"].Clear();
            await OnInitializedAsync();
        }
        public Task selectproca()
        {
            return Task.Run(() =>
               {

                   try
                   {
                       dapss.Fill(dspss, "peoplea");
                       errora += dspss.Tables[0].Rows.Count.ToString();
                       for (int i = 0; i < dspss.Tables[0].Rows.Count; i++)
                       {
                           PersonModel pmm = new PersonModel();
                           pmm.Ida = dspss.Tables[0].Rows[i]["Id"].ToString();
                           pmm.konua = dspss.Tables[0].Rows[i]["konu"].ToString();
                           pmm.Mesaja = dspss.Tables[0].Rows[i]["mesaj"].ToString();
                           pmm.veritutikia = dspss.Tables[0].Rows[i]["veritut"].ToString();

                           peoplea.Add(pmm);
                       }

                   }
                   catch (Exception ex1)
                   {
                       errora = ex1.ToString();

                   }
               });
        }







        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS




        static string sqlll = "select Id,mail,aktif from kullanıcılar";
        static SqlDataAdapter dapsss = new SqlDataAdapter(sqlll, conn);
        SqlCommandBuilder cbbb = new SqlCommandBuilder(dapsss);
        DataSet dspsss = new DataSet();

        public List<PersonModel> peopleb = new List<PersonModel>();
        public async Task aktifet(string cc, string cca)
        {
            Console.WriteLine(cc);
            DataRowCollection itemColumns = dspsss.Tables[0].Rows;
            for (int i = 0; i < dspsss.Tables[0].Rows.Count; i++)
            {
                if (dspsss.Tables[0].Rows[i]["Id"].ToString() == cc)
                    dspsss.Tables[0].Rows[i]["aktif"] = aktifverisi;
            }
            dapsss.Update(dspsss, "peopleb");
            cbbb.Dispose();
            dspsss.Tables["peopleb"].Clear();
            await OnInitializedAsync();
        }
        public Task selectprocb()
        {
            return Task.Run(() =>
               {

                   try
                   {
                       dapsss.Fill(dspsss, "peopleb");
                       error += dspsss.Tables[0].Rows.Count.ToString();
                       for (int i = 0; i < dspsss.Tables[0].Rows.Count; i++)
                       {
                           PersonModel pmmm = new PersonModel();

                           pmmm.Idb = dspsss.Tables[0].Rows[i]["Id"].ToString();
                           pmmm.email = dspsss.Tables[0].Rows[i]["mail"].ToString();
                           pmmm.akt = dspsss.Tables[0].Rows[i]["aktif"].ToString();

                           peopleb.Add(pmmm);
                       }

                   }
                   catch (Exception ex2)
                   {
                       error = ex2.ToString();

                   }
               });
        }

        public void UpdateName(ChangeEventArgs e)
        {
            aktifverisi = e.Value as string;
        }




        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS




        public string aktifverisi { get; set; }
        public string error { get; set; }
        public string errora { get; set; }
        public string jj { get; set; }
        public string jja { get; set; }
        public string jjb { get; set; }
        public string jjc { get; set; }
        public string cc { get; set; }
        public string cca { get; set; }
        public string mesajtut { get; set; }
        public string konutut { get; set; }
        public string veriyitut { get; set; }
        public string idtut { get; set; }


    }


}