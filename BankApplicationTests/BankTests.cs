using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication;

namespace BankApplicationTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void AddToBank_ValidAccount_ReturnsTrue()
        {
            //Arrange
            Bank bank = new Bank("Test Bank");
            Checking checking = new Checking("Bob Test");

            //Act
            bank.AddToBank(checking);

            //Assert
            Assert.IsTrue(bank.accounts.Contains(checking));
        }

        [TestMethod]
        public void AddToBank_InvalidAccount_ReturnsFalse()
        {
            Bank bank = new Bank("Test Bank");

            bank.AddToBank(null);

            Assert.IsTrue(!bank.accounts.Contains(null));
        }

    }
}
