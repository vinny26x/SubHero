using System.Windows;
using System.Windows.Controls;

namespace SubHero.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountControl.xaml
    /// A custom control for incrementing/decrementing a numeric value
    /// </summary>
    public partial class CountControl : UserControl
    {
        /// <summary>
        /// Dependency property for the current value
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(uint), typeof(CountControl),
                new PropertyMetadata((uint)1, OnValueChanged));

        /// <summary>
        /// Dependency property for the minimum value
        /// </summary>
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(uint), typeof(CountControl),
                new PropertyMetadata((uint)1));

        /// <summary>
        /// Dependency property for the maximum value
        /// </summary>
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(uint), typeof(CountControl),
                new PropertyMetadata((uint)12));

        /// <summary>
        /// Gets or sets the current value
        /// </summary>
        public uint Value
        {
            get { return (uint)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum value
        /// </summary>
        public uint Minimum
        {
            get { return (uint)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum value
        /// </summary>
        public uint Maximum
        {
            get { return (uint)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CountControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles increment button click
        /// </summary>
        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Maximum)
            {
                Value++;
            }
        }

        /// <summary>
        /// Handles decrement button click
        /// </summary>
        private void DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Minimum)
            {
                Value--;
            }
        }

        /// <summary>
        /// Called when the Value property changes
        /// </summary>
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Could add additional logic here if needed
        }
    }
}