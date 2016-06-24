using NUnit.Framework;
using ResistorEngine;
using Moq;
namespace ResistorEngine.Tests
{
    [TestFixture]
    public class OhmValueCalculatorTests
    {
        private Mock<IBandA> _mockBandA;
        private Mock<IBandB> _mockBandB;
        private Mock<IMultiplier> _mockMultiplier;
        private Mock<ITolerance> _mockTolerance;
        private readonly string _colorPlaceHolder = "Black";

        [SetUp]
        public void Init()
        {
            _mockBandA = new Mock<IBandA>();
            _mockBandB = new Mock<IBandB>();
            _mockMultiplier = new Mock<IMultiplier>();
            _mockTolerance = new Mock<ITolerance>();
        }
        [Test, Combinatorial]
        public void AreInputsValid_Returns_False_When_Parameters_Are_NullOrEmpty(
            [Values(null, "")] string bandAColor,
            [Values(null, "")] string bandBColor,
            [Values(null, "")] string bandCColor)
        {
            //Arrange
            var sut = new OhmValueCalculator(_mockBandA.Object,_mockBandB.Object,_mockMultiplier.Object,_mockTolerance.Object);
            //Act
            //Assert
            Assert.That(sut.AreInputsValid(bandAColor, bandBColor, bandCColor, "Tolerance").Equals(false));
        }

        [Test, Combinatorial]
        public void CalculateOhmValue_Returns_0_When_InputsInValid(
         [Values(null, "")] string bandAColor,
            [Values(null, "")] string bandBColor,
            [Values(null, "")] string bandCColor)
        {
            //Arrange
            var sut = new OhmValueCalculator(_mockBandA.Object, _mockBandB.Object, _mockMultiplier.Object, _mockTolerance.Object);
            //Act
            //Assert
            Assert.That(sut.AreInputsValid(bandAColor, bandBColor, bandCColor, "Tolerance").Equals(false));
            Assert.That(sut.CalculateOhmValue(bandAColor, bandBColor, bandCColor, "Tolerance").Equals(0));
        }

        [Test]
        public void When_BandBColor_Not_Valid_Return_0()
        {
            //Arrange
            _mockBandB.Setup(x => x.IsValidColor()).Returns(false);
            var sut = new OhmValueCalculator(new BandA(), _mockBandB.Object, new Multiplier(), new Tolerance());

            //Act
            //Assert
            Assert.That(sut.CalculateOhmValue(_colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder).Equals(0));
        }

        [Test]
        public void When_BandAColor_Not_Valid_Return_0()
        {
            //Arrange
            _mockBandA.Setup(x => x.IsValidColor()).Returns(false);
            var sut = new OhmValueCalculator(_mockBandA.Object, new BandB(), new Multiplier(), new Tolerance());

            //Act
            //Assert
            Assert.That(sut.CalculateOhmValue(_colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder).Equals(0));
        }
        [Test]
        public void When_MultiplierColor_Not_Valid_Return_0()
        {
            //Arrange
            _mockMultiplier.Setup(x => x.IsValidColor()).Returns(false);
            var sut = new OhmValueCalculator(new BandA(), new BandB(), _mockMultiplier.Object, new Tolerance());

            //Act
            //Assert
            Assert.That(sut.CalculateOhmValue(_colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder).Equals(0));
        }

        [Test]
        public void When_Color_Valid_Then_GetValues_Are_Executed()
        {
            //Arrange
            _mockBandA.Setup(x => x.GetValue()).Verifiable();
            _mockBandA.Setup(x => x.IsValidColor()).Returns(true);

            _mockBandB.Setup(x => x.GetValue()).Verifiable();
            _mockBandB.Setup(x => x.IsValidColor()).Returns(true);

            _mockMultiplier.Setup(x => x.GetValue()).Verifiable();
            _mockMultiplier.Setup(x => x.IsValidColor()).Returns(true);

            var sut = new OhmValueCalculator(_mockBandA.Object, _mockBandB.Object, _mockMultiplier.Object, _mockTolerance.Object);

            //Act
            sut.CalculateOhmValue(_colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder, _colorPlaceHolder);
            
            //Assert
            _mockBandA.Verify(x => x.GetValue(), Times.Once());
            _mockBandB.Verify(x => x.GetValue(), Times.Once());
            _mockMultiplier.Verify(x => x.GetValue(), Times.Once());
        }

    }
}