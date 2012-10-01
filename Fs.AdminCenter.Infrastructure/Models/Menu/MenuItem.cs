using System.Collections.Generic;

namespace Fs.AdminCenter.Infrastructure.Models.Menu
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Route { get; set; }

        public List<MenuSubItem> MenuSubItems { get; set; }
    }

    public class MenuSubItem
    {
        public string Name { get; set; }

        public string Route { get; set; }

    }
}
