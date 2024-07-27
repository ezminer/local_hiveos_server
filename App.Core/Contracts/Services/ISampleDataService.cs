using System.Collections.Generic;
using System.Threading.Tasks;

using MyApp.Core.Models;

namespace MyApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetGridDataAsync();
    }
}
