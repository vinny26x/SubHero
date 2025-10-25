using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A club sub with turkey, ham, bacon, and other classic ingredients
    /// </summary>
    public class ClubSub : Entree
    {
        /// <summary>
        /// Constructor that sets up the Club Sub's specific ingredients
        /// </summary>
        public ClubSub()
        {
            // Add only the ingredients that are available on a Club Sub
            // Default ingredients (included by default)
            AddAvailableIngredient(IngredientType.Turkey, isDefault: true);
            AddAvailableIngredient(IngredientType.Ham, isDefault: true);
            AddAvailableIngredient(IngredientType.Bacon, isDefault: true);
            AddAvailableIngredient(IngredientType.CheddarCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.ChipotleMayo, isDefault: true);
            AddAvailableIngredient(IngredientType.Lettuce, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.RedOnion, isDefault: true);

            // Optional ingredients (not included by default)
            AddAvailableIngredient(IngredientType.SwissCheese, isDefault: false);
            AddAvailableIngredient(IngredientType.Avocado, isDefault: false);
        }

        /// <summary>
        /// The default bread type for club subs
        /// </summary>
        public override BreadType DefaultBread => BreadType.Hoagie;

        /// <summary>
        /// The name of the club sub
        /// </summary>
        public override string Name => "Club Sub";

        /// <summary>
        /// The description of this sandwich
        /// </summary>
        public override string Description => "Classic club sandwich stacked high";

        /// <summary>
        /// The base price before size adjustments (specialty sub pricing)
        /// </summary>
        protected override decimal BasePrice => 8.98m;

        /// <summary>
        /// Custom price calculation for specialty subs
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = BasePrice;

                // Add premium ingredient charges (specialty sub pricing)
                bool hasCheddar = Ingredients[IngredientType.CheddarCheese].Included;
                bool hasSwiss = Ingredients[IngredientType.SwissCheese].Included;

                if (hasCheddar && hasSwiss)
                {
                    cost += 1.00m; // Both cheeses
                }

                if (Ingredients[IngredientType.Avocado].Included)
                {
                    cost += 1.00m; // Avocado surcharge
                }

                // Apply size adjustments
                switch (Size)
                {
                    case SizeType.Small:
                        cost -= 3.00m;
                        break;
                    case SizeType.Large:
                        cost += 2.00m;
                        break;
                }

                return cost;
            }
        }

        // Convenience properties for easy access to specific ingredients
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
        /// Whether this sandwich contains cheddar cheese
        /// </summary>
        public bool CheddarCheese
        {
            get => Ingredients[IngredientType.CheddarCheese].Included;
            set => Ingredients[IngredientType.CheddarCheese].Included = value;
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
        /// Whether this sandwich contains swiss cheese
        /// </summary>
        public bool SwissCheese
        {
            get => Ingredients[IngredientType.SwissCheese].Included;
            set => Ingredients[IngredientType.SwissCheese].Included = value;
        }

        /// <summary>
        /// Whether this sandwich contains avocado
        /// </summary>
        public bool Avocado
        {
            get => Ingredients[IngredientType.Avocado].Included;
            set => Ingredients[IngredientType.Avocado].Included = value;
        }
    }
}