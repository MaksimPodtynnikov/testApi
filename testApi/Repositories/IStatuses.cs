namespace testApi.Repositories
{
    public interface IStatuses
    {
        Task<Status?> Get(long id);
    }
}
