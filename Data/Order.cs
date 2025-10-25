using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using SubHero.Data.Enums;

namespace SubHero.Data
{
    /// <summary>
    /// Represents an order containing multiple menu items
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// Field for the collection of menu items
        /// </summary>
        private List<IMenuItem> _items;

        /// <summary>
        /// Field for the tax rate
        /// </summary>
        private decimal _taxRate = 0.0915m;

        /// <summary>
        /// Static field to track the last order number used
        /// </summary>
        private static int _lastOrderNumber = 0;

        /// <summary>
        /// Field for this order's unique number
        /// </summary>
        private int _number;

        /// <summary>
        /// Field for the date and time this order was placed
        /// </summary>
        private DateTime _placedAt;

        /// <summary>
        /// Event that is raised when a property of this order changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Event that is raised when the collection of items changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// Constructor for a new order
        /// </summary>
        public Order()
        {
            _items = new List<IMenuItem>();
            _number = ++_lastOrderNumber;
            _placedAt = DateTime.Now;
        }

        /// <summary>
        /// The unique number identifying this order
        /// </summary>
        public int Number
        {
            get { return _number; }
        }

        /// <summary>
        /// The date and time when this order was placed
        /// </summary>
        public DateTime PlacedAt
        {
            get { return _placedAt; }
        }

        /// <summary>
        /// The sales tax rate for this order (default 9.15%)
        /// </summary>
        public decimal TaxRate
        {
            get { return _taxRate; }
            set
            {
                _taxRate = value;
                OnPropertyChanged(nameof(TaxRate));
                OnPropertyChanged(nameof(Tax));
                OnPropertyChanged(nameof(Total));
            }
        }

        /// <summary>
        /// The subtotal of all items in the order before tax
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0m;
                foreach (IMenuItem item in _items)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// The tax amount for this order (Subtotal * TaxRate)
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Subtotal * TaxRate;
            }
        }

        /// <summary>
        /// The total price including tax (Subtotal + Tax)
        /// </summary>
        public decimal Total
        {
            get
            {
                return Subtotal + Tax;
            }
        }

        /// <summary>
        /// Helper method to raise the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Helper method to raise the CollectionChanged event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Handles property changes from items in the order
        /// </summary>
        private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // When any item's Price changes, update order totals
            if (e.PropertyName == nameof(IMenuItem.Price))
            {
                OnPropertyChanged(nameof(Subtotal));
                OnPropertyChanged(nameof(Tax));
                OnPropertyChanged(nameof(Total));
            }
        }

        #region ICollection<IMenuItem> Implementation

        /// <summary>
        /// The number of items in this order
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Whether this collection is read-only (always false for Order)
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to this order
        /// </summary>
        /// <param name="item">The menu item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);

            // Subscribe to property changes from the item
            if (item is INotifyPropertyChanged notifyItem)
            {
                notifyItem.PropertyChanged += OnItemPropertyChanged;
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Tax));
            OnPropertyChanged(nameof(Total));
        }

        /// <summary>
        /// Removes all items from this order
        /// </summary>
        public void Clear()
        {
            // Unsubscribe from all items
            foreach (var item in _items)
            {
                if (item is INotifyPropertyChanged notifyItem)
                {
                    notifyItem.PropertyChanged -= OnItemPropertyChanged;
                }
            }

            _items.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Tax));
            OnPropertyChanged(nameof(Total));
        }

        /// <summary>
        /// Determines whether this order contains a specific item
        /// </summary>
        /// <param name="item">The item to locate</param>
        /// <returns>True if the item is found, false otherwise</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Copies the items in this order to an array
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The starting index in the array</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes a specific item from this order
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was removed, false if it wasn't found</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            bool result = _items.Remove(item);

            if (result)
            {
                // Unsubscribe from property changes
                if (item is INotifyPropertyChanged notifyItem)
                {
                    notifyItem.PropertyChanged -= OnItemPropertyChanged;
                }

                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                OnPropertyChanged(nameof(Subtotal));
                OnPropertyChanged(nameof(Tax));
                OnPropertyChanged(nameof(Total));
            }
            return result;
        }

        /// <summary>
        /// Returns an enumerator for the items in this order
        /// </summary>
        /// <returns>An enumerator for IMenuItem</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns a non-generic enumerator for the items in this order
        /// </summary>
        /// <returns>A non-generic enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}