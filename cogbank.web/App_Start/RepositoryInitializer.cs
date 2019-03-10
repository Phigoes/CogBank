using cogbank.data.SQLInitializer;

namespace cogbank.web.App_Start
{
	public class RepositoryInitializer
	{
		public static void Initialize()
		{
			DbInitializer.Initialize();
		}
	}
}