using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Brainfuck_IDE.src
{
    class BFCompile
    {
        private string BFCode = null;
        private string translatedCode = null;
        private string filename = null;
        private string addatCP = "memory[memptr]++;\n";
        private string subatCP = "memory[memptr]--;\n";
        private string incMemPtr = "memptr++;\n";
        private string decMemPtr = "memptr--;\n";
        private string outputatCP = "Console.Write(memory[memptr]);\n";
        private string inputatCP = "memory[memptr] = Console.Read();\n";
        private string loopBeginatCP = "while( memory[memptr] != 0 ){\n";
        private string loopEndatCP = "}\n";

        //private int memptr = 0;

        public BFCompile()
        {

        }
        public BFCompile(string Code, string filename)
        {
            BFCode = Code;
            this.filename = filename;
        }

        public string translateToCS()
        {
            foreach (char item in BFCode)
            {
                switch (item)
                {
                    case '+':
                        translatedCode += addatCP;
                        break;
                    case '-':
                        translatedCode += subatCP;
                        break;
                    case '<':
                        translatedCode += decMemPtr;
                        break;
                    case '>':
                        translatedCode += incMemPtr;
                        break;
                    case '[':
                        translatedCode += loopBeginatCP;
                        break;
                    case ']':
                        translatedCode += loopEndatCP;
                        break;
                    case '.':
                        translatedCode += outputatCP;
                        break;
                    case ',':
                        translatedCode += inputatCP;
                        break;
                    default:
                        break;
                }
            }

            return translatedCode;
        }

        public void Savecodetofile()
        {
            string s = translateToCS();
            using (StreamWriter sw = new StreamWriter("E:\\" + filename + ".cs"))
            {
                sw.WriteLine(s);
            }
        }
    }
}
