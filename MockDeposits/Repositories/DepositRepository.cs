using MockDeposits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDeposits.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        public IEnumerable<Deposit> GetDeposits()
        {
            throw new NotImplementedException();
        }

        public Deposit GetDepositByID(int depositId)
        {
            throw new NotImplementedException();
        }

        public void InsertDeposit(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeposit(int depositID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateDeposit(Deposit deposit)
        {
            throw new NotImplementedException();
        }
    }
}
