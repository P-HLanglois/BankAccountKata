using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    internal class HistoriqueDeTransactions
    {
        private readonly List<TransactionBancaire> _transactions;

        public HistoriqueDeTransactions()
        {
            _transactions = new List<TransactionBancaire>();
        }

        public void AjouterTransaction(TransactionBancaire transactionBancaire)
        {
            _transactions.Add(transactionBancaire);
        }

        public string Afficher()
        {
            return _transactions.Select(AffichageLigneTransactionParDefaut)
                .Reverse()
                .Aggregate("", (returnedString, transactionString) => returnedString + transactionString.ToString());
        }

        private string AffichageLigneTransactionParDefaut(TransactionBancaire transaction)
        {
            return "\r\n" + transaction.AffichageParDefaut();
        }

        public double BalanceActuelle()
        {
            return _transactions.Count() != 0 ? _transactions.Last().Balance : 0;
        }

        public bool isEmpty()
        {
            return _transactions.Count == 0;
        }
    }
}