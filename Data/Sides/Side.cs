using SubHero.Data.Enums;
using System.ComponentModel;

namespace SubHero.Data.Sides
{
    /// <summary>
    /// Abstract base class for all side items
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
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
        /// The name of the side item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the side item
        /// </summary>
        public abstract string Description { get; }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// The price of the side item
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories in the side item
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Preparation information for the side item
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }
    }
}