namespace GokoSite.Services.Data
{
    using GokoSite.Web.ViewModels.News;

    public interface INewsService
    {
        public void AddNew(NewAddInputModel input);

        public void RemoveNew(string newId);

        public void EditNew(NewAddInputModel input);
    }
}
