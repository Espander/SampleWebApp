using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SampleWebApp.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SampleWebApp.Controllers
{
    [System.Web.Http.Authorize]
    public class UserInfoController : ApiController
    {
        private readonly ApplicationDbContext m_DbContext;

        public UserInfoController()
        {
            m_DbContext = new ApplicationDbContext();
        }


        // GET: api/UserInfo
        [System.Web.Http.AllowAnonymous]
        [ResponseType(typeof(ICollection<UserInfoModel>))]
        public async Task<IHttpActionResult> GetUserInfoModels()
        {
            IList<UserInfoModel> result = await m_DbContext.UserInfoModels.ToListAsync();
            
            return Ok(result);
        }

        // GET: api/UserInfo/5
        [ResponseType(typeof(UserInfoModel))]
        public async Task<IHttpActionResult> GetUserInfoModel(int id)
        {
            UserInfoModel userInfoModel = await m_DbContext.UserInfoModels.FindAsync(id);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            return Ok(userInfoModel);
        }


        // POST: api/UserInfo
        [ResponseType(typeof(UserInfoModel))]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> PostUserInfoModel(
            [Bind(Include = "NickName,FavoriteDateTime,FavoriteNumber,FavoriteDayOfWeekId")]
        UserInfoModel userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            m_DbContext.UserInfoModels.Add(userInfoModel);

            await m_DbContext.SaveChangesAsync();


            return CreatedAtRoute("DefaultApi", new { id = userInfoModel.Id }, userInfoModel);
        }

        // DELETE: api/UserInfo/5
        [ResponseType(typeof(UserInfoModel))]
        public async Task<IHttpActionResult> DeleteUserInfoModel(int id)
        {
            UserInfoModel userInfoModel = await m_DbContext.UserInfoModels.FindAsync(id);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            m_DbContext.UserInfoModels.Remove(userInfoModel);
            await m_DbContext.SaveChangesAsync();

            return Ok(userInfoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_DbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoModelExists(int id)
        {
            return m_DbContext.UserInfoModels.Count(e => e.Id == id) > 0;
        }
    }
}