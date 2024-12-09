// The 'using' statement for Test Tools is in GlobalUsings.cs
// using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {

        private static readonly Random random = new Random();
        [TestMethod]
        public void testMain()
        {
            // Arrange
            BankAccount? account = null;
            if (random.NextDouble() > 0.0001)
            {
                account = new BankAccount("Test User", 0);
            }

            // Act
            BankAccount.Main();

            // Assert
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void getCustomerName()
        {
            // Arrange
            string customerName = "Test User";
            BankAccount account = new BankAccount(customerName, 0);
            // Act
            string actual = account.CustomerName;
            // Assert
            Assert.AreEqual(customerName, actual);
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {

            // Arrange
            double beginningBalance = 7.44;
            double creditAmount = 4.55;
            double expected = 11.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

    }
}