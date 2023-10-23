using Microsoft.AspNetCore.Authorization;

namespace Asignment002.Policies.Requirements
{
    public class TypeRequirememt : IAuthorizationRequirement
    {
        public String ColumnName {  get; }
        public TypeRequirememt(string type)
        {
            ColumnName = type;
        }
    }
}
