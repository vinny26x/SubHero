using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// An Italian-inspired sub with layers of savory meats and cheeses
    /// </summary>
    public class ItalianSub : Entree
    {
        /// <summary>
        /// Constructor that sets up the Italian Sub's specific ingredients
        /// </summary>
        public ItalianSub()
        {
            AddAvailableIngredient(IngredientType.Salami, isDefault: true);
            AddAvailableIngredient(IngredientType.Pepperoni, isDefault: true);
            AddAvailableIngredient(IngredientType.Ham, isDefault: true);
            AddAvailableIngredient(IngredientType.ProvoloneCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.CheddarCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.Lettuce, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.ItalianDressing, isDefault: true);
            AddAvailableIngredient(IngredientType.RoastedRedPeppers, isDefault: true);
        }

        /// <summary>
        /// The default bread type for Italian subs
        /// </summary>
        public override BreadType DefaultBread => BreadType.Hoagie;

        /// <summary>
        /// The name of the Italian sub
        /// </summary>
        public override string Name => "Italian Sub";

        /// <summary>
        /// The description of this sub
        /// </summary>
        public override string Description => "An Italian-inspired sub with layers of savory meats and cheeses";

        /// <summary>
        /// The base price before size adjustments (specialty sub pricing)
        /// </summary>
        protected override decimal BasePrice => 10.99m;

        /// <summary>
        /// Whether this sub contains salami
        /// </summary>
        public bool Salami
        {
            get => Ingredients[IngredientType.Salami].Included;
            set
            {
                if (Ingredients[IngredientType.Salami].Included != value)
                {
                    Ingredients[IngredientType.Salami].Included = value;
                    OnPropertyChanged(nameof(Salami));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sub contains pepperoni
        /// </summary>
        public bool Pepperoni
        {
            get => Ingredients[IngredientType.Pepperoni].Included;
            set
            {
                if (Ingredients[IngredientType.Pepperoni].Included != value)
                {
                    Ingredients[IngredientType.Pepperoni].Included = value;
                    OnPropertyChanged(nameof(Pepperoni));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sub contains ham
        /// </summary>
        public bool Ham
        {
            get => Ingredients[IngredientType.Ham].Included;
            set
            {
                if (Ingredients[IngredientType.Ham].Included != value)
                {
                    Ingredients[IngredientType.Ham].Included = value;
                    OnPropertyChanged(nameof(Ham));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sub contains provolone cheese
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
        /// Whether this sub contains cheddar cheese
        /// </summary>
        public bool CheddarCheese
        {
            get => Ingredients[IngredientType.CheddarCheese].Included;
            set
            {
                if (Ingredients[IngredientType.CheddarCheese].Included != value)
                {
                    Ingredients[IngredientType.CheddarCheese].Included = value;
                    OnPropertyChanged(nameof(CheddarCheese));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this sub contains lettuce
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
        /// Whether this sub contains tomato
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
        /// Whether this sub contains Italian dressing
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
        /// Whether this sub contains roasted red peppers
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
    }
}