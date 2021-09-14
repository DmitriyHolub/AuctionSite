using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace CurrencyHelper
{
    class Program
    {
        static void Main(string[] args)
        {

            const string pathCurrencyAPI = "https://www.nbrb.by/api/exrates/rates";

            var neededIdCurrencies = new List<int>() { 431, 451, 456 };

            var currencies = new List<ResponseCurrency>();

            foreach (var id in neededIdCurrencies)
            {
                var request = HttpWebRequest.Create($"{pathCurrencyAPI}/{id}");
                var response = request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var responseCurrency = reader.ReadToEnd();
                        var data = JsonSerializer.Deserialize<ResponseCurrency>(responseCurrency);

                        currencies.Add(data);
                    }
                }
            }
            Console.Read();
        }
    }
}
