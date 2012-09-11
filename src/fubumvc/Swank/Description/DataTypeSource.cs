﻿using System;
using System.Reflection;
using System.Xml.Serialization;

namespace Swank.Description
{
    public class DataTypeSource : IDescriptionSource<Type, DataTypeDescription>
    {
        public DataTypeDescription GetDescription(Type type)
        {
            var description = type.GetCustomAttribute<CommentsAttribute>();
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            var elementType = Extensions.GetListElementType(type);
            return new DataTypeDescription {
                Id = elementType != null ? elementType.FullName.Hash() : type.FullName.Hash(),
                Name = xmlType != null ? xmlType.TypeName : elementType != null ? "ArrayOf" + elementType.Name : type.Name,
                Comments = description != null ? description.Comments : null,
                Namespace = type.Namespace
            };
        }
    }
}