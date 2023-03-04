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
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.TextTrolley.Data.Models.Requester MapToNew(IMappingContext context)
        {
            var entity = new IntelliTect.TextTrolley.Data.Models.Requester();
            MapTo(entity, context);
            return entity;
        }
    }
}
