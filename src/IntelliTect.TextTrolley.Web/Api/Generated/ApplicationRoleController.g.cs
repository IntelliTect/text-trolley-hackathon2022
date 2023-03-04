
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
    [Route("api/ApplicationRole")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ApplicationRoleController
        : BaseApiController<IntelliTect.TextTrolley.Data.Models.ApplicationRole, ApplicationRoleDtoGen, IntelliTect.TextTrolley.Data.AppDbContext>
    {
        public ApplicationRoleController(IntelliTect.TextTrolley.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<IntelliTect.TextTrolley.Data.Models.ApplicationRole>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationRoleDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationRole> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ApplicationRoleDtoGen>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationRole> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationRole> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationRoleDtoGen>> Save(
            [FromForm] ApplicationRoleDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationRole> dataSource,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ApplicationRole> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationRoleDtoGen>> Delete(
            int id,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ApplicationRole> behaviors,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ApplicationRole> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
