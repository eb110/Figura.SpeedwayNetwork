using Figura.SpeedwayNetwork.Model;
using Figura.SpeedwayNetwork.Model.DAO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Figura.SpeedwayNetwork.Service
{
    public class NetworkService : INetworkService
    {
        private readonly SpeedwayNetworkDb _context;

        public NetworkService(SpeedwayNetworkDb context)
        {
            _context = context;
        }

        public async Task<Country> AddCountry(Country country)
        {
            try
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            IQueryable<Country> query = _context.Countries.Where(x => x.Name.Equals(country.Name));

            var res = query.FirstOrDefault();

            if (res == null)
            {
                throw new Exception("Adding country failed - country has not ended up in database");
            }

            return res;
        }

        public async Task<FirstName> AddName(FirstName name)
        {
            try
            {
                _context.Add(name);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            IQueryable<FirstName> query = _context.FirstNames.Where(x => x.Name.Equals(name.Name));

            var res = query.FirstOrDefault();

            if (res == null)
            {
                throw new Exception("Adding name failed - name has not ended up in database");
            }

            return res;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            IQueryable<Country> query = _context.Countries;

            List<Country> countries = null!;

            try
            {
                countries = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (countries == null)
            {
                throw new Exception("Get all countries exception");
            }

            return countries;
        }

        public async Task<List<FirstName>> GetAllNames()
        {
            IQueryable<FirstName> query = _context.FirstNames;

            List<FirstName> names = null!;

            try
            {
                names = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (names == null)
            {
                throw new Exception("Get all names exception");
            }

            return names;
        }
    }
}
