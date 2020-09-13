using FluentAssertions;
using Shouldly;
using Xunit;

namespace MarkGravestock.TestTools
{
    public class XUnitTest
    {
        [Fact]
        public void xunit_can_use_its_own_assertions()
        {
            Assert.Equal(4, Calculator.Add(1, 3));
        }
        
        [Theory]
        [InlineData(4, 3, 1)]
        public void xunit_can_use_its_own_assertions_in_a_theory(int expected, int argumentOne, int argumentTwo)
        {
            Assert.Equal(expected, Calculator.Add(argumentOne, argumentTwo));
        }

        [Fact]
        public void xunit_can_use_fluent_assertions()
        {
            Calculator.Add(1, 3).Should().Be(4);
        }

        [Fact]
        public void xunit_can_use_shouldly()
        {
            Calculator.Add(1, 4).ShouldBe(5);
        }
    }

    public static class Calculator
    {
        public static int Add(int firstArgument, int secondArgument)
        {
            return firstArgument + secondArgument;
        }
    }
}
