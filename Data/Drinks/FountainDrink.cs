using SubHero.Data.Enums;

namespace SubHero.Data.Drinks
{
    /// <summary>
    /// A fountain drink with various soda flavors and sizes
    /// </summary>
    public class FountainDrink : Drink
    {
        private SodaType _flavor = SodaType.Coke;
        private SizeType _size = SizeType.Medium;
        private bool _ice = true;

        /// <summary>
        /// The flavor of the soda
        /// </summary>
        public SodaType Flavor
        {
            get => _flavor;
            set
            {
                if (_flavor != value)
                {
                    _flavor = value;
                    OnPropertyChanged(nameof(Flavor));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// The size of the drink
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
        /// Whether the drink includes ice
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
        /// The name of the fountain drink
        /// </summary>
        public override string Name => "Fountain Drink";

        /// <summary>
        /// The description of the fountain drink
        /// </summary>
        public override string Description => "Standard soda from the fountain";

        /// <summary>
        /// The price of the drink based on size
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case SizeType.Small:
                        return 1.75m;
                    case SizeType.Medium:
                        return 2.00m;
                    case SizeType.Large:
                        return 2.50m;
                    default:
                        return 2.00m;
                }
            }
        }

        /// <summary>
        /// The calories in the drink based on size and flavor
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint caloriesPerOunce = 0;
                // find calories per ounce based on flavor
                switch (Flavor)
                {
                    case SodaType.Coke:
                        caloriesPerOunce = 12;
                        break;
                    case SodaType.CokeZero:
                        caloriesPerOunce = 0;
                        break;
                    case SodaType.DrPepper:
                    case SodaType.OrangeFanta:
                        caloriesPerOunce = 13;
                        break;
                    case SodaType.MountainDew:
                        caloriesPerOunce = 14;
                        break;
                }
                return CalculateCalories(caloriesPerOunce);
            }
        }

        /// <summary>
        /// Prep info for the drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                // Add size
                instructions.Add(Size.ToString());
                // Add flavor
                switch (Flavor)
                {
                    case SodaType.Coke:
                        instructions.Add("Coke");
                        break;
                    case SodaType.CokeZero:
                        instructions.Add("Coke Zero");
                        break;
                    case SodaType.DrPepper:
                        instructions.Add("Dr Pepper");
                        break;
                    case SodaType.OrangeFanta:
                        instructions.Add("Orange Fanta");
                        break;
                    case SodaType.MountainDew:
                        instructions.Add("Mountain Dew");
                        break;
                }
                // Add ice instruction if no ice
                if (!Ice)
                {
                    instructions.Add("Hold Ice");
                }
                return instructions;
            }
        }
    }
}