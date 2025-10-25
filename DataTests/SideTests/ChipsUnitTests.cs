using SubHero.Data.Sides;
using SubHero.Data.Enums;

namespace SubHero.DataTests.SideTests
{
    /// <summary>
    /// Unit tests for the Chips class
    /// </summary>
    public class ChipsUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultFlavorIsCorrectTest()
        {
            Chips chips = new Chips();
            Assert.Equal(ChipType.Lays, chips.Flavor);
        }

        #endregion

        #region Price Tests

        [Fact]
        public void PriceIsCorrectTest()
        {
            Chips chips = new Chips();
            Assert.Equal(1.95m, chips.Price);
        }

        [Theory]
        [InlineData(ChipType.Lays)]
        [InlineData(ChipType.Doritos)]
        [InlineData(ChipType.Cheetos)]
        [InlineData(ChipType.SunChips)]
        [InlineData(ChipType.Pretzels)]
        public void PriceDoesNotChangeWithFlavorTest(ChipType flavor)
        {
            Chips chips = new Chips();
            chips.Flavor = flavor;
            Assert.Equal(1.95m, chips.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(ChipType.Lays, 240u)]
        [InlineData(ChipType.Doritos, 250u)]
        [InlineData(ChipType.Cheetos, 260u)]
        [InlineData(ChipType.SunChips, 210u)]
        [InlineData(ChipType.Pretzels, 180u)]
        public void CaloriesAreCorrectTest(ChipType flavor, uint expectedCalories)
        {
            Chips chips = new Chips();
            chips.Flavor = flavor;
            Assert.Equal(expectedCalories, chips.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Theory]
        [InlineData(ChipType.Lays, "Lays")]
        [InlineData(ChipType.Doritos, "Doritos")]
        [InlineData(ChipType.Cheetos, "Cheetos")]
        [InlineData(ChipType.SunChips, "Sun Chips")]
        [InlineData(ChipType.Pretzels, "Pretzels")]
        public void PreparationInformationIsCorrectTest(ChipType flavor, string expectedInfo)
        {
            Chips chips = new Chips();
            chips.Flavor = flavor;
            Assert.Contains(expectedInfo, chips.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationHasOnlyOneItemTest()
        {
            Chips chips = new Chips();
            chips.Flavor = ChipType.Doritos;

            var prepInfo = chips.PreparationInformation.ToList();
            Assert.Single(prepInfo);
            Assert.Equal("Doritos", prepInfo[0]);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            Chips chips = new Chips();
            Assert.IsAssignableFrom<IMenuItem>(chips);
        }

        [Fact]
        public void CanBeCastToSideTest()
        {
            Chips chips = new Chips();
            Assert.IsAssignableFrom<Side>(chips);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            Chips chips = new Chips();
            Assert.Equal("Chips", chips.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            Chips chips = new Chips();
            Assert.Equal("Your favorite bags of crunchy deliciousness", chips.Description);
        }

        #endregion

        #region Flavor Property Tests

        [Theory]
        [InlineData(ChipType.Lays)]
        [InlineData(ChipType.Doritos)]
        [InlineData(ChipType.Cheetos)]
        [InlineData(ChipType.SunChips)]
        [InlineData(ChipType.Pretzels)]
        public void FlavorPropertyCanBeChangedTest(ChipType flavor)
        {
            Chips chips = new Chips();
            chips.Flavor = flavor;
            Assert.Equal(flavor, chips.Flavor);
        }

        [Fact]
        public void FlavorPropertyDefaultsToLaysTest()
        {
            Chips chips = new Chips();
            Assert.Equal(ChipType.Lays, chips.Flavor);
        }

        #endregion
    }
}