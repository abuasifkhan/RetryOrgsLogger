using Microsoft.AspNetCore.Mvc;
using RetryOrgsLogger.Model;
using RetryOrgsLogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetryOrgsLogger.Controllers
{
    [Route("api/[controller]")]
    public class GetAllRetryOrgsController : Controller
    {
        private IRetryOrgsData _retryOrgData;

        public GetAllRetryOrgsController(IRetryOrgsData retryOrgData)
        {
            _retryOrgData = retryOrgData;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<RetryOrg> Get()
        {
            return _retryOrgData.GetAll();
        }
    }
}
