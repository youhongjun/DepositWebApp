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
        List<Deposit> deposits = new List<Deposit>();

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

        public void InitialiseDeposits()
        {
            throw new NotImplementedException();
        }

        public void AddDeposit()
        {
            throw new NotImplementedException();
        }

        public void RemoveDeposit()
        {
            throw new NotImplementedException();
        }
    }
}
