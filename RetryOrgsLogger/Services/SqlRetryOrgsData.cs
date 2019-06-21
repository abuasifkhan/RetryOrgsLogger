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
            if (_context.RetryOrgs.Any(r => r.Geo == newRetryOrg.Geo && r.OrganizationId == newRetryOrg.OrganizationId))
            {
                return Update(newRetryOrg);
            }
            else
            {
                _context.RetryOrgs.Add(newRetryOrg);
                _context.SaveChanges();
            }

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

        public RetryOrg Update(RetryOrg newRetryOrg)
        {
            // Update only if the timestamp is updated
            var previousData = Get(newRetryOrg.Geo, newRetryOrg.OrganizationId);
            if(previousData.PreciseTimeStamp < newRetryOrg.PreciseTimeStamp)
            {
                _context.Attach(newRetryOrg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return newRetryOrg;
        }
    }
}
