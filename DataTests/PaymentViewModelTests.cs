using SubHero.Data;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.DataTests
{
    /// <summary>
    /// Integration tests for PaymentViewModel
    /// </summary>
    public class PaymentViewModelTests
    {
        /// <summary>
        /// Integration test for complete order workflow with payment
        /// </summary>
        [Fact]
        public void CompleteOrderWorkflowTest()
        {
            // ============ FIRST ORDER ============

            // Create Order #1
            Order order1 = new Order();
            Assert.Equal(1, order1.Number);

            // Add Combo: Club Sub (small, wheat, swiss and cheddar cheese, no bacon) 
            //            + Side Salad (with avocado, no feta) 
            //            + Fountain Drink (large, Mountain Dew, no ice)
            var combo = CreateTestCombo();
            order1.Add(combo);

            // Add 5 Sugar Cookies
            var cookies = CreateSugarCookies();
            order1.Add(cookies);

            // Add Custom Sandwich on wrap (ham, turkey, bacon, avocado, mayo, lettuce)
            var customSandwich = CreateCustomSandwich();
            order1.Add(customSandwich);

            // Debug output
            Console.WriteLine($"Combo Price: ${combo.Price:F2}");
            Console.WriteLine($"Cookies Price: ${cookies.Price:F2}");
            Console.WriteLine($"Custom Sandwich Price: ${customSandwich.Price:F2}");
            Console.WriteLine($"Subtotal: ${order1.Subtotal:F4}");
            Console.WriteLine($"Tax: ${order1.Tax:F4}");
            Console.WriteLine($"Total: ${order1.Total:F4}");

            // Assert order totals
            Assert.Equal(30.12m, order1.Subtotal, 2);
            Assert.Equal(2.76m, order1.Tax, 2);
            Assert.Equal(32.87m, order1.Total, 2);

            // Create PaymentViewModel
            var paymentViewModel1 = new PaymentViewModel(order1);

            // Set payment amount
            paymentViewModel1.Paid = 40.00m;

            // Assert change
            Assert.Equal(7.13m, paymentViewModel1.Change, 2);

            // ============ SECOND ORDER ============

            // Create Order #2
            Order order2 = new Order();
            Assert.Equal(2, order2.Number);

            // Add Sun Chips
            var sunChips = new Chips() { Flavor = ChipType.SunChips };
            order2.Add(sunChips);

            // Add Large Italian Sub (no salami)
            var italianSub = CreateItalianSub();
            order2.Add(italianSub);

            // Add Small Strawberry Lemonade
            var lemonade = new Lemonade()
            {
                Size = SizeType.Small,
                Pink = true  // Strawberry lemonade
            };
            order2.Add(lemonade);

            // Debug output for order 2
            Console.WriteLine($"\nOrder 2:");
            Console.WriteLine($"Sun Chips Price: ${sunChips.Price:F2}");
            Console.WriteLine($"Italian Sub Price: ${italianSub.Price:F2}");
            Console.WriteLine($"Lemonade Price: ${lemonade.Price:F2}");
            Console.WriteLine($"Subtotal: ${order2.Subtotal:F4}");
            Console.WriteLine($"Tax: ${order2.Tax:F4}");
            Console.WriteLine($"Total: ${order2.Total:F4}");

            // Assert order totals
            Assert.Equal(18.19m, order2.Subtotal, 2);
            Assert.Equal(1.66m, order2.Tax, 2);
            Assert.Equal(19.85m, order2.Total, 2);

            // Create PaymentViewModel for order 2
            var paymentViewModel2 = new PaymentViewModel(order2);

            // Try to set payment less than total - should throw exception
            Assert.Throws<ArgumentException>(() =>
            {
                paymentViewModel2.Paid = 15.00m;
            });
        }

        /// <summary>
        /// Helper method to create the combo for testing
        /// Combo with Club Sub (small, wheat, swiss and cheddar cheese, no bacon)
        /// + Side Salad (with avocado, no feta)
        /// + Fountain Drink (large, Mountain Dew, no ice)
        /// Expected price: 80% of ($8.99 + $1.00 - $3.00 + $4.99 + $1.00 + $2.00 + $0.50) = $12.38
        /// </summary>
        private Combo CreateTestCombo()
        {
            var combo = new Combo();

            // Configure Club Sub
            var clubSub = new ClubSub();
            clubSub.Size = SizeType.Small;  // -$3.00
            clubSub.Bread = BreadType.Wheat;

            // Add swiss and cheddar cheese (both cost $1.00 each, not default)
            clubSub.SwissCheese = true;      // +$1.00
            clubSub.CheddarCheese = true;    // +$1.00

            // Remove bacon (is default on Club Sub)
            clubSub.Bacon = false;

            combo.SandwichChoice = clubSub;

            // Configure Side Salad
            var sideSalad = new SideSalad();
            sideSalad.Avocado = true;        // +$1.00
            sideSalad.FetaCheese = false;    // Remove default
            combo.SideChoice = sideSalad;

            // Configure Fountain Drink
            var fountainDrink = new FountainDrink();
            fountainDrink.Size = SizeType.Large;  // +$0.50
            fountainDrink.Flavor = SodaType.MountainDew;
            fountainDrink.Ice = false;
            combo.DrinkChoice = fountainDrink;

            return combo;
        }

        /// <summary>
        /// Helper method to create 5 sugar cookies
        /// Expected price: $6.00 + $1.75 = $7.75
        /// </summary>
        private Cookies CreateSugarCookies()
        {
            var cookies = new Cookies();
            cookies.Flavor = CookieType.Sugar;
            cookies.CookieCount = 5;  // 2 pairs ($6.00) + 1 extra ($1.75) = $7.75
            return cookies;
        }

        /// <summary>
        /// Helper method to create custom sandwich on wrap
        /// (ham, turkey, bacon, avocado, mayo, lettuce)
        /// Expected price: $5.99 + $1.00 + $1.00 + $1.00 + $1.00 = $9.99
        /// </summary>
        private CustomSandwich CreateCustomSandwich()
        {
            var sandwich = new CustomSandwich();
            sandwich.Bread = BreadType.Wrap;

            // Add ingredients (all cost $1.00 each except mayo and lettuce which are free)
            sandwich.Ham = true;       // +$1.00
            sandwich.Turkey = true;    // +$1.00
            sandwich.Bacon = true;     // +$1.00
            sandwich.Avocado = true;   // +$1.00
            sandwich.Mayo = true;      // free
            sandwich.Lettuce = true;   // free

            return sandwich;
        }

        /// <summary>
        /// Helper method to create large Italian Sub without salami
        /// Expected price: $10.99 + $2.00 = $12.99
        /// </summary>
        private ItalianSub CreateItalianSub()
        {
            var sub = new ItalianSub();
            sub.Size = SizeType.Large;  // +$2.00
            sub.Salami = false;          // Remove default ingredient
            return sub;
        }
    }
}