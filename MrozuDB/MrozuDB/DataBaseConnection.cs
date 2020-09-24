using MrozuDB.Model;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MrozuDB
{
    public static class DataBaseConnection
    {
        public static async Task<string> GetDetails(string url,string key,string value)
        {
            WebClient webClient = new WebClient();
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(key,value);

            byte[] response = await webClient.UploadValuesTaskAsync(url, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }

        public static async Task<string> GetList(string url)
        {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetStringAsync(url);

            return data;
        }
    }
}
