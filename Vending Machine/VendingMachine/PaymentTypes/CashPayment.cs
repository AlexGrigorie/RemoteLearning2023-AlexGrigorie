using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PaymentTypes
{
    internal class CashPayment : IPaymentAlgorithm
    {
        public string Name => "Cash";
        private readonly ICashPaymentTerminal cashPaymentTerminal;
        private readonly List<float> acceptedCoinsAndBanknotes = new List<float> { 0.5f, 1, 5, 10, 50 };

        public CashPayment(ICashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal ?? throw new ArgumentNullException(nameof(cashPaymentTerminal));
        }
        public void Run(float price)
        {
            float addedAmount = 0;

            while (addedAmount < price)
            {
                float money = cashPaymentTerminal.AskForMoney();
                if (!acceptedCoinsAndBanknotes.Contains(money))
                {
                    cashPaymentTerminal.GiveBackChange(addedAmount);
                    throw new InvalidMoneyException();
                }
                addedAmount += money;
            }
            if (addedAmount > price)
            {
                cashPaymentTerminal.GiveBackChange(addedAmount - price);
            }
        }
    }
}
