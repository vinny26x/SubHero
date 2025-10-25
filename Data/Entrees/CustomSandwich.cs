using SubHero.Data.Enums;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// A customizable sandwich that allows customers to choose their own ingredients
    /// </summary>
    public class CustomSandwich : Entree
    {
        /// <summary>
        /// Constructor for all available ingredients
        /// </summary>
        public CustomSandwich()
        {
            // Add all ingredients 
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

        // All ingredient properties with notifications
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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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

        public bool RanchDressing
        {
            get => Ingredients[IngredientType.RanchDressing].Included;
            set
            {
                if (Ingredients[IngredientType.RanchDressing].Included != value)
                {
                    Ingredients[IngredientType.RanchDressing].Included = value;
                    OnPropertyChanged(nameof(RanchDressing));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

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
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }
    }
}