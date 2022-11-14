using System;
namespace TransientScopedSingleton.Services.TransientService
{
	public interface ITransientService
	{
		Guid GetOperationId();
	}
}

