using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;

namespace SampleWebApp
{
    internal static class HttpClientHelper
    {
        /// <summary>
        /// Http client static instance to avoid redundant sockets creation.
        /// </summary>
        private static HttpClient m_Client = new HttpClient();


        public static async Task<ICollection<DaysOfWeek>> GetDaysOfWeek()
        {
            string requestUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + Constants.DaysOfWeekApiAddress;
            HttpResponseMessage response = await m_Client.GetAsync(requestUri);
            ICollection<DaysOfWeek> result = await response.Content.ReadAsAsync<ICollection<DaysOfWeek>>();

            return result ?? new List<DaysOfWeek>();
        }


        public static async Task<ICollection<UserInfoModel>> GetUserInfoList()
        {
            string requestUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + Constants.UserInfoApiAddress;
            HttpResponseMessage response = await m_Client.GetAsync(requestUri);
            ICollection<UserInfoModel> result = await response.Content.ReadAsAsync<ICollection<UserInfoModel>>();

           
            return result ?? new List<UserInfoModel>();
        }
    }
}