using System.Windows;
using System.Windows.Controls;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for EntreeCustomizationControl.xaml
    /// Allows customization of any Entree (sandwich, sub, wrap)
    /// </summary>
    public partial class EntreeCustomizationControl : UserControl
    {
        /// <summary>
        /// Event fired when user wants to make this entree into a combo
        /// </summary>
        public event EventHandler? MakeComboRequested;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntreeCustomizationControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Make it a Combo button click
        /// </summary>
        private void MakeItComboButton_Click(object sender, RoutedEventArgs e)
        {
            MakeComboRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Shows or hides the Make it a Combo button
        /// </summary>
        /// <param name="visible">Whether the button should be visible</param>
        public void SetComboButtonVisibility(bool visible)
        {
            MakeItComboButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}