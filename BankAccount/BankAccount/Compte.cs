using System.Collections.Generic;
using System.Transactions;

namespace BankAccount.Test
{
    public sealed class Compte
    {
        private int Balance;
        private List<TransactionBancaire> Transactions;

        public Compte()
        {
            Transactions = new List<TransactionBancaire>();
            Balance = 0;
        }

        public string ReleveDeCompte()
        {
            return "DATE | AMOUNT | BALANCE";
        }
    }
}