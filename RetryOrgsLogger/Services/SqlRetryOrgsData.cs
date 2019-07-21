using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public RetryOrg Delete(string geo, Guid organizationId)
        {
            var orgToDelete = Get(geo, organizationId);
            if (orgToDelete != null)
            {
                _context.Attach(orgToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            return orgToDelete;
        }

        public RetryOrg Get(string geo, Guid organizationId)
        {
            return _context.RetryOrgs.FirstOrDefault(r => r.Geo == geo && r.OrganizationId == organizationId);
        }

        public IEnumerable<RetryOrg> GetAll()
        {
            return _context.RetryOrgs.OrderBy(r => r.Geo);
        }

        public RetryOrg Update(RetryOrg newRetryOrg)
        {
            // Update only if the timestamp is updated or the solutionVersion
            var previousData = Get(newRetryOrg.Geo, newRetryOrg.OrganizationId);
            if (previousData == null)
            {
                return newRetryOrg;
            }

            if(previousData.PreciseTimeStamp < newRetryOrg.PreciseTimeStamp || previousData.SolutionVersion != newRetryOrg.SolutionVersion)     /// TODO: Room for improvements
            {
                _context.Attach(newRetryOrg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return newRetryOrg;
        }
    }
}
