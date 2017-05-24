using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox
{

    class PagingController
    {
        private int[] _hashmap;
        private int _pagingFault;
        private int _numberOfPages;
        private int _numberOfInstructionsInEachPage;
        private int _numberOfInstructions;
        private int _memorySize;

        public PagingController(int pageCnt, int instrCnt, int size)
        {
            _numberOfPages = pageCnt;
            _numberOfInstructionsInEachPage = instrCnt;
            _memorySize = size;
            _numberOfInstructions = _numberOfPages * _numberOfInstructionsInEachPage;

            _hashmap = new int[_numberOfInstructions];
            _pagingFault = 0;
        }

        public void operateLeastRecentlyUsedAlgorithm(Page page, ref Memory memory)
        {

        }
    }
}
