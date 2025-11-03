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
        /// Tracks if we're currently editing a combo (to hide "Make it a Combo" button)
        /// </summary>
        private bool _isEditingCombo = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            MenuSelection.MenuItemAdded += OnMenuItemAdded;
            OrderSummary.EditItemRequested += OnEditItemRequested;

            // Wire up Complete Order button
            CompleteOrderButton.Click += CompleteOrderButton_Click;

            // Wire up Cancel Order button
            CancelOrderButton.Click += CancelOrderButton_Click;
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
            _isEditingCombo = false;
            ShowCustomizationScreen(e.MenuItem);
        }

        /// <summary>
        /// Handles when an item needs to be edited from the order summary
        /// </summary>
        private void OnEditItemRequested(object? sender, IMenuItem item)
        {
            // Check if we're editing a combo
            _isEditingCombo = item is Combo;
            ShowCustomizationScreen(item);
        }

        /// <summary>
        /// Shows the appropriate customization screen for a menu item
        /// </summary>
        private void ShowCustomizationScreen(IMenuItem item)
        {
            UserControl? customizationControl = null;

            // Check which customization control to show based on item type
            if (item is Combo combo)
            {
                var comboControl = new ComboCustomizationControl();
                comboControl.DataContext = combo;
                comboControl.UpdateDisplayNames();

                // Subscribe to edit events
                comboControl.EditEntreeRequested += (s, e) => ShowComboItemCustomization(combo, combo.SandwichChoice);
                comboControl.EditSideRequested += (s, e) => ShowComboItemCustomization(combo, combo.SideChoice);
                comboControl.EditDrinkRequested += (s, e) => ShowComboItemCustomization(combo, combo.DrinkChoice);

                customizationControl = comboControl;
            }
            else if (item is Entree entree)
            {
                var entreeControl = new EntreeCustomizationControl();
                entreeControl.DataContext = entree;

                // Hide or show the "Make it a Combo" button
                entreeControl.SetComboButtonVisibility(!_isEditingCombo);

                // Subscribe to Make Combo event
                entreeControl.MakeComboRequested += (s, e) => ConvertToCombo(entree);

                customizationControl = entreeControl;
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
                // Set the DataContext to the item being changed (if not already set)
                if (customizationControl.DataContext == null)
                {
                    customizationControl.DataContext = item;
                }

                // Swap the content
                ContentBorder.Child = customizationControl;
            }
        }

        /// <summary>
        /// Converts an entree to a combo
        /// </summary>
        private void ConvertToCombo(Entree entree)
        {
            // Create a new combo with the entree
            var combo = new Combo
            {
                SandwichChoice = entree
            };

            // Find the entree in the order and replace it with the combo
            int index = -1;
            for (int i = 0; i < OrderSummary.Order.Count; i++)
            {
                if (OrderSummary.Order.ElementAt(i) == entree)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                // Remove the entree
                OrderSummary.Order.Remove(entree);

                // Add the combo in its place
                var items = OrderSummary.Order.ToList();
                items.Insert(index, combo);

                OrderSummary.Order.Clear();
                foreach (var item in items)
                {
                    OrderSummary.Order.Add(item);
                }
            }

            OrderSummary.UpdateTotals();

            // Show the combo customization screen
            _isEditingCombo = true;
            ShowCustomizationScreen(combo);
        }

        /// <summary>
        /// Shows customization for an item within a combo
        /// </summary>
        private void ShowComboItemCustomization(Combo combo, IMenuItem comboItem)
        {
            UserControl? customizationControl = null;

            if (comboItem is Entree entree)
            {
                var entreeControl = new EntreeCustomizationControl();
                entreeControl.DataContext = entree;

                // IMPORTANT: Hide the "Make it a Combo" button since we're editing within a combo
                entreeControl.SetComboButtonVisibility(false);

                customizationControl = entreeControl;
            }
            else if (comboItem is Apple)
            {
                customizationControl = new AppleCustomizationControl();
            }
            else if (comboItem is Chips)
            {
                customizationControl = new ChipsCustomizationControl();
            }
            else if (comboItem is Cookies)
            {
                customizationControl = new CookiesCustomizationControl();
            }
            else if (comboItem is SideSalad)
            {
                customizationControl = new SideSaladCustomizationControl();
            }
            else if (comboItem is FountainDrink)
            {
                customizationControl = new FountainDrinkCustomizationControl();
            }
            else if (comboItem is IcedTea)
            {
                customizationControl = new IcedTeaCustomizationControl();
            }
            else if (comboItem is Lemonade)
            {
                customizationControl = new LemonadeCustomizationControl();
            }

            if (customizationControl != null)
            {
                customizationControl.DataContext = comboItem;
                ContentBorder.Child = customizationControl;
            }
        }

        /// <summary>
        /// Handles the Complete Order button click
        /// </summary>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if order has items
            if (OrderSummary.Order.Count == 0)
            {
                MessageBox.Show(
                    "Cannot complete an empty order. Please add items first.",
                    "Empty Order",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            // Create payment view model
            var paymentViewModel = new PaymentViewModel(OrderSummary.Order);

            // Create payment control
            var paymentControl = new PaymentControl();
            paymentControl.DataContext = paymentViewModel;

            // Subscribe to payment finalized event
            paymentControl.PaymentFinalized += (s, ev) => StartNewOrder();

            // Show payment control
            ContentBorder.Child = paymentControl;
        }

        /// <summary>
        /// Handles the Cancel Order button click
        /// </summary>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to cancel this order? All items will be removed.",
                "Cancel Order",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                StartNewOrder();
            }
        }

        /// <summary>
        /// Starts a new order
        /// </summary>
        private void StartNewOrder()
        {
            // Create new order in OrderSummary
            var newOrder = new Order();

            // This is a bit tricky - we need to replace the order in OrderSummary
            // The easiest way is to recreate the OrderSummary control
            var newOrderSummary = new OrderSummaryControl();
            newOrderSummary.EditItemRequested += OnEditItemRequested;

            // Replace in the grid
            Grid mainGrid = (Grid)this.Content;
            mainGrid.Children.Remove(OrderSummary);
            mainGrid.Children.Add(newOrderSummary);
            Grid.SetColumn(newOrderSummary, 1);
            Grid.SetRow(newOrderSummary, 0);

            OrderSummary = newOrderSummary;

            // Reset flags
            _isEditingCombo = false;

            // Go back to menu
            ContentBorder.Child = MenuSelection;
        }

        /// <summary>
        /// Handles the Back to Menu button click
        /// </summary>
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset combo editing flag
            _isEditingCombo = false;

            // Show the menu selection control again
            ContentBorder.Child = MenuSelection;
        }
    }
}