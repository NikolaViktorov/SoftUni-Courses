namespace GokoSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GokoSite.Data;
    using GokoSite.Data.Models.RP;
    using GokoSite.Web.ViewModels.Forums;

    public class ForumsService : IForumsService
    {
        private readonly ApplicationDbContext db;

        public ForumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<string> AddPost(AddForumModel input)
        {
            var post = new Forum()
            {
                ForumText = input.ForumText,
                ForumTopic = input.ForumTopic,
                Likes = input.Likes,
            };

            await this.db.Forums.AddAsync(post);

            await this.db.SaveChangesAsync();

            return post.ForumId;
        }

        public async Task AddPostToUser(string userId, string forumId)
        {
            var post = this.db.Forums.FirstOrDefault(f => f.ForumId == forumId);

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

        public async Task DeletePost(string postId)
        {
            var post = this.db.Forums.FirstOrDefault(f => f.ForumId == postId);

            if (post != null)
            {
                this.db.Remove(post);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task EditPost(AddForumModel input)
        {
            var post = this.db.Forums.FirstOrDefault(f => f.ForumId == input.ForumId);

            if (post != null)
            {
                post.ForumText = input.ForumText;
                post.ForumTopic = input.ForumTopic;

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
            var forums = new List<PersonalForumViewModel>();

            var userForums = this.db.UserForums.Where(uf => uf.UserId == userId).ToList();
            var forumIds = userForums.Select(uf => uf.ForumId).ToArray();

            foreach (var forum in this.db.Forums.Where(f => forumIds.Contains(f.ForumId)))
            {
                forums.Add(new PersonalForumViewModel()
                {
                    ForumId = forum.ForumId,
                    ForumText = forum.ForumText,
                    ForumTopic = forum.ForumTopic,
                    OwnerId = userId,
                });
            }

            return forums;
        }

        public EditForumViewModel GetPost(string postId)
        {
            var postDb = this.db.Forums.FirstOrDefault(f => f.ForumId == postId);

            if (postDb == null)
            {
                return null;
            }

            return new EditForumViewModel()
            {
                ForumId = postDb.ForumId,
                ForumTopic = postDb.ForumTopic,
                ForumText = postDb.ForumText,
                Likes = postDb.Likes,
            };
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
