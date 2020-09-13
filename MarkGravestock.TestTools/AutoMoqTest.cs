using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace MarkGravestock.TestTools
{
    public class AutoMoqTest
    {
        [Fact]
        public void it_can_create_mocks_as_well()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            
            var accountRepository = fixture.Freeze<Mock<IAccountRepository>>();
            var account = fixture.Create<Account>();
            var withdrawlAmount = fixture.Create<decimal>();

            var sut = fixture.Create<WithdrawlFeature>();
            
            accountRepository.Setup(x => x.GetAccountById(It.Is<Guid>(y => y == account.Id))).Returns(account);
            
            sut.Execute(account, withdrawlAmount, accountRepository.Object);        

            accountRepository.Verify(x => x.Update(It.Is<Account>(y => y.Id == account.Id)));
        }

        [Theory, AutoMoqData]
        public void it_can_reduce_boilerplate(WithdrawlFeature sut, Mock<IAccountRepository> accountRepository, Account account, decimal withdrawlAmount)
        {
            accountRepository.Setup(x => x.GetAccountById(It.Is<Guid>(y => y == account.Id))).Returns(account);
            
            sut.Execute(account, withdrawlAmount, accountRepository.Object);        
            
            accountRepository.Verify(x => x.Update(It.Is<Account>(y => y.Id == account.Id)));
        }
    }
    
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}