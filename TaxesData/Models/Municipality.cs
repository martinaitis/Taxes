namespace TaxesData.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        public string MunicipalityName { get; set; }
        public string Rule { get; set; }
        public Municipality(int id, string municipalityName, string rule)
        {
            Id = id;
            MunicipalityName = municipalityName;
            Rule = rule;
        }
    }
}
