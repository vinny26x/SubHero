using SubHero.Data.Entrees;
using SubHero.Data.Enums;

namespace SubHero.DataTests.EntreeTests
{
    /// <summary>
    /// Unit tests for the ItalianSub class
    /// </summary>
    public class ItalianSubUnitTests 
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.Equal(SizeType.Medium, sub.Size);
        }

        [Fact]
        public void DefaultBreadIsCorrectTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.Equal(BreadType.Hoagie, sub.Bread);
        }

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.True(sub.Salami);
            Assert.True(sub.Pepperoni);
            Assert.True(sub.Ham);
            Assert.True(sub.ProvoloneCheese);
            Assert.True(sub.CheddarCheese);
            Assert.True(sub.Lettuce);
            Assert.True(sub.Tomato);
            Assert.True(sub.ItalianDressing);
            Assert.True(sub.RoastedRedPeppers);
        }

        #endregion

        #region Constraint Tests
        [Theory]
        [InlineData(BreadType.Wheat, SizeType.Large)]     // wheat doesn't allow large
        [InlineData(BreadType.Sourdough, SizeType.Large)] // sourdough doesn't allow large
        [InlineData(BreadType.Wrap, SizeType.Small)]      // wrap only allows medium
        [InlineData(BreadType.Wrap, SizeType.Large)]      // wrap only allows medium
        public void InvalidBreadSizeCombinationsDoNotChangePropertiesTest(BreadType invalidBread, SizeType invalidSize)
        {
            ItalianSub sub = new ItalianSub();
            sub.Bread = BreadType.Hoagie;
            sub.Size = SizeType.Medium;

            // Try to set invalid combination
            sub.Bread = invalidBread;
            sub.Size = invalidSize;

            // Bread changes (because invalidBread + Medium is valid)
            // Size stays Medium (because invalidBread + invalidSize is invalid)
            Assert.Equal(invalidBread, sub.Bread);      // ← CHANGE THIS LINE from Hoagie to invalidBread
            Assert.Equal(SizeType.Medium, sub.Size);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, 7.99)] // Small
        [InlineData(SizeType.Medium, 10.99)] // Medium (base price)
        [InlineData(SizeType.Large, 12.99)] // Large
        public void PriceIsCorrectTest(SizeType size, decimal expectedPrice)
        {
            ItalianSub sub = new ItalianSub();
            sub.Size = size;
            Assert.Equal(expectedPrice, sub.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, BreadType.Hoagie, SizeType.Small, 577)]
        [InlineData(true, true, true, true, true, true, true, true, true, BreadType.Hoagie, SizeType.Medium, 1154)]
        [InlineData(true, true, true, true, true, true, true, true, true, BreadType.Hoagie, SizeType.Large, 1731)]
        [InlineData(false, false, false, false, false, false, false, false, false, BreadType.Hoagie, SizeType.Medium, 290)]
        [InlineData(true, false, true, true, true, true, true, true, true, BreadType.Hoagie, SizeType.Medium, 1004)]
        [InlineData(true, true, false, true, true, true, true, true, true, BreadType.Hoagie, SizeType.Medium, 1004)]
        [InlineData(true, true, true, false, true, true, true, true, true, BreadType.Hoagie, SizeType.Medium, 1054)]
        [InlineData(true, true, true, true, true, true, true, true, true, BreadType.Wheat, SizeType.Medium, 1124)]
        public void CaloriesAreCorrectTest(bool salami, bool pepperoni, bool ham, bool provolone, bool cheddar,
            bool lettuce, bool tomato, bool italianDressing, bool redPeppers, BreadType bread, SizeType size, uint expectedCalories)
        {
            ItalianSub sub = new ItalianSub();
            sub.Salami = salami;
            sub.Pepperoni = pepperoni;
            sub.Ham = ham;
            sub.ProvoloneCheese = provolone;
            sub.CheddarCheese = cheddar;
            sub.Lettuce = lettuce;
            sub.Tomato = tomato;
            sub.ItalianDressing = italianDressing;
            sub.RoastedRedPeppers = redPeppers;
            sub.Bread = bread;
            sub.Size = size;

            Assert.Equal(expectedCalories, sub.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            ItalianSub sub = new ItalianSub();
            sub.Size = SizeType.Large;

            Assert.Contains("Large", sub.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesBreadChangeTest()
        {
            ItalianSub sub = new ItalianSub();
            sub.Bread = BreadType.Wheat;

            Assert.Contains("Use Wheat Bread", sub.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            ItalianSub sub = new ItalianSub();
            sub.Salami = false; // Remove default ingredient

            Assert.Contains("Hold Salami", sub.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.IsAssignableFrom<IMenuItem>(sub);
        }

        [Fact]
        public void CanBeCastToEntreeTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.IsAssignableFrom<Entree>(sub);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.Equal("Italian Sub", sub.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            ItalianSub sub = new ItalianSub();
            Assert.Equal("An Italian-inspired sub with layers of savory meats and cheeses", sub.Description);
        }

        #endregion
    }
}