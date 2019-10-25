using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticalStorageService.Models;
namespace StatisticalStorageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportLoadDataController : ControllerBase
    {
        private readonly LoadContext context;
        public ReportLoadDataController(LoadContext loadContext)
        {
            context = loadContext;
        }

        [HttpPost]
        public async Task<ActionResult<LoadData>> PostReportLoadData(ReportLoadData data)
        {
            if(data.LoadValue < 0 || data.LoadValue > 100)
            {
                return BadRequest();
            }

            // store as a new LoadData.
            var loadData = new LoadData { LoadValue = data.LoadValue, Timestamp = DateTime.Now };
            context.LoadDatas.Add(loadData) ;
            await context.SaveChangesAsync();

            return loadData;
        }

        // todo for test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoadData>>> GetLoadDatas()
        {
            return await context.LoadDatas.ToListAsync();
        }
    }
}
