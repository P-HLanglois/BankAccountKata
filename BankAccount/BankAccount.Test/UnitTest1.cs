using System;
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
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE");
        }
        
        [Test]
        public void DepotDoitAjouterDeLArgentAuCompteEtSeVoirSurLeReleve()
        {
            // Given
            var date = new DateTime(2019, 4, 1);
            
            // When new account created
            compte.Deposer(1000, date);
            
            // Then
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE\r\n"
                                                          + "Depot | 01/04/2019 | 1000 | 1000");
        }
        
        [Test]
        public void RetraitDoitRetirerDeLArgentAuCompteEtSeVoirSurLeReleve()
        {
            // Given
            var date = new DateTime(2019, 4, 1);
            
            // When new account created
            compte.Retirer(1000, date);
            
            // Then
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE\r\n"
                                                          + "Retrait | 01/04/2019 | 1000 | -1000");
        }
    }
}