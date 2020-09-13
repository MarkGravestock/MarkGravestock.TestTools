using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace MarkGravestock.TestTools
{
    public class AutoFixtureTest
    {
        [Fact]
        public void autofixture_can_create_anonymous_variables()
        {
            var fixture = new Fixture();

            var argumentOne = fixture.Create<int>();
            var argumentTwo = fixture.Create<int>();

            var expected = argumentOne + argumentTwo;
            
            Calculator.Add(argumentOne, argumentTwo).Should().Be(expected);
        }

        [Theory, AutoData]
        public void xunit_integration_can_reduce_boilerplate_creating_anonymous_variables(int argumentOne, int argumentTwo)
        {
            var expected = argumentOne + argumentTwo;
            
            Calculator.Add(argumentOne, argumentTwo).Should().Be(expected);
        }
    }
}