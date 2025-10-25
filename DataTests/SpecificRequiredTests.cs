using SubHero.Data;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests
{
    /// <summary>
    /// Specific required test cases to ensure consistent functionality
    /// </summary>
    public class SpecificRequiredTests
    {
        [Fact]
        public void ClubSubWithBothCheesesAndAvocadoOnSmallSourdoughTest()
        {
            ClubSub sub = new ClubSub();
            sub.Size = SizeType.Small;
            sub.Bread = BreadType.Sourdough;
            sub.SwissCheese = true; // Add second cheese (cheddar is default)
            sub.Avocado = true;

            // Expected values
            Assert.Equal(445u, sub.Calories);
            Assert.Equal(7.99m, sub.Price);

            // Expected preparation information (exactly 4 items)
            var prepInfo = sub.PreparationInformation.ToList();
            Assert.Equal(4, prepInfo.Count);
            Assert.Contains("Use Sourdough Bread", prepInfo);
            Assert.Contains("Small", prepInfo);
            Assert.Contains("Add Swiss Cheese", prepInfo);
            Assert.Contains("Add Avocado", prepInfo);
        }

        [Fact]
        public void MediterraneanWrapWithNoHummusAndNoItalianDressingTest()
        {
            MediterraneanWrap wrap = new MediterraneanWrap();
            wrap.Hummus = false; // Remove default
            wrap.ItalianDressing = false; // Remove default

            // Expected values
            Assert.Equal(335u, wrap.Calories);
            Assert.Equal(7.99m, wrap.Price);

            // Expected preparation information (exactly 2 items)
            var prepInfo = wrap.PreparationInformation.ToList();
            Assert.Equal(2, prepInfo.Count);
            Assert.Contains("Hold Hummus", prepInfo);
            Assert.Contains("Hold Italian Dressing", prepInfo);
        }

        [Fact]
        public void CustomSandwichWithSpecificIngredientsOnLargeHoagieTest()
        {
            CustomSandwich sandwich = new CustomSandwich();
            sandwich.Bread = BreadType.Hoagie;
            sandwich.Size = SizeType.Large;
            sandwich.Size = SizeType.Medium;

            // Add only the specified ingredients (all others should be false by default)
            sandwich.Turkey = true;
            sandwich.Ham = true;
            sandwich.Bacon = true;
            sandwich.RanchDressing = true;
            sandwich.KalamataOlives = true;

            // Expected values
            Assert.Equal(1147u, sandwich.Calories);
            Assert.Equal(11.49m, sandwich.Price);

            // Expected preparation information (exactly 7 items)
            var prepInfo = sandwich.PreparationInformation.ToList();
            Assert.Equal(7, prepInfo.Count);
            Assert.Contains("Use Hoagie", prepInfo);
            Assert.Contains("Large", prepInfo);
            Assert.Contains("Add Turkey", prepInfo);
            Assert.Contains("Add Ham", prepInfo);
            Assert.Contains("Add Bacon", prepInfo);
            Assert.Contains("Add Ranch Dressing", prepInfo);
            Assert.Contains("Add Kalamata Olives", prepInfo);
        }

        [Fact]
        public void SideSaladWithNoTomatoesNoRedOnionsWithAvocadoTest()
        {
            SideSalad salad = new SideSalad();
            salad.Tomato = false; // Remove default
            salad.RedOnion = false; // Remove default
            salad.Avocado = true; // Add non-default

            // Expected values
            Assert.Equal(470u, salad.Calories);
            Assert.Equal(5.99m, salad.Price);

            // Expected preparation information (exactly 3 items)
            var prepInfo = salad.PreparationInformation.ToList();
            Assert.Equal(3, prepInfo.Count);
            Assert.Contains("Hold Tomato", prepInfo);
            Assert.Contains("Hold Red Onion", prepInfo);
            Assert.Contains("Add Avocado", prepInfo);
        }

        [Fact]
        public void LargeStrawberryLemonadeTest()
        {
            Lemonade lemonade = new Lemonade();
            lemonade.Size = SizeType.Large;
            lemonade.Pink = true; // You need to add this property to Lemonade class

            // Expected values
            Assert.Equal(288u, lemonade.Calories); // 9 cal/oz * 32oz
            Assert.Equal(3.00m, lemonade.Price);

            // Expected preparation information (exactly 2 items)
            var prepInfo = lemonade.PreparationInformation.ToList();
            Assert.Equal(2, prepInfo.Count);
            Assert.Contains("Large", prepInfo);
            Assert.Contains("Add Strawberry", prepInfo);
        }

        [Fact]
        public void ComboWithSpecificConfigurationTest()
        {
            Combo combo = new Combo();

            // Small turkey cranberry sandwich with provolone cheese
            TurkeyCranberrySandwich sandwich = new TurkeyCranberrySandwich();
            sandwich.Size = SizeType.Small;
            sandwich.ProvoloneCheese = true; // Add non-default cheese
            combo.SandwichChoice = sandwich;

            // 3 oatmeal raisin cookies
            Cookies cookies = new Cookies();
            cookies.Flavor = CookieType.OatmealRaisin;
            cookies.CookieCount = 3;
            combo.SideChoice = cookies;

            // Large Mountain Dew
            FountainDrink drink = new FountainDrink();
            drink.Size = SizeType.Large;
            drink.Flavor = SodaType.MountainDew; // Changed to match your FountainDrink implementation
            combo.DrinkChoice = drink;

            // Expected values
            Assert.Equal(1240u, combo.Calories);
            Assert.Equal(10.99m, combo.Price);

            // Expected preparation information (exactly 8 items)
            var prepInfo = combo.PreparationInformation.ToList();
            Assert.Equal(8, prepInfo.Count);
            Assert.Contains("Sandwich: Turkey Cranberry Sandwich", prepInfo);
            Assert.Contains("\tSmall", prepInfo);
            Assert.Contains("\tAdd Provolone Cheese", prepInfo);
            Assert.Contains("Side: Cookies", prepInfo);
            Assert.Contains("\t3 Oatmeal Raisin Cookies", prepInfo);
            Assert.Contains("Drink: Fountain Drink", prepInfo);
            Assert.Contains("\tLarge", prepInfo);
            Assert.Contains("\tMountain Dew", prepInfo);
        }
    }
}