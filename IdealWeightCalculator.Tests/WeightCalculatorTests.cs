using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Reflection.Metadata;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {

        //public TestContext TestContext { get; set; }

        //[ClassInitialize]
        //public static void classInitialize(TestContext context)
        //{
        //    Console.WriteLine("In Class Intializer");
        //}

        //[ClassCleanup]
        //public static void classCleanup()
        //{
        //}

        //[TestInitialize]
        //public static void testInitialize()
        //{
        //    Console.WriteLine("In Test Intializer");
        //}

        //[TestCleanup]
        //public static void testCleanup()
        //{
        //    Console.WriteLine("In class CleanUp");
        //}

        [TestMethod]
        [Description("This test is about checking if the ideal body weight " +
            "Of a man with 180 CM in height is equals to 72.5")]
        [Owner("SafaAlatrech")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWight_isSexM_Height_180_Return_72_5()
        {

            // Arrange : Preparez les données nécessaires pour le test
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'm',
                Height = 180

            };

            // Act : Applez la méthode que je veux tester 
            double actual = sut.GetIdealBodyWeight();
            double excepted = 72.5;

            // Assert : Véifier que le résultat réel correspand le résultat attendu
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        [Description("This test is about checking if the ideal body weight " +
            "Of a woman with 160 CM in height is equals to 72.5")]
        [Owner("SafaAlatrech")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_Female_ReturnsCorrectValue()
        {
            // Arrange
            var calculator = new WeightCalculator();
            calculator.Height = 160;
            calculator.Sex = 'w';

            // Act
            var result = calculator.GetIdealBodyWeight();

            // Assert
            Assert.AreEqual(55, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("This test is about checking UnkownSex And Throw Excepetion")]
        [Owner("SafaAlatrech")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_UnknownSex_ThowExcepetion()
        {
            // Arrange
            var calculator = new WeightCalculator();
            calculator.Height = 170;
            calculator.Sex = 'x';

            // Act
            var result = calculator.GetIdealBodyWeight();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [Description("This test is about using some Assert methods")]
        [Owner("SafaAlatrech")]
        [Priority(2)]
        [TestCategory("AssertMethods")]
        public void Assert_Tests()
        {
            Assert.AreEqual(100, 90 + 10);
            //Assert.AreNotEqual(100, 90);

            //WeightCalculator calc1 = new WeightCalculator();
            //WeightCalculator calc2 = calc1;
            //Assert.AreSame(calc1, calc2);

            //WeightCalculator calculator = new WeightCalculator();
            //Assert.IsInstanceOfType(calculator, typeof(WeightCalculator));
            //calculator = null;
            //Assert.IsNull(calculator);

        }

        [TestMethod]
        [Description("This test is about using some Assert methods")]
        [Owner("SafaAlatrech")]
        [Priority(2)]
        [TestCategory("AssertMethods")]
        public void StringAssertTests()
        {
            string name = "safa";
            //StringAssert.Contains(name, "afa");
            StringAssert.EndsWith(name, "afa");

        }

        [TestMethod]
        [Description("This test is about using some string Assert methods")]
        [Owner("SafaAlatrech")]
        [Priority(2)]
        [TestCategory("StringAssertMethods")]
        [Ignore]
        public void CollectionAssertTests()
        {
            List<string> names = new List<string>()
            {
                "safa",
                "marwa",
                "Isra",
                "Loujayen"
            };
            CollectionAssert.AllItemsAreNotNull(names);
            CollectionAssert.Contains(names, "safa");
            CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));
        }

        [TestMethod]
        [Description("This test is about using some Fluent Assert methods")]
        [Owner("SafaAlatrech")]
        [Priority(3)]
        [TestCategory("FluentAssertMethods")]
        [Timeout(3000)]
        public void FlentAssertionsTests()
        {
            string name = "safa";

            name.Should().StartWith("s").And.EndWith("a");

            int number = 10;
            number.Should().BeGreaterThan(8);
            number.Should().BeLessThanOrEqualTo(10);

            List<string> values = new List<string>()
            {
                "Ahmed",
                "Yassine"
            };

            values.Should().HaveCount(2);
            values.Should().NotBeEmpty();


        }


        [TestMethod]
        [Description("Test ideal body weight from data source")]
        [Owner("Safa Alatrech")]
        [Priority(3)]
        public void GetIdealBodyWeightFromDataSource_WthGoodInputs_Returns_Correct_Results()
        {
            //Arrange
            WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository());

            //Act
            List<double> actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expeceted = { 62.5, 62.75, 74 };


            //Assert 
            CollectionAssert.AreEqual(expeceted, actual);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_Moq()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                 new WeightCalculator {Sex='w', Height=175},
                new WeightCalculator  {Sex='m', Height=167},

            };

            Mock<IDataRepository> repository = new Mock<IDataRepository>();

            repository.Setup(w => w.GetWeights()).Returns(weights);

            WeightCalculator weightCalculator = new WeightCalculator(repository.Object);
            var actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expeceted =
            {
                62.5,
                62.75
            };

            actual.Should().BeEquivalentTo(expeceted);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_FakeItEasy()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                 new WeightCalculator {Sex='w', Height=175},
                new WeightCalculator  {Sex='m', Height=167},

            };

            IDataRepository repository = A.Fake<IDataRepository>();

            //repository.Setup(w => w.GetWeights()).Returns(weights);
            A.CallTo(() => repository.GetWeights()).Returns(weights);

            WeightCalculator weightCalculator = new WeightCalculator(repository);
            var actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expeceted =
            {
                62.5,
                62.75
            };

            actual.Should().BeEquivalentTo(expeceted);
        }

        [DataTestMethod]
        [DataRow(175, 'w', 62.5)]
        [DataRow(167, 'm', 62.75)]
        [DataRow(182, 'm', 74)]
        public void Working_with_Data_Driven_Tests(double height, char sex, double expeceted)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Sex = sex

            };

            var actual = weightCalculator.GetIdealBodyWeight();

            actual.Should().Be(expeceted);
        }

        public static List<object[]> TestCases() 
        {
            return new List<object[]>
            {
                new object[] {175,'w',62.5},
                new object[] {167,'m',62.75},
                new object[] {182,'m',74}
            };
        }

}


}