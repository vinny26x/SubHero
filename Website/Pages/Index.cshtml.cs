using Microsoft.AspNetCore.Mvc.RazorPages;
using SubHero.Data;
using SubHero.Data.Enums;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Gets the collection of all entrees
        /// </summary>
        public IEnumerable<IMenuItem> Entrees { get; private set; } = new List<IMenuItem>();

        /// <summary>
        /// Gets the collection of all sides
        /// </summary>
        public IEnumerable<IMenuItem> Sides { get; private set; } = new List<IMenuItem>();

        /// <summary>
        /// Gets the collection of all drinks
        /// </summary>
        public IEnumerable<IMenuItem> Drinks { get; private set; } = new List<IMenuItem>();

        /// <summary>
        /// Gets the collection of all combos
        /// </summary>
        public IEnumerable<IMenuItem> Combos { get; private set; } = new List<IMenuItem>();

        /// <summary>
        /// Gets the collection of all available ingredients
        /// </summary>
        public IEnumerable<IngredientItem> Ingredients { get; private set; } = new List<IngredientItem>();

        /// <summary>
        /// Handles GET requests - loads the menu data
        /// </summary>
        public void OnGet()
        {
            Entrees = Menu.Entrees;
            Sides = Menu.Sides;
            Drinks = Menu.Drinks;
            Combos = Menu.Combos;
            Ingredients = Menu.Ingredients;
        }
    }
}