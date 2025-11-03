using SubHero.Data.Enums;
using System.ComponentModel;

namespace SubHero.Data.Entrees
{
    /// <summary>
    /// abstract base class for all entree items (sandwiches, subs, wraps)
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event raised when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Helper method to raise PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Field for the bread type
        /// </summary>
        private BreadType _bread;

        /// <summary>
        /// Field for the size
        /// </summary>
        private SizeType _size = SizeType.Medium;

        /// <summary>
        /// Collection of ingredients for this entree
        /// </summary>
        protected Dictionary<IngredientType, IngredientItem> Ingredients { get; set; }

        /// <summary>
        /// Constructor for ingredients collection
        /// </summary>
        protected Entree()
        {
            Ingredients = new Dictionary<IngredientType, IngredientItem>();
            _bread = DefaultBread;
        }

        /// <summary>
        /// The default bread type for this entree
        /// </summary>
        public abstract BreadType DefaultBread { get; }

        /// <summary>
        /// The name of the entree
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the entree
        /// </summary>
        public abstract string Description { get; }

        private SizeType? _attemptedSize = null;

        /// <summary>
        /// The current bread choice for this entree
        /// </summary>
        public virtual BreadType Bread
        {
            get { return _bread; }
            set
            {
                BreadType oldBread = _bread;

                if (IsValidBreadSizeCombination(value, _size))
                {
                    _bread = value;
                }

                // After changing bread, try to apply attempted size if valid
                if (_attemptedSize.HasValue && IsValidBreadSizeCombination(_bread, _attemptedSize.Value))
                {
                    _size = _attemptedSize.Value;
                    _attemptedSize = null;
                }

                // notify if bread actually changed
                if (oldBread != _bread)
                {
                    OnPropertyChanged(nameof(Bread));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                    OnPropertyChanged(nameof(SizeOptions));
                }
            }
        }

        /// <summary>
        /// The current size of this entree
        /// </summary>
        public virtual SizeType Size
        {
            get { return _size; }
            set
            {
                SizeType oldSize = _size;

                if (IsValidBreadSizeCombination(_bread, value))
                {
                    _size = value;
                    _attemptedSize = null;
                }
                else
                {
                    _attemptedSize = value; // Remember the attempted size
                }

                // notify if size actually changed
                if (oldSize != _size)
                {
                    OnPropertyChanged(nameof(Size));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                    OnPropertyChanged(nameof(BreadOptions));
                }
            }
        }


        /// <summary>
        /// Gets the available size options based on the current bread choice
        /// </summary>
        public IEnumerable<SizeType> SizeOptions
        {
            get
            {
                List<SizeType> options = new List<SizeType>();

                switch (Bread)
                {
                    case BreadType.Wrap:
                        options.Add(SizeType.Medium);
                        break;
                    case BreadType.Wheat:
                    case BreadType.Sourdough:
                        options.Add(SizeType.Small);
                        options.Add(SizeType.Medium);
                        break;
                    case BreadType.Hoagie:
                        options.Add(SizeType.Small);
                        options.Add(SizeType.Medium);
                        options.Add(SizeType.Large);
                        break;
                }

                return options;
            }
        }

        /// <summary>
        /// Gets the available bread options based on the current size choice
        /// </summary>
        public IEnumerable<BreadType> BreadOptions
        {
            get
            {
                List<BreadType> options = new List<BreadType>();

                switch (Size)
                {
                    case SizeType.Small:
                        options.Add(BreadType.Wheat);
                        options.Add(BreadType.Sourdough);
                        options.Add(BreadType.Hoagie);
                        break;
                    case SizeType.Medium:
                        options.Add(BreadType.Wheat);
                        options.Add(BreadType.Sourdough);
                        options.Add(BreadType.Wrap);
                        options.Add(BreadType.Hoagie);
                        break;
                    case SizeType.Large:
                        options.Add(BreadType.Hoagie);
                        break;
                }

                return options;
            }
        }

