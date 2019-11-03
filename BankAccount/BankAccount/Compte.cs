using System;
using System.Text;

namespace BankAccount.Test
{
    public sealed class Compte
    {
        private readonly HistoriqueDeTransactions _historiqueDeTransactions;

        public Compte()
        {
            _historiqueDeTransactions = new HistoriqueDeTransactions();
        }

        public string ReleveDeCompte()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("OPERATION | DATE | MONTANT | BALANCE");
            stringBuilder.Append(_historiqueDeTransactions.Afficher());
            return stringBuilder.ToString();
        }

        public void Deposer(int montant, DateTime date)
        {
            var nouveauDepot = TransactionBancaire.CreerDepot(montant, date, BalanceActuelle());
            _historiqueDeTransactions.AjouterTransaction(nouveauDepot);
        }

        public double BalanceActuelle()
        {
            return _historiqueDeTransactions.BalanceActuelle();
        }
    }
}