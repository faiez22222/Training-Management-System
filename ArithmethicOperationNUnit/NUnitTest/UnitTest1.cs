using ArithmethicOperationNUnit;

namespace NUnitTest
{
    [TestFixture]
    public class Tests
    {
        Arithmetic arithmetic;
        [SetUp]
        public void Setup()
        {
            arithmetic = new Arithmetic();  
        }

        [Test]
        public void AddTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            int result = arithmetic.Add(4 ,5);
            int actual = 9;
            Assert.That(result , Is.EqualTo(actual));
        }

        [Test]
        public void AddWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.Throws<ArgumentNullException>(() => arithmetic.Add(4, null));
        }

        [Test]
        public void SubTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            int result = arithmetic.Subtract(4, 5);
            int actual = -1;
            Assert.That(result, Is.EqualTo(actual));
        }

        [Test]
        public void SubWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.Throws<ArgumentNullException>(() => arithmetic.Add(4, null));
        }

        [Test]
        public void MultiplyTest()
        {
            Arithmetic arithmetic = new Arithmetic();
            int result = arithmetic.Multiply(4, 5);
            int actual = 20;
            Assert.That(result, Is.EqualTo(actual));
        }

        [Test]
        public void MultiplyWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.Throws<ArgumentNullException>(() => arithmetic.Add(4, null));
        }


        [Test]
        public void DivisionTest()
        {
            Arithmetic arithmetic = new Arithmetic();
           double result = arithmetic.Divide(10, 5);
            double actual = 2;
            Assert.That(result, Is.EqualTo(actual));
        }

        [Test]
        public void DevideWithNullValus()
        {
            Arithmetic arithmetic = new Arithmetic();

            Assert.Throws<ArgumentNullException>(() => arithmetic.Add(4, null));
        }

        [TearDown]
        public void Completed()
        {
            arithmetic = null;
        }
    }
}