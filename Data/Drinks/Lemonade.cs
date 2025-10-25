using SubHero.Data.Enums;

namespace SubHero.Data.Drinks
{
    /// <summary>
    /// Fresh squeezed lemonade in classic or pink flavors
    /// </summary>
    public class Lemonade : Drink
    {
        /// <summary>
        /// The size of the lemonade
        /// </summary>
        public override SizeType Size { get; set; } = SizeType.Medium;

        /// <summary>
        /// Whether the lemonade includes ice
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Whether the lemonade is pink lemonade
        /// </summary>
        public bool Pink { get; set; } = false;



        /// <summary>
        /// The name of the lemonade
        /// </summary>
        public override string Name => "Lemonade";

        /// <summary>
        /// The description of the lemonade
        /// </summary>
        public override string Description => "Fresh squeezed lemonade";

        /// <summary>
        /// The price of the lemonade based on size
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal basePrice = 2.50m; // Medium price

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
        /// The calories in the lemonade based on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                // Lemonade has 9 calories per ounce
                return CalculateCalories(9);
            }
        }

        /// <summary>
        /// Prep info for the lemonade
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                // Add size first
                instructions.Add(Size.ToString());

                // Add custom
                if (Pink)
                {
                    instructions.Add("Pink Lemonade");
                    instructions.Add("Add Strawberry");
                }

                if (!Ice)
                {
                    instructions.Add("Hold Ice");
                }

                return instructions;
            }
        }
    }
}