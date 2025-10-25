using SubHero.Data.Enums;
using SubHero.Data.Sides;

namespace SubHero.DataTests.SideTests
{
    /// <summary>
    /// Unit tests for the Apple class
    /// </summary>
    public class AppleUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSlicedIsFalseTest()
        {
            Apple apple = new Apple();
            Assert.False(apple.Sliced);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(false, 1.25)]
        [InlineData(true, 1.75)]
        public void PriceIsCorrectTest(bool sliced, decimal expectedPrice)
        {
            Apple apple = new Apple();
            apple.Sliced = sliced;
            Assert.Equal(expectedPrice, apple.Price);
        }

        #endregion

        #region Calories Tests

        [Fact]
        public void CaloriesAreCorrectTest()
        {
            Apple apple = new Apple();
            Assert.Equal(100u, apple.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithSlicingTest()
        {
            Apple apple = new Apple();
            apple.Sliced = true;
            Assert.Equal(100u, apple.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationEmptyWhenNotSlicedTest()
        {
            Apple apple = new Apple();
            apple.Sliced = false;
            Assert.Empty(apple.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesSlicedWhenSlicedTest()
        {
            Apple apple = new Apple();
            apple.Sliced = true;
            Assert.Contains("Sliced", apple.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            Apple apple = new Apple();
            Assert.IsAssignableFrom<IMenuItem>(apple);
        }

        [Fact]
        public void CanBeCastToSideTest()
        {
            Apple apple = new Apple();
            Assert.IsAssignableFrom<Side>(apple);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            Apple apple = new Apple();
            Assert.Equal("Apple", apple.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            Apple apple = new Apple();
            Assert.Equal("Honeycrisp apple", apple.Description);
        }

        #endregion
    }
}