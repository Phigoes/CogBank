using System;

namespace cogbank.service.locator
{
	public class ServiceLocator
	{
		public static Func<IServiceProvider> ContainerAccessor { get; set; }

		static IServiceProvider Container => ContainerAccessor();

		private static readonly object lockObject = new object();

		private static ServiceLocator instance;

		public static ServiceLocator Instance
		{
			get
			{
				lock (lockObject)
				{
					if (instance == null)
					{
						instance = new ServiceLocator();
					}
				}

				return instance;
			}
		}

		public T Create<T>() where T : class
		{
			return (T)Container.GetService(typeof(T));
		}
	}
}
