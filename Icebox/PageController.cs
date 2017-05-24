using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox
{

    class PageController
    {
        private int[] _hashmap;
        private MemoryBlock[] _memoryBlock;
        private int _pageFault;

        public PageController()
        {
            _hashmap = new int[320];
            _memoryBlock = new MemoryBlock[4];
            _pageFault = 0;
        }
    }
}
