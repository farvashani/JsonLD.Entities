using System.Collections.Generic;
using NullGuard;

namespace JsonLD.Entities
{
    /// <summary>
    /// Contains JSON-LD special property names
    /// </summary>
    [NullGuard(ValidationFlags.All)]
    public static class JsonLdKeywords
    {
        /// <summary>
        /// @id property
        /// </summary>
        public const string Id = "@id";

        /// <summary>
        /// @type property
        /// </summary>
        public const string Type = "@type";

        private static readonly IDictionary<string, string> KnownPropertyNames = new Dictionary<string, string>();

        static JsonLdKeywords()
        {
            KnownPropertyNames.Add("Id", Id);
            KnownPropertyNames.Add("Type", Type);
            KnownPropertyNames.Add("Types", Type);
        }

        /// <summary>
        /// Gets the keyword for a C# property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>a JSON-LD keyword or null</returns>
        [return: AllowNull]
        internal static string GetKeywordForProperty(string propertyName)
        {
            KnownPropertyNames.TryGetValue(propertyName, out propertyName);

            return propertyName;
        }
    }
}
