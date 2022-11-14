using System;
using TransientScopedSingleton.Services.ScopedService;
using TransientScopedSingleton.Services.SingletonService;
using TransientScopedSingleton.Services.TransientService;

namespace TransientScopedSingleton.Services
{
	public class OperationService: ITransientService,IScopedService,ISingletonService
	{
		Guid Id;

		public OperationService()
		{
			Id = Guid.NewGuid();
		}

        public Guid GetOperationId()
        {
			return Id;
        }
    }
}

