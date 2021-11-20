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
using Microsoft.AspNetCore.Components.Forms;
using System.Data;

namespace mvvm1.Pages
{
    public class PersonModel
    {

        public string Id { get; set; }
        public string Ida { get; set; }
        public string Idb { get; set; }
        public string Name { get; set; }
        public string Mesaj { get; set; }
        public string Mesaja { get; set; }
        public string konu { get; set; }
        public string konua { get; set; }
        public string studentnumber { get; set; }
        public string graduation { get; set; }
        public string graduationyear { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string veritutiki { get; set; }
        public string veritutikia { get; set; }
        public string aktiff { get; set; }
        //aktiflikte kullanılan email
        public string email { get; set; }
        //aktiflik durumunu adminpage'e yazdırırken
        public string akt { get; set; }


    }
    public class RegisterBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        public Account EntryAccount { get; set; } = new Account();
        static string connectionString = "Data Source=(localdb)\\akifzsche; database=smyodb;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select Id,Name,studentnumber,graduation,graduationyear,mail,password,aktif from kullanıcılar";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dsps = new DataSet();

        public List<PersonModel> people = new List<PersonModel>();
        public string error { get; set; }



        public string inputName { get; set; }
        public string inputstudentnumber { get; set; }
        public string inputgraduation { get; set; }
        public string inputgraduationyear { get; set; }
        public string inputmail { get; set; }
        public string inputpassword { get; set; }
        public string aktif { get; set; } = "no";



        public async Task InsertData()
        {
            inputName = @EntryAccount.AccountName;
            inputstudentnumber = @EntryAccount.AccountNumber;
            inputgraduationyear = @EntryAccount.Gradyear;
            inputmail = @EntryAccount.EMailAddress;
            inputpassword = @EntryAccount.password;
            if (inputName != null && inputstudentnumber != null && inputgraduationyear != null && inputmail != null && inputpassword != null)
            {
                dsps.Tables[0].Rows.Add(null, inputName, inputstudentnumber, inputgraduation, inputgraduationyear, inputmail, inputpassword, aktif);
                daps.Update(dsps, "people");
                dsps.Tables["people"].Clear();
                inputstudentnumber = "";
                await OnInitializedAsync();

                Navigation.NavigateTo("/login", false);
            }
        }


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
                           pm.Id = dsps.Tables[0].Rows[i]["Id"].ToString();
                           pm.Name = dsps.Tables[0].Rows[i]["Name"].ToString();


                           people.Add(pm);
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
            inputgraduation = e.Value as string;
        }

    }
}
