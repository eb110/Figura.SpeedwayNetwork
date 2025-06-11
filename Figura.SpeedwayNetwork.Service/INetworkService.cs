using Figura.SpeedwayNetwork.Model.DAO;

namespace Figura.SpeedwayNetwork.Service
{
    public interface INetworkService
    {
        public Task<List<FirstName>> GetAllNames();
        public Task<List<Country>> GetAllCountries();
        public Task<FirstName> AddName(FirstName name);
        public Task<Country> AddCountry(Country country);
    }
}
