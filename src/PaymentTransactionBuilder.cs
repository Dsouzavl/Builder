using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //essa interface define um contrato para os builders de transacao, para construirem meu objeto
    public abstract class PaymentTransactionBuilder
    {
        protected PaymentTransaction transaction;

        public PaymentTransaction GetPaymentTransaction() {
            return this.transaction;
        }

        public void CreatePaymentTransaction() {
            transaction = new PaymentTransaction();
        }

        public abstract void CatchTransactionId();
        public abstract void CatchTransactionOccurenceDate();
        public abstract void CheckTransactionType();
    }
}
