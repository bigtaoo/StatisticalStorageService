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
        public async Task<ActionResult<ReportLoadData>> PostReportLoadData(ReportLoadData data)
        {
            context.LoadDatas.Add(new LoadData{ LoadValue = data.LoadValue, Timestamp = DateTime.Now }) ;
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostReportLoadData), new { id = data.LoadValue }, data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoadData>>> GetLoadDatas()
        {
            return await context.LoadDatas.ToListAsync();
        }
    }
}
