using SubHero.Data.Enums;

namespace SubHero.Data
{
    /// <summary>
    /// Represents an ingredient for a menu item
    /// </summary>
    public class IngredientItem
    {
        /// <summary>
        /// The type of ingredient
        /// </summary>
        public IngredientType Ingredient { get; }

        /// <summary>
        /// Whether this ingredient is included in the menu item
        /// </summary>
        public bool Included { get; set; } = false;

        /// <summary>
        /// Whether this ingredient is included by default in the menu item
        /// </summary>
        public bool Default { get; init; } = false;

        /// <summary>
        /// Constructor that initializes ingredient type
        /// </summary>
        /// <param name="ingredient">The type of ingredient</param>
        public IngredientItem(IngredientType ingredient)
        {
            Ingredient = ingredient;
        }

        /// <summary>
        /// The display name of the ingredient 
        /// </summary>
        public string Name
        {
            get
            {
                switch (Ingredient)
                {
                    case IngredientType.CheddarCheese:
                        return "Cheddar Cheese";
                    case IngredientType.SwissCheese:
                        return "Swiss Cheese";
                    case IngredientType.ChipotleMayo:
                        return "Chipotle Mayo";
                    case IngredientType.RedOnion:
                        return "Red Onion";
                    case IngredientType.CranberrySauce:
                        return "Cranberry Sauce";
                    case IngredientType.CreamCheese:
                        return "Cream Cheese";
                    case IngredientType.ProvoloneCheese:
                        return "Provolone Cheese";
                    case IngredientType.FetaCheese:
                        return "Feta Cheese";
                    case IngredientType.KalamataOlives:
                        return "Kalamata Olives";
                    case IngredientType.RoastedRedPeppers:
                        return "Roasted Red Peppers";
                    case IngredientType.ItalianDressing:
                        return "Italian Dressing";
                    case IngredientType.RanchDressing:
                        return "Ranch Dressing";
                    default:
                        return Ingredient.ToString();
                }
            }
        }

        /// <summary>
        /// The calories provided by this ingredient
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Ingredient)
                {
                    case IngredientType.Turkey:
                        return 25;
                    case IngredientType.Ham:
                        return 150; 
                   case IngredientType.CheddarCheese:
                   case IngredientType.ProvoloneCheese:
                        return 100; 
                    case IngredientType.SwissCheese:
                        return 100;  
                    case IngredientType.Bacon:
                        return 170;  
                    case IngredientType.Avocado:
                        return 200;
                    case IngredientType.Mayo:
                        return 90;
                    case IngredientType.ChipotleMayo:
                        return 90;
                    case IngredientType.Lettuce:
                        return 15;
                    case IngredientType.RedOnion:
                        return 15;
                    case IngredientType.Cucumber:
                        return 30;
                    case IngredientType.Sprouts:
                        return 3;
                    case IngredientType.Tomato:
                        return 25;
                    case IngredientType.CranberrySauce:
                        return 75;
                    case IngredientType.Salami:
                        return 239;
                    case IngredientType.Hummus:
                        return 130;
                    case IngredientType.CreamCheese:
                        return 125;
                    case IngredientType.FetaCheese:
                        return 50;
                    case IngredientType.ItalianDressing:
                        return 70;
                    case IngredientType.KalamataOlives:
                    case IngredientType.RoastedRedPeppers:
                        return 15;
                    case IngredientType.Pepperoni:
                        return 150;
                    case IngredientType.RanchDressing:
                        return 90;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// The unit cost of this ingredient
        /// </summary>
        public decimal UnitCost
        {
            get
            {
                switch (Ingredient)
                {
                    // $1.00 for meats, cheeses, avocado, cranberry sauce, and hummus
                    case IngredientType.Turkey:
                    case IngredientType.Ham:
                    case IngredientType.Bacon:
                    case IngredientType.Salami:
                    case IngredientType.Pepperoni:
                    case IngredientType.CheddarCheese:
                    case IngredientType.SwissCheese:
                    case IngredientType.ProvoloneCheese:
                    case IngredientType.CreamCheese:
                    case IngredientType.FetaCheese:
                    case IngredientType.Avocado:
                        return 1.00m;
                    case IngredientType.CranberrySauce:
                    case IngredientType.Hummus:
                        return 1.00m;
                    // $0.50 for roasted red peppers and Kalamata olives
                    case IngredientType.RoastedRedPeppers:
                    case IngredientType.KalamataOlives:
                        return 0.50m;
                    // $0.00 for everything else
                    default:
                        return 0.00m;
                }
            }
        }
    }
}