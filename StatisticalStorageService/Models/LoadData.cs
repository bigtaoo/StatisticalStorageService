using System;
namespace StatisticalStorageService.Models
{
    public class LoadData
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int LoadValue { get; set; }
    }
}
