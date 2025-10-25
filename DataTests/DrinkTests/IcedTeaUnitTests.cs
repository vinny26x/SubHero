using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests.DrinkTests
{
    /// <summary>
    /// Unit tests for the IcedTea class
    /// </summary>
    public class IcedTeaUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.Equal(SizeType.Medium, tea.Size);
        }

        [Fact]
        public void DefaultIceIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.True(tea.Ice);
        }

        [Fact]
        public void DefaultSweetIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.True(tea.Sweet);
        }

        [Fact]
        public void DefaultLemonIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.False(tea.Lemon);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, 2.00)]
        [InlineData(SizeType.Medium, 2.25)]
        [InlineData(SizeType.Large, 2.75)]
        public void PriceIsCorrectTest(SizeType size, decimal expectedPrice)
        {
            IcedTea tea = new IcedTea();
            tea.Size = size;
            Assert.Equal(expectedPrice, tea.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithSweetnessTest(bool sweet)
        {
            IcedTea tea = new IcedTea();
            tea.Sweet = sweet;
            // Price should remain the same regardless of sweetness
            Assert.Equal(2.25m, tea.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithIceTest(bool ice)
        {
            IcedTea tea = new IcedTea();
            tea.Ice = ice;
            // Price should remain the same regardless of ice
            Assert.Equal(2.25m, tea.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PriceDoesNotChangeWithLemonTest(bool lemon)
        {
            IcedTea tea = new IcedTea();
            tea.Lemon = lemon;
            // Price should remain the same regardless of lemon
            Assert.Equal(2.25m, tea.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, SizeType.Small, 96u)]   // Sweet tea: 6 cal/oz * 16oz
        [InlineData(true, SizeType.Medium, 120u)] // Sweet tea: 6 cal/oz * 20oz
        [InlineData(true, SizeType.Large, 192u)]  // Sweet tea: 6 cal/oz * 32oz
        [InlineData(false, SizeType.Small, 0u)]   // Unsweetened: 0 calories
        [InlineData(false, SizeType.Medium, 0u)]  // Unsweetened: 0 calories
        [InlineData(false, SizeType.Large, 0u)]   // Unsweetened: 0 calories
        public void CaloriesAreCorrectTest(bool sweet, SizeType size, uint expectedCalories)
        {
            IcedTea tea = new IcedTea();
            tea.Sweet = sweet;
            tea.Size = size;
            Assert.Equal(expectedCalories, tea.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithIceTest()
        {
            IcedTea tea = new IcedTea();
            tea.Ice = false;
            // Calories should remain the same regardless of ice
            Assert.Equal(120u, tea.Calories);
        }

        [Fact]
        public void CaloriesDoNotChangeWithLemonTest()
        {
            IcedTea tea = new IcedTea();
            tea.Lemon = true;
            // Calories should remain the same regardless of lemon
            Assert.Equal(120u, tea.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            IcedTea tea = new IcedTea();
            tea.Size = SizeType.Large;

            Assert.Contains("Large", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesUnsweetenedTest()
        {
            IcedTea tea = new IcedTea();
            tea.Sweet = false;

            Assert.Contains("Unsweetened", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeUnsweetenedWhenSweetTest()
        {
            IcedTea tea = new IcedTea();
            tea.Sweet = true;

            Assert.DoesNotContain("Unsweetened", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHoldIceTest()
        {
            IcedTea tea = new IcedTea();
            tea.Ice = false;

            Assert.Contains("Hold Ice", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeHoldIceWhenIceIsTrueTest()
        {
            IcedTea tea = new IcedTea();
            tea.Ice = true;

            Assert.DoesNotContain("Hold Ice", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesAddLemonTest()
        {
            IcedTea tea = new IcedTea();
            tea.Lemon = true;

            Assert.Contains("Add Lemon", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationDoesNotIncludeAddLemonWhenLemonIsFalseTest()
        {
            IcedTea tea = new IcedTea();
            tea.Lemon = false;

            Assert.DoesNotContain("Add Lemon", tea.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationWithMultipleCustomizationsTest()
        {
            IcedTea tea = new IcedTea();
            tea.Size = SizeType.Small;
            tea.Sweet = false;
            tea.Ice = false;
            tea.Lemon = true;

            var prepInfo = tea.PreparationInformation.ToList();
            Assert.Contains("Small", prepInfo);
            Assert.Contains("Unsweetened", prepInfo);
            Assert.Contains("Hold Ice", prepInfo);
            Assert.Contains("Add Lemon", prepInfo);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            IcedTea tea = new IcedTea();
            Assert.IsAssignableFrom<IMenuItem>(tea);
        }

        [Fact]
        public void CanBeCastToDrinkTest()
        {
            IcedTea tea = new IcedTea();
            Assert.IsAssignableFrom<Drink>(tea);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.Equal("Iced Tea", tea.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            IcedTea tea = new IcedTea();
            Assert.Equal("Freshly brewed iced tea with choice of sweetness", tea.Description);
        }

        #endregion

        #region Property Tests

        [Fact]
        public void SizePropertyCanBeChangedTest()
        {
            IcedTea tea = new IcedTea();
            tea.Size = SizeType.Large;
            Assert.Equal(SizeType.Large, tea.Size);
        }

        [Fact]
        public void IcePropertyCanBeChangedTest()
        {
            IcedTea tea = new IcedTea();
            tea.Ice = false;
            Assert.False(tea.Ice);
            tea.Ice = true;
            Assert.True(tea.Ice);
        }

        [Fact]
        public void SweetPropertyCanBeChangedTest()
        {
            IcedTea tea = new IcedTea();
            tea.Sweet = false;
            Assert.False(tea.Sweet);
            tea.Sweet = true;
            Assert.True(tea.Sweet);
        }

        [Fact]
        public void LemonPropertyCanBeChangedTest()
        {
            IcedTea tea = new IcedTea();
            tea.Lemon = true;
            Assert.True(tea.Lemon);
            tea.Lemon = false;
            Assert.False(tea.Lemon);
        }

        #endregion
    }
}