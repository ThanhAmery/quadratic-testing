namespace QuadraticEquation
{
    using NUnit.Framework;

    public class Tests
    {
        private QuadraticEquation quadraticEquation; 

        [SetUp]
        public void Setup()
        {
            quadraticEquation = new QuadraticEquation(); 
        }

        [TestCase(0, 2, -4, ExpectedResult = "2")]
        [TestCase(1, -3, 2, ExpectedResult = "The quadratic has two solutions: 2 and 1")]
        [TestCase(1, -2, 1, ExpectedResult = "1")]
        [TestCase(1, 0, 1, ExpectedResult = "No real roots!")]
        public string Test_CalculateQuadraticEquation(int a, int b, int c)
        {
            return quadraticEquation.CalculateQuadraticEquation(a, b, c);
        }

        [Test]
        public void Test_RealRoots()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, -3, 2);
            Assert.AreEqual("The quadratic has two solutions: 2 and 1", result);
        }

        [Test]
        public void Test_OneRealRoot()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, -2, 1);
            Assert.AreEqual("1", result);
        }

        [Test]
        public void Test_NoRealRoots()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, 0, 1);
            Assert.AreEqual("No real roots!", result);
        }

       

        [Test]
        public void Test_LinearEquation()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(0, 2, -4);
            Assert.AreEqual("2", result);
        }

        [Test]
        public void Test_DivisionByZero_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => quadraticEquation.CalculateQuadraticEquation(0, 0, 5));
            Assert.That(ex.Message, Is.EqualTo("Invalid result: expected return!"));
        }

        [Test]
        public void Test_NoValidEquation_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => quadraticEquation.CalculateQuadraticEquation(0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("No valid equation!"));
        }
    }

}