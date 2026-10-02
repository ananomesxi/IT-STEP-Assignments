namespace MovieTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // AAA Arrangement, Act, Assert

            // arrange
            int a = 5;
            int b = 10;

            // act
            int sum = a + b;

            // assert

            Assert.Equal(15, sum);
        }
    }
}
