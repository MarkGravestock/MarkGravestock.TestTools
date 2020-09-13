using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace MarkGravestock.TestTools
{
    public class FluentAssertionsTest
    {
        [Fact]
        public void it_can_compare_object_instances()
        {
            new Money {Amount = 50, Currency = Money.CurrencyCode.GBP}.Should().NotBeSameAs(new Money {Amount = 50, Currency = Money.CurrencyCode.GBP});
        }
        
        [Fact]
        public void it_can_compare_object_equality()
        {
            new Money {Amount = 50, Currency = Money.CurrencyCode.GBP}.Should().BeEquivalentTo(new Money {Amount = 50, Currency = Money.CurrencyCode.GBP});
        }

        [Fact]
        public void it_can_compare_object_equality_when_different()
        {
            new Money {Amount = 50, Currency = Money.CurrencyCode.GBP}.Should().NotBeEquivalentTo(new Money {Amount = 50, Currency = Money.CurrencyCode.USD});
        }

        [Fact]
        public void calculator_should_perform()
        {
            Action calculation = (() => Calculator.Add(2, 2));
            
            calculation.ExecutionTime().Should().BeLessThan(200.Milliseconds());
        }
        
        private class Money
        {
            public enum CurrencyCode
            {
                GBP,
                USD
            }

            public decimal Amount { get; set; }

            public CurrencyCode Currency { get; set; }
        }
    }
}