using SubHero.Data.Enums;

namespace SubHero.Data.Sides
{
    /// <summary>
    /// A fresh side salad with customizable ingredients
    /// </summary>
    public class SideSalad : Side
    {
        /// <summary>
        /// Collection of available ingredients for this salad
        /// </summary>
        private Dictionary<IngredientType, IngredientItem> Ingredients { get; set; }

        /// <summary>
        /// Constructor that sets up available salad ingredients
        /// </summary>
        public SideSalad()
        {
            Ingredients = new Dictionary<IngredientType, IngredientItem>();

            AddAvailableIngredient(IngredientType.FetaCheese, isDefault: true);
            AddAvailableIngredient(IngredientType.Tomato, isDefault: true);
            AddAvailableIngredient(IngredientType.Cucumber, isDefault: true);
            AddAvailableIngredient(IngredientType.RedOnion, isDefault: true);
            AddAvailableIngredient(IngredientType.RanchDressing, isDefault: true);
            AddAvailableIngredient(IngredientType.Avocado, isDefault: false);
        }

        /// <summary>
        /// The name of the side salad
        /// </summary>
        public override string Name => "Side Salad";

        /// <summary>
        /// The description of the side salad
        /// </summary>
        public override string Description => "Garden salad with lots of veggies";

        /// <summary>
        /// The price of the side salad (includes avocado surcharge)
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 4.99m; // base price

                // Add avocado surcharge
                if (Ingredients[IngredientType.Avocado].Included)
                {
                    cost += 1.00m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The calories in the side salad
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint totalCals = 20; // base calories for greens

                foreach (var ingredient in Ingredients.Values)
                {
                    if (ingredient.Included)
                    {
                        // Ranch dressing and avocado use normal calories
                        if (ingredient.Ingredient == IngredientType.RanchDressing ||
                            ingredient.Ingredient == IngredientType.Avocado)
                        {
                            totalCals += ingredient.Calories;
                        }
                        else
                        {
                            // All other ingredients are double calories 
                            totalCals += ingredient.Calories * 2;
                        }
                    }
                }

                return totalCals;
            }
        }

        /// <summary>
        /// Preparation information for the side salad
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                foreach (var ingredient in Ingredients.Values)
                {
                    if (ingredient.Included && !ingredient.Default)
                    {
                        instructions.Add($"Add {ingredient.Name}");
                    }
                    else if (!ingredient.Included && ingredient.Default)
                    {
                        instructions.Add($"Hold {ingredient.Name}");
                    }
                }

                return instructions;
            }
        }

        /// <summary>
        /// Helper method to add an ingredient to this salad
        /// </summary>
        /// <param name="ingredientType">The type of ingredient to add</param>
        /// <param name="isDefault">Whether this ingredient is included by default</param>
        private void AddAvailableIngredient(IngredientType ingredientType, bool isDefault = false)
        {
            var ingredient = new IngredientItem(ingredientType)
            {
                Default = isDefault,
                Included = isDefault
            };
            Ingredients[ingredientType] = ingredient;
        }

        // Ingredient properties with property change notifications
        /// <summary>
        /// Whether this salad includes feta cheese
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
        /// Whether this salad includes tomato
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
        /// Whether this salad includes cucumber
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
        /// Whether this salad includes red onion
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
        /// Whether this salad includes ranch dressing
        /// </summary>
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

        /// <summary>
        /// Whether this salad includes avocado
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