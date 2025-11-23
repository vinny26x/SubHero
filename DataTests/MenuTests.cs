using SubHero.Data;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests
{
    /// <summary>
    /// Tests for the static Menu class
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// Tests that the Entrees property returns the correct count
        /// 7 entree types × valid bread/size combinations
        /// Wrap: 1 size (Medium)
        /// Wheat: 2 sizes (Small, Medium)
        /// Sourdough: 2 sizes (Small, Medium)
        /// Hoagie: 3 sizes (Small, Medium, Large)
        /// Total per entree type: 1 + 2 + 2 + 3 = 8 combinations
        /// 7 types × 8 = 56 entrees
        /// </summary>
        [Fact]
        public void EntreesCountShouldBeCorrect()
        {
            var entrees = Menu.Entrees;
            int expected = 7 * (1 + 2 + 2 + 3); // 7 types × 8 bread/size combos = 56
            Assert.Equal(expected, entrees.Count());
        }

        /// <summary>
        /// Tests that the Sides property returns the correct count
        /// 1 Apple + 5 Chip types + (4 Cookie flavors × 5 counts) + 1 Side Salad
        /// = 1 + 5 + 20 + 1 = 27 sides
        /// </summary>
        [Fact]
        public void SidesCountShouldBeCorrect()
        {
            var sides = Menu.Sides;
            int expected = 1 + 5 + (4 * 5) + 1; // Apple + Chips + Cookies + Salad = 27
            Assert.Equal(expected, sides.Count());
        }

        /// <summary>
        /// Tests that the Drinks property returns the correct count
        /// (5 Soda flavors × 3 sizes) + (2 tea types × 3 sizes) + (2 lemonade types × 3 sizes)
        /// = 15 + 6 + 6 = 27 drinks
        /// </summary>
        [Fact]
        public void DrinksCountShouldBeCorrect()
        {
            var drinks = Menu.Drinks;
            int expected = (5 * 3) + (2 * 3) + (2 * 3); // Fountain + Tea + Lemonade = 27
            Assert.Equal(expected, drinks.Count());
        }

        /// <summary>
        /// Tests that the Combos property returns the correct count
        /// 7 entree types × 4 side types × 3 drink types = 84 combos
        /// </summary>
        [Fact]
        public void CombosCountShouldBeCorrect()
        {
            var combos = Menu.Combos;
            int expected = 7 * 4 * 3; // 7 entrees × 4 sides × 3 drinks = 84
            Assert.Equal(expected, combos.Count());
        }

        /// <summary>
        /// Tests that the FullMenu property returns the correct count
        /// </summary>
        [Fact]
        public void FullMenuCountShouldBeCorrect()
        {
            var fullMenu = Menu.FullMenu;
            int expected = (7 * 8) + 27 + 27 + (7 * 4 * 3); // Entrees + Sides + Drinks + Combos
            Assert.Equal(expected, fullMenu.Count());
        }

        /// <summary>
        /// Tests that the Ingredients property returns the correct count
        /// Should have 24 ingredient types
        /// </summary>
        [Fact]
        public void IngredientsCountShouldBeCorrect()
        {
            var ingredients = Menu.Ingredients;
            int expected = 24; // Count of IngredientType enum values
            Assert.Equal(expected, ingredients.Count());
        }

        /// <summary>
        /// Tests that all entree types are present in the Entrees collection
        /// </summary>
        [Fact]
        public void EntreesShouldContainAllEntreeTypes()
        {
            var entrees = Menu.Entrees;

            // Check that each entree type exists
            Assert.Contains(entrees, e => e is CustomSandwich);
            Assert.Contains(entrees, e => e is CaliforniaClubWrap);
            Assert.Contains(entrees, e => e is ClubSub);
            Assert.Contains(entrees, e => e is ItalianSub);
            Assert.Contains(entrees, e => e is MediterraneanWrap);
            Assert.Contains(entrees, e => e is TurkeyCranberrySandwich);
            Assert.Contains(entrees, e => e is VeggieSandwich);
        }

        /// <summary>
        /// Tests that specific bread/size combinations exist for CustomSandwich
        /// </summary>
        [Fact]
        public void EntreesShouldContainSpecificBreadSizeCombinations()
        {
            var entrees = Menu.Entrees;

            // Test some specific valid combinations
            Assert.Contains(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Wheat && cs.Size == SizeType.Small);
            Assert.Contains(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Wrap && cs.Size == SizeType.Medium);
            Assert.Contains(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Hoagie && cs.Size == SizeType.Large);
        }

        /// <summary>
        /// Tests that invalid bread/size combinations do NOT exist
        /// </summary>
        [Fact]
        public void EntreesShouldNotContainInvalidBreadSizeCombinations()
        {
            var entrees = Menu.Entrees;

            // Wrap should NOT have Small or Large
            Assert.DoesNotContain(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Wrap && cs.Size == SizeType.Small);
            Assert.DoesNotContain(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Wrap && cs.Size == SizeType.Large);

            // Wheat should NOT have Large
            Assert.DoesNotContain(entrees, e =>
                e is CustomSandwich cs && cs.Bread == BreadType.Wheat && cs.Size == SizeType.Large);
        }

        /// <summary>
        /// Tests that all chip flavors are present in Sides
        /// </summary>
        [Fact]
        public void SidesShouldContainAllChipFlavors()
        {
            var sides = Menu.Sides;

            foreach (ChipType chipType in Enum.GetValues(typeof(ChipType)))
            {
                Assert.Contains(sides, s => s is Chips chips && chips.Flavor == chipType);
            }
        }

        /// <summary>
        /// Tests that all cookie flavors and counts are present in Sides
        /// </summary>
        [Fact]
        public void SidesShouldContainAllCookieCombinations()
        {
            var sides = Menu.Sides;

            foreach (CookieType flavor in Enum.GetValues(typeof(CookieType)))
            {
                for (uint count = 2; count <= 6; count++)
                {
                    Assert.Contains(sides, s =>
                        s is Cookies cookies && cookies.Flavor == flavor && cookies.CookieCount == count);
                }
            }
        }

        /// <summary>
        /// Tests that Apple and SideSalad are present in Sides
        /// </summary>
        [Fact]
        public void SidesShouldContainAppleAndSideSalad()
        {
            var sides = Menu.Sides;

            Assert.Contains(sides, s => s is Apple);
            Assert.Contains(sides, s => s is SideSalad);
        }

        /// <summary>
        /// Tests that all fountain drink flavors and sizes are present
        /// </summary>
        [Fact]
        public void DrinksShouldContainAllFountainDrinkCombinations()
        {
            var drinks = Menu.Drinks;

            foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
            {
                foreach (SodaType flavor in Enum.GetValues(typeof(SodaType)))
                {
                    Assert.Contains(drinks, d =>
                        d is FountainDrink fd && fd.Size == size && fd.Flavor == flavor);
                }
            }
        }

        /// <summary>
        /// Tests that all iced tea combinations are present
        /// </summary>
        [Fact]
        public void DrinksShouldContainAllIcedTeaCombinations()
        {
            var drinks = Menu.Drinks;

            foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
            {
                // Sweet tea
                Assert.Contains(drinks, d =>
                    d is IcedTea tea && tea.Size == size && tea.Sweet == true);
                // Unsweet tea
                Assert.Contains(drinks, d =>
                    d is IcedTea tea && tea.Size == size && tea.Sweet == false);
            }
        }

        /// <summary>
        /// Tests that all lemonade combinations are present
        /// </summary>
        [Fact]
        public void DrinksShouldContainAllLemonadeCombinations()
        {
            var drinks = Menu.Drinks;

            foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
            {
                // Regular lemonade
                Assert.Contains(drinks, d =>
                    d is Lemonade lem && lem.Size == size && lem.Pink == false);
                // Pink lemonade
                Assert.Contains(drinks, d =>
                    d is Lemonade lem && lem.Size == size && lem.Pink == true);
            }
        }

        /// <summary>
        /// Tests that all ingredient types are present in Ingredients
        /// </summary>
        [Fact]
        public void IngredientsShouldContainAllIngredientTypes()
        {
            var ingredients = Menu.Ingredients;

            foreach (IngredientType type in Enum.GetValues(typeof(IngredientType)))
            {
                Assert.Contains(ingredients, i => i.Ingredient == type);
            }
        }

        /// <summary>
        /// Tests that FullMenu contains items from all categories
        /// </summary>
        [Fact]
        public void FullMenuShouldContainAllCategories()
        {
            var fullMenu = Menu.FullMenu;

            // Should contain at least one of each type
            Assert.Contains(fullMenu, item => item is Entree);
            Assert.Contains(fullMenu, item => item is Side);
            Assert.Contains(fullMenu, item => item is Drink);
            Assert.Contains(fullMenu, item => item is Combo);
        }
    }
}