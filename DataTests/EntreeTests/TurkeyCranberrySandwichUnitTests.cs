using SubHero.Data.Entrees;
using SubHero.Data.Enums;

namespace SubHero.DataTests.EntreeTests
{
    /// <summary>
    /// Unit tests for the TurkeyCranberrySandwich class
    /// </summary>
    public class TurkeyCranberrySandwichUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.Equal(SizeType.Medium, sandwich.Size);
        }

        [Fact]
        public void DefaultBreadIsCorrectTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.Equal(BreadType.Wheat, sandwich.Bread);
        }

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.True(sandwich.Turkey);
            Assert.True(sandwich.CranberrySauce);
            Assert.True(sandwich.CreamCheese);
            Assert.True(sandwich.RedOnion);
            Assert.False(sandwich.ProvoloneCheese); // Optional ingredient
        }

        #endregion

        #region Constraint Tests

        [Theory]
        [InlineData(BreadType.Wheat, SizeType.Large)] // Invalid: wheat doesn't allow large
        [InlineData(BreadType.Sourdough, SizeType.Large)] // Invalid: sourdough doesn't allow large
        [InlineData(BreadType.Wrap, SizeType.Small)] // Invalid: wrap only allows medium
        [InlineData(BreadType.Wrap, SizeType.Large)] // Invalid: wrap only allows medium
        public void InvalidBreadSizeCombinationsDoNotChangePropertiesTest(BreadType invalidBread, SizeType invalidSize)
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Bread = BreadType.Wheat;
            sandwich.Size = SizeType.Medium;

            // Try to set invalid combination
            sandwich.Bread = invalidBread;
            sandwich.Size = invalidSize;

            // Should remain unchanged
            Assert.Equal(invalidBread, sandwich.Bread);
            Assert.Equal(SizeType.Medium, sandwich.Size);
        }

        [Theory]
        [InlineData(BreadType.Hoagie, SizeType.Small)]
        [InlineData(BreadType.Hoagie, SizeType.Medium)]
        [InlineData(BreadType.Hoagie, SizeType.Large)]
        [InlineData(BreadType.Wheat, SizeType.Small)]
        [InlineData(BreadType.Wheat, SizeType.Medium)]
        [InlineData(BreadType.Sourdough, SizeType.Small)]
        [InlineData(BreadType.Sourdough, SizeType.Medium)]
        public void ValidBreadSizeCombinationsChangePropertiesTest(BreadType validBread, SizeType validSize)
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Bread = validBread;
            sandwich.Size = validSize;

            Assert.Equal(validBread, sandwich.Bread);
            Assert.Equal(validSize, sandwich.Size);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(SizeType.Small, false, 5.49)] // Small, no both cheeses
        [InlineData(SizeType.Medium, false, 8.49)] // Medium, no both cheeses
        [InlineData(SizeType.Large, false, 10.49)] // Large, no both cheeses (if hoagie bread)
        [InlineData(SizeType.Small, true, 6.49)] // Small, both cheeses
        [InlineData(SizeType.Medium, true, 9.49)] // Medium, both cheeses
        [InlineData(SizeType.Large, true, 11.49)] // Large, both cheeses (if hoagie bread)
        public void PriceIsCorrectTest(SizeType size, bool bothCheeses, decimal expectedPrice)
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            if (size == SizeType.Large)
            {
                sandwich.Bread = BreadType.Hoagie; // Need hoagie for large size
            }
            sandwich.Size = size;
            sandwich.ProvoloneCheese = bothCheeses; // Both cheeses when true (cream cheese is default)

            Assert.Equal(expectedPrice, sandwich.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, false, BreadType.Wheat, SizeType.Small, 245)]
        [InlineData(true, true, true, true, false, BreadType.Wheat, SizeType.Medium, 490)]
        [InlineData(true, true, true, true, false, BreadType.Hoagie, SizeType.Large, 735)]
        [InlineData(false, false, false, false, false, BreadType.Wheat, SizeType.Medium, 250)]
        [InlineData(true, false, true, true, false, BreadType.Wheat, SizeType.Medium, 415)]
        [InlineData(true, true, false, true, false, BreadType.Wheat, SizeType.Medium, 365)]
        [InlineData(true, true, true, false, false, BreadType.Wheat, SizeType.Medium, 475)]
        [InlineData(true, true, true, true, true, BreadType.Wheat, SizeType.Medium, 590)]
        public void CaloriesAreCorrectTest(bool turkey, bool cranberry, bool cream, bool redOnion, bool provolone,
            BreadType bread, SizeType size, uint expectedCalories)
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Turkey = turkey;
            sandwich.CranberrySauce = cranberry;
            sandwich.CreamCheese = cream;
            sandwich.RedOnion = redOnion;
            sandwich.ProvoloneCheese = provolone;
            sandwich.Bread = bread;
            sandwich.Size = size;

            Assert.Equal(expectedCalories, sandwich.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesSizeTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Size = SizeType.Large;
            sandwich.Bread = BreadType.Hoagie; // Need hoagie for large

            Assert.Contains("Large", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesBreadChangeTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Bread = BreadType.Sourdough;

            Assert.Contains("Use Sourdough Bread", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesAddedIngredientsTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.ProvoloneCheese = true; // Add non-default ingredient

            Assert.Contains("Add Provolone Cheese", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Turkey = false; // Remove default ingredient

            Assert.Contains("Hold Turkey", sandwich.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationEmptyWithDefaultsTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            // Default ingredients, default bread, default size

            var prepInfo = sandwich.PreparationInformation.ToList();
            Assert.Single(prepInfo); // Should only contain "Medium"
            Assert.Contains("Medium", prepInfo);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.IsAssignableFrom<IMenuItem>(sandwich);
        }

        [Fact]
        public void CanBeCastToEntreeTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.IsAssignableFrom<Entree>(sandwich);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.Equal("Turkey Cranberry Sandwich", sandwich.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            Assert.Equal("A festive sandwich with turkey, cranberry sauce, and cream cheese", sandwich.Description);
        }

        #endregion

        #region Individual Ingredient Property Tests

        [Fact]
        public void TurkeyPropertyCanBeChangedTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Turkey = false;
            Assert.False(sandwich.Turkey);
            sandwich.Turkey = true;
            Assert.True(sandwich.Turkey);
        }

        [Fact]
        public void CranberrySaucePropertyCanBeChangedTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.CranberrySauce = false;
            Assert.False(sandwich.CranberrySauce);
            sandwich.CranberrySauce = true;
            Assert.True(sandwich.CranberrySauce);
        }

        [Fact]
        public void CreamCheesePropertyCanBeChangedTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.CreamCheese = false;
            Assert.False(sandwich.CreamCheese);
            sandwich.CreamCheese = true;
            Assert.True(sandwich.CreamCheese);
        }

        [Fact]
        public void RedOnionPropertyCanBeChangedTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.RedOnion = false;
            Assert.False(sandwich.RedOnion);
            sandwich.RedOnion = true;
            Assert.True(sandwich.RedOnion);
        }

        [Fact]
        public void ProvoloneCheesePropertyCanBeChangedTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.ProvoloneCheese = true;
            Assert.True(sandwich.ProvoloneCheese);
            sandwich.ProvoloneCheese = false;
            Assert.False(sandwich.ProvoloneCheese);
        }

        #endregion

        #region Both Cheeses Surcharge Tests

        [Fact]
        public void BothCheesesSurchargeAppliesTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            decimal basePrice = sandwich.Price; // Should be 8.49 for medium

            sandwich.ProvoloneCheese = true; // Add second cheese
            decimal priceWithBothCheeses = sandwich.Price;

            Assert.Equal(basePrice + 1.00m, priceWithBothCheeses);
        }

        [Fact]
        public void SingleCheeseNoSurchargeTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();

            // Test with only cream cheese (default)
            sandwich.ProvoloneCheese = false;
            decimal priceWithOneCheese = sandwich.Price;
            Assert.Equal(8.49m, priceWithOneCheese);

            // Test with only provolone cheese
            sandwich.CreamCheese = false;
            sandwich.ProvoloneCheese = true;
            decimal priceWithOtherCheese = sandwich.Price;
            Assert.Equal(8.49m, priceWithOtherCheese);
        }

        [Fact]
        public void NoCheesesNoSurchargeTest()
        {
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.CreamCheese = false;
            sandwich.ProvoloneCheese = false;

            Assert.Equal(8.49m, sandwich.Price); // Base price, no surcharge
        }

        #endregion
    }
}