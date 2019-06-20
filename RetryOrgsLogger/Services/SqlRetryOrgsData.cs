using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetryOrgsLogger.Data;
using RetryOrgsLogger.Model;

namespace RetryOrgsLogger.Services
{
    public class SqlRetryOrgsData : IRetryOrgsData
    {
        private RetryOrgsLoggerDbContext _context;

        public SqlRetryOrgsData(RetryOrgsLoggerDbContext context)
        {
            _context = context;
        }
        public RetryOrg Add(RetryOrg newRetryOrg)
        {
            _context.RetryOrgs.Add(newRetryOrg);
            _context.SaveChanges();

            return newRetryOrg;
        }

        public RetryOrg Get(string Geo, Guid organizationId)
        {
            return _context.RetryOrgs.FirstOrDefault(r => r.Geo == Geo && r.OrganizationId == organizationId);
        }

        public IEnumerable<RetryOrg> GetAll()
        {
            return _context.RetryOrgs.OrderBy(r => r.Geo);
        }

        public RetryOrg Update(string Geo, Guid organizationId)
        {
            throw new NotImplementedException();
        }
    }
}
