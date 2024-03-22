namespace ICook.Services.Data
{
    using ICook.Web.ViewModels.Home;

    public interface IHomeService
    {
        IndexViewModel GetIndexViewModelWithCounts();
    }
}
