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

    public class AdminBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavManager { get; set; }

        static string connectionString = "Data Source=(localdb)\\akifzsche; database=smyodb;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select mail,pass from adminler";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dsps = new DataSet();

        public List<PersonModel> people = new List<PersonModel>();
        public string error { get; set; }
        public string loginerror { get; set; }
        public string adminname { get; set; }
        public string adminpass { get; set; }
        protected override async Task OnInitializedAsync()
        {
            people.Clear();
            await selectproc();

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

                           pm.mail = dsps.Tables[0].Rows[i]["mail"].ToString();
                           pm.password = dsps.Tables[0].Rows[i]["pass"].ToString();

                           people.Add(pm);
                       }

                   }
                   catch (Exception ex)
                   {
                       error = ex.ToString();

                   }
               });
        }
        public void loginadmin()
        {
            foreach (var p in people)
            {
                if (@p.mail == adminname && @p.password == adminpass)
                    NavManager.NavigateTo("/adminpage", false);
                else
                    loginerror = "kullanıcı adı veya şifre yanlış";

            }

        }





    }
}