using System.ComponentModel;
using System.Text;
using SubHero.Data.Enums;

namespace SubHero.Data  // ← Change this from SubHero.PointOfSale
{
    /// <summary>
    /// ViewModel for the payment control
    /// </summary>
    public class PaymentViewModel : INotifyPropertyChanged
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
        /// The order being paid for
        /// </summary>
        private Order _order;

        /// <summary>
        /// Backing field for paid amount
        /// </summary>
        private decimal _paid;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="order">The order to create payment for</param>
        public PaymentViewModel(Order order)
        {
            _order = order;
            _paid = order.Total; // Default to total amount
        }

        /// <summary>
        /// Gets the items in the order for display
        /// </summary>
        public IEnumerable<IMenuItem> OrderItems => _order;

        /// <summary>
        /// The subtotal of the order
        /// </summary>
        public decimal Subtotal => _order.Subtotal;

        /// <summary>
        /// The tax on the order
        /// </summary>
        public decimal Tax => _order.Tax;

        /// <summary>
        /// The total cost of the order
        /// </summary>
        public decimal Total => _order.Total;

        /// <summary>
        /// The amount paid by the customer
        /// </summary>
        public decimal Paid
        {
            get => _paid;
            set
            {
                if (value < Total)
                {
                    throw new ArgumentException($"Payment amount must be at least ${Total:F2}");
                }

                if (_paid != value)
                {
                    _paid = value;
                    OnPropertyChanged(nameof(Paid));
                    OnPropertyChanged(nameof(Change));
                    OnPropertyChanged(nameof(IsPaymentValid));
                }
            }
        }

        /// <summary>
        /// The change to give back to the customer
        /// </summary>
        public decimal Change => Paid - Total;

        /// <summary>
        /// Whether the payment amount is valid (at least the total)
        /// </summary>
        public bool IsPaymentValid => Paid >= Total;

        /// <summary>
        /// Gets the receipt text for this order
        /// </summary>
        public string Receipt
        {
            get
            {
                StringBuilder receipt = new StringBuilder();

                receipt.AppendLine($"Order #{_order.Number}");
                receipt.AppendLine($"Date: {_order.PlacedAt:MM/dd/yyyy HH:mm:ss}");
                receipt.AppendLine();
                receipt.AppendLine("Items:");
                receipt.AppendLine("----------------------------------------");

                foreach (var item in _order)
                {
                    receipt.AppendLine($"{item.Name} - ${item.Price:F2}");

                    // Add special instructions
                    foreach (var instruction in item.PreparationInformation)
                    {
                        receipt.AppendLine($"  {instruction}");
                    }

                    receipt.AppendLine();
                }

                receipt.AppendLine("----------------------------------------");
                receipt.AppendLine($"Subtotal: ${Subtotal:F2}");
                receipt.AppendLine($"Tax: ${Tax:F2}");
                receipt.AppendLine($"Total: ${Total:F2}");
                receipt.AppendLine($"Paid: ${Paid:F2}");
                receipt.AppendLine($"Change: ${Change:F2}");
                receipt.AppendLine("----------------------------------------");
                receipt.AppendLine();

                return receipt.ToString();
            }
        }
    }
}