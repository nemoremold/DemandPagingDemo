using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox
{
    class Page
    {
        private int[,] _page;
        private int _numberOfPages;
        private int _numberOfInstructionsInEachPage;
        private int _numberOfInstructions;

        public Page(int pageCnt, int instrCnt)
        {
            _numberOfPages = pageCnt;
            _numberOfInstructionsInEachPage = instrCnt;
            _numberOfInstructions = _numberOfPages * _numberOfInstructionsInEachPage;
            _page = new int[_numberOfPages, _numberOfInstructionsInEachPage];
            init();
            init_Page();
        }

        private Page()
        {

        }

        private bool changePage(ref int page, ref int instruction)
        {
            if (instruction == 10)
            {
                ++page;
                instruction = 0;
            }

            if (page >= _numberOfPages)
            {
                return false;
            }
            return true;
        }

        private void init()
        {
            Random rd = new Random();
            int type = 1;
            int instructionIndex = 0;
            int nowIndex = -1;

            for (int page = 0; page < _numberOfPages;)
            {
                if (!changePage(ref page, ref instructionIndex))
                {
                    break;
                }
                if (type == 1)
                {
                    nowIndex = rd.Next(0, _numberOfInstructions - 1);
                    _page[page, instructionIndex++] = nowIndex;
                    if (!changePage(ref page, ref instructionIndex))
                    {
                        break;
                    }
                    _page[page, instructionIndex++] = nowIndex + 1;
                    type = 2;
                }
                else if (type == 2)
                {
                    if (nowIndex > 0)
                    {
                        nowIndex = rd.Next(0, nowIndex - 1);
                    }
                    _page[page, instructionIndex++] = nowIndex;
                    if (!changePage(ref page, ref instructionIndex))
                    {
                        break;
                    }
                    _page[page, instructionIndex++] = nowIndex + 1;
                    type = 3;
                }
                else
                {
                    if (nowIndex < _numberOfInstructions - 2)
                    {
                        nowIndex = rd.Next(nowIndex + 2, _numberOfInstructions - 1);
                    }
                    _page[page, instructionIndex++] = nowIndex;
                    if (!changePage(ref page, ref instructionIndex))
                    {
                        break;
                    }
                    _page[page, instructionIndex++] = nowIndex + 1;
                    type = 2;
                }
            }
        }

        public void init_Page()
        {
            for (int page = 0; page < _numberOfPages; ++page)
            {
                for (int instruction = 0; instruction < _numberOfInstructionsInEachPage; ++instruction)
                {
                    _page[page, instruction] = _page[page, instruction] / 10;
                }
            }
        }

        public int getInstruction(int page, int instruction)
        {
            if (page >= _numberOfPages || instruction >= _numberOfInstructionsInEachPage)
            {
                Exception excep = new Exception("Invalid address of instruction.");
                throw excep;
            }
            else
            {
                return _page[page, instruction];
            }
        }
    }
}
