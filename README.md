# O padrão _Builder_

## Escrito por Victor Souza A.k.a _vhost_

Estamos chegando quase ao último artigo em relação ao padrões de projeto criacionais ( _não fique triste_ ), nesse artigo vou explicar o padrão _Builder_, o seu melhor amigo na hora de construir objetos complexos.

O padrão _Builder_ deve ser utilizado quando você possui um objeto muito complexo de construir, através dele, sua construção será levada do construtor da classe, para uma outra classe responsável por construir e devolver seu objeto, onde será possível incluir uma certa lógica na hora da construção, isso te lembra o [_Factory method_](https://github.com/Dsouzavl/Factory-method) correto? Sim, pode até ser, mas eles não são iguais, enquanto através do _Factory method_ você pode escolher qual objeto quer retornar, no _Builder_ ele cria e retorna apenas um objeto específico, fora que suas motivações são totalmente diferentes. Todo _Builder_ retorna o objeto complexo específico para o qual ele foi criado esse sempre será seu cliente, um exemplo de objeto complexo pode ser, um objeto que tem muitos parâmetros no seu construtor, e também não podemos definir como propriedades e altera-lás após instânciarmos o objeto, pois o risco de termos objetos incompletos é muito grande. Mantenha sempre em mente, _Builder_ é para ser usado para construir objetos complexos, esse é o foco do padrão. 

### _Recomendo olhar o código fonte para poder analisar com mais cautela a arquitetura do padrão Builder_

```csharp
 public class PaymentTransaction
    {
        public Guid TransactionKey;

        public DateTime TransactionOccurenceDate;

        public string TransactionType;

        public PaymentTransaction(Guid transactionKey, DateTime transactionOccurenceDate, string transactionType){
            this.TransactionKey = TransactionKey;
            this.TransactionOccurenceDate = transactionOccurenceDate;
            this.TransactionType = transactionType
        }

        public void DisplayTransaction()
        {
            Console.WriteLine($@"TransactionKey: {TransactionKey}  
                              Transaction occurence date {TransactionOccurenceDate} 
                              Transaction type {TransactionType} 
                                ");
            Console.ReadLine();
      
        }

    }
```
Tudo bem, não parece que nossa classe é tão complexa de construir, mas é apenas um exemplo, a primeira coisa a se fazer é declarar o modelo que todo builder vai ter que seguir para criamos nosso objeto complexo.

```csharp
    public abstract class PaymentTransactionBuilder
    {
        protected PaymentTransaction transaction;

        public PaymentTransaction GetPaymentTransaction() {
            return this.transaction;
        }

        public void CreatePaymentTransaction() {
            transaction = new PaymentTransaction();
        }

        public abstract void CatchTransactionKey();
        public abstract void CatchTransactionOccurenceDate();
        public abstract void CheckTransactionType();
    }
```
Okay, parece ótimo, temos uma abstração de um _Builder_ que cria, retorna e compõe o nosso objeto, ao invés de passarmos paramêtros para o construtor, adicionaremos suas valores através dos métodos para pegar a TransactionKey, a data de ocorrência da transação e o tipo de transação que é.

```csharp
public class CreditTransactionBuilder : PaymentTransactionBuilder {
        public override void CatchTransactionKey() {
           this.transaction.TransactionKey = Guid.NewGuid();
        }

        public override void CatchTransactionOccurenceDate() {
           this.transaction.TransactionOccurenceDate = new DateTime(2000,03,01);
        }

        public override void CheckTransactionType() {
           this.transaction.TransactionType = "Credit";
        }
    }
```

```csharp
  public class PaymentTransactionCreator {

        private readonly PaymentTransactionBuilder _builder;

        public PaymentTransactionCreator(PaymentTransactionBuilder builder) {
            this._builder = builder;
        }

        public void ConstructPaymentTransaction() {
            _builder.CreatePaymentTransaction();
            _builder.CatchTransactionKey();
            _builder.CatchTransactionOccurenceDate();
            _builder.CheckTransactionType();
        }

        public PaymentTransaction GetPaymentTransaction() {
           return _builder.GetPaymentTransaction();
        }
    }
```
O que fizemos acima foi separar as repsonsabilidades, cada classe na arquitetura do _Builder_ tem uma função específica, a nossa abstração de _builder_ serve para compormos um contrato que todo _builder_ concreto deve seguir, para que ela seja "capaz" de criar nosso objeto ( _sim, poderiamos fazer através de uma interface, mas como queria implementações default, utilizei uma classe abstrata_ ), os nossos _builders_ concretos, assinam nosso contrato e implementam os métodos para compor o nosso objeto, geralmente dando o valor real as propriedades do objeto que ele vai retornar, e nosso **creator** faz a mágica acontecer, ele recebe um _builder_, na verdade qualquer _builder_ que tenha assinado o contrato, e disponibiliza dois métodos, onde um vai estar sendo responsável por construir o objeto de fato, e o outro por retornar o objeto criado. Ficamos livres, podemos construir o nosso objeto passando um quantidade _n_ de _builders_, poderíamos ter um _builder_ para cartão de débito por exemplo, mas o mais importante é que dessa forma separamos as responsabilidades de construção, onde o creator apenas lida com a lógica do processo ( _que pode, e deve ser reaproveitada_ ) e o _builder_ com os dados do nosso objeto, criamos, instânciamos, anulando quase que completamente a complexidade, fazendo jus a razão de existência do padrão _Builder_. Observe: 

```csharp
class Program {
        static void Main(string[] args) {

            var paymentCreator = new PaymentTransactionCreator(new CreditTransactionBuilder());

            paymentCreator.ConstructPaymentTransaction();
            var transaction = paymentCreator.GetPaymentTransaction();

            transaction.DisplayTransaction();

        }

    }
```
Simples, instânciamos nosso _creator_, nosso _builder_ que queremos utilizar, contruimos e chamamos ele, sem dor.

## Final

Esse é um ótimo padrão, quem sabe muitas vez você já até o implementou, mas não o conhece, espero que esse artigo lhe ajude a compreendê-lo, e sempre se lembre, não sofra para construir objetos complexos, o _Builder_ é seu amigo.

Para mais artigos sobre padrões de projeto e OO veja meu [GitHub](https://github.com/Dsouzavl).

Obrigado a todos os leitores.

Boa noite.