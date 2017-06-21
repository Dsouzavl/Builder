using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder {

    //builder se torna apenas uma classe para atribuição e manipulação de dados.
    public class CreditTransactionBuilder : PaymentTransactionBuilder {
        public override void CatchTransactionId() {
           this.transaction.TransactionId = Guid.NewGuid();
        }

        public override void CatchTransactionOccurenceDate() {
           this.transaction.TransactionOccurenceDate = new DateTime(2000,03,01);
        }

        public override void CheckTransactionType() {
           this.transaction.TransactionType = "Credit";
        }
    }
}
