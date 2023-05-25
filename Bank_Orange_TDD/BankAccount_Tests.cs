using Bank_Orange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;

namespace Bank_Orange_TDD
{
    [TestClass]
    public class BankAccount_Tests
    {
        [TestMethod]
        [TestCategory("Currency")]
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
        [TestCategory("Currency")]

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
        [TestCategory("Currency")]

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
        [TestMethod]
        [TestCategory("Currency")]
        public void CurrencyConverter_ConvertsDollarsToKronaCorrectly()
        {
            //Arrange
            var acc = new BankAccount();

            string currencyFrom = "$";
            string currencyTo = "Kr";
            decimal money = 100.0m;


            //Act
            decimal actual = acc.CurrencyConverter(currencyFrom, currencyTo, money);
            decimal expected = money * acc.currencyExchanges.DollarCurrencyRate;


            //Assert
            Assert.AreEqual(actual, expected);

        }
        [TestMethod]
        [TestCategory("Currency")]
        public void CurrencyConverter_ConvertsKronaToDollarCorrectly()
        {
            //Arrange
            var acc = new BankAccount();

            string currencyFrom = "Kr";
            string currencyTo = "$";
            decimal money = 100.0m;


            //Act
            decimal actual = acc.CurrencyConverter(currencyFrom, currencyTo, money);
            decimal expected = money / acc.currencyExchanges.DollarCurrencyRate;


            //Assert
            Assert.AreEqual(actual, expected);

        }
        [TestMethod]
        [TestCategory("AddAccount")]
        public void AddNewBankAccount_AddsNewBankAccountCorrectly()
        {
            //Arrange
            var bankAccount = new BankAccount();


            //Act
            //Simulate input for console readline.
            var input = new StringReader("1\nSparkonto_Test\n2\n100\n");
            Console.SetIn(input);

            //Listen to the console for Console.WriteLine's
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            bankAccount.AddNewBankAccount();
            var output = consoleOutput.ToString();

            //Assert
            //Check if a account with the same name exists.
            Assert.IsTrue(bankAccount.BankAccountList
                .Contains(bankAccount.BankAccountList
                .FirstOrDefault(a => a.AccountName == "Sparkonto_Test")));

            //Check if success message was printed to the console.
            Assert.IsTrue(output.Contains("Successfully added bank account."));
        }


        [TestMethod]
        public void TransferMoneyInUser_ZeroAmount_ReturnsInvalidNumberMessage()
        {
            // Arrange
            var bankAccount = new BankAccount();
            var firstAcc = new AccountDetails("Sparkonto", 0, "sek", false, false, 0);
            var secoundAcc = new AccountDetails("Sparkonto", 10, "sek", false, false, 1);
            bankAccount.BankAccountList .Add(firstAcc);
            bankAccount.BankAccountList .Add(secoundAcc);

            // Act
            var input = new StringReader("1\n0\n2");
            Console.SetIn(input);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            bankAccount.TransfereMoneyinUser();
            var output = consoleOutput.ToString();

            // Assert
            Assert.IsTrue(output.Contains("Please enter a valid number."));
        }
        [TestMethod]
        public void TransferMoneyInUser_InsuffiecentAmount_ReturnErrorMessage()
        {
            // Arrange
            var bankAccount = new BankAccount();
            var firstAcc = new AccountDetails("Sparkonto", 0, "sek", false, false, 0);
            var secoundAcc = new AccountDetails("Sparkonto", 10, "sek", false, false, 1);
            bankAccount.BankAccountList .Add(firstAcc);
            bankAccount.BankAccountList .Add(secoundAcc);

            // Act
            var input = new StringReader("1\n1000\n2");
            Console.SetIn(input);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            bankAccount.TransfereMoneyinUser();
            var output = consoleOutput.ToString();

            // Assert
            Assert.IsTrue(output.Contains("Insufficent funds."));
        }
        [TestMethod]
        public void TransferMoneyInUser_TransfersMoneyCorrectly()
        {
            // Arrange
            var bankAccount = new BankAccount();
            var firstAcc = new AccountDetails("Sparkonto", 10, "sek", false, false, 0);
            var secoundAcc = new AccountDetails("Sparkonto", 10, "sek", false, false, 1);
            bankAccount.BankAccountList .Add(firstAcc);
            bankAccount.BankAccountList .Add(secoundAcc);

            // Act
            var input = new StringReader("1\n10\n2");
            Console.SetIn(input);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            bankAccount.TransfereMoneyinUser();
            var output = consoleOutput.ToString();

            // Assert
            Assert.IsTrue(bankAccount.BankAccountList.Contains(bankAccount.BankAccountList.FirstOrDefault(a => a.Money == 20)));
            Assert.IsTrue(output.Contains("Transaction has been successful."));
        }
    }
}