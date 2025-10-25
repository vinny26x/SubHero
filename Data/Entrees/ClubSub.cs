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
            AddAvailableIngredient(IngredientType.Turkey, isDefault: true);
            AddAvailableIngredient(IngredientType.Ham, isDefault: true);
            AddAvailableIngredient(IngredientType.Bacon, isDefault: true);
            AddAvailableIngredient(IngredientType.CheddarCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.ChipotleMayo, isDefault: true);
            AddAvailableIngredient(IngredientType.Lettuce, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.RedOnion, isDefault: true);
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

                // Add premium ingredient charges 
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
        /// Whether this sandwich contains ham
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
        /// Whether this sandwich contains bacon
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
        /// Whether this sandwich contains cheddar cheese
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
                    OnPropertyChanged(nameof(Price));
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
        /// Whether this sandwich contains swiss cheese
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
                    OnPropertyChanged(nameof(Price));
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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}