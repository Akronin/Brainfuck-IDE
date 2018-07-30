using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_IDE
{
    class BfInterpreter
    {
        private byte[] memory;
        private int memPtr;
        private string code;
        private int codePtr;
        private char input;
        private char output;
        private int loop;
        private readonly int memSize = 30000;
        //private bool isInput = false;
        private bool isOutput = false;
        private bool isMemChanged = false;

        public BfInterpreter() { }

        public BfInterpreter(string code, int pointerToCode = 0)
        {
            memory = new byte[memSize];
            pointerToCode = 0;
            this.code = code;
            this.codePtr = pointerToCode;
        }
        public BfInterpreter(byte[] memory, int pointerToMem, string code, int pointerToCode)
        {
            this.memory = memory;
            this.memPtr = pointerToMem;
            this.code = code;
            this.codePtr = pointerToCode;
        }

        public byte[] Memory { get => memory; set { memory = value; } }
        public int MemPtr { get => memPtr; set { memPtr = value; } }
        public string Code { get => code; set { code = value; } }
        public int CodePtr { get => codePtr; set { codePtr = value; } }
        public char Input { set { input = value; } }
        public char Output { get => output; }
        public char CharAtCP { get => Code[codePtr]; }
        public bool IsOutput { get => isOutput; set => isOutput = value; }
        public bool IsMemChanged { get => isMemChanged; set => isMemChanged = value; }


        public void InterpretBF()
        {
            switch (Code[codePtr])
            {
                case '+':
                    memory[memPtr]++;
                    isMemChanged = true;
                    break;
                case '-':
                    memory[memPtr]--;
                    isMemChanged = true;
                    break;
                case '>':
                    memPtr++;
                    if (memPtr >= memSize)
                    {
                        memPtr = 0;
                    }
                    break;
                case '<':
                    memPtr--;
                    if (memPtr < 0)
                    {
                        memPtr = memSize - 1;
                    }
                    break;
                case '.':
                    output = (char)memory[memPtr];
                    isOutput = true;
                    break;
                case ',':
                    memory[memPtr] = (byte)input;
                    //isInput = true;
                    break;
                case '[':
                    //int loop;
                    if (memory[memPtr] == 0)
                    {
                        loop = 1;
                        while (loop > 0)
                        {
                            codePtr++;
                            char c = code[codePtr];
                            if (c == '[')
                            {
                                loop++;
                            }
                            else if (c == ']')
                            {
                                loop--;
                            }
                        }
                    }
                    break;
                case ']':
                    loop = 1;
                    while (loop > 0)
                    {
                        codePtr--;
                        char c = code[codePtr];
                        if (c == '[')
                        {
                            loop--;
                        }
                        else if (c == ']')
                        {
                            loop++;
                        }
                    }
                    codePtr--;
                    break;
            }
            codePtr++;
        }

        void PrintToCS(string filename)
        {
            
        }
    }
}
