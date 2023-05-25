using Bank_Orange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Orange_TDD
{
    [TestClass]
    public class BankSystem_Tests
    {
        [TestMethod]
        public void Login_IsDoneCorrectly()
        {
            //Arrange
            var acc = new BankAccount();
            var bs = new BankSystem();
            bs.AccountDictionary.Add(1, acc);
            bs.PersonDictionary.Add(1, new Person() { UserName = "Test", Password = "Test", IsAdmin = false});


            //Act
            var input = new StringReader("Test\nTest");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            bs.Login();

            //Assert
            var message = output.ToString();
            Assert.IsTrue(message.Contains("Successfully logged in!"));
            Assert.IsTrue(bs.InLoggedUserAccount == acc);
        }
    }
}
