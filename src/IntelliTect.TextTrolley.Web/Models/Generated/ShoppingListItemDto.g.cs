using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.TextTrolley.Web.Models
{
    public partial class ShoppingListItemDtoGen : GeneratedDto<IntelliTect.TextTrolley.Data.Models.ShoppingListItem>
    {
        public ShoppingListItemDtoGen() { }

        private int? _ShoppingListItemId;
        private string _Name;
        private int? _ShoppingListId;
        private bool? _Purchased;

        public int? ShoppingListItemId
        {
            get => _ShoppingListItemId;
            set { _ShoppingListItemId = value; Changed(nameof(ShoppingListItemId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public int? ShoppingListId
        {
            get => _ShoppingListId;
            set { _ShoppingListId = value; Changed(nameof(ShoppingListId)); }
        }
        public bool? Purchased
        {
            get => _Purchased;
            set { _Purchased = value; Changed(nameof(Purchased)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.TextTrolley.Data.Models.ShoppingListItem obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ShoppingListItemId = obj.ShoppingListItemId;
            this.Name = obj.Name;
            this.ShoppingListId = obj.ShoppingListId;
            this.Purchased = obj.Purchased;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.TextTrolley.Data.Models.ShoppingListItem entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ShoppingListItemId))) entity.ShoppingListItemId = (ShoppingListItemId ?? entity.ShoppingListItemId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(ShoppingListId))) entity.ShoppingListId = (ShoppingListId ?? entity.ShoppingListId);
            if (ShouldMapTo(nameof(Purchased))) entity.Purchased = (Purchased ?? entity.Purchased);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.ShoppingListItem MapToNew(IMappingContext context)
        {
            var entity = new IntelliTect.TextTrolley.Data.Models.ShoppingListItem();
            MapTo(entity, context);
            return entity;
        }
    }
}
