
using Xunit;

namespace ModernCSharpGuidelines
{
    // ⚖ DO use Range to access element subsets when available
    // ⚖ DO use the Index (^x) to access elements from the end when available
    public class RangeAndIndex
    {
        [Fact]
        public void SampleIndexOperatorFromEnd()
        {
            // GUIDELINE
            // ⚖ DO favor target type new over var when invoking constructors
            int[] array = new[] { 1, 2, 3, 4, 5, 42};
            int fourtyTwo = array[^1];
            Assert.Equal(42, fourtyTwo);
        }

        [Fact]
        public void SampleRangeOperatorFromEnd()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 42 };
            int[]? lastTwo = array[^2..^0];
            Assert.Equal((5, 42), (lastTwo[0], lastTwo[1]));
        }
    }
}
