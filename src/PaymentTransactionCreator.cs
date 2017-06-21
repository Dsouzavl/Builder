using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder {
    public class PaymentTransactionCreator {

        private readonly PaymentTransactionBuilder _builder;

        public PaymentTransactionCreator(PaymentTransactionBuilder builder) {
            this._builder = builder;
        }

        public void ConstructPaymentTransaction() {
            _builder.CreatePaymentTransaction();
            _builder.CatchTransactionId();
            _builder.CatchTransactionOccurenceDate();
            _builder.CheckTransactionType();
        }

        public PaymentTransaction GetPaymentTransaction() {
           return _builder.GetPaymentTransaction();
        }
    }
}
