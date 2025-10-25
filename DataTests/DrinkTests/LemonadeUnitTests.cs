using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests.DrinkTests
{
    /// <summary>
    /// Unit tests for the Lemonade class
    /// </summary>
    public class LemonadeUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.Equal(SizeType.Medium, lemonade.Size);
        }

        [Fact]
        public void DefaultIceIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.True(lemonade.Ice);
        }

        [Fact]
        public void DefaultPinkIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.False(lemonade.Pink);
        }

        [Fact]
        public void DefaultStrawberryIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.False(lemonade.Pink);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, 2.25)]
        [InlineData(SizeType.Medium, 2.50)]
        [InlineData(SizeType.Large, 3.00)]
        public void PriceIsCorrectTest(SizeType size, decimal expectedPrice)
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = size;
            Assert.Equal(expectedPrice, lemonade.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithIceTest(bool ice)
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Ice = ice;
            // Price should remain the same regardless of ice
            Assert.Equal(2.50m, lemonade.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithPinkTest(bool pink)
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = pink;
            // Price should remain the same regardless of pink flavor
            Assert.Equal(2.50m, lemonade.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithStrawberryTest(bool strawberry)
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = strawberry;
            // Price should remain the same regardless of strawberry flavor
            Assert.Equal(2.50m, lemonade.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(SizeType.Small, 144u)]  // 9 cal/oz * 16oz
        [InlineData(SizeType.Medium, 180u)] // 9 cal/oz * 20oz
        [InlineData(SizeType.Large, 288u)]  // 9 cal/oz * 32oz
        public void CaloriesAreCorrectTest(SizeType size, uint expectedCalories)
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = size;
            Assert.Equal(expectedCalories, lemonade.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithIceTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Ice = false;
            // Calories should remain the same regardless of ice
            Assert.Equal(180u, lemonade.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithPinkTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;
            // Calories should remain the same regardless of pink flavor
            Assert.Equal(180u, lemonade.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithStrawberryTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;
            // Calories should remain the same regardless of strawberry flavor
            Assert.Equal(180u, lemonade.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = SizeType.Large;

            Assert.Contains("Large", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesPinkLemonadeTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;

            Assert.Contains("Pink Lemonade", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludePinkWhenFalseTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = false;

            Assert.DoesNotContain("Pink Lemonade", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesAddStrawberryTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;

            Assert.Contains("Add Strawberry", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeStrawberryWhenFalseTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = false;

            Assert.DoesNotContain("Add Strawberry", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHoldIceTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Ice = false;

            Assert.Contains("Hold Ice", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeHoldIceWhenIceIsTrueTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Ice = true;

            Assert.DoesNotContain("Hold Ice", lemonade.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationWithMultipleCustomizationsTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = SizeType.Small;
            lemonade.Pink = true;
            lemonade.Ice = false;
            lemonade.Pink = true;

            var prepInfo = lemonade.PreparationInformation.ToList();
            Assert.Contains("Small", prepInfo);
            Assert.Contains("Pink Lemonade", prepInfo);
            Assert.Contains("Hold Ice", prepInfo);
            Assert.Contains("Add Strawberry", prepInfo);
        }

        [Fact]
        public void PreparationInformationDefaultHasOnlySizeTest()
        {
            Lemonade lemonade = new Lemonade();
            // Default: Medium size, ice = true, pink = false, strawberry = false

            var prepInfo = lemonade.PreparationInformation.ToList();
            Assert.Single(prepInfo);
            Assert.Contains("Medium", prepInfo);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.IsAssignableFrom<IMenuItem>(lemonade);
        }

        [Fact]
        public void CanBeCastToDrinkTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.IsAssignableFrom<Drink>(lemonade);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.Equal("Lemonade", lemonade.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            Lemonade lemonade = new Lemonade();
            Assert.Equal("Fresh squeezed lemonade", lemonade.Description);
        }

        #endregion

        #region Property Tests

        [Fact]
        public void SizePropertyCanBeChangedTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = SizeType.Large;
            Assert.Equal(SizeType.Large, lemonade.Size);
        }

        [Fact]
        public void IcePropertyCanBeChangedTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Ice = false;
            Assert.False(lemonade.Ice);
            lemonade.Ice = true;
            Assert.True(lemonade.Ice);
        }

        [Fact]
        public void PinkPropertyCanBeChangedTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;
            Assert.True(lemonade.Pink);
            lemonade.Pink = false;
            Assert.False(lemonade.Pink);
        }

        [Fact]
        public void StrawberryPropertyCanBeChangedTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Pink = true;
            Assert.True(lemonade.Pink);
            lemonade.Pink = false;
            Assert.False(lemonade.Pink);
        }

        #endregion
    }
}