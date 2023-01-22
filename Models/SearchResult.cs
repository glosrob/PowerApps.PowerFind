namespace XRTSoft.PowerApps.PowerFind.Models
{
    /// <summary>
    /// Result from a component search.
    /// </summary>
    public class SearchResult
    {
        // Properties

        /// <summary>
        /// Gets or sets the display value for the component.
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the Type of the component.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the id for the component.
        /// </summary>
        public string Id { get; set; }

        // Methods

        /// <summary>
        /// Provides a string represetation of this object.
        /// </summary>
        /// <returns>A string represetation of this object.</returns>
        public override string ToString()
        {
            return Display;
        }
    }
}
