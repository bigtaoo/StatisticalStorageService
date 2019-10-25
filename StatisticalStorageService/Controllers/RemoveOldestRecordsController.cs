using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatisticalStorageService.Models;
using System.Linq;

namespace StatisticalStorageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemoveOldestRecordsController : ControllerBase
    {
        private readonly LoadContext context;
        public RemoveOldestRecordsController(LoadContext loadContext)
        {
            context = loadContext;
        }

        [HttpDelete("{n}")]
        public async Task<ActionResult<int>> RemoveOldestRecords(int n)
        {
            // error input
            if(n <= 0)
            {
                return 0;
            }

            var result = from r in context.LoadDatas orderby r.Id select r;
            var count = result.Count();
            // large { n }, delete all
            if (n >= count)
            {
                context.LoadDatas.RemoveRange(context.LoadDatas);
                await context.SaveChangesAsync();
                return count;
            }
            // delete oldest { n } value
            context.LoadDatas.RemoveRange(result.Take(n));
            await context.SaveChangesAsync();

            return n;
        }
    }
}
