using System.Windows;
using System.Windows.Controls;
using SubHero.Data;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for ComboCustomizationControl.xaml
    /// Allows customization of a Combo meal
    /// </summary>
    public partial class ComboCustomizationControl : UserControl
    {
        /// <summary>
        /// Event fired when user wants to edit the entree
        /// </summary>
        public event EventHandler? EditEntreeRequested;

        /// <summary>
        /// Event fired when user wants to edit the side
        /// </summary>
        public event EventHandler? EditSideRequested;

        /// <summary>
        /// Event fired when user wants to edit the drink
        /// </summary>
        public event EventHandler? EditDrinkRequested;

        /// <summary>
        /// Constructor
        /// </summary>
        public ComboCustomizationControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the display names based on current combo selections
        /// </summary>
        public void UpdateDisplayNames()
        {
            if (DataContext is Combo combo)
            {
                EntreeNameTextBlock.Text = combo.SandwichChoice.Name;
                SideNameTextBlock.Text = combo.SideChoice.Name;
                DrinkNameTextBlock.Text = combo.DrinkChoice.Name;
            }
        }

        /// <summary>
        /// Handles entree type selection changes
        /// </summary>
        private void EntreeTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EntreeTypeComboBox.SelectedItem is ComboBoxItem item && DataContext is Combo combo)
            {
                string? tag = item.Tag as string;

                Entree? newEntree = tag switch
                {
                    "CustomSandwich" => new CustomSandwich(),
                    "CaliforniaClubWrap" => new CaliforniaClubWrap(),
                    "ClubSub" => new ClubSub(),
                    "ItalianSub" => new ItalianSub(),
                    "MediterraneanWrap" => new MediterraneanWrap(),
                    "TurkeyCranberry" => new TurkeyCranberrySandwich(),
                    "VeggieSandwich" => new VeggieSandwich(),
                    _ => null
                };

                if (newEntree != null)
                {
                    combo.SandwichChoice = newEntree;
                    UpdateDisplayNames();
                }
            }
        }

        /// <summary>
        /// Handles side type selection changes
        /// </summary>
        private void SideTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SideTypeComboBox.SelectedItem is ComboBoxItem item && DataContext is Combo combo)
            {
                string? tag = item.Tag as string;

                Side? newSide = tag switch
                {
                    "Apple" => new Apple(),
                    "Chips" => new Chips(),
                    "Cookies" => new Cookies(),
                    "SideSalad" => new SideSalad(),
                    _ => null
                };

                if (newSide != null)
                {
                    combo.SideChoice = newSide;
                    UpdateDisplayNames();
                }
            }
        }

        /// <summary>
        /// Handles drink type selection changes
        /// </summary>
        private void DrinkTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrinkTypeComboBox.SelectedItem is ComboBoxItem item && DataContext is Combo combo)
            {
                string? tag = item.Tag as string;

                Drink? newDrink = tag switch
                {
                    "FountainDrink" => new FountainDrink(),
                    "IcedTea" => new IcedTea(),
                    "Lemonade" => new Lemonade(),
                    _ => null
                };

                if (newDrink != null)
                {
                    combo.DrinkChoice = newDrink;
                    UpdateDisplayNames();
                }
            }
        }

        /// <summary>
        /// Handles Edit Entree button click
        /// </summary>
        private void EditEntree_Click(object sender, RoutedEventArgs e)
        {
            EditEntreeRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles Edit Side button click
        /// </summary>
        private void EditSide_Click(object sender, RoutedEventArgs e)
        {
            EditSideRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles Edit Drink button click
        /// </summary>
        private void EditDrink_Click(object sender, RoutedEventArgs e)
        {
            EditDrinkRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}