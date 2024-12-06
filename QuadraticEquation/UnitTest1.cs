namespace QuadraticEquation
{
    using NUnit.Framework;

    [TestFixture] //đánh dấu đây là một bộ các unit test.
    public class Tests
    {
        private QuadraticEquation quadraticEquation; 

        [SetUp]
        public void Setup()
        {
            quadraticEquation = new QuadraticEquation(); 
        }

        [TestCase(0, 2, -4, ExpectedResult = "2")]
        [TestCase(1, 3, 2, ExpectedResult = "The quadratic has two solutions: 2 and 1")]
        [TestCase(1, -2, 1, ExpectedResult = "1")]
        [TestCase(1, 0, 1, ExpectedResult = "No real roots!")]
        [TestCase(-1, -3, -2, ExpectedResult = "The quadratic has two solutions: -2 and -1")]
        [TestCase(0, 0, 5, ExpectedResult = "Invalid result: expected return!")]



		//Test hàm với bộ data tách ra, Kiểm thử nhiều trường hợp với TestCase
		public string Test_CalculateQuadraticEquation(int a, int b, int c)
        {
            return quadraticEquation.CalculateQuadraticEquation(a, b, c);
        }

        [Test] //TH: PT có 2 nghiệm phân biệt 
        public void Test_RealRoots()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, -3, 2);
            Assert.AreEqual("The quadratic has two solutions: 2 and 1", result);
        }

        [Test]  //TH: 3 hệ số đều âm có 2 nghiệm phân biệt 
        public void Test_NegativeCoefficients_TwoRealRoots()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(-1, -3, -2);
            Assert.AreEqual("The quadratic has two solutions: -2 and -1", result);
        }

        [Test] //TH: PT có 1 nghiệm kép
		public void Test_OneRealRoot()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, -2, 1);
            Assert.AreEqual("1", result);
        }

        [Test] //TH: PT vô nghiệm
		public void Test_NoRealRoots()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(1, 0, 1);
            Assert.AreEqual("No real roots!", result);
        }

       

        [Test] //TH: PT có nghiệm kép
		public void Test_LinearEquation()
        {
            string result = quadraticEquation.CalculateQuadraticEquation(0, 2, -4);
            Assert.AreEqual("2", result);
        }

		[Test] //TH: PT không hợp lệ, 2 hệ số a và b đều bằng 0
		public void Test_DivisionByZero_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => quadraticEquation.CalculateQuadraticEquation(0, 0, 5));
            Assert.That(ex.Message, Is.EqualTo("Invalid result: expected return!"));
        }

        [Test] //TH: PT không hợp lệ, 3 hệ số đều bằng 0
		public void Test_NoValidEquation_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => quadraticEquation.CalculateQuadraticEquation(0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("No valid equation!"));
        }
    }

}