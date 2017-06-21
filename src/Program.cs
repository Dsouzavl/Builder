using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder {
    class Program {
        static void Main(string[] args) {

            var paymentCreator = new PaymentTransactionCreator(new CreditTransactionBuilder());

            paymentCreator.ConstructPaymentTransaction();
            var transaction = paymentCreator.GetPaymentTransaction();

            transaction.DisplayTransaction();

        }

    }
}