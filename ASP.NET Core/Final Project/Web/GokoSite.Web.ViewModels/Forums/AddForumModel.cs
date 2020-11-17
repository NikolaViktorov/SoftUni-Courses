namespace GokoSite.Web.ViewModels.Forums
{
    using System.ComponentModel.DataAnnotations;

    public class AddForumModel
    {
        [Required]
        public string ForumTopic { get; set; }

        [Required]
        public string ForumText { get; set; }
    }
}
