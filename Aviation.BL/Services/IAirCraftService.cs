using Aviation.BL.Dto;
using Aviation.DAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviation.BL.Services
{
    public interface IAirCraftService
    {
        void AddAirCraft(AirCraftCreate airCraft);

        void UpdateAirCraft(AirCraftUpdate airCraft);

        AirCraftGet GetAirCraftById(int id);

        IEnumerable<AirCraftGet> FilterAirCrafts(AirCraftSearchFilter filter);

        IEnumerable<AirCraftGet> FilterAirCrafts(string searchText);

        void RemoveAirCraft(int id);
    }
}
