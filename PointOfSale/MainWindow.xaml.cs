using System.Windows;
using System.Windows.Controls;
using SubHero.Data;
using SubHero.Data.Enums;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            
            MenuSelection.MenuItemAdded += OnMenuItemAdded;

            
            OrderSummary.EditItemRequested += OnEditItemRequested;
        }

        /// <summary>
        /// Handles when a menu item is added from the menu selection
        /// </summary>
        private void OnMenuItemAdded(object? sender, MenuItemAddedEventArgs e)
        {
            // Add to order
            OrderSummary.Order.Add(e.MenuItem);
            OrderSummary.UpdateTotals();

            // Show customization screen for the new item
            ShowCustomizationScreen(e.MenuItem);
        }

        /// <summary>
        /// Handles when an item needs to be edited from the order summary
        /// </summary>
        private void OnEditItemRequested(object? sender, IMenuItem item)
        {
            ShowCustomizationScreen(item);
        }

        /// <summary>
        /// Shows the appropriate customization screen for a menu item
        /// </summary>
        private void ShowCustomizationScreen(IMenuItem item)
        {
            UserControl? customizationControl = null;

            // checkwhich customization control to show based on item type
            if (item is Entree)
            {
                customizationControl = new EntreeCustomizationControl();
            }
            else if (item is Apple)
            {
                customizationControl = new AppleCustomizationControl();
            }
            else if (item is Chips)
            {
                customizationControl = new ChipsCustomizationControl();
            }
            else if (item is Cookies)
            {
                customizationControl = new CookiesCustomizationControl();
            }
            else if (item is SideSalad)
            {
                customizationControl = new SideSaladCustomizationControl();
            }
            else if (item is FountainDrink)
            {
                customizationControl = new FountainDrinkCustomizationControl();
            }
            else if (item is IcedTea)
            {
                customizationControl = new IcedTeaCustomizationControl();
            }
            else if (item is Lemonade)
            {
                customizationControl = new LemonadeCustomizationControl();
            }

            if (customizationControl != null)
            {
                // set the DataContext to the item being changed
                customizationControl.DataContext = item;

                // swap the content
                ContentBorder.Child = customizationControl;
            }
        }

        /// <summary>
        /// Handles the Back to Menu button click
        /// </summary>
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // show the menu selection control again
            ContentBorder.Child = MenuSelection;
        }
    }
}