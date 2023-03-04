using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.TextTrolley.Web.Models
{
    public partial class ShoppingListDtoGen : GeneratedDto<IntelliTect.TextTrolley.Data.Models.ShoppingList>
    {
        public ShoppingListDtoGen() { }

        private int? _ShoppingListId;
        private string _RequesterId;
        private System.Collections.Generic.ICollection<int> _ApplicationUserIds;

        public int? ShoppingListId
        {
            get => _ShoppingListId;
            set { _ShoppingListId = value; Changed(nameof(ShoppingListId)); }
        }
        public string RequesterId
        {
            get => _RequesterId;
            set { _RequesterId = value; Changed(nameof(RequesterId)); }
        }
        public System.Collections.Generic.ICollection<int> ApplicationUserIds
        {
            get => _ApplicationUserIds;
            set { _ApplicationUserIds = value; Changed(nameof(ApplicationUserIds)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.TextTrolley.Data.Models.ShoppingList obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ShoppingListId = obj.ShoppingListId;
            this.RequesterId = obj.RequesterId;
            this.ApplicationUserIds = obj.ApplicationUserIds;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.TextTrolley.Data.Models.ShoppingList entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ShoppingListId))) entity.ShoppingListId = (ShoppingListId ?? entity.ShoppingListId);
            if (ShouldMapTo(nameof(RequesterId))) entity.RequesterId = RequesterId;
            if (ShouldMapTo(nameof(ApplicationUserIds))) entity.ApplicationUserIds = ApplicationUserIds?.ToList();
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.ShoppingList MapToNew(IMappingContext context)
        {
            var entity = new IntelliTect.TextTrolley.Data.Models.ShoppingList();
            MapTo(entity, context);
            return entity;
        }
    }
}
