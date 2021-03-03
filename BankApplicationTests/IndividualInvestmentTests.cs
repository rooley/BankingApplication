using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication;

namespace BankApplicationTests
{
    [TestClass]
    public class IndividualInvestmentTests
    {
        [TestMethod]
        public void Deposit_ValidAmount_ReturnsTrue()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            ii.Deposit(50);

            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Deposit_NegativeAmount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            ii.Deposit(-50);

            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_ReturnsTrue()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;

            ii.Withdraw(50);

            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;

            ii.Withdraw(-50);

            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Withdraw_MoreThanCurrentBalance_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;

            ii.Withdraw(60);

            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Withdraw_AmountGreaterThan1000_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 1001;

            ii.Withdraw(1001);

            Assert.IsTrue(ii.balance == 1001);
        }

        [TestMethod]
        public void Transfer_ValidAmountToValidAccount_ReturnsTrue()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;
            CorporateInvestment ci = new CorporateInvestment("Bob Test");

            ii.Transfer(ci, 50);

            Assert.IsTrue(ii.balance == 0);
            Assert.IsTrue(ci.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToValidAccount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;
            CorporateInvestment ci = new CorporateInvestment("Bob Test");

            ii.Transfer(ci, 60);

            Assert.IsTrue(ii.balance == 50);
            Assert.IsTrue(ci.balance == 0);
        }

        [TestMethod]
        public void Transfer_NegativeAmountToValidAccount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;
            CorporateInvestment ci = new CorporateInvestment("Bob Test");

            ii.Transfer(ci, -50);

            Assert.IsTrue(ii.balance == 50);
            Assert.IsTrue(ci.balance == 0);
        }

        [TestMethod]
        public void Transfer_ValidAmountToInvalidAccount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;

            ii.Transfer(null, 50);

            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToInvalidAccount_ReturnsFalse()
        {
            IndividualInvestment ii = new IndividualInvestment("Bob Test");
            ii.balance = 50;

            ii.Transfer(null, -50);

            Assert.IsTrue(ii.balance == 50);
        }
    }
}
