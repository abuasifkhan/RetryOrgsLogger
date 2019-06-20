using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetryOrgsLogger.Model
{
    public class RetryOrg
    {
        /*
         {
    "organizationId": "848dbd5a-0ddc-4eee-bda1-c18b83ea11bf",
    "Geo": "NA",
    "PreciseTimeStamp": "2019-06-14T09:41:26.8381793",
    "solutionVersion": "9.0.1905.4009",
    "solutionName": "msdynce_MarketingPatch201905",
    "ErrorMessage": "Microsoft.Crm.BusinessEntities.CrmSolutionException: The solution installation or removal failed due to the installation or removal of another solution at the same time. Please try again later.\r"
  },
         */
        [Key, Column(Order = 0)]
        public string Geo { get; set; }
        [Key, Column(Order = 1)]
        public Guid organizationId { get; set; }
        public DateTime PreciseTimeStamp { get; set; }
        public string SolutionName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
