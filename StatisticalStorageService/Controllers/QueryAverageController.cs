using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticalStorageService.Models;

namespace StatisticalStorageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueryAverageController : ControllerBase
    {
        private readonly LoadContext context;
        public QueryAverageController(LoadContext loadContext)
        {
            context = loadContext;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetAverage()
        {
            var allData = await context.LoadDatas.ToListAsync();
            // empty storage
            if(allData.Count == 0)
            {
                return 0;
            }
            // calculate the average
            var total = 0;
            foreach(var v in allData)
            {
                total += v.LoadValue;
            }
            var average = total / allData.Count;

            return average;
        }
    }
}
