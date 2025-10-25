using SubHero.Data.Enums;
using System.ComponentModel;

namespace SubHero.Data.Drinks
{
    /// <summary>
    /// Abstract base class for all drink items
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
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
        /// The size of the drink
        /// </summary>
        public abstract SizeType Size { get; set; }

        /// <summary>
        /// The name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories in the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Prep information for the drink
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Gets the number of ounces for the current size
        /// Standard sizes: Small=16oz, Medium=20oz, Large=32oz
        /// </summary>
        protected uint GetOunces()
        {
            switch (Size)
            {
                case SizeType.Small:
                    return 16;
                case SizeType.Medium:
                    return 20;
                case SizeType.Large:
                    return 32;
                default:
                    return 20;
            }
        }

        /// <summary>
        /// Calculates calories based on size and calories per ounce
        /// </summary>
        /// <param name="caloriesPerOunce">The calories per ounce for this drink</param>
        /// <returns>Total calories for the drink</returns>
        protected uint CalculateCalories(uint caloriesPerOunce)
        {
            return GetOunces() * caloriesPerOunce;
        }
    }
}