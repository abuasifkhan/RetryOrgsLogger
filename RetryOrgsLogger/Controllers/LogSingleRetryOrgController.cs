using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RetryOrgsLogger.Model;
using RetryOrgsLogger.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetryOrgsLogger.Controllers
{
    [Route("api/[controller]")]
    public class LogSingleRetryOrgController : Controller
    {
        private IRetryOrgsData _retryOrgData;

        public LogSingleRetryOrgController(IRetryOrgsData retryOrgData)
        {
            _retryOrgData = retryOrgData;
        }
        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<RetryOrg> Get()
        //{
        //    return _retryOrgData.GetAll();
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            RetryOrg retryOrg = JsonConvert.DeserializeObject<RetryOrg>(value.ToString(Formatting.None));
            _retryOrgData.Add(retryOrg);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{geo}/{organizationId}")]
        public void Delete(string geo, Guid organizationId)
        {
            _retryOrgData.Delete(geo, organizationId);
        }
    }
}
