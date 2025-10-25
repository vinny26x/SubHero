using SubHero.Data.Entrees;
using SubHero.Data.Enums;

namespace SubHero.DataTests.EntreeTests
{
    /// <summary>
    /// Unit tests for the VeggieSandwich class
    /// </summary>
    public class VeggieSandwichUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.Equal(SizeType.Medium, sandwich.Size);
        }

        [Fact]
        public void DefaultBreadIsCorrectTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.Equal(BreadType.Sourdough, sandwich.Bread);
        }

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.True(sandwich.ProvoloneCheese);
            Assert.True(sandwich.CreamCheese);
            Assert.True(sandwich.Avocado);
            Assert.True(sandwich.Lettuce);
            Assert.True(sandwich.Tomato);
            Assert.True(sandwich.Cucumber);
            Assert.True(sandwich.ChipotleMayo);
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
            var sandwich = new VeggieSandwich();
            sandwich.Bread = BreadType.Sourdough;
            sandwich.Size = SizeType.Medium;

            // Attempt sequence: valid bread change, then invalid size change
            sandwich.Bread = invalidBread;   // valid with Medium → persists
            sandwich.Size = invalidSize;    // invalid for that bread → rejected

            // Expect: bread remains last valid bread; size remains Medium
            Assert.Equal(invalidBread, sandwich.Bread);   // ← change this line
            Assert.Equal(SizeType.Medium, sandwich.Size);
        }



        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, 4.99)] // Small
        [InlineData(SizeType.Medium, 7.99)] // Medium (base price)
        [InlineData(SizeType.Large, 9.99)] // Large
        public void PriceIsCorrectTest(SizeType size, decimal expectedPrice)
        {
            VeggieSandwich sandwich = new VeggieSandwich();

            // Need to change to Hoagie for Large size (Sourdough doesn't allow Large)
            if (size == SizeType.Large)
            {
                sandwich.Bread = BreadType.Hoagie;
            }

            sandwich.Size = size;
            Assert.Equal(expectedPrice, sandwich.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, true, true, true, BreadType.Sourdough, SizeType.Small, 373)]
        [InlineData(true, true, true, true, true, true, true, BreadType.Sourdough, SizeType.Medium, 746)]
        [InlineData(true, true, true, true, true, true, true, BreadType.Sourdough, SizeType.Large, 1119)]
        [InlineData(false, false, false, false, false, false, false, BreadType.Sourdough, SizeType.Medium, 250)]
        [InlineData(true, false, true, true, true, true, true, BreadType.Sourdough, SizeType.Medium, 621)]
        [InlineData(true, true, false, true, true, true, true, BreadType.Sourdough, SizeType.Medium, 546)]
        [InlineData(true, true, true, false, true, true, true, BreadType.Sourdough, SizeType.Medium, 731)]
        [InlineData(true, true, true, true, true, true, true, BreadType.Wheat, SizeType.Medium, 746)]
        public void CaloriesAreCorrectTest(bool provolone, bool cream, bool avocado, bool lettuce, bool tomato,
            bool cucumber, bool chipotleMayo, BreadType bread, SizeType size, uint expectedCalories)
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            sandwich.ProvoloneCheese = provolone;
            sandwich.CreamCheese = cream;
            sandwich.Avocado = avocado;
            sandwich.Lettuce = lettuce;
            sandwich.Tomato = tomato;
            sandwich.Cucumber = cucumber;
            sandwich.ChipotleMayo = chipotleMayo;
            sandwich.Bread = bread;
            sandwich.Size = size;

            Assert.Equal(expectedCalories, sandwich.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            sandwich.Bread = BreadType.Hoagie;  // ← ADD THIS LINE (Hoagie allows Large)
            sandwich.Size = SizeType.Large;

            Assert.Contains("Large", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesBreadChangeTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            sandwich.Bread = BreadType.Wheat;

            Assert.Contains("Use Wheat Bread", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            sandwich.ProvoloneCheese = false; // Remove default ingredient

            Assert.Contains("Hold Provolone Cheese", sandwich.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.IsAssignableFrom<IMenuItem>(sandwich);
        }

        [Fact]
        public void CanBeCastToEntreeTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.IsAssignableFrom<Entree>(sandwich);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.Equal("Veggie Sandwich", sandwich.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            VeggieSandwich sandwich = new VeggieSandwich();
            Assert.Equal("A vegetarian sandwich piled high with crisp veggies and two cheeses", sandwich.Description);
        }

        #endregion
    }
}