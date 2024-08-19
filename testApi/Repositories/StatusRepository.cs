using testApi.Data;
using Microsoft.EntityFrameworkCore;

namespace testApi.Repositories
{
    public class StatusRepository: IStatuses
    {
        private readonly AppDBContent appDBContent;
        public StatusRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public Task<Status?> Get(long id) => appDBContent.Statuses.FirstOrDefaultAsync(p => p.Id == id);
    }
}
