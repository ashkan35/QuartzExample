using Quartz;
using System.Reflection;

namespace QuartzExample.Jobs
{
    public static class JobsCollectionExtention
    {
        public static IServiceCollection AddAllJobs(this IServiceCollection services)
        {
            var type = typeof(IJob);
            var types = Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => x.GetInterfaces().Contains(type));
            foreach (var item in types)
            {
                services.AddSingleton(item); // lifetime
             
            }
            return services;
        }


    }
       
    
}
