namespace _3_Rucksacks.Tests
{
    public class ItemTests
    {
        [Theory]
        [InlineData('a', 1)]
        [InlineData('z', 26)]
        [InlineData('A', 27)]
        [InlineData('Z', 52)]
        [InlineData('p', 16)]
        [InlineData('L', 38)]
        [InlineData('P', 42)]
        [InlineData('v', 22)]
        [InlineData('t', 20)]
        [InlineData('s', 19)]
        public void GetPriority_ShouldReturnExpected_WhenValidInput(char input, int expected)
        {
            var underTest = new Item(input);
            int result = underTest.Priority;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('*')]
        [InlineData('(')]
        [InlineData('%')]
        public void GetPriority_ShouldThrowException_WhenInputOutOfDefinedRange(char input)
        {
            var underTest = new Item(input);
            Assert.Throws<ArgumentException>(() => underTest.Priority);
        }
    }
}
