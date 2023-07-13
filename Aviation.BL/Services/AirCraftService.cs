using AutoMapper;
using Aviation.BL.Dto;
using Aviation.DAL.Filters;
using Aviation.DAL.Model;
using Aviation.DAL.Repositories;

namespace Aviation.BL.Services
{
    public class AirCraftService : IAirCraftService
    {
        private readonly IRepository<AirCraft> _repository;
        private readonly IMapper _mapper;

        public AirCraftService(
            IRepository<AirCraft> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AddAirCraft(AirCraftCreate airCraft)
        {
            _repository.Add(_mapper.Map<AirCraft>(airCraft));
            _repository.Save();
        }

        public void UpdateAirCraft(AirCraftUpdate airCraft)
        {
            var oldAirCraft = _repository.GetById(airCraft.Id);
            oldAirCraft.Model = airCraft.Model;
            oldAirCraft.Make = airCraft.Make;
            oldAirCraft.Registration = airCraft.Registration;
            oldAirCraft.Location = airCraft.Location;
            _repository.Save();
        }

        public AirCraftGet GetAirCraftById(int id)
        {
            return _mapper.Map<AirCraftGet>(_repository.GetById(id));
        }

        public IEnumerable<AirCraftGet> FilterAirCrafts(AirCraftSearchFilter filter)
        {
            var query = _repository.GetAll();

            if (!string.IsNullOrEmpty(filter.Registration))
            {
                query = query.Where(x => x.Registration == filter.Registration);
            }

            if (!string.IsNullOrEmpty(filter.Make))
            {
                query = query.Where(x => x.Make == filter.Make);
            }

            if (!string.IsNullOrEmpty(filter.Model))
            {
                query = query.Where(x => x.Model == filter.Model);
            }

            return _mapper.Map<IEnumerable<AirCraftGet>>(query.ToList());
        }

        public IEnumerable<AirCraftGet> FilterAirCrafts(string searchText)
        {
            var query = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => 
                x.Registration.Contains(searchText) ||
                x.Make.Contains(searchText) ||
                x.Location.Contains(searchText));
            }

            return _mapper.Map<IEnumerable<AirCraftGet>>(query.ToList());
        }

        public void RemoveAirCraft(int id)
        {
            var airCraft = _repository.GetById(id);

            if(airCraft != null)
            {
                _repository.Delete(airCraft);
                _repository.Save();
            }
        }
    }
}
