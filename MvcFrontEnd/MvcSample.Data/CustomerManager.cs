using System.Collections.Generic;
using System.Data;
using MvcSample.Data.Abstracts;
using MvcSample.Entities;
using SolutionUtilities;

namespace MvcSample.Data
{
    public class CustomerManager : BaseDataManager
    {

        public ProcessStatus<ICollection<Customer>> GetCustomerFromDatabase()
        {
            return GetRecords<Customer>("usp_GetCustomers", CommandType.StoredProcedure);
        }

        public void AddCustomer(Customer model)
        {
            AddParameter(model, m=> m.AccountNumber, ParameterDirection.Input, SqlDbType.NVarChar, 16);
        }
    }
}