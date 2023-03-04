using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.TextTrolley.Web.Models
{
    public partial class ApplicationRoleDtoGen : GeneratedDto<IntelliTect.TextTrolley.Data.Models.ApplicationRole>
    {
        public ApplicationRoleDtoGen() { }

        private int? _Id;
        private string _Name;
        private string _NormalizedName;
        private string _ConcurrencyStamp;

        public int? Id
        {
            get => _Id;
            set { _Id = value; Changed(nameof(Id)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string NormalizedName
        {
            get => _NormalizedName;
            set { _NormalizedName = value; Changed(nameof(NormalizedName)); }
        }
        public string ConcurrencyStamp
        {
            get => _ConcurrencyStamp;
            set { _ConcurrencyStamp = value; Changed(nameof(ConcurrencyStamp)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.TextTrolley.Data.Models.ApplicationRole obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.Id = obj.Id;
            this.Name = obj.Name;
            this.NormalizedName = obj.NormalizedName;
            this.ConcurrencyStamp = obj.ConcurrencyStamp;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.TextTrolley.Data.Models.ApplicationRole entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Id))) entity.Id = (Id ?? entity.Id);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(NormalizedName))) entity.NormalizedName = NormalizedName;
            if (ShouldMapTo(nameof(ConcurrencyStamp))) entity.ConcurrencyStamp = ConcurrencyStamp;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.ApplicationRole MapToNew(IMappingContext context)
        {
            var entity = new IntelliTect.TextTrolley.Data.Models.ApplicationRole();
            MapTo(entity, context);
            return entity;
        }
    }
}
