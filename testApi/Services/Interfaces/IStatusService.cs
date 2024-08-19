using testApi.Domain.Response;
using System.Threading.Tasks;

namespace testApi.Services.Interfaces
{
	public interface IStatusService
	{
		Task<IBaseResponse<Status>> GetStatus(long id);
	}
}
