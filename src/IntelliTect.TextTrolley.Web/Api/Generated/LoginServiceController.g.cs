
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using IntelliTect.TextTrolley.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Web.Api
{
    [Route("api/LoginService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class LoginServiceController : Controller
    {
        protected IntelliTect.TextTrolley.Data.Services.ILoginService Service { get; }

        public LoginServiceController(IntelliTect.TextTrolley.Data.Services.ILoginService service)
        {
            Service = service;
        }

        /// <summary>
        /// Method: LoginUser
        /// </summary>
        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public virtual async Task<ItemResult> LoginUser(
            [FromServices] IntelliTect.TextTrolley.Data.AppDbContext db,
            [FromForm(Name = "email")] string email,
            [FromForm(Name = "password")] string password)
        {
            var _methodResult = await Service.LoginUser(db, email, password);
            var _result = new ItemResult(_methodResult);
            return _result;
        }

        /// <summary>
        /// Method: RegisterUser
        /// </summary>
        [HttpPost("RegisterUser")]
        [AllowAnonymous]
        public virtual async Task<ItemResult> RegisterUser(
            [FromServices] IntelliTect.TextTrolley.Data.AppDbContext db,
            [FromForm(Name = "firstName")] string firstName,
            [FromForm(Name = "lastName")] string lastName,
            [FromForm(Name = "email")] string email,
            [FromForm(Name = "password")] string password,
            [FromForm(Name = "phoneNumber")] string phoneNumber)
        {
            var _methodResult = await Service.RegisterUser(db, firstName, lastName, email, password, phoneNumber);
            var _result = new ItemResult(_methodResult);
            return _result;
        }
    }
}
