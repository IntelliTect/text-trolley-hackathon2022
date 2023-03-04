
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
    [Route("api/Requester")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class RequesterController
        : BaseApiController<IntelliTect.TextTrolley.Data.Models.Requester, RequesterDtoGen, IntelliTect.TextTrolley.Data.AppDbContext>
    {
        public RequesterController(IntelliTect.TextTrolley.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<IntelliTect.TextTrolley.Data.Models.Requester>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<RequesterDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.Requester> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<RequesterDtoGen>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.Requester> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.Requester> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<RequesterDtoGen>> Save(
            [FromForm] RequesterDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.Requester> dataSource,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.Requester> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<RequesterDtoGen>> Delete(
            int id,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.Requester> behaviors,
            IDataSource<IntelliTect.TextTrolley.Data.Models.Requester> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
