using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication;

namespace BankApplicationTests
{
    [TestClass]
    public class CorporateInvestmentTests
    {
        [TestMethod]
        public void Deposit_ValidAmount_ReturnsTrue()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");

            ci.Deposit(50);

            Assert.IsTrue(ci.balance == 50);
        }

        [TestMethod]
        public void Deposit_NegativeAmount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");

            ci.Deposit(-50);

            Assert.IsTrue(ci.balance == 0);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_ReturnsTrue()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;

            ci.Withdraw(50);

            Assert.IsTrue(ci.balance == 0);
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;

            ci.Withdraw(-50);

            Assert.IsTrue(ci.balance == 50);
        }

        [TestMethod]
        public void Withdraw_MoreThanCurrentBalance_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;

            ci.Withdraw(60);

            Assert.IsTrue(ci.balance == 50);
        }

        [TestMethod]
        public void Transfer_ValidAmountToValidAccount_ReturnsTrue()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            ci.Transfer(ii, 50);

            Assert.IsTrue(ci.balance == 0);
            Assert.IsTrue(ii.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToValidAccount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            ci.Transfer(ii, 60);

            Assert.IsTrue(ci.balance == 50);
            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Transfer_NegativeAmountToValidAccount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;
            IndividualInvestment ii = new IndividualInvestment("Bob Test");

            ci.Transfer(ii, -50);

            Assert.IsTrue(ci.balance == 50);
            Assert.IsTrue(ii.balance == 0);
        }

        [TestMethod]
        public void Transfer_ValidAmountToInvalidAccount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;

            ci.Transfer(null, 50);

            Assert.IsTrue(ci.balance == 50);
        }

        [TestMethod]
        public void Transfer_InvalidAmountToInvalidAccount_ReturnsFalse()
        {
            CorporateInvestment ci = new CorporateInvestment("Bob Test");
            ci.balance = 50;

            ci.Transfer(null, -50);

            Assert.IsTrue(ci.balance == 50);
        }
    }
}
