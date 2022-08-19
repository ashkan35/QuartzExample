using Quartz;

namespace QuartzExample.Jobs
{
    public class ExampleJob2 
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var rnd=new Random();
            await File.AppendAllLinesAsync(@"D:\Quartz.txt",new List<string> { "SecondJob" + DateTime.Now.ToString("hhmmss") });
        }
    }
}
