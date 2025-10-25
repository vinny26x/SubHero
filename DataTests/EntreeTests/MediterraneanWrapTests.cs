using SubHero.Data.Entrees;
using SubHero.Data.Enums;

namespace SubHero.DataTests.EntreeTests
{
    /// <summary>
    /// Unit tests for the MediterraneanWrap class
    /// </summary>
    public class MediterraneanWrapUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.Equal(SizeType.Medium, wrap.Size);
        }

        [Fact]
        public void DefaultBreadIsCorrectTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.Equal(BreadType.Wrap, wrap.Bread);
        }

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.True(wrap.Hummus);
            Assert.True(wrap.FetaCheese);
            Assert.True(wrap.KalamataOlives);
            Assert.True(wrap.Cucumber);
            Assert.True(wrap.Tomato);
            Assert.True(wrap.ItalianDressing);
            Assert.True(wrap.RoastedRedPeppers);
            Assert.False(wrap.Avocado); // Optional ingredient
        }

        #endregion

        #region Constraint Tests

        [Theory]
        [InlineData(SizeType.Small)] // Wraps only allow medium
        [InlineData(SizeType.Large)] // Wraps only allow medium
        public void InvalidSizeDoesNotChangePropertyTest(SizeType invalidSize)
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Size = invalidSize;
            Assert.Equal(SizeType.Medium, wrap.Size);
        }

        [Theory]
        [InlineData(BreadType.Hoagie)] // Changing from wrap should not work
        [InlineData(BreadType.Wheat)] // Changing from wrap should not work
        [InlineData(BreadType.Sourdough)] // Changing from wrap should not work
        public void InvalidBreadDoesNotChangePropertyTest(BreadType invalidBread)
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Bread = invalidBread;
            Assert.Equal(BreadType.Wrap, wrap.Bread);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(false, 7.99)] // No avocado
        [InlineData(true, 8.99)] // With avocado surcharge
        public void PriceIsCorrectTest(bool avocado, decimal expectedPrice)
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Avocado = avocado;
            // Wraps are always medium size
            Assert.Equal(expectedPrice, wrap.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, true, true, true, false, BreadType.Wrap, 555)]
        [InlineData(false, false, false, false, false, false, false, false, BreadType.Wrap, 220)]
        [InlineData(true, false, true, true, true, true, true, false, BreadType.Wrap, 505)]
        [InlineData(true, true, false, true, true, true, true, false, BreadType.Wrap, 475)]
        [InlineData(true, true, true, false, true, true, true, false, BreadType.Wrap, 545)]
        [InlineData(true, true, true, true, false, true, true, false, BreadType.Wrap, 530)]
        [InlineData(true, true, true, true, true, false, true, false, BreadType.Wrap, 465)]
        [InlineData(true, true, true, true, true, true, true, true, BreadType.Wrap, 755)]
        public void CaloriesAreCorrectTest(bool hummus, bool feta, bool olives, bool cucumber, bool tomato,
            bool italianDressing, bool redPeppers, bool avocado, BreadType bread, uint expectedCalories)
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Hummus = hummus;
            wrap.FetaCheese = feta;
            wrap.KalamataOlives = olives;
            wrap.Cucumber = cucumber;
            wrap.Tomato = tomato;
            wrap.ItalianDressing = italianDressing;
            wrap.RoastedRedPeppers = redPeppers;
            wrap.Avocado = avocado;
            wrap.Bread = bread;

            Assert.Equal(expectedCalories, wrap.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationDoesNotIncludeSizeForWrapTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.DoesNotContain("Medium", wrap.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesAddedIngredientsTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Avocado = true; // Add non-default ingredient

            Assert.Contains("Add Avocado", wrap.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Hummus = false; // Remove default ingredient

            Assert.Contains("Hold Hummus", wrap.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationEmptyWithDefaultIngredientsTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            // All default ingredients, default bread, wrap doesn't show size
            Assert.Empty(wrap.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.IsAssignableFrom<IMenuItem>(wrap);
        }

        [Fact]
        public void CanBeCastToEntreeTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.IsAssignableFrom<Entree>(wrap);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.Equal("Mediterranean Wrap", wrap.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            Assert.Equal("A vegetarian Mediterranean-style wrap", wrap.Description);
        }

        #endregion

        #region Individual Ingredient Property Tests

        [Fact]
        public void HummusPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Hummus = false;
            Assert.False(wrap.Hummus);
            wrap.Hummus = true;
            Assert.True(wrap.Hummus);
        }

        [Fact]
        public void FetaCheesePropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.FetaCheese = false;
            Assert.False(wrap.FetaCheese);
            wrap.FetaCheese = true;
            Assert.True(wrap.FetaCheese);
        }

        [Fact]
        public void KalamataOlivesPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.KalamataOlives = false;
            Assert.False(wrap.KalamataOlives);
            wrap.KalamataOlives = true;
            Assert.True(wrap.KalamataOlives);
        }

        [Fact]
        public void AvocadoPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Avocado = true;
            Assert.True(wrap.Avocado);
            wrap.Avocado = false;
            Assert.False(wrap.Avocado);
        }

        [Fact]
        public void CucumberPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Cucumber = false;
            Assert.False(wrap.Cucumber);
            wrap.Cucumber = true;
            Assert.True(wrap.Cucumber);
        }

        [Fact]
        public void TomatoPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Tomato = false;
            Assert.False(wrap.Tomato);
            wrap.Tomato = true;
            Assert.True(wrap.Tomato);
        }

        [Fact]
        public void ItalianDressingPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.ItalianDressing = false;
            Assert.False(wrap.ItalianDressing);
            wrap.ItalianDressing = true;
            Assert.True(wrap.ItalianDressing);
        }

        [Fact]
        public void RoastedRedPeppersPropertyCanBeChangedTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.RoastedRedPeppers = false;
            Assert.False(wrap.RoastedRedPeppers);
            wrap.RoastedRedPeppers = true;
            Assert.True(wrap.RoastedRedPeppers);
        }

        #endregion
    }
}