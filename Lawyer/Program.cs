using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawyerOffice.Contracts;
using LawyerOffice.Implementation;
using LawyerOffice.Service;
using LawyerOffice.Utility;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using AreaGeografica.Models;

namespace LawyerOffice
{
    internal class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            /*
            Lawyer lawyer = new Lawyer();
            var lingua = "english";
            var translatethis = lawyer.Documento = "hello";

            OfficeManager officemanager = new OfficeManager();
            officemanager.ordinaTraduzione(lingua, translatethis);
            Food bringme = new Food("Cappuccino");
            officemanager.askFood(bringme);
            officemanager.ordinaCibo(bringme, DateTime.Now);
            officemanager.ordinaTask(TASKTYPE.fiscale, DateTime.Now);*/

            #region ClientHttp

            RunAsync().GetAwaiter().GetResult();

           
        }

        static async Task<Country> GetCountryByNameAsync(string Name)
        {
            Country std = null;
            HttpResponseMessage response = await client.GetAsync($"AreaGeografica/Title?Title={Name}");
            if (response.IsSuccessStatusCode)
            {
                std = await response.Content.ReadAsAsync<Country>();
            }
            return std;
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            Country paese = await GetCountryByNameAsync("Italy");
            
            Console.WriteLine(paese.nameCountry);

        }
        #endregion ClientHttp

        public class Lawyer
        {
            public string Cibo { get; set; }
            public string Documento { get; set; }
            }
        }
}
