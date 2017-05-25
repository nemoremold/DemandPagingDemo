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
        private int _nowIndex;
        private int _numberOfPages;
        private int _numberOfInstructionsInEachPage;
        private int _numberOfInstructions;
        private int _memorySize;
        private bool _slowDown;

        public PagingController(int pageCnt, int instrCnt, int size)
        {
            _numberOfPages = pageCnt;
            _numberOfInstructionsInEachPage = instrCnt;
            _memorySize = size;
            _numberOfInstructions = _numberOfPages * _numberOfInstructionsInEachPage;

            _hashmap = new int[_numberOfInstructions];
            _pagingFault = 0;
            _slowDown = false;
        }

        public void operateLeastRecentlyUsedAlgorithm(Page page, ref Memory memory)
        {
            int memoryUsed = 0;
            _nowIndex = 0;
            for (int i = 0; i < _numberOfInstructions; ++i)
            {
                _hashmap[i] = -1;
            }

            for (int i = 0; i < _numberOfPages; ++i)
            {
                for (int j = 0; j < _numberOfInstructionsInEachPage; ++j)
                {
                    if (_slowDown)
                    {
                        for (int k = 0; k < 50000000; ++k) ;
                    }
                    ++_nowIndex;
                    if (_hashmap[page.getInstruction(i, j)] != -1)
                    {
                        _hashmap[page.getInstruction(i, j)] = i * j;
                    }
                    else
                    {
                        ++_pagingFault;
                        MemoryBlock newBlock = new MemoryBlock(i, j, page.getInstruction(i, j));
                        if (memoryUsed < _memorySize)
                        {
                            newBlock.setBlockIndex(memoryUsed++);
                            memory.writeMemory(newBlock);
                            _hashmap[page.getInstruction(i, j)] = i * _numberOfInstructionsInEachPage + j;
                        }
                        else
                        {
                            newBlock.setBlockIndex(0);
                            MemoryBlock rewrittenBlock = memory.readMemory(0);
                            _hashmap[rewrittenBlock.getInstruction()] = -1;
                            memory.overwriteMemory(newBlock);
                            _hashmap[page.getInstruction(i, j)] = i * _numberOfInstructionsInEachPage + j;
                        }
                    }
                    sortMemory(memoryUsed, ref memory);
                }
            }
        }

        public void sortMemory(int size, ref Memory memory)
        {
            Memory temp = memory;
            int[] order;
            order = new int[size];
            for (int i = 0; i < size; ++i)
            {
                order[i] = i;
            }
            Array.Sort(order, (x, y) => _hashmap[temp.readMemory(x).getInstruction()].CompareTo(_hashmap[temp.readMemory(y).getInstruction()]));
            memory.sort(size, order);
        }

        public int getPagingFaults()
        {
            return _pagingFault;
        }

        public int getNowIndex()
        {
            return _nowIndex;
        }

        public void setSlowingStatus(bool status)
        {
            _slowDown = status;
        }
    }
}
