using NUnit.Framework;
using NFluent;

namespace BankAccount.Test
{
    public class Tests
    {
        private Compte compte;

        [SetUp]
        public void Setup()
        {
            compte = new Compte();
        }

        [Test]
        public void CompteCreeDoitEtreInitialiseAvecUneListeDeTransactionsVide()
        {
            // Given / When new account created
            // Then
            Check.That(compte.ReleveDeCompte()).IsEqualTo("DATE | MONTANT | BALANCE");
        }
    }
}