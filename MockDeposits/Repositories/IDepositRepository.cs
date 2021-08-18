using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MockDeposits.Models;

namespace MockDeposits.Repositories
{
    public interface IDepositRepository
    {
        IEnumerable<Deposit> GetDeposits();
        Deposit GetDepositByID(int depositId);
        void InsertDeposit(Deposit deposit);
        void DeleteDeposit(int depositID);
        void UpdateDeposit(Deposit deposit);
        void Save();
    }
}
