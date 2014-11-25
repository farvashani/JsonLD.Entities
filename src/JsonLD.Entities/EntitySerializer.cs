﻿using JsonLD.Core;
using Newtonsoft.Json;

namespace JsonLD.Entities
{
    /// <summary>
    /// Entity serializer
    /// </summary>
    public class EntitySerializer : IEntitySerializer
    {
        private readonly IContextProvider _contextProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySerializer"/> class.
        /// </summary>
        /// <param name="contextProvider">The JSON-LD @context provider.</param>
        public EntitySerializer(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        /// <summary>
        /// Deserializes the NQuads into a typed model
        /// </summary>
        /// <typeparam name="T">destination entity model type</typeparam>
        /// <param name="nQuads">RDF data in NQuads.</param>
        public T Deserialize<T>(string nQuads)
        {
            var jsonLdObject = JsonLdProcessor.FromRDF(nQuads);
            var jsonLdContext = _contextProvider.GetExpandedContext(typeof(T));
            return JsonLdProcessor.Compact(jsonLdObject, jsonLdContext, new JsonLdOptions()).ToObject<T>(new JsonSerializer
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat
                });
        }
    }
}