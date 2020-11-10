using System.Collections.Generic;
using TaxesData.Models;

namespace TaxesData
{
    public interface ISourceProvider
    {
        public void SetConnectionString(string connectionString);
        Municipality GetMunicipality(string municipalityName);
        public List<Tax> GetRuleTaxes(string rule);
        public List<Municipality> GetMunicipalities();
    }
}
