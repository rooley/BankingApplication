using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication;

namespace BankApplicationTests
{
    [TestClass]
    public class CheckingTests
    {
        [TestMethod]
        public void Deposit_ValidAmount_ReturnsTrue()
        {
            Checking checking = new Checking("Bob Test");

            checking.Deposit(50);

            Assert.IsTrue(checking.balance == 50);
        }

        [TestMethod]
        public void Deposit_NegativeAmount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");

            checking.Deposit(-50);

            Assert.IsTrue(checking.balance == 0);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_ReturnsTrue()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;

            checking.Withdraw(50);

            Assert.IsTrue(checking.balance == 0);
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;

            checking.Withdraw(-50);

            Assert.IsTrue(checking.balance == 50);
        }

        [TestMethod]
        public void Withdraw_MoreThanCurrentBalance_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;

            checking.Withdraw(60);

            Assert.IsTrue(checking.balance == 50);
        }

        [TestMethod]
        public void Transfer_ValidAmountToValidAccount_ReturnsTrue()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            checking.Transfer(ii, 50);

            Assert.IsTrue(checking.balance == 0);
            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToValidAccount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            checking.Transfer(ii, 60);

            Assert.IsTrue(checking.balance == 50);
            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Transfer_NegativeAmountToValidAccount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            checking.Transfer(ii, -50);

            Assert.IsTrue(checking.balance == 50);
            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Transfer_ValidAmountToInvalidAccount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;

            checking.Transfer(null, 50);

            Assert.IsTrue(checking.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToInvalidAccount_ReturnsFalse()
        {
            Checking checking = new Checking("Bob Test");
            checking.balance = 50;

            checking.Transfer(null, -50);

            Assert.IsTrue(checking.balance == 50);
        }
    }

   
}
