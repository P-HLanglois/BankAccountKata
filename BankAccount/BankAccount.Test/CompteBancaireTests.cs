using System;
using NUnit.Framework;
using NFluent;

namespace BankAccount.Test
{
    public class CompteBancaireTests
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
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE"
                                                          + "\r\nDepot | 01/04/2019 | 1000 | 1000");
        }

        [Test]
        public void RetraitDoitRetirerDeLArgentAuCompteEtSeVoirSurLeReleve()
        {
            // Given
            var date = new DateTime(2019, 4, 1);

            // When new account created
            compte.Retirer(1000, date);

            // Then
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE"
                                                          + "\r\nRetrait | 01/04/2019 | 1000 | -1000");
        }
        
        [Test]
        public void LeReleveDoitAfficherPlusieursDepotsDuPlusRecentAuPlusAncien()
        {
            // Given
            var date1 = new DateTime(2019, 4, 1);
            var date2 = new DateTime(2019, 4, 3);

            // When new account created
            compte.Deposer(2059.45, date1);
            compte.Deposer(1500, date2);

            // Then
            Check.That(compte.ReleveDeCompte()).IsEqualTo("OPERATION | DATE | MONTANT | BALANCE"
                                                          + "\r\nDepot | 03/04/2019 | 1500 | 3559,45"
                                                          + "\r\nDepot | 01/04/2019 | 2059,45 | 2059,45");
        }
    }
}