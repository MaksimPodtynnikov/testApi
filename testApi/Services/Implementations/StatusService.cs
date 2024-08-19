using testApi.Services.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using testApi.Repositories;
using testApi.Domain.Enum;
using testApi.Domain.Response;

namespace testApi.Services.Implementations
{
	public class StatusService : IStatusService
	{
		private readonly IStatuses _statusRepository;
		public StatusService(IStatuses DepartmentRepository) 
		{
            _statusRepository = DepartmentRepository;
		}
		public async Task<IBaseResponse<Status>> GetStatus(long id)
		{
			try
			{
				var status = await _statusRepository.Get(id);
				if (status == null)
				{
					return new BaseResponse<Status>()
					{
						Description = "Cтатус не найден",
						StatusCode = StatusCode.ObjectNotFound
					};
				}

				return new BaseResponse<Status>()
				{
					StatusCode = StatusCode.OK,
					Data = status
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Status>()
				{
					Description = $"[GetStatus] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}
