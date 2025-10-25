using System.ComponentModel;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.Data
{
    /// <summary>
    /// A combo meal that includes an entree, side, and drink at a discounted price
    /// </summary>
    public class Combo : IMenuItem, INotifyPropertyChanged
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

        private Entree _sandwichChoice;
        private Drink _drinkChoice;
        private Side _sideChoice;

        /// <summary>
        /// The entree choice for this combo
        /// </summary>
        public Entree SandwichChoice
        {
            get => _sandwichChoice;
            set
            {
                // Unsubscribe from old item
                if (_sandwichChoice != null)
                {
                    _sandwichChoice.PropertyChanged -= OnChildItemPropertyChanged;
                }

                _sandwichChoice = value;

                // Subscribe to new item
                if (_sandwichChoice != null)
                {
                    _sandwichChoice.PropertyChanged += OnChildItemPropertyChanged;
                }

                OnPropertyChanged(nameof(SandwichChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The drink choice for this combo
        /// </summary>
        public Drink DrinkChoice
        {
            get => _drinkChoice;
            set
            {
                // Unsubscribe from old item
                if (_drinkChoice != null)
                {
                    _drinkChoice.PropertyChanged -= OnChildItemPropertyChanged;
                }

                _drinkChoice = value;

                // Subscribe to new item
                if (_drinkChoice != null)
                {
                    _drinkChoice.PropertyChanged += OnChildItemPropertyChanged;
                }

                OnPropertyChanged(nameof(DrinkChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The side choice for this combo
        /// </summary>
        public Side SideChoice
        {
            get => _sideChoice;
            set
            {
                // Unsubscribe from old item
                if (_sideChoice != null)
                {
                    _sideChoice.PropertyChanged -= OnChildItemPropertyChanged;
                }

                _sideChoice = value;

                // Subscribe to new item
                if (_sideChoice != null)
                {
                    _sideChoice.PropertyChanged += OnChildItemPropertyChanged;
                }

                OnPropertyChanged(nameof(SideChoice));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Constructor for default combo choices
        /// </summary>
        public Combo()
        {
            _sandwichChoice = new CustomSandwich();
            _drinkChoice = new FountainDrink();
            _sideChoice = new Chips();

            // Subscribe to property changes
            _sandwichChoice.PropertyChanged += OnChildItemPropertyChanged;
            _drinkChoice.PropertyChanged += OnChildItemPropertyChanged;
            _sideChoice.PropertyChanged += OnChildItemPropertyChanged;
        }

        /// <summary>
        /// Handles property changes from child items
        /// </summary>
        private void OnChildItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // When a child item's property changes, update combo properties
            if (e.PropertyName == nameof(IMenuItem.Price))
            {
                OnPropertyChanged(nameof(Price));
            }
            if (e.PropertyName == nameof(IMenuItem.Calories))
            {
                OnPropertyChanged(nameof(Calories));
            }
            if (e.PropertyName == nameof(IMenuItem.PreparationInformation))
            {
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The name of the combo
        /// </summary>
        public string Name => "Combo";

        /// <summary>
        /// The description of the combo
        /// </summary>
        public string Description => "A sandwich plus your choice of side and drink";

        /// <summary>
        /// The price of the combo 
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal totalPrice = SandwichChoice.Price + DrinkChoice.Price + SideChoice.Price;
                return totalPrice * 0.8m; // 20% discount
            }
        }

        /// <summary>
        /// The total calories of all items in the combo
        /// </summary>
        public uint Calories
        {
            get
            {
                return SandwichChoice.Calories + DrinkChoice.Calories + SideChoice.Calories;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Preparation information for all items in the combo
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                // Add sandwich information
                instructions.Add($"Sandwich: {SandwichChoice.Name}");
                foreach (var instruction in SandwichChoice.PreparationInformation)
                {
                    instructions.Add($"\t{instruction}");
                }
                // Add side information
                instructions.Add($"Side: {SideChoice.Name}");
                foreach (var instruction in SideChoice.PreparationInformation)
                {
                    instructions.Add($"\t{instruction}");
                }
                // Add drink information
                instructions.Add($"Drink: {DrinkChoice.Name}");
                foreach (var instruction in DrinkChoice.PreparationInformation)
                {
                    instructions.Add($"\t{instruction}");
                }
                return instructions;
            }
        }
    }
}