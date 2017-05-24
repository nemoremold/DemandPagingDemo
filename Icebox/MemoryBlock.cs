using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox
{
    class MemoryBlock
    {
        private int _pageIndex;
        private int _instructionIndex;
        private int _Instruction;
        private int _blockIndex;

        public MemoryBlock(int i, int j, int p)
        {
            _pageIndex = i;
            _instructionIndex = j;
            _Instruction = p;
        }

        public MemoryBlock(int i, int j, int p, int k)
        {
            _pageIndex = i;
            _instructionIndex = j;
            _Instruction = p;
            _blockIndex = k;
        }

        public int getPageIndex()
        {
            return _pageIndex;
        }

        public int getInstructionIndex()
        {
            return _instructionIndex;
        }

        public int getInstruction()
        {
            return _Instruction;
        }

        public int getBlockIndex()
        {
            return _blockIndex;
        }

        public void setBlockIndex(int blockIndex)
        {
            _blockIndex = blockIndex;
        }
    }
}
