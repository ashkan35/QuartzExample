using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzExample.Jobs;
using QuartzExample.Models;
using System.Diagnostics;

namespace QuartzExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IScheduler _scheduler;

        public HomeController(ILogger<HomeController> logger,ISchedulerFactory schedulerFactory)
        {
            _logger = logger;
            _schedulerFactory = schedulerFactory;
            _scheduler = _schedulerFactory.GetScheduler("Quartz ASP.NET Core Sample Scheduler").Result;

        }

        public async Task<IActionResult> Index()
        {
            IJobDetail job = JobBuilder.Create<ExampleJob>()
.WithIdentity("myJob")
.Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger2")
                 .WithIdentity("Cron Trigger23")
        .WithCronSchedule("0/10 * * * * ?")
        .WithDescription("my awesome cron trigger").Build();


            await _scheduler.ScheduleJob(job, trigger);
           
            return View();
        }

        public async Task<IActionResult> Privacy()
        {


            var name = _scheduler.SchedulerName;
            var ff = _scheduler.SchedulerInstanceId;
            var jobs= await _scheduler.GetCurrentlyExecutingJobs();

            return View();
        }
        public async Task<IActionResult> AddJob()
        {
           
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}