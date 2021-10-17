using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_booking_system.Models;
using Tier2_Database.DataAccess;

namespace Tier2_Database.Services
{
    public class ResourceService : IResourceService
    {
        public async Task<IList<Resource>> GetResources()
        {
            await using (SimpleBookingDBContext SBContext = new SimpleBookingDBContext())
            {
                try
                {
                    var tempResources = SBContext.Resources.ToList();
                    return tempResources;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;
        }
    }
}