﻿namespace VendingMachine.Business.Interfaces
{
    internal interface ICashPaymentTerminal
    {
        public float AskForMoney();
        public void GiveBackChange(float change);
    }
}
