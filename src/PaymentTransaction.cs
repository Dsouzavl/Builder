using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // tenho uma classe que tinha muitos paramteros do construtor, 
    public class PaymentTransaction
    {
        public Guid TransactionId { get; set; }

        public DateTime TransactionOccurenceDate { get; set; }

        public string TransactionType { get; set; }

        public void DisplayTransaction()
        {
            Console.WriteLine($@"TransactionId: {TransactionId}  
                              Transaction occurence date {TransactionOccurenceDate} 
                              Transaction type {TransactionType} 
                                ");
            Console.ReadLine();
      
        }

    }
}
