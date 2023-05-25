using Bank_Orange;
using System.Security.Cryptography.X509Certificates;

namespace Bank_Orange_TDD
{
    [TestClass]
    public class BankAccount_Tests
    {
        [TestMethod]
        public void CurrencyConvertFromSek_ConvertsToDollarCorrectly()
        {
            //Arrange
            var acc = new BankAccount();

            string currency = "$";
            decimal money = 1000.0m;


            //Act
            decimal expected = money / acc.currencyExchanges.DollarCurrencyRate;
            decimal actual = acc.CurrencyConvertFromSek(currency, money);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CurrencyConvertFromSek_ConvertsToEuroCorrectly()
        {
            //Arrange
            var acc = new BankAccount();

            string currency = "€";
            decimal money = 1000.0m;


            //Act
            decimal expected = money / acc.currencyExchanges.EuroCurrencyRate;
            decimal actual = acc.CurrencyConvertFromSek(currency, money);
            

            //Assert
            Assert.AreEqual(expected, actual);
        } 
        [TestMethod]
        public void CurrencyConvertFromSek_DecimalValueShouldBeLessAfterConvert()
        {
            //Arrange
            var acc = new BankAccount();

            string currency = "€";
            decimal money = 1000.0m;


            //Act
            decimal actual = acc.CurrencyConvertFromSek(currency, money);
            bool expected = actual < money;



            //Assert
            Assert.IsTrue(expected);
        }
        //[TestMethod]
        //public void TransferMoneyInUser_ZeroAmount_ReturnsInvalidNumberMessage()
        //{
        //    // Arrange
        //    var bankAccount = new BankAccount();
        //    var firstAcc = new AccountDetails("Sparkonto",0,"sek",false, false,2);
        //    var secoundAcc = new AccountDetails("Sparkonto", 10, "sek", false, false, 3);

        //    // Act
        //    var input = new StringReader("1\n0\n2\n\n");
        //    Console.SetIn(input);

        //    var consoleOutput = new StringWriter();
        //    Console.SetOut(consoleOutput);

        //    bankAccount.TransfereMoneyinUser();
        //    var output = consoleOutput.ToString();

        //    // Assert
        //    Assert.IsTrue(output.Contains("Please enter a valid number."));
        //}
    }
}