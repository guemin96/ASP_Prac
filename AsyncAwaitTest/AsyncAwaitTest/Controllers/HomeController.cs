using AsyncAwaitTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            //Stopwatch watch = new Stopwatch();

            //watch.Start();
            Test1();
            Test2();
            Test3();
            //watch.Stop();

            //var result = watch.ElapsedMilliseconds;
            return View();
        }
        public async Task<IActionResult> Contact()
        {
           // Stopwatch watch = new Stopwatch();

           // watch.Start();
            var test1 = Test1Async();
            var test2 = Test2Async();
            var test3 = Test3Async();

            var result1 = await test1;
            var result2 = await test2;
            var result3 = await test3;
           // watch.Stop();
           // var result = watch.ElapsedMilliseconds;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int Test1()
        {
            Thread.Sleep(3000);
            return 0;
        }
        public int Test2()
        {
            Thread.Sleep(3000);
            return 0;
        }
        public int Test3()
        {
            Thread.Sleep(3000);
            return 0;
        }
        public async Task<int> Test1Async()
        {
            await Task.Delay(3000);
            return 0;
        }
        public async Task<int> Test2Async()
        {
            await Task.Delay(3000);
            return 0;
        }
        public async Task<int> Test3Async()
        {
            await Task.Delay(3000);
            return 0;
        }

    }
}
