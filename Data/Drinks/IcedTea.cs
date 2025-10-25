using SubHero.Data.Enums;

namespace SubHero.Data.Drinks
{
    /// <summary>
    /// Freshly brewed iced tea with choice of sweetness
    /// </summary>
    public class IcedTea : Drink
    {
        private SizeType _size = SizeType.Medium;
        private bool _ice = true;
        private bool _sweet = true;
        private bool _lemon = false;

        /// <summary>
        /// The size of the iced tea
        /// </summary>
        public override SizeType Size
        {
            get => _size;
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged(nameof(Size));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether the tea includes ice
        /// </summary>
        public bool Ice
        {
            get => _ice;
            set
            {
                if (_ice != value)
                {
                    _ice = value;
                    OnPropertyChanged(nameof(Ice));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether the tea is sweetened
        /// </summary>
        public bool Sweet
        {
            get => _sweet;
            set
            {
                if (_sweet != value)
                {
                    _sweet = value;
                    OnPropertyChanged(nameof(Sweet));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// Whether the tea includes lemon
        /// </summary>
        public bool Lemon
        {
            get => _lemon;
            set
            {
                if (_lemon != value)
                {
                    _lemon = value;
                    OnPropertyChanged(nameof(Lemon));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// The name of the iced tea
        /// </summary>
        public override string Name => "Iced Tea";

        /// <summary>
        /// The description of the iced tea
        /// </summary>
        public override string Description => "Freshly brewed iced tea with choice of sweetness";

        /// <summary>
        /// The price of the iced tea based on size
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal basePrice = 2.25m; // Medium price
                switch (Size)
                {
                    case SizeType.Small:
                        return basePrice - 0.25m;
                    case SizeType.Large:
                        return basePrice + 0.50m;
                    default: // Medium
                        return basePrice;
                }
            }
        }

        /// <summary>
        /// The calories in the iced tea based on size and sweetness
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (!Sweet)
                    return 0; // Unsweetened tea has no calories
                // Sweet tea has 6 calories per ounce 
                return CalculateCalories(6);
            }
        }

        /// <summary>
        /// Preparation information for the iced tea
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                // Add size first
                instructions.Add(Size.ToString());

                if (!Sweet)
                {
                    instructions.Add("Unsweetened");
                }
                if (!Ice)
                {
                    instructions.Add("Hold Ice");
                }
                if (Lemon)
                {
                    instructions.Add("Add Lemon");
                }
                return instructions;
            }
        }
    }
}