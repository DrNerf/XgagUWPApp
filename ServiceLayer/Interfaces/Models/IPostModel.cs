namespace ServiceLayer
{
    /// <summary>
    /// Post Model.
    /// </summary>
    public interface IPostModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        long DateCreatedTicks { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        string DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [any new comments].
        /// </summary>
        bool AnyNewComments { get; set; }

        /// <summary>
        /// Gets or sets you tube link.
        /// </summary>
        string YouTubeLink { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is you tube post.
        /// </summary>
        bool IsYouTubePost { get; set; }
    }
}
