using System;
namespace TransientScopedSingleton.Services.ScopedService
{
	public interface IScopedService
	{
		Guid GetOperationId();
	}
}

