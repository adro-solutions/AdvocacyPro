using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Models.DTO;
using System.Security.Claims;
using Newtonsoft.Json;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers.Base
{
    [Authorize]
    [ResponseCache(CacheProfileName = CacheProfiles.Never)]
    public abstract class AuthBaseController : Controller
    {
        private UserData _userData;
        public UserData UserData
        {
            get
            {
                if (_userData == null)
                {
                    string claim = ((ClaimsPrincipal)HttpContext.User).Claims.First(c => c.Type == ClaimTypes.UserData).Value;
                    _userData = JsonConvert.DeserializeObject<UserData>(claim);
                }

                return _userData;
            }
        }

        public Product Product
        {
            get
            {
                return UserData.Product;
            }
        }
        
        public int OrganizationId
        {
            get
            {
                return UserData.OrganizationId;
            }
        }

        public int UserId
        {
            get
            {
                return UserData.Id;
            }
        }
    }
}
