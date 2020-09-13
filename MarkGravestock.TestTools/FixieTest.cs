using FluentAssertions;

namespace MarkGravestock.TestTools
{
    public class FixieTests
    {
        public void ShouldAdd()
        {
            Calculator.Add(2, 3).Should().Be(5);
        }

        public void ShouldSubtract()
        {
            Calculator.Add(5, 3).Should().Be(8);
        }
    }
}