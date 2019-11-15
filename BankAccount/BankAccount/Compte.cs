using System;
using System.Text;

namespace BankAccount
{
    public sealed class Compte
    {
        private readonly HistoriqueDeTransactions _historiqueDeTransactions;
        const string MessageHistoriqueVide = "Vous n'avez effectué aucune transaction à ce jour";

        public Compte()
        {
            _historiqueDeTransactions = new HistoriqueDeTransactions();
        }

        public string ReleveDeCompte()
        {
            var stringBuilder = new StringBuilder();

            if (_historiqueDeTransactions.isEmpty())
            {
                stringBuilder.Append(MessageHistoriqueVide);
                return stringBuilder.ToString();
            }

            stringBuilder.Append("OPERATION | DATE | MONTANT | BALANCE");
            stringBuilder.Append(_historiqueDeTransactions.Afficher());
            return stringBuilder.ToString();
        }

        public double BalanceActuelle()
        {
            return _historiqueDeTransactions.BalanceActuelle();
        }

        public void Deposer(double montant, DateTime date)
        {
            var nouveauDepot = TransactionBancaire.CreerDepot(montant, date, BalanceActuelle());
            _historiqueDeTransactions.AjouterTransaction(nouveauDepot);
        }

        public void Retirer(double montant, in DateTime date)
        {
            var nouveauRetrait = TransactionBancaire.CreerRetrait(montant, date, BalanceActuelle());
            _historiqueDeTransactions.AjouterTransaction(nouveauRetrait);
        }
    }
}