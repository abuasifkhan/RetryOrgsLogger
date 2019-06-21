using Microsoft.CodeAnalysis.CSharp.Syntax;
using RetryOrgsLogger.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace RetryOrgsLogger.Services
{
    public interface IRetryOrgsData
    {
        IEnumerable<RetryOrg> GetAll();
        RetryOrg Get(string Geo, Guid organizationId);
        RetryOrg Add(RetryOrg newRetryOrg);
        RetryOrg Update(RetryOrg newRetryOrg);
    }
}
