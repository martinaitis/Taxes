using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TaxesData;
using TaxesData.Models;
using TaxesRules;

namespace TaxesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : BaseController
    {
        private const string TAXES_CONNECTION_TYPE_PATH = "ConnectionStrings:Taxes:Type";
        private const string TAXES_CONNECTION_STRING_PATH = "ConnectionStrings:Taxes:Value";

        private readonly ISourceProvider _sourceProvider;

        public TaxesController(LoggerResolver loggerAccessor, SourceProviderResolver sourceProviderAccesor, IConfiguration configuration) : base(loggerAccessor)
        {
            _sourceProvider = sourceProviderAccesor(configuration[TAXES_CONNECTION_TYPE_PATH]);
            _sourceProvider.SetConnectionString(configuration[TAXES_CONNECTION_STRING_PATH]);
        }

        [HttpGet]
        public IActionResult Get(string municipalityName, DateTime taxDate)
        {
            var municipality = _sourceProvider.GetMunicipality(municipalityName);

            if (municipality != null && taxDate != null)
            {               
                IRule rule = RuleFactory.GetRule(municipality.Rule);               
                return ResponseToOK(rule.CalculateTax(rule.GetAppliedTaxes(taxDate, _sourceProvider)));
            }
            else
                return ResponseToNotFound();
        }
        [HttpGet("MunicipalitiesNames")]
        public IActionResult GetMunicipalitiesNames()
        {
            List<Municipality> municipalities = _sourceProvider.GetMunicipalities();
            List<string> municipalitiesNames = new List<string>();

            foreach (Municipality municipality in municipalities)
                municipalitiesNames.Add(municipality.MunicipalityName);

            return ResponseToOK(municipalitiesNames);
        }
    }
}
