
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
    [Route("api/ApplicationUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ApplicationUserController
        : BaseApiController<IntelliTect.TextTrolley.Data.Models.ApplicationUser, ApplicationUserDtoGen, IntelliTect.TextTrolley.Data.AppDbContext>
    {
        public ApplicationUserController(IntelliTect.TextTrolley.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<IntelliTect.TextTrolley.Data.Models.ApplicationUser>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ApplicationUserDtoGen>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Save(
            [FromForm] ApplicationUserDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationUser> dataSource,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ApplicationUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Delete(
            int id,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ApplicationUser> behaviors,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationUser> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
