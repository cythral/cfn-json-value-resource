using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Lambdajection.Attributes;
using Lambdajection.CustomResource;

using Microsoft.Extensions.Logging;

#pragma warning disable IDE0060

namespace Cythral.CloudFormation.JsonValue
{
    /// <summary>
    /// Custom resource provider for retrieving a JSON value.
    /// </summary>
    [CustomResourceProvider(typeof(Startup))]
    public partial class Handler
    {
        private readonly ILogger<Handler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler" /> class.
        /// </summary>
        /// <param name="logger">Logger to use.</param>
        public Handler(ILogger<Handler> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request to get a JSON value.
        /// </summary>
        /// <param name="request">The custom resource request.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting task.</returns>
        public Task<OutputData> Create(CustomResourceRequest<Properties> request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var props = request.ResourceProperties;
            logger.LogInformation("Received request: {@props}", props);

            var json = JsonSerializer.Deserialize<Dictionary<string, object>>(props!.Json!);
            logger.LogInformation("Deserialized json: {@json}", json);

            object? result = null;
            json?.TryGetValue(props!.Key!, out result);
            logger.LogInformation("Found result: {@result}", result);

            var id = string.IsNullOrEmpty(request.PhysicalResourceId) ? Guid.NewGuid().ToString() : request.PhysicalResourceId;
            return Task.FromResult(new OutputData { Id = id, Result = result });
        }

        /// <summary>
        /// Handles a request to get a JSON value.
        /// </summary>
        /// <param name="request">The custom resource request.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting task.</returns>
        public Task<OutputData> Update(CustomResourceRequest<Properties> request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Create(request, cancellationToken);
        }

        /// <summary>
        /// Handles a request to get a JSON value.
        /// </summary>
        /// <param name="request">The custom resource request.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting task.</returns>
        public Task<OutputData> Delete(CustomResourceRequest<Properties> request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Create(request, cancellationToken);
        }
    }
}