        /// <summary>
        /// Gets the collection of available ingredients for this entree
        /// </summary>
        public IEnumerable<IngredientItem> AvailableIngredients
        {
            get => Ingredients.Values;
        }

        /// <summary>
        /// The base price of this entree before size change
        /// </summary>
        protected abstract decimal BasePrice { get; }

        /// <summary>
        /// The price of this entree including size change and ingredient costs
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal cost = BasePrice;

                // Add ingredient costs ONLY for non-default ingredients
                foreach (var ingredient in Ingredients.Values)
                {
                    if (ingredient.Included && !ingredient.Default)
                    {
                        cost += ingredient.UnitCost;
                    }
                }

                // Adjust for size
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
        /// The calories in this entree including bread, ingredients, and size adjustments
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                uint baseCals = 0;

                // Base calories for bread type
                switch (Bread)
                {
                    case BreadType.Wrap:
                        baseCals = 220;
                        break;
                    case BreadType.Wheat:
                    case BreadType.Sourdough:
                        baseCals = 250;
                        break;
                    case BreadType.Hoagie:
                        baseCals = 290;
                        break;
                }

                // Add ingredient calories
                foreach (var ingredient in Ingredients.Values)
                {
                    if (ingredient.Included)
                    {
                        baseCals += ingredient.Calories;
                    }
                }

                // Apply size scaling
                switch (Size)
                {
                    case SizeType.Small:
                        baseCals = baseCals / 2;
                        break;
                    case SizeType.Large:
                        baseCals = (uint)(baseCals * 1.5);
                        break;
                }

                return baseCals;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Prep information for this entree
        /// </summary>
        public virtual IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                // Add size info (unless it's a wrap)
                if (Bread != BreadType.Wrap)
                {
                    instructions.Add(Size.ToString());
                }

                // Add bread info if changes happen
                if (Bread != DefaultBread)
                {
                    switch (Bread)
                    {
                        case BreadType.Wheat:
                            instructions.Add("Use Wheat Bread");
                            break;
                        case BreadType.Sourdough:
                            instructions.Add("Use Sourdough Bread");
                            break;
                        case BreadType.Wrap:
                            instructions.Add("Use Wrap");
                            break;
                        case BreadType.Hoagie:
                            instructions.Add("Use Hoagie");
                            break;
                    }
                }

                // Add instructions for non-default included ingredients
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
        /// Checks if a bread type and size combination is allowed
        /// </summary>
        /// <param name="bread">The bread type</param>
        /// <param name="size">The size</param>
        /// <returns>True if the combination is valid</returns>
        protected bool IsValidBreadSizeCombination(BreadType bread, SizeType size)
        {
            // If current bread is Wrap, only allow Wrap 
            if (_bread == BreadType.Wrap && bread != BreadType.Wrap)
            {
                return false;
            }

            // If trying to change to Wrap from something else, only allow if current size is Medium
            if (bread == BreadType.Wrap && _size != SizeType.Medium)
            {
                return false;
            }

            switch (bread)
            {
                case BreadType.Wrap:
                    return size == SizeType.Medium;
                case BreadType.Wheat:
                case BreadType.Sourdough:
                    return size == SizeType.Small || size == SizeType.Medium;
                case BreadType.Hoagie:
                    return true; // Any size allowed
                default:
                    return false;
            }
        }

        /// <summary>
        /// Method to add an ingredient to this entree
        /// </summary>
        /// <param name="ingredientType">The type of ingredient to add</param>
        /// <param name="isDefault">Whether this ingredient is included by default</param>
        protected void AddAvailableIngredient(IngredientType ingredientType, bool isDefault = false)
        {
            var ingredient = new IngredientItem(ingredientType)
            {
                Default = isDefault,
                Included = isDefault
            };

            // Subscribe to ingredient property changes
            ingredient.PropertyChanged += OnIngredientPropertyChanged;

            Ingredients[ingredientType] = ingredient;
        }

        /// <summary>
        /// Handles property changes from individual ingredients
        /// </summary>
        private void OnIngredientPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IngredientItem.Included))
            {
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }
    }
}