using SubHero.Data.Enums;

namespace SubHero.Data.Sides
{
    /// <summary>
    /// Freshly baked cookies in various flavors
    /// </summary>
    public class Cookies : Side
    {
        /// <summary>
        /// Backing field for cookie count
        /// </summary>
        private uint _cookieCount = 2;

        /// <summary>
        /// Backing field for flavor
        /// </summary>
        private CookieType _flavor = CookieType.ChocolateChip;

        /// <summary>
        /// The flavor of the cookies
        /// </summary>
        public CookieType Flavor
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
        /// The number of cookies (2-6)
        /// </summary>
        public uint CookieCount
        {
            get { return _cookieCount; }
            set
            {
                if (value >= 2 && value <= 6 && _cookieCount != value)
                {
                    _cookieCount = value;
                    OnPropertyChanged(nameof(CookieCount));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(PreparationInformation));
                }
                // If value is outside bounds, leave count unchanged
            }
        }

        /// <summary>
        /// The name of the cookies
        /// </summary>
        public override string Name => "Cookies";

        /// <summary>
        /// The description of the cookies
        /// </summary>
        public override string Description => "Freshly baked cookies in a variety of flavors";

        /// <summary>
        /// The price based on cookie count ($3.00 per pair + $1.75 for unpaired cookie)
        /// </summary>
        public override decimal Price
        {
            get
            {
                uint pairs = CookieCount / 2;
                uint extraCookie = CookieCount % 2;
                decimal cost = pairs * 3.00m;
                if (extraCookie > 0)
                {
                    cost += 1.75m;
                }
                return cost;
            }
        }

        /// <summary>
        /// The total calories based on flavor and count
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint caloriesPerCookie = 0;
                switch (Flavor)
                {
                    case CookieType.ChocolateChip:
                        caloriesPerCookie = 180;
                        break;
                    case CookieType.OatmealRaisin:
                        caloriesPerCookie = 150;
                        break;
                    case CookieType.Sugar:
                        caloriesPerCookie = 160;
                        break;
                    case CookieType.PeanutButter:
                        caloriesPerCookie = 190;
                        break;
                }
                return CookieCount * caloriesPerCookie;
            }
        }

        /// <summary>
        /// Preparation information for the cookies
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                string flavorName = "";
                switch (Flavor)
                {
                    case CookieType.ChocolateChip:
                        flavorName = "Chocolate Chip";
                        break;
                    case CookieType.OatmealRaisin:
                        flavorName = "Oatmeal Raisin";
                        break;
                    case CookieType.Sugar:
                        flavorName = "Sugar";
                        break;
                    case CookieType.PeanutButter:
                        flavorName = "Peanut Butter";
                        break;
                }
                instructions.Add($"{CookieCount} {flavorName} Cookies");
                return instructions;
            }
        }
    }
}