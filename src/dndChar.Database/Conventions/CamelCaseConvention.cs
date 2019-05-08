using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace dndChar.Database.Conventions
{
    public class CamelCaseConvention : IMemberMapConvention
    {
        public string Name => nameof(CamelCaseConvention);

        public void Apply(BsonMemberMap memberMap)
        {
            memberMap.SetElementName(char.ToLowerInvariant(memberMap.MemberName[0]) + memberMap.MemberName.Substring(1));
        }
    }
}
