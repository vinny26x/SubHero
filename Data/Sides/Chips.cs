using SubHero.Data.Enums;

namespace SubHero.Data.Sides
{
    /// <summary>
    /// A bag of chips in various flavors
    /// </summary>
    public class Chips : Side
    {
        private ChipType _flavor = ChipType.Lays;

        /// <summary>
        /// The flavor of chips
        /// </summary>
        public ChipType Flavor
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
        /// The name of the chips
        /// </summary>
        public override string Name => "Chips";

        /// <summary>
        /// The description of the chips
        /// </summary>
        public override string Description => "Your favorite bags of crunchy deliciousness";

        /// <summary>
        /// The price of the chips
        /// </summary>
        public override decimal Price => 1.95m;

        /// <summary>
        /// The calories in the chips based on flavor
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Flavor)
                {
                    case ChipType.Lays:
                        return 240;
                    case ChipType.Doritos:
                        return 250;
                    case ChipType.Cheetos:
                        return 260;
                    case ChipType.SunChips:
                        return 210;
                    case ChipType.Pretzels:
                        return 180;
                    default:
                        return 240;
                }
            }
        }

        /// <summary>
        /// Preparation information for the chips
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                switch (Flavor)
                {
                    case ChipType.Lays:
                        instructions.Add("Lays");
                        break;
                    case ChipType.Doritos:
                        instructions.Add("Doritos");
                        break;
                    case ChipType.Cheetos:
                        instructions.Add("Cheetos");
                        break;
                    case ChipType.SunChips:
                        instructions.Add("Sun Chips");
                        break;
                    case ChipType.Pretzels:
                        instructions.Add("Pretzels");
                        break;
                }
                return instructions;
            }
        }
    }
}