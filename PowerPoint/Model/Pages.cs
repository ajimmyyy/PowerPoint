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

        //新增頁面
        public void AddPage(Shapes page)
        {
            _pages.Add(page);
        }

        //刪除頁面
        public void DeletePage(Shapes page)
        {
            _pages.Remove(page);
        }

        //取得頁面
        public Shapes GetPage(int index)
        {
            return _pages[index];
        }

        //取得頁面index
        public int GetPageIndex(Shapes page)
        {
            return _pages.IndexOf(page);
        }

        //取得頁面數量
        public int Count
        {
            get
            {
                return _pages.Count();
            }
        }

        //取得頁面
        public List<Shapes> PagesList
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
            }
        }
    }
}
