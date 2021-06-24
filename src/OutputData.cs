using System;

using Lambdajection.CustomResource;

namespace Cythral.CloudFormation.JsonValue
{
    /// <summary>
    /// JSON value resource provider output data.
    /// </summary>
    public class OutputData : ICustomResourceOutputData
    {
        /// <summary>
        /// Gets or sets the ID of the output data.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the custom resource result.
        /// </summary>
        public object? Result { get; set; }
    }
}
