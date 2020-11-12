namespace GokoSite.Services.Data
{
    using GokoSite.Data;
    using GokoSite.Data.Models.RP;
    using GokoSite.Web.ViewModels.Forums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ForumsService : IForumsService
    {
        private readonly ApplicationDbContext db;

        public ForumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPost(AddForumModel input)
        {
            var post = new Forum()
            {
                ForumText = input.ForumText,
                ForumTopic = input.ForumTopic,
                Likes = input.Likes,
            };

            await this.db.Forums.AddAsync(post);

            await this.db.SaveChangesAsync();
        }

        public async Task AddPostToUser(string userId)
        {
            var post = this.db.Forums.OrderByDescending(f => f.ForumId).FirstOrDefault();

            if (post != null)
            {
                this.db.UserForums.Add(new UserForums()
                {
                    UserId = userId,
                    ForumId = post.ForumId,
                });

                await this.db.SaveChangesAsync();
            }
        }

        public ICollection<ForumViewModel> GetAll(string userId)
        {
            var forums = new List<ForumViewModel>();
            foreach (var forum in this.db.Forums.ToList())
            {
                forums.Add(new ForumViewModel()
                {
                    ForumId = forum.ForumId,
                    ForumText = forum.ForumText,
                    ForumTopic = forum.ForumTopic,
                    Likes = forum.Likes,
                    Liked = IsForumLiked(forum.ForumId, userId),
                });
            }
            return forums;
        }

        public ICollection<PersonalForumViewModel> GetPersonalPosts(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task Like(string postId, string userId)
        {
            var forum = this.db.Forums.FirstOrDefault(f => f.ForumId == postId);

            var isLiked = this.IsForumLiked(postId, userId);
            var userLike = this.db.UserLikes.FirstOrDefault(f => f.ForumId == postId && f.UserId == userId);

            if (isLiked)
            {
                forum.Likes -= 1;
                userLike.Liked = false;
            }
            else
            {
                forum.Likes += 1;
                userLike.Liked = true;
            }

            await this.db.SaveChangesAsync();
        }

        private bool IsForumLiked(string postId, string userId)
        {
            var userLike = this.db.UserLikes.FirstOrDefault(f => f.ForumId == postId && f.UserId == userId);

            if (userLike == null)
            {
                this.db.UserLikes.Add(new UserLikes()
                {
                    ForumId = postId,
                    UserId = userId,
                    Liked = false,
                });

                this.db.SaveChanges();

                return false;
            }

            return userLike.Liked;
        }
    }
}
