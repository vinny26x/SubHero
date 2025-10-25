using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A vegetarian sandwich piled high with crisp veggies and two cheeses
    /// </summary>
    public class VeggieSandwich : Entree
    {
        /// <summary>
        /// Constructor that sets up the Veggie Sandwich's specific ingredients
        /// </summary>
        public VeggieSandwich()
        {
            AddAvailableIngredient(IngredientType.ProvoloneCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.CreamCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.Avocado, isDefault: true);
            AddAvailableIngredient(IngredientType.Lettuce, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.Cucumber, isDefault: true);
            AddAvailableIngredient(IngredientType.ChipotleMayo, isDefault: true);
        }

        /// <summary>
        /// The default bread type for veggie sandwiches
        /// </summary>
        public override BreadType DefaultBread => BreadType.Sourdough;

        /// <summary>
        /// The name of the veggie sandwich
        /// </summary>
        public override string Name => "Veggie Sandwich";

        /// <summary>
        /// The description of this sandwich
        /// </summary>
        public override string Description => "A vegetarian sandwich piled high with crisp veggies and two cheeses";

        /// <summary>
        /// The base price before size adjustments 
        /// </summary>
        protected override decimal BasePrice => 7.99m;

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
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains avocado
        /// </summary>
        public bool Avocado
        {
            get => Ingredients[IngredientType.Avocado].Included;
            set
            {
                if (Ingredients[IngredientType.Avocado].Included != value)
                {
                    Ingredients[IngredientType.Avocado].Included = value;
                    OnPropertyChanged(nameof(Avocado));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains lettuce
        /// </summary>
        public bool Lettuce
        {
            get => Ingredients[IngredientType.Lettuce].Included;
            set
            {
                if (Ingredients[IngredientType.Lettuce].Included != value)
                {
                    Ingredients[IngredientType.Lettuce].Included = value;
                    OnPropertyChanged(nameof(Lettuce));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains tomato
        /// </summary>
        public bool Tomato
        {
            get => Ingredients[IngredientType.Tomato].Included;
            set
            {
                if (Ingredients[IngredientType.Tomato].Included != value)
                {
                    Ingredients[IngredientType.Tomato].Included = value;
                    OnPropertyChanged(nameof(Tomato));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains cucumber
        /// </summary>
        public bool Cucumber
        {
            get => Ingredients[IngredientType.Cucumber].Included;
            set
            {
                if (Ingredients[IngredientType.Cucumber].Included != value)
                {
                    Ingredients[IngredientType.Cucumber].Included = value;
                    OnPropertyChanged(nameof(Cucumber));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sandwich contains chipotle mayo
        /// </summary>
        public bool ChipotleMayo
        {
            get => Ingredients[IngredientType.ChipotleMayo].Included;
            set
            {
                if (Ingredients[IngredientType.ChipotleMayo].Included != value)
                {
                    Ingredients[IngredientType.ChipotleMayo].Included = value;
                    OnPropertyChanged(nameof(ChipotleMayo));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}