using SubHero.Data.Sides;
using SubHero.Data.Enums;

namespace SubHero.DataTests.SideTests
{
    /// <summary>
    /// Unit tests for the SideSalad class
    /// </summary>
    public class SideSaladUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            SideSalad salad = new SideSalad();
            Assert.True(salad.FetaCheese);
            Assert.True(salad.Tomato);
            Assert.True(salad.Cucumber);
            Assert.True(salad.RedOnion);
            Assert.True(salad.RanchDressing);
            Assert.False(salad.Avocado); // Optional ingredient
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(false, 4.99)] // No avocado
        [InlineData(true, 5.99)] // With avocado surcharge
        public void PriceIsCorrectTest(bool avocado, decimal expectedPrice)
        {
            SideSalad salad = new SideSalad();
            salad.Avocado = avocado;
            Assert.Equal(expectedPrice, salad.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, true, false, 190u)]
        [InlineData(false, false, false, false, false, false, 20u)]
        [InlineData(true, false, true, true, true, false, 140u)]
        [InlineData(true, true, false, true, true, false, 170u)]
        [InlineData(true, true, true, false, true, false, 170u)]
        [InlineData(true, true, true, true, false, false, 100u)]
        [InlineData(true, true, true, true, true, true, 390u)]
        [InlineData(false, false, false, false, true, false, 110u)]
        public void CaloriesAreCorrectTest(bool feta, bool tomato, bool cucumber, bool redOnion, bool ranch, bool avocado, uint expectedCalories)
        {
            SideSalad salad = new SideSalad();
            salad.FetaCheese = feta;
            salad.Tomato = tomato;
            salad.Cucumber = cucumber;
            salad.RedOnion = redOnion;
            salad.RanchDressing = ranch;
            salad.Avocado = avocado;

            Assert.Equal(expectedCalories, salad.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesAddedIngredientsTest()
        {
            SideSalad salad = new SideSalad();
            salad.Avocado = true; // Add non-default ingredient

            Assert.Contains("Add Avocado", salad.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            SideSalad salad = new SideSalad();
            salad.FetaCheese = false; // Remove default ingredient

            Assert.Contains("Hold Feta Cheese", salad.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesMultipleChangesTest()
        {
            SideSalad salad = new SideSalad();
            salad.Tomato = false; // Remove default
            salad.RedOnion = false; // Remove default
            salad.Avocado = true; // Add non-default

            var prepInfo = salad.PreparationInformation.ToList();
            Assert.Contains("Hold Tomato", prepInfo);
            Assert.Contains("Hold Red Onion", prepInfo);
            Assert.Contains("Add Avocado", prepInfo);
        }

        [Fact]
        public void PreparationInformationEmptyWithDefaultIngredientsTest()
        {
            SideSalad salad = new SideSalad();
            // All default ingredients, no changes
            Assert.Empty(salad.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            SideSalad salad = new SideSalad();
            Assert.IsAssignableFrom<IMenuItem>(salad);
        }

        [Fact]
        public void CanBeCastToSideTest()
        {
            SideSalad salad = new SideSalad();
            Assert.IsAssignableFrom<Side>(salad);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            SideSalad salad = new SideSalad();
            Assert.Equal("Side Salad", salad.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            SideSalad salad = new SideSalad();
            Assert.Equal("Garden salad with lots of veggies", salad.Description);
        }

        #endregion

        #region Individual Ingredient Property Tests

        [Fact]
        public void FetaCheesePropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.FetaCheese = false;
            Assert.False(salad.FetaCheese);
            salad.FetaCheese = true;
            Assert.True(salad.FetaCheese);
        }

        [Fact]
        public void TomatoPropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.Tomato = false;
            Assert.False(salad.Tomato);
            salad.Tomato = true;
            Assert.True(salad.Tomato);
        }

        [Fact]
        public void CucumberPropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.Cucumber = false;
            Assert.False(salad.Cucumber);
            salad.Cucumber = true;
            Assert.True(salad.Cucumber);
        }

        [Fact]
        public void RedOnionPropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.RedOnion = false;
            Assert.False(salad.RedOnion);
            salad.RedOnion = true;
            Assert.True(salad.RedOnion);
        }

        [Fact]
        public void RanchDressingPropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.RanchDressing = false;
            Assert.False(salad.RanchDressing);
            salad.RanchDressing = true;
            Assert.True(salad.RanchDressing);
        }

        [Fact]
        public void AvocadoPropertyCanBeChangedTest()
        {
            SideSalad salad = new SideSalad();
            salad.Avocado = true;
            Assert.True(salad.Avocado);
            salad.Avocado = false;
            Assert.False(salad.Avocado);
        }

        #endregion

        #region Avocado Surcharge Tests

        [Fact]
        public void AvocadoSurchargeAppliesTest()
        {
            SideSalad salad = new SideSalad();
            decimal basePrice = salad.Price; // Should be 4.99

            salad.Avocado = true; // Add avocado
            decimal priceWithAvocado = salad.Price;

            Assert.Equal(basePrice + 1.00m, priceWithAvocado);
        }

        [Fact]
        public void NoAvocadoNoSurchargeTest()
        {
            SideSalad salad = new SideSalad();
            salad.Avocado = false;

            Assert.Equal(4.99m, salad.Price); // Base price, no surcharge
        }

        #endregion

        #region Special Calorie Calculation Tests

        [Fact]
        public void DoubleCaloriesForMostIngredientsTest()
        {
            SideSalad salad = new SideSalad();

            // Test with only feta cheese (should be doubled)
            salad.FetaCheese = true;
            salad.Tomato = false;
            salad.Cucumber = false;
            salad.RedOnion = false;
            salad.RanchDressing = false;
            salad.Avocado = false;

            // Base greens (20) + Feta (50 * 2) = 120 calories
            Assert.Equal(120u, salad.Calories);
        }

        [Fact]
        public void RanchAndAvocadoNotDoubledTest()
        {
            SideSalad salad = new SideSalad();

            // Test with only ranch dressing (should NOT be doubled)
            salad.FetaCheese = false;
            salad.Tomato = false;
            salad.Cucumber = false;
            salad.RedOnion = false;
            salad.RanchDressing = true;
            salad.Avocado = false;

            // Base greens (20) + Ranch (90 * 1) = 110 calories
            Assert.Equal(110u, salad.Calories);
        }

        #endregion
    }
}