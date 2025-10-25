using SubHero.Data;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests
{
    /// <summary>
    /// Unit tests for the Combo class
    /// </summary>
    public class ComboUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSandwichChoiceIsCustomSandwichTest()
        {
            Combo combo = new Combo();
            Assert.IsType<CustomSandwich>(combo.SandwichChoice);
        }

        [Fact]
        public void DefaultSideChoiceIsChipsTest()
        {
            Combo combo = new Combo();
            Assert.IsType<Chips>(combo.SideChoice);
        }

        [Fact]
        public void DefaultDrinkChoiceIsFountainDrinkTest()
        {
            Combo combo = new Combo();
            Assert.IsType<FountainDrink>(combo.DrinkChoice);
        }

        #endregion

        #region Price Tests

        [Fact]
        public void PriceIs80PercentOfTotalItemsTest()
        {
            Combo combo = new Combo();

            decimal expectedTotal = combo.SandwichChoice.Price + combo.SideChoice.Price + combo.DrinkChoice.Price;
            decimal expectedComboPrice = expectedTotal * 0.8m;

            Assert.Equal(expectedComboPrice, combo.Price);
        }

        #endregion

        #region Calories Tests

        [Fact]
        public void CaloriesEqualSumOfAllItemsTest()
        {
            Combo combo = new Combo();

            uint expectedCalories = combo.SandwichChoice.Calories + combo.SideChoice.Calories + combo.DrinkChoice.Calories;

            Assert.Equal(expectedCalories, combo.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationIncludesAllItemsTest()
        {
            Combo combo = new Combo();

            var prepInfo = combo.PreparationInformation.ToList();

            Assert.Contains("Sandwich: Custom Sandwich", prepInfo);
            Assert.Contains("Side: Chips", prepInfo);
            Assert.Contains("Drink: Fountain Drink", prepInfo);
        }

        [Fact]
        public void PreparationInformationHasCorrectFormatTest()
        {
            Combo combo = new Combo();

            var prepInfo = combo.PreparationInformation.ToList();

            // Should have sandwich section
            Assert.Contains("Sandwich: Custom Sandwich", prepInfo);

            // Should have side section
            Assert.Contains("Side: Chips", prepInfo);

            // Should have drink section
            Assert.Contains("Drink: Fountain Drink", prepInfo);

            // Should have indented instructions (tabs)
            bool hasTabIndentation = prepInfo.Any(instruction => instruction.StartsWith("\t"));
            Assert.True(hasTabIndentation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            Combo combo = new Combo();
            Assert.IsAssignableFrom<IMenuItem>(combo);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            Combo combo = new Combo();
            Assert.Equal("Combo", combo.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            Combo combo = new Combo();
            Assert.Equal("A sandwich plus your choice of side and drink", combo.Description);
        }

        #endregion

        #region Property Assignment Tests

        [Fact]
        public void CanAssignDifferentSandwichTest()
        {
            Combo combo = new Combo();
            ClubSub newSandwich = new ClubSub();
            combo.SandwichChoice = newSandwich;
            Assert.Equal(newSandwich, combo.SandwichChoice);
        }

        [Fact]
        public void CanAssignDifferentSideTest()
        {
            Combo combo = new Combo();
            Apple newSide = new Apple();
            combo.SideChoice = newSide;
            Assert.Equal(newSide, combo.SideChoice);
        }

        [Fact]
        public void CanAssignDifferentDrinkTest()
        {
            Combo combo = new Combo();
            IcedTea newDrink = new IcedTea();
            combo.DrinkChoice = newDrink;
            Assert.Equal(newDrink, combo.DrinkChoice);
        }

        #endregion
    }
}