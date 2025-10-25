using SubHero.Data.Entrees;
using SubHero.Data.Enums;

namespace SubHero.DataTests.EntreeTests
{
    /// <summary>
    /// Unit tests for the CaliforniaClubWrap class
    /// </summary>
    public class CaliforniaClubWrapUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultSizeIsCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.Equal(SizeType.Medium, wrap.Size);
        }

        [Fact]
        public void DefaultBreadIsCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.Equal(BreadType.Wrap, wrap.Bread);
        }

        [Fact]
        public void DefaultIngredientsAreCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.True(wrap.Turkey);
            Assert.True(wrap.Bacon);
            Assert.True(wrap.Avocado);
            Assert.True(wrap.SwissCheese);
            Assert.True(wrap.Tomato);
            Assert.True(wrap.Sprouts);
            Assert.True(wrap.Mayo);
        }

        #endregion

        #region Constraint Tests

        [Theory]
        [InlineData(SizeType.Small)] // Wraps only allow medium
        [InlineData(SizeType.Large)] // Wraps only allow medium
        public void InvalidSizeDoesNotChangePropertyTest(SizeType invalidSize)
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Size = invalidSize;
            Assert.Equal(SizeType.Medium, wrap.Size);
        }

        [Theory]
        [InlineData(BreadType.Hoagie)] // Changing from wrap should not work for medium size
        [InlineData(BreadType.Wheat)] // Changing from wrap should not work for medium size
        [InlineData(BreadType.Sourdough)] // Changing from wrap should not work for medium size
        public void InvalidBreadDoesNotChangePropertyTest(BreadType invalidBread)
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Bread = invalidBread;
            Assert.Equal(BreadType.Wrap, wrap.Bread);
        }

        #endregion

        #region Price Tests

        [Fact]
        public void PriceIsCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            // Wraps are always medium size, base price 9.49
            Assert.Equal(9.49m, wrap.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(true, true, true, true, true, true, true, BreadType.Wrap, 754)]
        [InlineData(false, false, false, false, false, false, false, BreadType.Wrap, 220)]
        [InlineData(true, false, true, true, true, true, true, BreadType.Wrap, 584)]
        [InlineData(true, true, false, true, true, true, true, BreadType.Wrap, 554)]
        [InlineData(true, true, true, false, true, true, true, BreadType.Wrap, 654)]
        [InlineData(true, true, true, true, false, true, true, BreadType.Wrap, 729)]
        [InlineData(true, true, true, true, true, false, true, BreadType.Wrap, 751)]
        [InlineData(true, true, true, true, true, true, false, BreadType.Wrap, 664)]
        public void CaloriesAreCorrectTest(bool turkey, bool bacon, bool avocado, bool swiss,
            bool tomato, bool sprouts, bool mayo, BreadType bread, uint expectedCalories)
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Turkey = turkey;
            wrap.Bacon = bacon;
            wrap.Avocado = avocado;
            wrap.SwissCheese = swiss;
            wrap.Tomato = tomato;
            wrap.Sprouts = sprouts;
            wrap.Mayo = mayo;
            wrap.Bread = bread;

            Assert.Equal(expectedCalories, wrap.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Fact]
        public void PreparationInformationDoesNotIncludeSizeForWrapTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.DoesNotContain("Medium", wrap.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesHeldIngredientsTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Turkey = false; // Remove default ingredient
            Assert.Contains("Hold Turkey", wrap.PreparationInformation);
        }

        [Fact]
        public void PreparationInformationIncludesMultipleHeldIngredientsTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Turkey = false; // Remove default ingredient
            wrap.Bacon = false; // Remove default ingredient

            var prepInfo = wrap.PreparationInformation.ToList();
            Assert.Contains("Hold Turkey", prepInfo);
            Assert.Contains("Hold Bacon", prepInfo);
        }

        [Fact]
        public void PreparationInformationEmptyWithDefaultIngredientsTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            // All default ingredients, default bread, wrap doesn't show size
            Assert.Empty(wrap.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.IsAssignableFrom<IMenuItem>(wrap);
        }

        [Fact]
        public void CanBeCastToEntreeTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.IsAssignableFrom<Entree>(wrap);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.Equal("California Club Wrap", wrap.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            Assert.Equal("A California-style club in a wrap", wrap.Description);
        }

        #endregion

        #region Individual Ingredient Property Tests

        [Fact]
        public void TurkeyPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Turkey = false;
            Assert.False(wrap.Turkey);
            wrap.Turkey = true;
            Assert.True(wrap.Turkey);
        }

        [Fact]
        public void BaconPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Bacon = false;
            Assert.False(wrap.Bacon);
            wrap.Bacon = true;
            Assert.True(wrap.Bacon);
        }

        [Fact]
        public void AvocadoPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Avocado = false;
            Assert.False(wrap.Avocado);
            wrap.Avocado = true;
            Assert.True(wrap.Avocado);
        }

        [Fact]
        public void SwissCheesePropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.SwissCheese = false;
            Assert.False(wrap.SwissCheese);
            wrap.SwissCheese = true;
            Assert.True(wrap.SwissCheese);
        }

        [Fact]
        public void TomatoPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Tomato = false;
            Assert.False(wrap.Tomato);
            wrap.Tomato = true;
            Assert.True(wrap.Tomato);
        }

        [Fact]
        public void SproutsPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Sprouts = false;
            Assert.False(wrap.Sprouts);
            wrap.Sprouts = true;
            Assert.True(wrap.Sprouts);
        }

        [Fact]
        public void MayoPropertyCanBeChangedTest()
        {
            CaliforniaClubWrap wrap = new CaliforniaClubWrap();
            wrap.Mayo = false;
            Assert.False(wrap.Mayo);
            wrap.Mayo = true;
            Assert.True(wrap.Mayo);
        }

        #endregion
    }
}