using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A festive sandwich with turkey, cranberry sauce, and cream cheese
    /// </summary>
    public class TurkeyCranberrySandwich : Entree
    {
        /// <summary>
        /// Constructor that sets up the Turkey Cranberry Sandwich's specific ingredients
        /// </summary>
        public TurkeyCranberrySandwich()
        {
            // Add only the ingredients that are available on a Turkey Cranberry Sandwich
            // Default ingredients 
            AddAvailableIngredient(IngredientType.Turkey, isDefault: true);
            AddAvailableIngredient(IngredientType.CranberrySauce, isDefault: true);
            AddAvailableIngredient(IngredientType.CreamCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.RedOnion, isDefault: true);

            // Optional ingredients 
            AddAvailableIngredient(IngredientType.ProvoloneCheese, isDefault: false);
        }

        /// <summary>
        /// The default bread type for turkey cranberry sandwiches
        /// </summary>
        public override BreadType DefaultBread => BreadType.Wheat;

        /// <summary>
        /// The name of the turkey cranberry sandwich
        /// </summary>
        public override string Name => "Turkey Cranberry Sandwich";

        /// <summary>
        /// The description of this sandwich
        /// </summary>
        public override string Description => "A festive sandwich with turkey, cranberry sauce, and cream cheese";

        /// <summary>
        /// The base price before size adjustments (specialty sandwich pricing)
        /// </summary>
        protected override decimal BasePrice => 8.49m;

        /// <summary>
        /// Custom price calculation for Turkey Cranberry Sandwich (includes both cheese surcharge)
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = BasePrice;

                // Add both cheese surcharge
                bool hasCream = Ingredients[IngredientType.CreamCheese].Included;
                bool hasProvolone = Ingredients[IngredientType.ProvoloneCheese].Included;

                if (hasCream && hasProvolone)
                {
                    cost += 1.00m; // Both cheeses surcharge
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

        /// <summary>
        /// Whether this sandwich contains turkey
        /// </summary>
        public bool Turkey
        {
            get => Ingredients[IngredientType.Turkey].Included;
            set
            {
                if (Ingredients[IngredientType.Turkey].Included != value)
                {
                    Ingredients[IngredientType.Turkey].Included = value;
                    OnPropertyChanged(nameof(Turkey));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains cranberry sauce
        /// </summary>
        public bool CranberrySauce
        {
            get => Ingredients[IngredientType.CranberrySauce].Included;
            set
            {
                if (Ingredients[IngredientType.CranberrySauce].Included != value)
                {
                    Ingredients[IngredientType.CranberrySauce].Included = value;
                    OnPropertyChanged(nameof(CranberrySauce));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains cream cheese
        /// </summary>
        public bool CreamCheese
        {
            get => Ingredients[IngredientType.CreamCheese].Included;
            set
            {
                if (Ingredients[IngredientType.CreamCheese].Included != value)
                {
                    Ingredients[IngredientType.CreamCheese].Included = value;
                    OnPropertyChanged(nameof(CreamCheese));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains red onion
        /// </summary>
        public bool RedOnion
        {
            get => Ingredients[IngredientType.RedOnion].Included;
            set
            {
                if (Ingredients[IngredientType.RedOnion].Included != value)
                {
                    Ingredients[IngredientType.RedOnion].Included = value;
                    OnPropertyChanged(nameof(RedOnion));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains provolone cheese
        /// </summary>
        public bool ProvoloneCheese
        {
            get => Ingredients[IngredientType.ProvoloneCheese].Included;
            set
            {
                if (Ingredients[IngredientType.ProvoloneCheese].Included != value)
                {
                    Ingredients[IngredientType.ProvoloneCheese].Included = value;
                    OnPropertyChanged(nameof(ProvoloneCheese));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}