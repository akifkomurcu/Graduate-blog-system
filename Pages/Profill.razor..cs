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
    public class ProfillBase : ComponentBase
    {
        static string connectionString = "Data Source=(localdb)\\akifzsche; database=akifzsche;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select * from arpost";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dsps = new DataSet();
        public List<PersonModel> people = new List<PersonModel>();

        protected override async Task OnInitializedAsync()
        {
            people.Clear();

            await selectproc();
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
        [Inject]
        public ProtectedLocalStorage localStorage { get; set; }
        protected async Task ReadCookies(string cookiekey)
        {
            var Value = await localStorage.GetAsync<string>(cookiekey);
            resultCookieValue = Value.Success ? Value.Value : "";
            localtut = cookiekey;

        }
        public string localtut { get; set; }
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
        public string error { get; set; }
        [Parameter]
        public string bbtut { get; set; }
        public string UserID { get; set; } = "";
        public string resultCookieValue { get; set; } = "";
        public string veritut1 { get; set; }

    }
}