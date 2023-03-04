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
        private IntelliTect.TextTrolley.Web.Models.RequesterDtoGen _Requester;
        private System.Collections.Generic.ICollection<IntelliTect.TextTrolley.Web.Models.ApplicationUserDtoGen> _ApplicationUsers;
        private System.Collections.Generic.ICollection<IntelliTect.TextTrolley.Web.Models.ShoppingListItemDtoGen> _Items;
        private bool? _IsComplete;
        private bool? _IsDelivered;

        public int? ShoppingListId
        {
            get => _ShoppingListId;
            set { _ShoppingListId = value; Changed(nameof(ShoppingListId)); }
        }
        public IntelliTect.TextTrolley.Web.Models.RequesterDtoGen Requester
        {
            get => _Requester;
            set { _Requester = value; Changed(nameof(Requester)); }
        }
        public System.Collections.Generic.ICollection<IntelliTect.TextTrolley.Web.Models.ApplicationUserDtoGen> ApplicationUsers
        {
            get => _ApplicationUsers;
            set { _ApplicationUsers = value; Changed(nameof(ApplicationUsers)); }
        }
        public System.Collections.Generic.ICollection<IntelliTect.TextTrolley.Web.Models.ShoppingListItemDtoGen> Items
        {
            get => _Items;
            set { _Items = value; Changed(nameof(Items)); }
        }
        public bool? IsComplete
        {
            get => _IsComplete;
            set { _IsComplete = value; Changed(nameof(IsComplete)); }
        }
        public bool? IsDelivered
        {
            get => _IsDelivered;
            set { _IsDelivered = value; Changed(nameof(IsDelivered)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.TextTrolley.Data.Models.ShoppingList obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ShoppingListId = obj.ShoppingListId;
            this.IsComplete = obj.IsComplete;
            this.IsDelivered = obj.IsDelivered;
            if (tree == null || tree[nameof(this.Requester)] != null)
                this.Requester = obj.Requester.MapToDto<IntelliTect.TextTrolley.Data.Models.Requester, RequesterDtoGen>(context, tree?[nameof(this.Requester)]);

            var propValApplicationUsers = obj.ApplicationUsers;
            if (propValApplicationUsers != null && (tree == null || tree[nameof(this.ApplicationUsers)] != null))
            {
                this.ApplicationUsers = propValApplicationUsers
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<IntelliTect.TextTrolley.Data.Models.ApplicationUser, ApplicationUserDtoGen>(context, tree?[nameof(this.ApplicationUsers)])).ToList();
            }
            else if (propValApplicationUsers == null && tree?[nameof(this.ApplicationUsers)] != null)
            {
                this.ApplicationUsers = new ApplicationUserDtoGen[0];
            }

            var propValItems = obj.Items;
            if (propValItems != null && (tree == null || tree[nameof(this.Items)] != null))
            {
                this.Items = propValItems
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<IntelliTect.TextTrolley.Data.Models.ShoppingListItem, ShoppingListItemDtoGen>(context, tree?[nameof(this.Items)])).ToList();
            }
            else if (propValItems == null && tree?[nameof(this.Items)] != null)
            {
                this.Items = new ShoppingListItemDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.TextTrolley.Data.Models.ShoppingList entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ShoppingListId))) entity.ShoppingListId = (ShoppingListId ?? entity.ShoppingListId);
            if (ShouldMapTo(nameof(IsComplete))) entity.IsComplete = (IsComplete ?? entity.IsComplete);
            if (ShouldMapTo(nameof(IsDelivered))) entity.IsDelivered = (IsDelivered ?? entity.IsDelivered);
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
