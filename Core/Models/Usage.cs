using System;
using Core.Enums;

namespace Core.Models
{
    public class Usage<T>
    {
        public T Data { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public ResourceTypeEnum ResourceType { get; private set; }

        public Usage(T data, DateTime createdOn, ResourceTypeEnum resourceType)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            CreatedOn = createdOn;
            ResourceType = resourceType;
        }
    }
}