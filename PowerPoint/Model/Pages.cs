using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Pages
    {
        List<Shapes> _pages = new List<Shapes>();

        public void AddPage(Shapes page)
        {
            _pages.Add(page);
        }

        public void DeletePage(Shapes page)
        {
            _pages.Remove(page);
        }

        public Shapes GetPage(int index)
        {
            return _pages[index];
        }

        public int GetPageIndex(Shapes page)
        {
            return _pages.IndexOf(page);
        }
    }
}
