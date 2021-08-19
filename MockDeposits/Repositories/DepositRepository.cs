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

        double minPrincipal = 3 * 1000 * 1000;
        double maxPrincipal = 5 * 1000 * 1000;

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
            deposits.Clear();

            int numberOfBigDeposits = 12;
            for (int i = 0; i < numberOfBigDeposits; i++)
            {
                AddDeposit();
            }

            double totalMaturityAmount = deposits.Sum(d => d.MaturityAmount);

            int numberOfDeposits = 50 - numberOfBigDeposits;

            double minMaturityAmount = (70 * 1000 * 1000 - totalMaturityAmount) / numberOfDeposits;
            double maxMaturityAmount = (100 * 1000 * 1000 - totalMaturityAmount) / numberOfDeposits;

            for (int i = 0; i < numberOfDeposits; i++)
            {
                var deposit = new Deposit()
                {
                    StartDate = DateTime.Today.AddDays(-1 * r.Next(1, 186)),
                    TermInYears = r.Next(1, 3),
                    InterestRate = 0.001 * r.Next(15, 30),
                    MaturityAmount = r.NextDouble() * (maxMaturityAmount - minMaturityAmount) + minMaturityAmount
                };

                deposit.EndDate = deposit.StartDate.AddYears(deposit.TermInYears);
                deposit.Principal = deposit.MaturityAmount / (1 + deposit.TermInYears * deposit.InterestRate);

                deposits.Add(deposit);
            }
        }

        public void AddDeposit()
        {
            var deposit = new Deposit()
            {
                StartDate = DateTime.Today.AddDays(-1 * r.Next(1, 186)),
                TermInYears = r.Next(1, 3),
                InterestRate = 0.001 * r.Next(15, 30),
                Principal = r.NextDouble() * (maxPrincipal - minPrincipal) + minPrincipal
            };

            deposit.EndDate = deposit.StartDate.AddYears(deposit.TermInYears);
            deposit.MaturityAmount = deposit.Principal * (1 + deposit.TermInYears * deposit.InterestRate);

            deposits.Add(deposit);
        }

        public void RemoveDeposit()
        {
            var deposit = deposits.Where(d => d.Principal >= minPrincipal && d.Principal <= maxPrincipal).FirstOrDefault();
            if (deposit != null)
                deposits.Remove(deposit);
        }
    }
}
