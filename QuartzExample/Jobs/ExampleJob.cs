using Quartz;

namespace QuartzExample.Jobs
{
    public class ExampleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await File.AppendAllLinesAsync(@"D:\Quartz.txt",new List<string> {"FisrtJob"+ DateTime.Now.ToString("hhmmss") });
        }
    }
}
