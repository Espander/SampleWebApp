using SampleWebApp.Models;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Http client static instance to avoid redundant sockets creation.
        /// </summary>
        private static HttpClient m_Client = new HttpClient();

        public async Task<ActionResult> Index()
        {
            UserInfoModel uiModel = new UserInfoModel();

            uiModel.DaysOfWeek = await HttpClientHelper.GetDaysOfWeek();

            return View(uiModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserInfoModel formData)
        {
            if (ModelState.IsValid)
            {

                string request = Request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + Constants.UserInfoApiAddress;
                HttpResponseMessage message = await m_Client.PostAsync(request, formData, new JsonMediaTypeFormatter());

                return RedirectToAction("Status", new { success = message.IsSuccessStatusCode });
            }

            formData.DaysOfWeek = await HttpClientHelper.GetDaysOfWeek();
            return View(formData);
        }


        public ActionResult Status()
        {
            return View();
        }

    }
}