using SubHero.Data.Sides;
using SubHero.Data.Enums;

namespace SubHero.DataTests.SideTests
{
    /// <summary>
    /// Unit tests for the Cookies class
    /// </summary>
    public class CookiesUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultFlavorIsCorrectTest()
        {
            Cookies cookies = new Cookies();
            Assert.Equal(CookieType.ChocolateChip, cookies.Flavor);
        }

        [Fact]
        public void DefaultCookieCountIsCorrectTest()
        {
            Cookies cookies = new Cookies();
            Assert.Equal(2u, cookies.CookieCount);
        }

        #endregion

        #region Constraint Tests

        [Theory]
        [InlineData(1u)] // Below minimum
        [InlineData(0u)] // Below minimum
        [InlineData(7u)] // Above maximum
        [InlineData(10u)] // Above maximum
        public void InvalidCookieCountDoesNotChangePropertyTest(uint invalidCount)
        {
            Cookies cookies = new Cookies();
            uint originalCount = cookies.CookieCount;
            cookies.CookieCount = invalidCount;
            Assert.Equal(originalCount, cookies.CookieCount);
        }

        [Theory]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(4u)]
        [InlineData(5u)]
        [InlineData(6u)]
        public void ValidCookieCountChangesPropertyTest(uint validCount)
        {
            Cookies cookies = new Cookies();
            cookies.CookieCount = validCount;
            Assert.Equal(validCount, cookies.CookieCount);
        }

        #endregion

        #region Price Tests

        [Theory]
        [InlineData(2u, 3.00)] // 1 pair
        [InlineData(3u, 4.75)] // 1 pair + 1 extra
        [InlineData(4u, 6.00)] // 2 pairs
        [InlineData(5u, 7.75)] // 2 pairs + 1 extra
        [InlineData(6u, 9.00)] // 3 pairs
        public void PriceIsCorrectTest(uint cookieCount, decimal expectedPrice)
        {
            Cookies cookies = new Cookies();
            cookies.CookieCount = cookieCount;
            Assert.Equal(expectedPrice, cookies.Price);
        }

        #endregion

        #region Calories Tests

        [Theory]
        [InlineData(CookieType.ChocolateChip, 2u, 360u)]
        [InlineData(CookieType.ChocolateChip, 3u, 540u)]
        [InlineData(CookieType.OatmealRaisin, 2u, 300u)]
        [InlineData(CookieType.OatmealRaisin, 4u, 600u)]
        [InlineData(CookieType.Sugar, 2u, 320u)]
        [InlineData(CookieType.Sugar, 5u, 800u)]
        [InlineData(CookieType.PeanutButter, 2u, 380u)]
        [InlineData(CookieType.PeanutButter, 6u, 1140u)]
        public void CaloriesAreCorrectTest(CookieType flavor, uint count, uint expectedCalories)
        {
            Cookies cookies = new Cookies();
            cookies.Flavor = flavor;
            cookies.CookieCount = count;
            Assert.Equal(expectedCalories, cookies.Calories);
        }

        #endregion

        #region Preparation Information Tests

        [Theory]
        [InlineData(CookieType.ChocolateChip, 2u, "2 Chocolate Chip Cookies")]
        [InlineData(CookieType.OatmealRaisin, 3u, "3 Oatmeal Raisin Cookies")]
        [InlineData(CookieType.Sugar, 4u, "4 Sugar Cookies")]
        [InlineData(CookieType.PeanutButter, 5u, "5 Peanut Butter Cookies")]
        public void PreparationInformationIsCorrectTest(CookieType flavor, uint count, string expectedInfo)
        {
            Cookies cookies = new Cookies();
            cookies.Flavor = flavor;
            cookies.CookieCount = count;
            Assert.Contains(expectedInfo, cookies.PreparationInformation);
        }

        #endregion

        #region Interface Tests

        [Fact]
        public void CanBeCastToIMenuItemTest()
        {
            Cookies cookies = new Cookies();
            Assert.IsAssignableFrom<IMenuItem>(cookies);
        }

        [Fact]
        public void CanBeCastToSideTest()
        {
            Cookies cookies = new Cookies();
            Assert.IsAssignableFrom<Side>(cookies);
        }

        #endregion

        #region Name and Description Tests

        [Fact]
        public void NameIsCorrectTest()
        {
            Cookies cookies = new Cookies();
            Assert.Equal("Cookies", cookies.Name);
        }

        [Fact]
        public void DescriptionIsCorrectTest()
        {
            Cookies cookies = new Cookies();
            Assert.Equal("Freshly baked cookies in a variety of flavors", cookies.Description);
        }

        #endregion
    }
}