using Newtonsoft.Json;

namespace ServiceLayer
{
    /// <summary>
    /// Post Model.
    /// </summary>
    /// <seealso cref="ServiceLayer.IPostModel" />
    internal class PostModel : IPostModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public long DateCreatedTicks { get; set; }

        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        [JsonProperty(PropertyName = "commentsCount")]
        public int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [any new comments].
        /// </summary>
        [JsonProperty(PropertyName = "anyNewComments")]
        public bool AnyNewComments { get; set; }

        /// <summary>
        /// Gets or sets you tube link.
        /// </summary>
        [JsonProperty(PropertyName = "youTubeLink")]
        public string YouTubeLink { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public string DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is you tube post.
        /// </summary>
        public bool IsYouTubePost { get; set; }
    }
}
