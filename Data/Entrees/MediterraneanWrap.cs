using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A vegetarian Mediterranean-style wrap
    /// </summary>
    public class MediterraneanWrap : Entree
    {
        /// <summary>
        /// Constructor that sets up the Mediterranean Wrap's specific ingredients
        /// </summary>
        public MediterraneanWrap()
        {
            AddAvailableIngredient(IngredientType.Hummus, isDefault: true);
            AddAvailableIngredient(IngredientType.FetaCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.KalamataOlives, isDefault: true);
            AddAvailableIngredient(IngredientType.Cucumber, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.ItalianDressing, isDefault: true);
            AddAvailableIngredient(IngredientType.RoastedRedPeppers, isDefault: true);
            AddAvailableIngredient(IngredientType.Avocado, isDefault: false);
        }

        /// <summary>
        /// The default bread type for wraps
        /// </summary>
        public override BreadType DefaultBread => BreadType.Wrap;

        /// <summary>
        /// The name of the Mediterranean wrap
        /// </summary>
        public override string Name => "Mediterranean Wrap";

        /// <summary>
        /// The description of this wrap
        /// </summary>
        public override string Description => "A vegetarian Mediterranean-style wrap";

        /// <summary>
        /// The base price before size adjustment
        /// </summary>
        protected override decimal BasePrice => 7.99m;

        /// <summary>
        /// Custom price calculation for Mediterranean wrap (includes avocado surcharge)
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = BasePrice;

                // Add avocado surcharge 
                if (Ingredients[IngredientType.Avocado].Included)
                {
                    cost += 1.00m;
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
        /// Whether this wrap contains hummus
        /// </summary>
        public bool Hummus
        {
            get => Ingredients[IngredientType.Hummus].Included;
            set
            {
                if (Ingredients[IngredientType.Hummus].Included != value)
                {
                    Ingredients[IngredientType.Hummus].Included = value;
                    OnPropertyChanged(nameof(Hummus));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains feta cheese
        /// </summary>
        public bool FetaCheese
        {
            get => Ingredients[IngredientType.FetaCheese].Included;
            set
            {
                if (Ingredients[IngredientType.FetaCheese].Included != value)
                {
                    Ingredients[IngredientType.FetaCheese].Included = value;
                    OnPropertyChanged(nameof(FetaCheese));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains Kalamata olives
        /// </summary>
        public bool KalamataOlives
        {
            get => Ingredients[IngredientType.KalamataOlives].Included;
            set
            {
                if (Ingredients[IngredientType.KalamataOlives].Included != value)
                {
                    Ingredients[IngredientType.KalamataOlives].Included = value;
                    OnPropertyChanged(nameof(KalamataOlives));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains cucumber
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
        /// Whether this wrap contains tomato
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
        /// Whether this wrap contains Italian dressing
        /// </summary>
        public bool ItalianDressing
        {
            get => Ingredients[IngredientType.ItalianDressing].Included;
            set
            {
                if (Ingredients[IngredientType.ItalianDressing].Included != value)
                {
                    Ingredients[IngredientType.ItalianDressing].Included = value;
                    OnPropertyChanged(nameof(ItalianDressing));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains roasted red peppers
        /// </summary>
        public bool RoastedRedPeppers
        {
            get => Ingredients[IngredientType.RoastedRedPeppers].Included;
            set
            {
                if (Ingredients[IngredientType.RoastedRedPeppers].Included != value)
                {
                    Ingredients[IngredientType.RoastedRedPeppers].Included = value;
                    OnPropertyChanged(nameof(RoastedRedPeppers));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains avocado
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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}