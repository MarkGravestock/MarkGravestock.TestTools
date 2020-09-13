using System;
using FluentAssertions;
using Xunit;
using Moq;

namespace MarkGravestock.TestTools
{
    public class MoqTest
    {
        [Fact]
        public void it_can_capture_updated_value()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var account = new Account {Id = Guid.NewGuid(), Balance = 50m};
            
            var sut = new WithdrawlFeature();
            
            accountRepository.Setup(x => x.GetAccountById(It.Is<Guid>(y => y == account.Id))).Returns(account);
            
            Account accountAfterTransfer = null;

            accountRepository.Setup(x => x.Update(It.Is<Account>(y => y.Id == account.Id))).Callback<Account>(z => accountAfterTransfer = z);

            sut.Execute(account, 25, accountRepository.Object);        
            
            accountAfterTransfer.Balance.Should().Be(25);
        }

    }

    public class WithdrawlFeature
    {
        public void Execute(Account account, decimal amount, IAccountRepository accountRepository)
        {
            var accountToWithdraw = accountRepository.GetAccountById(account.Id);

            accountToWithdraw.Balance -= amount;
            
            accountRepository.Update(accountToWithdraw);
        }
    }
    
    public interface IAccountRepository
    {
        Account GetAccountById(Guid accountId);

        void Update(Account account);
    }
    
    public class Account
    {
        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}