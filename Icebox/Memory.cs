using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox
{
    class Memory
    {
        private MemoryBlock[] _memoryBlocks;
        private int _memorySize;

        public Memory(int size)
        {
            _memorySize = size;
            _memoryBlocks = new MemoryBlock[_memorySize];
        }

        private Memory()
        {

        }

        public void deleteFromMemory(int index)
        {
            if (index >= _memorySize)
            {
                Exception excep = new Exception("Invalid memory index.");
                throw excep;
            }
            else
            {
                _memoryBlocks[index] = null;
            }
        }

        public MemoryBlock readMemory(int index)
        {
            if (index >= _memorySize)
            {
                Exception excep = new Exception("Invalid memory index.");
                throw excep;
            }
            else
            {
                return _memoryBlocks[index];
            }
        }

        public void writeMemory(MemoryBlock block)
        {
            int memoryToBeWritten = block.getBlockIndex();
            if (memoryToBeWritten >= _memorySize || _memoryBlocks[memoryToBeWritten] != null)
            {
                Exception excep = new Exception("Invalid memory index.");
                throw excep;
            }
            else
            {
                _memoryBlocks[memoryToBeWritten] = block;
            }
        }

        public void overwriteMemory(MemoryBlock block)
        {
            int memoryToBeWritten = block.getBlockIndex();
            if (memoryToBeWritten >= _memorySize)
            {
                Exception excep = new Exception("Invalid memory index.");
                throw excep;
            }
            else
            {
                _memoryBlocks[memoryToBeWritten] = block;
            }
        }
    }
}
