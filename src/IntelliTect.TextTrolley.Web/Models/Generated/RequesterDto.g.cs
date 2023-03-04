using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.TextTrolley.Web.Models
{
    public partial class RequesterDtoGen : GeneratedDto<IntelliTect.TextTrolley.Data.Models.Requester>
    {
        public RequesterDtoGen() { }

        private int? _RequesterId;
        private string _RequesterName;
        private string _RequesterNumber;
        private int? _ActiveShoppingListKey;
        private IntelliTect.TextTrolley.Web.Models.ShoppingListDtoGen _ActiveShoppingList;

        public int? RequesterId
        {
            get => _RequesterId;
            set { _RequesterId = value; Changed(nameof(RequesterId)); }
        }
        public string RequesterName
        {
            get => _RequesterName;
            set { _RequesterName = value; Changed(nameof(RequesterName)); }
        }
        public string RequesterNumber
        {
            get => _RequesterNumber;
            set { _RequesterNumber = value; Changed(nameof(RequesterNumber)); }
        }
        public int? ActiveShoppingListKey
        {
            get => _ActiveShoppingListKey;
            set { _ActiveShoppingListKey = value; Changed(nameof(ActiveShoppingListKey)); }
        }
        public IntelliTect.TextTrolley.Web.Models.ShoppingListDtoGen ActiveShoppingList
        {
            get => _ActiveShoppingList;
            set { _ActiveShoppingList = value; Changed(nameof(ActiveShoppingList)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.TextTrolley.Data.Models.Requester obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.RequesterId = obj.RequesterId;
            this.RequesterName = obj.RequesterName;
            this.RequesterNumber = obj.RequesterNumber;
            this.ActiveShoppingListKey = obj.ActiveShoppingListKey;
            if (tree == null || tree[nameof(this.ActiveShoppingList)] != null)
                this.ActiveShoppingList = obj.ActiveShoppingList.MapToDto<IntelliTect.TextTrolley.Data.Models.ShoppingList, ShoppingListDtoGen>(context, tree?[nameof(this.ActiveShoppingList)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.TextTrolley.Data.Models.Requester entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(RequesterId))) entity.RequesterId = (RequesterId ?? entity.RequesterId);
            if (ShouldMapTo(nameof(RequesterName))) entity.RequesterName = RequesterName;
            if (ShouldMapTo(nameof(RequesterNumber))) entity.RequesterNumber = RequesterNumber;
            if (ShouldMapTo(nameof(ActiveShoppingListKey))) entity.ActiveShoppingListKey = (ActiveShoppingListKey ?? entity.ActiveShoppingListKey);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.Requester MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new IntelliTect.TextTrolley.Data.Models.Requester()
            {
                RequesterName = RequesterName,
                RequesterNumber = RequesterNumber,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(RequesterId))) entity.RequesterId = (RequesterId ?? entity.RequesterId);
            if (ShouldMapTo(nameof(ActiveShoppingListKey))) entity.ActiveShoppingListKey = (ActiveShoppingListKey ?? entity.ActiveShoppingListKey);

            return entity;
        }
    }
}
