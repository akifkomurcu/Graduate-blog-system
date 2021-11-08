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

namespace mvvm1.Pages
{


    public class LoginBase : ComponentBase
    {
        [Parameter]
        public string tut { get; set; }

        static string connectionString = "Data Source=(localdb)\\akifzsche; database=akifzsche;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select * from kullanıcılar";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dsps = new DataSet();

        public List<PersonModel> people = new List<PersonModel>();
        public string error { get; set; }
        public string loginerror { get; set; }

        [Parameter]
        public string localtut { get; set; }
        [Inject]
        public ProtectedLocalStorage localStorage { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        public LoginData LoginData { get; set; }

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
                           pm.password = dsps.Tables[0].Rows[i]["password"].ToString();
                           pm.aktiff = dsps.Tables[0].Rows[i]["aktif"].ToString();

                           people.Add(pm);
                       }

                   }
                   catch (Exception ex)
                   {
                       error = ex.ToString();

                   }
               });
        }

        public LoginBase()
        {
            //
            LoginData = new LoginData();
        }

        public string resultCookieValue { get; set; } = "";

        protected async Task WriteCookies(string cookiekey, string cookievalue)
        {
            await localStorage.SetAsync(cookiekey, cookievalue);
            localtut = cookievalue;
        }
        protected async Task ReadCookies(string cookiekey)
        {
            var Value = await localStorage.GetAsync<string>(cookiekey);
            resultCookieValue = Value.Success ? Value.Value : "";
        }

        public async void OnValidSubmit()
        {
            //Console.WriteLine(LoginData.UserID);
            //tut = LoginData.UserID;
            await WriteCookies("userid", LoginData.UserID);
            foreach (var p in people)
            {
                if (@p.mail == LoginData.UserID && @p.password == LoginData.Password && @p.aktiff == "yes")
                    Navigation.NavigateTo("/sohbet", false);
                else
                if (@p.aktiff == "no")
                    loginerror = "Hesabınız aktif edilmemiş";
                else
                {
                    loginerror = "kullanıcı adı veya şifre yanlış";
                }


            }

        }

        public void OnInvalidSubmit()
        {
            //
        }



    }
}
