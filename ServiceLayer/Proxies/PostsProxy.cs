using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal class PostsProxy : ProxyBase, IPostsProxy
    {
        private const string SrcRegex = @"src=[""'](?<VideoUrl>\S*)[""']";

        private string PostsApiUrl
        {
            get
            {
                return $"{BaseApiAddress}posts";
            }
        }

        public Task<IEnumerable<IPostModel>> Get(int skip = 0, int take = 1)
        {
            return SafeExecute<IEnumerable<IPostModel>>(async () => 
            {
                using (var client = CreateHttpClient())
                {
                    var response = await client.GetAsync($"{PostsApiUrl}?skip={skip}&take={take}");
                    ValidateHttpResponse(response);
                    var result = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(result);
                    return TransformPostsData(posts).ToList();
                }
            });
        }

        public Task<IPostModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IPostModel> TransformPostsData(IEnumerable<PostModel> posts)
        {
            foreach (var post in posts)
            {
                post.IsYouTubePost = string.IsNullOrEmpty(post.ImageUrl);
                if (!post.IsYouTubePost)
                {
                    post.ImageUrl = $"{RuntimeInfo.BaseWebsiteAddress}{post.ImageUrl}";
                }
                else
                {
                    var matches = Regex.Matches(post.YouTubeLink, SrcRegex);
                    if (matches.Count > 0)
                    {
                        post.YouTubeLink = matches[0].Groups["VideoUrl"].Value;
                    }
                }

                post.DateCreated = new DateTime(post.DateCreatedTicks).ToString("d");

                yield return post;
            }
        }
    }
}
