using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._6
{
    class Page
    {
        private int index;
        private bool read;
        private bool modify;
        private DateTime time;

        public Page(int index, bool read, bool modify, DateTime time)
        {
            this.index = index;
            this.read = read;
            this.modify = modify;
            this.time = time;
        }

        //
        //private int time;

        public int Index { get => index; set => index = value; }
        public bool Read { get => read; set => read = value; }
        public bool Modify { get => modify; set => modify = value; }
        public DateTime Time { get => time; set => time = value; }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}