using System.Collections.Generic;
using System.Threading.Tasks;
using Simple_booking_system.Models;

namespace Tier2_Database.Services
{
    public interface IResourceService
    {
        Task<IList<Resource>> GetResources();
    }
}