using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab._6
{
    class Fifo
    {
        private List<Page> pages;
        private Timer timer;
        private List<int> pageIndexes;
        private int index;
        private int frameCount;

        public Fifo(List<int> pageIndexes, int frameCount)
        {
            this.pageIndexes = pageIndexes;
            this.frameCount = frameCount;
            this.pages = new List<Page>(frameCount);
        }

        public Fifo(List<Page> pages, Timer timer)
        {
            this.pages = pages;
            this.timer = timer;
        }

        public List<Page> Pages { get => pages; set => pages = value; }
        public Timer Timer { get => timer; set => timer = value; }
        public List<int> PageIndexes { get => pageIndexes; set => pageIndexes = value; }

        public void GetPageFaults()
        {
            int pageFaults = 0;
            for (int i = 0; i < pageIndexes.Count; i++)
            {
                Page page = new Page(pageIndexes[i], true, false, DateTime.Now);

                if (!ContainsPage(pages, page) && pages.Count < frameCount) {
                    pages.Add(page);
                    pageFaults++;
                }
                else if (ContainsPage(pages, page))
                {
                    Page currentPage = pages[index];
                    currentPage.Modify = true;
                    currentPage.Time = DateTime.Now;
                    pages.RemoveAt(index);
                    pages.Insert(index, currentPage);
                    pageFaults++;
                }
                else if (!ContainsPage(pages, page) && pages.Count == frameCount)
                {
                    Page recentPage = pages.OrderBy(k => k.Time).FirstOrDefault();
                    int index = pages.IndexOf(recentPage);
                    pages.Remove(recentPage);
                    pages.Insert(index, page);
                }
            }
            pages.ForEach(k => Console.WriteLine(k));
        }

        private bool ContainsPage(List<Page> pages, Page newPage)
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i].Index == newPage.Index)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        
    }
}
