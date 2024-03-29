﻿using System;

namespace BankAccount
{
    public class TransactionBancaire
    {
        private readonly double _montant;
        private readonly TypeTransaction _typeTransaction;
        private readonly DateTime _date;
        public readonly double Balance;

        private TransactionBancaire(double montant, TypeTransaction typeTransaction, DateTime date, double balance)
        {
            _montant = montant;
            _typeTransaction = typeTransaction;
            _date = date;
            Balance = balance;
        }

        public static TransactionBancaire CreerDepot(double montant, DateTime date, double balance)
        {
            return new TransactionBancaire(montant, TypeTransaction.Depot, date, balance + montant);
        }

        public string AffichageParDefaut()
        {
            return _typeTransaction + " | " + _date.ToString("dd/MM/yyyy") + " | " + _montant + " | " + Balance;
        }

        public static TransactionBancaire CreerRetrait(double montant, DateTime date, double balance)
        {
            return new TransactionBancaire(montant, TypeTransaction.Retrait, date, balance - montant);
        }
    }

    internal enum TypeTransaction
    {
        Depot,
        Retrait
    }
}