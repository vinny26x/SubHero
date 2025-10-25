using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A California-style club in a wrap
    /// </summary>
    public class CaliforniaClubWrap : Entree
    {
        /// <summary>
        /// Constructor for California Club Wrap's ingredients
        /// </summary>
        public CaliforniaClubWrap()
        {
            AddAvailableIngredient(IngredientType.Turkey, isDefault: true);
            AddAvailableIngredient(IngredientType.Bacon, isDefault: true);
            AddAvailableIngredient(IngredientType.Avocado, isDefault: true);
            AddAvailableIngredient(IngredientType.SwissCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.Sprouts, isDefault: true);
            AddAvailableIngredient(IngredientType.Mayo, isDefault: true);
        }

        /// <summary>
        /// The default bread type for wraps
        /// </summary>
        public override BreadType DefaultBread => BreadType.Wrap;

        /// <summary>
        /// The name of the California Club Wrap
        /// </summary>
        public override string Name => "California Club Wrap";

        /// <summary>
        /// The description of this wrap
        /// </summary>
        public override string Description => "A California-style club in a wrap";

        /// <summary>
        /// The base price before size adjustments (specialty wrap pricing)
        /// </summary>
        protected override decimal BasePrice => 9.49m;

        /// <summary>
        /// The price of the wrap (fixed price, ingredients included)
        /// </summary>
        public override decimal Price
        {
            get
            {
                return BasePrice; 
            }
        }

        /// <summary>
        /// Whether this wrap contains turkey
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
        /// Whether this wrap contains bacon
        /// </summary>
        public bool Bacon
        {
            get => Ingredients[IngredientType.Bacon].Included;
            set
            {
                if (Ingredients[IngredientType.Bacon].Included != value)
                {
                    Ingredients[IngredientType.Bacon].Included = value;
                    OnPropertyChanged(nameof(Bacon));
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
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains swiss cheese
        /// </summary>
        public bool SwissCheese
        {
            get => Ingredients[IngredientType.SwissCheese].Included;
            set
            {
                if (Ingredients[IngredientType.SwissCheese].Included != value)
                {
                    Ingredients[IngredientType.SwissCheese].Included = value;
                    OnPropertyChanged(nameof(SwissCheese));
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
        /// Whether this wrap contains sprouts
        /// </summary>
        public bool Sprouts
        {
            get => Ingredients[IngredientType.Sprouts].Included;
            set
            {
                if (Ingredients[IngredientType.Sprouts].Included != value)
                {
                    Ingredients[IngredientType.Sprouts].Included = value;
                    OnPropertyChanged(nameof(Sprouts));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether this wrap contains mayo
        /// </summary>
        public bool Mayo
        {
            get => Ingredients[IngredientType.Mayo].Included;
            set
            {
                if (Ingredients[IngredientType.Mayo].Included != value)
                {
                    Ingredients[IngredientType.Mayo].Included = value;
                    OnPropertyChanged(nameof(Mayo));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}