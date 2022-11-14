using System;
namespace TransientScopedSingleton.Services.SingletonService
{
	public interface ISingletonService
	{
		Guid GetOperationId();
	}
}

