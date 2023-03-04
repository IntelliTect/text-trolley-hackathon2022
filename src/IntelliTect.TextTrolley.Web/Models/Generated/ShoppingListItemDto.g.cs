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
        private string _OriginalName;
        private IntelliTect.TextTrolley.Web.Models.ShoppingListDtoGen _ShoppingList;
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
        public string OriginalName
        {
            get => _OriginalName;
            set { _OriginalName = value; Changed(nameof(OriginalName)); }
        }
        public IntelliTect.TextTrolley.Web.Models.ShoppingListDtoGen ShoppingList
        {
            get => _ShoppingList;
            set { _ShoppingList = value; Changed(nameof(ShoppingList)); }
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
            this.OriginalName = obj.OriginalName;
            this.Purchased = obj.Purchased;
            if (tree == null || tree[nameof(this.ShoppingList)] != null)
                this.ShoppingList = obj.ShoppingList.MapToDto<IntelliTect.TextTrolley.Data.Models.ShoppingList, ShoppingListDtoGen>(context, tree?[nameof(this.ShoppingList)]);

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
            if (ShouldMapTo(nameof(OriginalName))) entity.OriginalName = OriginalName;
            if (ShouldMapTo(nameof(Purchased))) entity.Purchased = (Purchased ?? entity.Purchased);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.ShoppingListItem MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new IntelliTect.TextTrolley.Data.Models.ShoppingListItem()
            {
                Name = Name,
                OriginalName = OriginalName,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(ShoppingListItemId))) entity.ShoppingListItemId = (ShoppingListItemId ?? entity.ShoppingListItemId);
            if (ShouldMapTo(nameof(Purchased))) entity.Purchased = (Purchased ?? entity.Purchased);

            return entity;
        }
    }
}
