using System.Collections.Generic;
using System.Threading.Tasks;
using DocIt.Models.DeveloperSample;

namespace DocIt.Data.DeveloperSample
{
    public interface IMyProductRepository
    {
        Task<IEnumerable<MyProduct>> GetAllAsync();

        Task<MyProduct> GetAsync(string id);

        Task<MyProduct> UpdateAsync(MyProduct objectToUpdate);

        Task<MyProduct> CreateAsync(MyProduct objectToCreate);
    }
}
