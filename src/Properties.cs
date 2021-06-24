namespace Cythral.CloudFormation.JsonValue
{
    /// <summary>
    /// Resource properties for the Json Value resource.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Gets or sets the JSON to get a value from.
        /// </summary>
        public string? Json { get; set; }

        /// <summary>
        /// Gets or sets the key to retrieve a value for in the Json.
        /// </summary>
        public string? Key { get; set; }
    }
}
