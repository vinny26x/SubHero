using System.Windows;
using System.Windows.Controls;
using SubHero.Data;
using SubHero.Data.Enums;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// Event fired when an item needs to be edited
        /// </summary>
        public event EventHandler<IMenuItem>? EditItemRequested;

        /// <summary>
        /// The current order being displayed
        /// </summary>
        private Order _order;

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
            _order = new Order();
            OrderListView.ItemsSource = _order;
            OrderNumberTextBlock.Text = _order.Number.ToString();
            DateTextBlock.Text = $"Date: {DateTime.Now:MM/dd/yyyy}";
            UpdateTotals();
        }

        /// <summary>
        /// Gets the current order
        /// </summary>
        public Order Order => _order;

        /// <summary>
        /// Updates the displayed totals
        /// </summary>
        public void UpdateTotals()
        {
            SubtotalTextBlock.Text = $"${_order.Subtotal:F2}";
            TaxTextBlock.Text = $"${_order.Tax:F2}";
            TotalTextBlock.Text = $"${_order.Total:F2}";
        }

        /// <summary>
        /// Handles the Edit button click
        /// </summary>
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is IMenuItem item)
            {
                EditItemRequested?.Invoke(this, item);
            }
        }
    }
}