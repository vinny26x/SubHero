using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests.DrinkTests
{
    /// <summary>
    /// Unit tests for the FountainDrink class
    /// </summary>
    public class FountainDrinkUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.Equal(SizeType.Medium, drink.Size);
        }

        [Fact]
        public void DefaultFlavorIsCorrectTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.Equal(SodaType.Coke, drink.Flavor);
        }

        [Fact]
        public void DefaultIceIsCorrectTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.True(drink.Ice);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, 1.75)]
        [InlineData(SizeType.Medium, 2.00)]
        [InlineData(SizeType.Large, 2.50)]
        public void PriceIsCorrectTest(SizeType size, decimal expectedPrice)
        {
            FountainDrink drink = new FountainDrink();
            drink.Size = size;
            Assert.Equal(expectedPrice, drink.Price);
        }

        [Theory]
        [InlineData(SodaType.Coke)]
        [InlineData(SodaType.CokeZero)]
        [InlineData(SodaType.OrangeFanta)]
        [InlineData(SodaType.MountainDew)]
        [InlineData(SodaType.DrPepper)]
        public void PriceDoesNotChangeWithFlavorTest(SodaType flavor)
        {
            FountainDrink drink = new FountainDrink();
            drink.Flavor = flavor;
            // Price should remain the same regardless of flavor
            Assert.Equal(2.00m, drink.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithIceTest(bool ice)
        {
            FountainDrink drink = new FountainDrink();
            drink.Ice = ice;
            // Price should remain the same regardless of ice
            Assert.Equal(2.00m, drink.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(SodaType.Coke, SizeType.Small, 192u)]      // 12 cal/oz * 16oz
        [InlineData(SodaType.Coke, SizeType.Medium, 240u)]     // 12 cal/oz * 20oz
        [InlineData(SodaType.Coke, SizeType.Large, 384u)]      // 12 cal/oz * 32oz
        [InlineData(SodaType.CokeZero, SizeType.Small, 0u)]    // 0 cal/oz * 16oz
        [InlineData(SodaType.CokeZero, SizeType.Medium, 0u)]   // 0 cal/oz * 20oz
        [InlineData(SodaType.CokeZero, SizeType.Large, 0u)]    // 0 cal/oz * 32oz
        [InlineData(SodaType.OrangeFanta, SizeType.Medium, 260u)] // 13 cal/oz * 20oz
        [InlineData(SodaType.MountainDew, SizeType.Medium, 280u)] // 14 cal/oz * 20oz
        [InlineData(SodaType.DrPepper, SizeType.Medium, 260u)]    // 13 cal/oz * 20oz
        public void CaloriesAreCorrectTest(SodaType flavor, SizeType size, uint expectedCalories)
        {
            FountainDrink drink = new FountainDrink();
            drink.Flavor = flavor;
            drink.Size = size;
            Assert.Equal(expectedCalories, drink.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithIceTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Ice = false;
            // Calories should remain the same regardless of ice
            Assert.Equal(240u, drink.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Size = SizeType.Large;

            Assert.Contains("Large", drink.PreparationInformation);
        }

        [Theory]
        [InlineData(SodaType.Coke, "Coke")]
        [InlineData(SodaType.CokeZero, "Coke Zero")]
        [InlineData(SodaType.OrangeFanta, "Orange Fanta")]
        [InlineData(SodaType.MountainDew, "Mountain Dew")]
        [InlineData(SodaType.DrPepper, "Dr Pepper")]
        public void PreparationInformationIncludesFlavorTest(SodaType flavor, string expectedInfo)
        {
            FountainDrink drink = new FountainDrink();
            drink.Flavor = flavor;
            Assert.Contains(expectedInfo, drink.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHoldIceWhenIceIsFalseTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Ice = false;

            Assert.Contains("Hold Ice", drink.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeHoldIceWhenIceIsTrueTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Ice = true;

            Assert.DoesNotContain("Hold Ice", drink.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationWithMultipleCustomizationsTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Size = SizeType.Small;
            drink.Flavor = SodaType.MountainDew;
            drink.Ice = false;

            var prepInfo = drink.PreparationInformation.ToList();
            Assert.Contains("Small", prepInfo);
            Assert.Contains("Mountain Dew", prepInfo);
            Assert.Contains("Hold Ice", prepInfo);
        }

        [Fact]
        public void PreparationInformationDefaultTest()
        {
            FountainDrink drink = new FountainDrink();
            // Default: Medium size, Coke flavor, ice = true

            var prepInfo = drink.PreparationInformation.ToList();
            Assert.Equal(2, prepInfo.Count);
            Assert.Contains("Medium", prepInfo);
            Assert.Contains("Coke", prepInfo);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.IsAssignableFrom<IMenuItem>(drink);
        }

        [Fact]
        public void CanBeCastToDrinkTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.IsAssignableFrom<Drink>(drink);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.Equal("Fountain Drink", drink.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            FountainDrink drink = new FountainDrink();
            Assert.Equal("Standard soda from the fountain", drink.Description);
        }

        #endregion

        #region Property Tests

        [Fact]
        public void SizePropertyCanBeChangedTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Size = SizeType.Large;
            Assert.Equal(SizeType.Large, drink.Size);
        }

        [Theory]
        [InlineData(SodaType.Coke)]
        [InlineData(SodaType.CokeZero)]
        [InlineData(SodaType.OrangeFanta)]
        [InlineData(SodaType.MountainDew)]
        [InlineData(SodaType.DrPepper)]
        public void FlavorPropertyCanBeChangedTest(SodaType flavor)
        {
            FountainDrink drink = new FountainDrink();
            drink.Flavor = flavor;
            Assert.Equal(flavor, drink.Flavor);
        }

        [Fact]
        public void IcePropertyCanBeChangedTest()
        {
            FountainDrink drink = new FountainDrink();
            drink.Ice = false;
            Assert.False(drink.Ice);
            drink.Ice = true;
            Assert.True(drink.Ice);
        }

        #endregion
    }
}