using SubHero.Data.Entrees;
using SubHero.Data.Sides;
using SubHero.Data.Drinks;
using SubHero.Data.Enums;

namespace SubHero.Data
{
    /// <summary>
    /// Static class providing access to the complete SubHero menu
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Gets all available entrees in all bread/size combinations with default ingredients
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<IMenuItem> entrees = new List<IMenuItem>();

                // Custom Sandwich - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        var sandwich = new CustomSandwich { Bread = bread, Size = size };
                        // Only add valid combinations
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            entrees.Add(sandwich);
                        }
                    }
                }

                // California Club Wrap - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var wrap = new CaliforniaClubWrap { Bread = bread, Size = size };
                            entrees.Add(wrap);
                        }
                    }
                }

                // Club Sub - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var sub = new ClubSub { Bread = bread, Size = size };
                            entrees.Add(sub);
                        }
                    }
                }

                // Italian Sub - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var sub = new ItalianSub { Bread = bread, Size = size };
                            entrees.Add(sub);
                        }
                    }
                }

                // Mediterranean Wrap - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var wrap = new MediterraneanWrap { Bread = bread, Size = size };
                            entrees.Add(wrap);
                        }
                    }
                }

                // Turkey Cranberry Sandwich - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var sandwich = new TurkeyCranberrySandwich { Bread = bread, Size = size };
                            entrees.Add(sandwich);
                        }
                    }
                }

                // Veggie Sandwich - all bread/size combinations
                foreach (BreadType bread in Enum.GetValues(typeof(BreadType)))
                {
                    foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                    {
                        if (IsValidBreadSizeCombination(bread, size))
                        {
                            var sandwich = new VeggieSandwich { Bread = bread, Size = size };
                            entrees.Add(sandwich);
                        }
                    }
                }

                return entrees;
            }
        }

        /// <summary>
        /// Gets all available sides in all configurations (except side salad ingredient variations)
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> sides = new List<IMenuItem>();

                // Apple - only default configuration
                sides.Add(new Apple());

                // Chips - all chip types
                foreach (ChipType chipType in Enum.GetValues(typeof(ChipType)))
                {
                    sides.Add(new Chips { Flavor = chipType });
                }

                // Cookies - all flavors, all counts (2-6)
                foreach (CookieType flavor in Enum.GetValues(typeof(CookieType)))
                {
                    for (uint count = 2; count <= 6; count++)
                    {
                        sides.Add(new Cookies { Flavor = flavor, CookieCount = count });
                    }
                }

                // Side Salad - only default configuration
                sides.Add(new SideSalad());

                return sides;
            }
        }

        /// <summary>
        /// Gets all available drinks in all sizes and flavors
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> drinks = new List<IMenuItem>();

                // Fountain Drink - all sizes × all soda types
                foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                {
                    foreach (SodaType flavor in Enum.GetValues(typeof(SodaType)))
                    {
                        drinks.Add(new FountainDrink { Size = size, Flavor = flavor });
                    }
                }

                // Iced Tea - all sizes × sweetened/unsweetened
                foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                {
                    drinks.Add(new IcedTea { Size = size, Sweet = true });
                    drinks.Add(new IcedTea { Size = size, Sweet = false });
                }

                // Lemonade - all sizes × regular/pink
                foreach (SizeType size in Enum.GetValues(typeof(SizeType)))
                {
                    drinks.Add(new Lemonade { Size = size, Pink = false });
                    drinks.Add(new Lemonade { Size = size, Pink = true });
                }

                return drinks;
            }
        }

        /// <summary>
        /// Gets all possible combos with default configurations
        /// </summary>
        public static IEnumerable<IMenuItem> Combos
        {
            get
            {
                List<IMenuItem> combos = new List<IMenuItem>();

                // Get default instances
                var defaultEntrees = new List<Entree>
                {
                    new CustomSandwich(),
                    new CaliforniaClubWrap(),
                    new ClubSub(),
                    new ItalianSub(),
                    new MediterraneanWrap(),
                    new TurkeyCranberrySandwich(),
                    new VeggieSandwich()
                };

                var defaultSides = new List<Side>
                {
                    new Apple(),
                    new Chips(),
                    new Cookies(),
                    new SideSalad()
                };

                var defaultDrinks = new List<Drink>
                {
                    new FountainDrink(),
                    new IcedTea(),
                    new Lemonade()
                };

                // Create combos for each combination
                foreach (var entree in defaultEntrees)
                {
                    foreach (var side in defaultSides)
                    {
                        foreach (var drink in defaultDrinks)
                        {
                            combos.Add(new Combo
                            {
                                SandwichChoice = entree,
                                SideChoice = side,
                                DrinkChoice = drink
                            });
                        }
                    }
                }

                return combos;
            }
        }

        /// <summary>
        /// Gets the full menu containing all items
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> fullMenu = new List<IMenuItem>();
                fullMenu.AddRange(Entrees);
                fullMenu.AddRange(Sides);
                fullMenu.AddRange(Drinks);
                fullMenu.AddRange(Combos);
                return fullMenu;
            }
        }

        /// <summary>
        /// Gets all available ingredients
        /// </summary>
        public static IEnumerable<IngredientItem> Ingredients
        {
            get
            {
                List<IngredientItem> ingredients = new List<IngredientItem>();

                foreach (IngredientType type in Enum.GetValues(typeof(IngredientType)))
                {
                    ingredients.Add(new IngredientItem(type));
                }

                return ingredients;
            }
        }

        /// <summary>
        /// Helper method to check if a bread/size combination is valid
        /// </summary>
        /// <param name="bread">The bread type</param>
        /// <param name="size">The size</param>
        /// <returns>True if valid combination</returns>
        private static bool IsValidBreadSizeCombination(BreadType bread, SizeType size)
        {
            switch (bread)
            {
                case BreadType.Wrap:
                    return size == SizeType.Medium;
                case BreadType.Wheat:
                case BreadType.Sourdough:
                    return size == SizeType.Small || size == SizeType.Medium;
                case BreadType.Hoagie:
                    return true; // All sizes valid
                default:
                    return false;
            }
        }
    }
}