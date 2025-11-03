using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        /// <summary>
        /// Event fired when payment is finalized
        /// </summary>
        public event EventHandler? PaymentFinalized;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Finalize Payment button click
        /// </summary>
        private void FinalizePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is PaymentViewModel viewModel)
            {
                // Write receipt to file
                try
                {
                    File.AppendAllText("receipts.txt", viewModel.Receipt);

                    // Show confirmation message
                    MessageBox.Show(
                        "Receipt has been printed!\n\nClick OK to start a new order.",
                        "Payment Complete",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    // Fire event to notify that payment is complete
                    PaymentFinalized?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error saving receipt: {ex.Message}",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
}