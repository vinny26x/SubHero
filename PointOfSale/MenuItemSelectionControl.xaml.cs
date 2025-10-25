using System;
using System.Windows;
using System.Windows.Controls;
using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;  // ← ADD THIS

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Event args for when a menu item is added
    /// </summary>
    public class MenuItemAddedEventArgs : EventArgs
    {
        /// <summary>
        /// The menu item that was added
        /// </summary>
        public IMenuItem MenuItem { get; set; }  // ← Now this will work

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItemAddedEventArgs(IMenuItem item)
        {
            MenuItem = item;
        }
    }

    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Event that fires when a menu item is added
        /// </summary>
        public event EventHandler<MenuItemAddedEventArgs>? MenuItemAdded;

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        // Entree click handlers
        private void AddCustomSandwich_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new CustomSandwich()));
        }

        private void AddCaliforniaClubWrap_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new CaliforniaClubWrap()));
        }

        private void AddClubSub_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new ClubSub()));
        }

        private void AddItalianSub_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new ItalianSub()));
        }

        private void AddMediterraneanWrap_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new MediterraneanWrap()));
        }

        private void AddTurkeyCranberry_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new TurkeyCranberrySandwich()));
        }

        private void AddVeggieSandwich_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new VeggieSandwich()));
        }

        // Side click handlers
        private void AddApple_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new Apple()));
        }

        private void AddChips_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new Chips()));
        }

        private void AddSideSalad_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new SideSalad()));
        }

        private void AddCookies_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new Cookies()));
        }

        // Drink click handlers
        private void AddFountainDrink_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new FountainDrink()));
        }

        private void AddIcedTea_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new IcedTea()));
        }

        private void AddLemonade_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAdded?.Invoke(this, new MenuItemAddedEventArgs(new Lemonade()));
        }
    }
}