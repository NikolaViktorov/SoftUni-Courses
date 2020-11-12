namespace GokoSite.Services.Data
{
    using GokoSite.Web.ViewModels.Forums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    // TODO
    public interface IForumsService
    {
        public ICollection<ForumViewModel> GetAll(string userId);

        public ICollection<PersonalForumViewModel> GetPersonalPosts(string userId);

        public Task Like(string postId, string userId);

        public Task<string> AddPost(AddForumModel input);

        public Task AddPostToUser(string userId, string forumId);
    }
}
