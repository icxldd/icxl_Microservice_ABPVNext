﻿using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace BaseService.BaseData
{
    public class DataDictionary : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DataDictionary(Guid id, [NotNull] string name,string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
