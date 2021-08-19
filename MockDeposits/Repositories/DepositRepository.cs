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

        Random r = new Random();

        public DepositRepository()
        {
            InitialiseDeposits();
        }

        public IEnumerable<Deposit> GetDeposits()
        {
            return deposits;
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
            int numberOfDeposits = 50;
            double minMaturityAmount = 70 * 1000 * 1000 / numberOfDeposits;
            double maxMaturityAmount = 100 * 1000 * 1000 / numberOfDeposits;

            deposits.Clear();
            for (int i = 0; i < numberOfDeposits; i++)
            {
                var deposit = new Deposit()
                {
                    StartDate = DateTime.Today.AddDays(-1 * r.Next(1, 186)),
                    TermInYears = r.Next(1, 5),
                    InterestRate = 0.001 * r.Next(15, 50),
                    MaturityAmount = r.NextDouble() * (maxMaturityAmount - minMaturityAmount) + minMaturityAmount
                };

                deposit.EndDate = deposit.StartDate.AddYears(deposit.TermInYears);
                deposit.Principal = deposit.MaturityAmount / (1 + deposit.TermInYears * deposit.InterestRate);

                deposits.Add(deposit);
            }
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
