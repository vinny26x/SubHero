using SubHero.Data.Enums;

namespace SubHero.Data.Sides
{
    /// <summary>
    /// Honeycrisp apple side item
    /// </summary>
    public class Apple : Side
    {
        private bool _sliced = false;

        /// <summary>
        /// Whether the apple is sliced or not
        /// </summary>
        public bool Sliced
        {
            get => _sliced;
            set
            {
                if (_sliced != value)
                {
                    _sliced = value;
                    OnPropertyChanged(nameof(Sliced));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
            }
        }

        /// <summary>
        /// The name of the apple
        /// </summary>
        public override string Name => "Apple";

        /// <summary>
        /// The description of the apple
        /// </summary>
        public override string Description => "Honeycrisp apple";

        /// <summary>
        /// The price for apple, $1.25 for unsliced, $1.75 for sliced
        /// </summary>
        public override decimal Price => Sliced ? 1.75m : 1.25m;

        /// <summary>
        /// The calories in the apple
        /// </summary>
        public override uint Calories => 100u;

        /// <summary>
        /// Preparation information for the apple
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                var info = new List<string>();
                if (Sliced)
                {
                    info.Add("Sliced");
                }
                return info;
            }
        }
    }
}