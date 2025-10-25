using SubHero.Data;
using SubHero.Data.Enums;

namespace SubHero.DataTests
{
    /// <summary>
    /// A mock menu item for testing
    /// </summary>
    internal class MockMenuItem : IMenuItem
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public uint Calories { get; set; }
        public IEnumerable<string> PreparationInformation { get; set; } = new List<string>();
    }

    /// <summary>
    /// Unit tests for the Order class
    /// </summary>
    public class OrderUnitTests
    {
        #region Default Property Tests

        [Fact]
        public void DefaultTaxRateIsCorrectTest()
        {
            Order order = new Order();
            Assert.Equal(0.0915m, order.TaxRate);
        }

        [Fact]
        public void DefaultSubtotalIsZeroTest()
        {
            Order order = new Order();
            Assert.Equal(0m, order.Subtotal);
        }

        [Fact]
        public void DefaultTaxIsZeroTest()
        {
            Order order = new Order();
            Assert.Equal(0m, order.Tax);
        }

        [Fact]
        public void DefaultTotalIsZeroTest()
        {
            Order order = new Order();
            Assert.Equal(0m, order.Total);
        }

        [Fact]
        public void DefaultCountIsZeroTest()
        {
            Order order = new Order();
            Assert.Equal(0, order.Count);
        }

        [Fact]
        public void DefaultIsReadOnlyIsFalseTest()
        {
            Order order = new Order();
            Assert.False(order.IsReadOnly);
        }

        #endregion

        #region TaxRate Property Tests

        [Theory]
        [InlineData(0.05)]
        [InlineData(0.10)]
        [InlineData(0.15)]
        [InlineData(0.0)]
        public void TaxRateCanBeSetTest(decimal taxRate)
        {
            Order order = new Order();
            order.TaxRate = taxRate;
            Assert.Equal(taxRate, order.TaxRate);
        }

        #endregion

        #region Subtotal Tests

        [Fact]
        public void SubtotalShouldReflectItemPricesTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        [Fact]
        public void EmptyOrderSubtotalIsZeroTest()
        {
            Order order = new Order();
            Assert.Equal(0m, order.Subtotal);
        }

        #endregion

        #region Tax Tests

        [Fact]
        public void TaxIsCalculatedCorrectlyTest()
        {
            Order order = new Order();
            order.TaxRate = 0.10m; // 10% tax
            order.Add(new MockMenuItem() { Price = 10.00m });
            Assert.Equal(1.00m, order.Tax);
        }

        [Theory]
        [InlineData(0.0915, 100.00, 9.15)]
        [InlineData(0.05, 50.00, 2.50)]
        [InlineData(0.08, 25.00, 2.00)]
        public void TaxCalculationWithDifferentRatesTest(decimal taxRate, decimal subtotal, decimal expectedTax)
        {
            Order order = new Order();
            order.TaxRate = taxRate;
            order.Add(new MockMenuItem() { Price = subtotal });
            Assert.Equal(expectedTax, order.Tax);
        }

        #endregion

        #region Total Tests

        [Fact]
        public void TotalIsSubtotalPlusTaxTest()
        {
            Order order = new Order();
            order.TaxRate = 0.10m; // 10% tax
            order.Add(new MockMenuItem() { Price = 10.00m });
            order.Add(new MockMenuItem() { Price = 5.00m });
            // Subtotal: 15.00, Tax: 1.50, Total: 16.50
            Assert.Equal(16.50m, order.Total);
        }

        #endregion

        #region Collection Interface Tests

        [Fact]
        public void CanAddItemsTest()
        {
            Order order = new Order();
            MockMenuItem item = new MockMenuItem() { Price = 5.00m };
            order.Add(item);
            Assert.Equal(1, order.Count);
            Assert.Contains(item, order);
        }

        [Fact]
        public void CanRemoveItemsTest()
        {
            Order order = new Order();
            MockMenuItem item = new MockMenuItem() { Price = 5.00m };
            order.Add(item);
            bool removed = order.Remove(item);
            Assert.True(removed);
            Assert.Equal(0, order.Count);
            Assert.DoesNotContain(item, order);
        }

        [Fact]
        public void CanClearAllItemsTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.00m });
            order.Clear();
            Assert.Equal(0, order.Count);
        }

        [Fact]
        public void ContainsWorksCorrectlyTest()
        {
            Order order = new Order();
            MockMenuItem item = new MockMenuItem() { Price = 5.00m };
            MockMenuItem otherItem = new MockMenuItem() { Price = 3.00m };

            order.Add(item);
            Assert.True(order.Contains(item));
            Assert.False(order.Contains(otherItem));
        }

        [Fact]
        public void CopyToWorksCorrectlyTest()
        {
            Order order = new Order();
            MockMenuItem item1 = new MockMenuItem() { Price = 1.00m };
            MockMenuItem item2 = new MockMenuItem() { Price = 2.00m };
            order.Add(item1);
            order.Add(item2);

            IMenuItem[] array = new IMenuItem[2];
            order.CopyTo(array, 0);

            Assert.Contains(item1, array);
            Assert.Contains(item2, array);
        }

        [Fact]
        public void GetEnumeratorWorksTest()
        {
            Order order = new Order();
            MockMenuItem item1 = new MockMenuItem() { Price = 1.00m };
            MockMenuItem item2 = new MockMenuItem() { Price = 2.00m };
            order.Add(item1);
            order.Add(item2);

            List<IMenuItem> enumerated = new List<IMenuItem>();
            foreach (IMenuItem item in order)
            {
                enumerated.Add(item);
            }

            Assert.Equal(2, enumerated.Count);
            Assert.Contains(item1, enumerated);
            Assert.Contains(item2, enumerated);
        }

        #endregion

        #region Interface Casting Tests

        [Fact]
        public void CanBeCastToICollectionTest()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<ICollection<IMenuItem>>(order);
        }

        #endregion
    }
}