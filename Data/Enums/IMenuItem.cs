namespace SubHero.Data.Enums
{
    /// <summary>
    /// Interface for all menu items
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The name of the menu item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The description of the menu item
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The price of the menu item
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// The calories in the menu item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// Preparation information for the menu item
        /// </summary>
        IEnumerable<string> PreparationInformation { get; }
    }
}