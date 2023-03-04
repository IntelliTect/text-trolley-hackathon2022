
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
    [Route("api/ShoppingList")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ShoppingListController
        : BaseApiController<IntelliTect.TextTrolley.Data.Models.ShoppingList, ShoppingListDtoGen, IntelliTect.TextTrolley.Data.AppDbContext>
    {
        public ShoppingListController(IntelliTect.TextTrolley.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<IntelliTect.TextTrolley.Data.Models.ShoppingList>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ShoppingListDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ShoppingList> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ShoppingListDtoGen>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ShoppingList> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ShoppingList> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ShoppingListDtoGen>> Save(
            [FromForm] ShoppingListDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ShoppingList> dataSource,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ShoppingList> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ShoppingListDtoGen>> Delete(
            int id,
            IBehaviors<IntelliTect.TextTrolley.Data.Models.ShoppingList> behaviors,
            IDataSource<IntelliTect.TextTrolley.Data.Models.ShoppingList> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
