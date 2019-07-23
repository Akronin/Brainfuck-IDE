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
        private string addatCP          = "\t\t\tmemory[memptr]++;\n";
        private string subatCP          = "\t\t\tmemory[memptr]--;\n";
        private string incMemPtr        = "\t\t\tmemptr++;\n";
        private string decMemPtr        = "\t\t\tmemptr--;\n";
        private string outputatCP       = "\t\t\tConsole.Write((char)memory[memptr]);\n";
        private string inputatCP        = "\t\t\tmemory[memptr] = Console.Read();\n";
        private string loopBeginatCP    = "\t\t\twhile( memory[memptr] != 0 ){\n";
        private string loopEndatCP      = "\t\t\t}\n";

        private string boilerCode = "using System;\n"
            + "namespace {0}\n"
            + "{{\n"
            + "\tstatic class Program\n"
            + "\t{{\n"
            + "\t\tstatic void Main()\n"
            + "\t\t{{\n"
            + "\t\t\tbyte[] memory = new byte[50000];\n"
            + "\t\t\tint memptr = 0;\n"
            + "{1}\n"
            + "\t\t\tConsole.ReadKey();\n"
            + "\t\t}}\n"
            + "\t}}\n"
            + "}}\n";

        //private int memptr = 0;
        private int indentCount = 0;
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
            string indentStr = new string('\t', indentCount);
            foreach (char subCode in BFCode)
            {
                switch (subCode)
                {
                    case '+':
                        translatedCode += indentStr + addatCP;
                        break;
                    case '-':
                        translatedCode += indentStr + subatCP;
                        break;
                    case '<':
                        translatedCode += indentStr + decMemPtr;
                        break;
                    case '>':
                        translatedCode += indentStr + incMemPtr;
                        break;
                    case '[':
                        translatedCode += indentStr + loopBeginatCP;
                        indentCount++;
                        indentStr = new string('\t', indentCount);
                        break;
                    case ']':
                        indentCount--;
                        indentStr = new string('\t', indentCount);
                        translatedCode += indentStr + loopEndatCP;
                        break;
                    case '.':
                        translatedCode += indentStr + outputatCP;
                        break;
                    case ',':
                        translatedCode += indentStr + inputatCP;
                        break;
                    default:
                        break;
                }
            }

            return translatedCode;
        }

        public void Savecodetofile()
        {
            string CSCode = translateToCS();
            string code = string.Format(boilerCode, filename.Replace(' ', '_').Substring(0, filename.IndexOf('.')), CSCode);
            using (StreamWriter sw = new StreamWriter("E:\\" + filename.Replace(' ', '_').Substring(0, filename.IndexOf('.')) + ".cs"))
            {
                sw.WriteLine(code);
            }
        }
    }
}
