using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A customizable sandwich that allows customers to choose their own ingredients
    /// </summary>
    public class CustomSandwich : Entree
    {
        /// <summary>
        /// Constructor that sets up all available ingredients
        /// </summary>
        public CustomSandwich()
        {
            // Add all ingredients as available, but none are default (custom = build your own)
            AddAvailableIngredient(IngredientType.Turkey);
            AddAvailableIngredient(IngredientType.Ham);
            AddAvailableIngredient(IngredientType.Bacon);
            AddAvailableIngredient(IngredientType.Salami);
            AddAvailableIngredient(IngredientType.Pepperoni);
            AddAvailableIngredient(IngredientType.CheddarCheese);
            AddAvailableIngredient(IngredientType.SwissCheese);
            AddAvailableIngredient(IngredientType.ProvoloneCheese);
            AddAvailableIngredient(IngredientType.CreamCheese);
            AddAvailableIngredient(IngredientType.FetaCheese);
            AddAvailableIngredient(IngredientType.Mayo);
            AddAvailableIngredient(IngredientType.ChipotleMayo);
            AddAvailableIngredient(IngredientType.RanchDressing);
            AddAvailableIngredient(IngredientType.ItalianDressing);
            AddAvailableIngredient(IngredientType.Lettuce);
            AddAvailableIngredient(IngredientType.Tomato);
            AddAvailableIngredient(IngredientType.RedOnion);
            AddAvailableIngredient(IngredientType.Cucumber);
            AddAvailableIngredient(IngredientType.Sprouts);
            AddAvailableIngredient(IngredientType.Avocado);
            AddAvailableIngredient(IngredientType.KalamataOlives);
            AddAvailableIngredient(IngredientType.RoastedRedPeppers);
            AddAvailableIngredient(IngredientType.CranberrySauce);
            AddAvailableIngredient(IngredientType.Hummus);
        }

        /// <summary>
        /// The default bread type for custom sandwiches
        /// </summary>
        public override BreadType DefaultBread => BreadType.Wheat;

        /// <summary>
        /// The name of the custom sandwich
        /// </summary>
        public override string Name => "Custom Sandwich";

        /// <summary>
        /// The description of the custom sandwich
        /// </summary>
        public override string Description => "Create your own sandwich with custom bread and toppings";

        /// <summary>
        /// The base price before size adjustments and ingredient costs
        /// </summary>
        protected override decimal BasePrice => 5.99m;

        // Convenience properties for easy access to all available ingredients

        /// <summary>
        /// Whether this sandwich contains turkey
        /// </summary>
        public bool Turkey
        {
            get => Ingredients[IngredientType.Turkey].Included;
            set => Ingredients[IngredientType.Turkey].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains ham
        /// </summary>
        public bool Ham
        {
            get => Ingredients[IngredientType.Ham].Included;
            set => Ingredients[IngredientType.Ham].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains bacon
        /// </summary>
        public bool Bacon
        {
            get => Ingredients[IngredientType.Bacon].Included;
            set => Ingredients[IngredientType.Bacon].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains salami
        /// </summary>
        public bool Salami
        {
            get => Ingredients[IngredientType.Salami].Included;
            set => Ingredients[IngredientType.Salami].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains pepperoni
        /// </summary>
        public bool Pepperoni
        {
            get => Ingredients[IngredientType.Pepperoni].Included;
            set => Ingredients[IngredientType.Pepperoni].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains cheddar cheese
        /// </summary>
        public bool CheddarCheese
        {
            get => Ingredients[IngredientType.CheddarCheese].Included;
            set => Ingredients[IngredientType.CheddarCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains swiss cheese
        /// </summary>
        public bool SwissCheese
        {
            get => Ingredients[IngredientType.SwissCheese].Included;
            set => Ingredients[IngredientType.SwissCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains provolone cheese
        /// </summary>
        public bool ProvoloneCheese
        {
            get => Ingredients[IngredientType.ProvoloneCheese].Included;
            set => Ingredients[IngredientType.ProvoloneCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains cream cheese
        /// </summary>
        public bool CreamCheese
        {
            get => Ingredients[IngredientType.CreamCheese].Included;
            set => Ingredients[IngredientType.CreamCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains feta cheese
        /// </summary>
        public bool FetaCheese
        {
            get => Ingredients[IngredientType.FetaCheese].Included;
            set => Ingredients[IngredientType.FetaCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains mayo
        /// </summary>
        public bool Mayo
        {
            get => Ingredients[IngredientType.Mayo].Included;
            set => Ingredients[IngredientType.Mayo].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains chipotle mayo
        /// </summary>
        public bool ChipotleMayo
        {
            get => Ingredients[IngredientType.ChipotleMayo].Included;
            set => Ingredients[IngredientType.ChipotleMayo].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains ranch dressing
        /// </summary>
        public bool RanchDressing
        {
            get => Ingredients[IngredientType.RanchDressing].Included;
            set => Ingredients[IngredientType.RanchDressing].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains Italian dressing
        /// </summary>
        public bool ItalianDressing
        {
            get => Ingredients[IngredientType.ItalianDressing].Included;
            set => Ingredients[IngredientType.ItalianDressing].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains lettuce
        /// </summary>
        public bool Lettuce
        {
            get => Ingredients[IngredientType.Lettuce].Included;
            set => Ingredients[IngredientType.Lettuce].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains tomato
        /// </summary>
        public bool Tomato
        {
            get => Ingredients[IngredientType.Tomato].Included;
            set => Ingredients[IngredientType.Tomato].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains red onion
        /// </summary>
        public bool RedOnion
        {
            get => Ingredients[IngredientType.RedOnion].Included;
            set => Ingredients[IngredientType.RedOnion].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains cucumber
        /// </summary>
        public bool Cucumber
        {
            get => Ingredients[IngredientType.Cucumber].Included;
            set => Ingredients[IngredientType.Cucumber].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains sprouts
        /// </summary>
        public bool Sprouts
        {
            get => Ingredients[IngredientType.Sprouts].Included;
            set => Ingredients[IngredientType.Sprouts].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains avocado
        /// </summary>
        public bool Avocado
        {
            get => Ingredients[IngredientType.Avocado].Included;
            set => Ingredients[IngredientType.Avocado].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains Kalamata olives
        /// </summary>
        public bool KalamataOlives
        {
            get => Ingredients[IngredientType.KalamataOlives].Included;
            set => Ingredients[IngredientType.KalamataOlives].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains roasted red peppers
        /// </summary>
        public bool RoastedRedPeppers
        {
            get => Ingredients[IngredientType.RoastedRedPeppers].Included;
            set => Ingredients[IngredientType.RoastedRedPeppers].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains cranberry sauce
        /// </summary>
        public bool CranberrySauce
        {
            get => Ingredients[IngredientType.CranberrySauce].Included;
            set => Ingredients[IngredientType.CranberrySauce].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains hummus
        /// </summary>
        public bool Hummus
        {
            get => Ingredients[IngredientType.Hummus].Included;
            set => Ingredients[IngredientType.Hummus].Included = value;
        }
    }
}