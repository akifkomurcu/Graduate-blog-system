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
    public class SohbetBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public ProtectedLocalStorage localStorage { get; set; }


        public async Task ReadCookies(string cookiekey)
        {
            var Value = await localStorage.GetAsync<string>(cookiekey);
            resultCookieValue = Value.Success ? Value.Value : "";
            localtut = cookiekey;

        }
        static string connectionString = "Data Source=(localdb)\\akifzsche; database=smyodb;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select * from post";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dsps = new DataSet();
        public List<PersonModel> people = new List<PersonModel>();

        public async Task InsertData()
        {

            dsps.Tables[0].Rows.Add(null, konuverisi, inputName, veritut1);
            daps.Update(dsps, "people");
            dsps.Tables["people"].Clear();
            inputName = "";
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
                           pm.konua = dsps.Tables[0].Rows[i]["konu"].ToString();
                           pm.Mesaja = dsps.Tables[0].Rows[i]["mesaj"].ToString();
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

        //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        //alttaki tablo boş olabilir admin onayladıkça oraya veri gelecek

        static string sqll = "select * from arpost";
        static SqlDataAdapter dapss = new SqlDataAdapter(sqll, conn);
        SqlCommandBuilder cbb = new SqlCommandBuilder(dapss);
        DataSet dspss = new DataSet();
        public List<PersonModel> peoplea = new List<PersonModel>();




        public async Task UpdateData(string bb, string bba)
        {
            //&& UserID == "akif@gmail.com"
            if (UserID == bba)
            {
                DataRowCollection itemColumns = dspss.Tables[0].Rows;
                for (int i = 0; i < dspss.Tables[0].Rows.Count; i++)
                {
                    if (dspss.Tables[0].Rows[i]["Id"].ToString() == bb)
                        dspss.Tables[0].Rows[i]["mesaj"] = inputName;
                    inputName = "";
                }
            }
            dapss.Update(dspss, "peoplea");
            cbb.Dispose();
            dspss.Tables["peoplea"].Clear();
            await OnInitializedAsync();
        }

        public async Task DeleteData(string bb, string bba)
        {
            //&& UserID == "akif@gmail.com"
            if (UserID == bba)
            {
                foreach (DataRow row in dspss.Tables[0].Rows)
                {
                    if (row["Id"].ToString() == bb)
                        row.Delete();
                }
                dapss.Update(dspss, "peoplea");
                cbb.Dispose();
                dspss.Tables["peoplea"].Clear();
                await OnInitializedAsync();
            }

        }



        protected override async Task OnInitializedAsync()
        {
            people.Clear();
            peoplea.Clear();
            await selectproc();
            await selectproca();
            await ReadCookies("userid");
            if (resultCookieValue != null)
            {
                UserID = resultCookieValue;
                veritut1 = UserID;
            }
            else
            {
                UserID = "NULL";
            }


        }
        public async void ClearLocalStorage()
        {

            await localStorage.DeleteAsync(localtut);
            Navigation.NavigateTo("/login", false);


        }

        public Task selectproca()
        {
            return Task.Run(() =>
               {

                   try
                   {
                       dapss.Fill(dspss, "peoplea");
                       error += dspss.Tables[0].Rows.Count.ToString();
                       for (int i = 0; i < dspss.Tables[0].Rows.Count; i++)
                       {
                           PersonModel pmm = new PersonModel();
                           pmm.Id = dspss.Tables[0].Rows[i]["Id"].ToString();
                           pmm.konua = dspss.Tables[0].Rows[i]["konu"].ToString();
                           pmm.Mesaja = dspss.Tables[0].Rows[i]["mesaj"].ToString();
                           pmm.veritutiki = dspss.Tables[0].Rows[i]["veritut"].ToString();

                           peoplea.Add(pmm);
                       }

                   }
                   catch (Exception ex)
                   {
                       error = ex.ToString();

                   }
               });
        }
        public void UpdateName(ChangeEventArgs e)
        {
            konuverisi = e.Value as string;
        }

        public string konuverisi { get; set; }
        public string bb { get; set; }
        public string bba { get; set; }
        public string bbb { get; set; }
        public string bbc { get; set; }
        public string error { get; set; }
        public string veritut1 { get; set; }
        public string veritutiki { get; set; }
        public string inputId { get; set; }
        public string inputName { get; set; }
        public string localtut { get; set; }
        public string UserID { get; set; } = "";
        public string resultCookieValue { get; set; } = "";

        public string bbtut { get; set; }




    }
}
