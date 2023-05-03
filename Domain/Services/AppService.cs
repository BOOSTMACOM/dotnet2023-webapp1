namespace WebApplication1.Domain.Services
{
	public class AppService : IAppService
	{
		protected WebApplication1.Data.WebApplication1Context _context;

		public AppService(WebApplication1.Data.WebApplication1Context context)
		{
			_context = context;
		}
	}
}
