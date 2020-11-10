using System;
using System.Collections.Generic;
using TaxesData.Models;

namespace TaxesData
{
    public class MongoDBSourceProvider : ISourceProvider
    {
        public void SetConnectionString(string connectionString)
        {
            throw new NotImplementedException();
        }
        public Municipality GetMunicipality(string municipalityName)
        {
            throw new NotImplementedException();
        }
        public List<Tax> GetRuleTaxes(string rule)
        {
            throw new NotImplementedException();
        }
        public List<Municipality> GetMunicipalities()
        {
            throw new NotImplementedException();
        }
    }
}
