using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Brainfuck_IDE.src;

namespace Brainfuck_IDE
{
    public partial class Form1 : Form
    {
        BfInterpreter bfintr;

        bool isRunning = false;
        bool isStarted = false;
        string filename;
        string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxBfEditor.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDia.Filter = "Brainfuck files (*.bf)|*.bf|All files (*.*)|*.*";
            if (openFileDia.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDia.FileName);
                textBoxBfEditor.Text = sr.ReadToEnd();
                sr.Close();
            }
            path = openFileDia.FileName;
            filename = path.Substring(path.LastIndexOf('\\') + 1);
            Form1.ActiveForm.Text = "Brainfuck IDE - " + filename;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDia.Filter = "Brainfuck files (*.bf)|*.bf|All files (*.*)|*.*";
            if (saveFileDia.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDia.FileName);
                sw.Write(textBoxBfEditor.Text);
                sw.Close();
            }
            path = saveFileDia.FileName;
            filename = path.Substring(path.LastIndexOf('\\') + 1);
            Form1.ActiveForm.Text = "Brainfuck IDE - " + filename;
        }

        private void debugToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string s = textBoxBfEditor.Text;
            textBoxBfOutput.Text = "";
            //int i = 0;
            //textBoxBfOutput.Text = s;
            bfintr = new BfInterpreter(s);
            //timerExeBf.Start();
            isRunning = true;
            isStarted = true;
            ExecBf();
        }

        private void textBoxBfInput_TextChanged(object sender, EventArgs e)
        {
            //timerInput.Stop();
            //timerExeBf.Start();
            if (isStarted)
            {
                isRunning = true;
                ExecBf();
            }
        }

        private void timerExeBf_Tick(object sender, EventArgs e)
        {
            if (bfintr.CharAtCP == ',' && textBoxBfInput.Text == "")
            {
                timerExeBf.Stop();
                return;
            }
            else if (bfintr.CharAtCP == ',')
            {
                bfintr.Input = textBoxBfInput.Text[0];
                textBoxBfInput.Text = textBoxBfInput.Text.Substring(1);
            }
            bfintr.InterpretBF();
            if (bfintr.IsOutput)
            {
                textBoxBfOutput.Text += bfintr.Output;
                bfintr.IsOutput = false;
            }

            if (bfintr.CodePtr == bfintr.Code.Length)
            {
                timerExeBf.Stop();
            }
        }

        private void ExecBf()
        {
            while (bfintr.CodePtr < bfintr.Code.Length)
            {
                if (bfintr.CharAtCP == ',' && textBoxBfInput.Text == "")
                {
                    isRunning = false;
                    return;
                }
                else if (bfintr.CharAtCP == ',')
                {
                    bfintr.Input = textBoxBfInput.Text[0];
                    textBoxBfInput.Text = textBoxBfInput.Text.Substring(1);
                }
                bfintr.InterpretBF();
                if (bfintr.IsMemChanged)
                {
                    UpdateMemView();
                    bfintr.IsMemChanged = false;
                }
                if (bfintr.IsOutput)
                {
                    textBoxBfOutput.Text += bfintr.Output;
                    bfintr.IsOutput = false;
                }
            }
            isStarted = false;
            //if (bfintr.CodePtr == bfintr.Code.Length)
            //{
            //    timerExeBf.Stop();
            //}
        }

        private void UpdateMemView()
        {
            string s = "";
            int begin = 0;
            int end = 20;

            if (textBoxMemBegin.Text == "")
            {
                begin = 0;
            }
            else
            {
                try
                {
                    begin = Convert.ToInt32(textBoxMemBegin.Text);
                }
                catch (FormatException r)
                {
                    MessageBox.Show(r.Message, "Error !!!");
                }
            }
            if (textBoxMemElements.Text == "")
            {
                end = begin + 20;
            }
            else
            {
                try
                {
                    end = begin + Convert.ToInt32(textBoxMemElements.Text);
                }
                catch (FormatException r)
                {
                    MessageBox.Show(r.Message, "Error !!!");
                }
            }
            if (begin > bfintr.MemSize)
            {
                begin = 0;
            }
            if ((end - begin) > 100)
            {
                end = begin + 100;
                textBoxMemElements.Text = 100.ToString();
            }

            textBoxBfMem.Clear();
            for (int i = begin; i < end; i++)
            {
                if (bfintr != null)
                {
                    s += string.Format("Mem[{0,3}] = {1,3} | 0x{1,2:X2}", i, bfintr.Memory[i]);
                    if (bfintr.Memory[i] != 0)
                        s += " | " + (char)bfintr.Memory[i] + "\r\n";
                    else
                        s += "\r\n";
                }
            }
            textBoxBfMem.Text = s;
        }

        private void timerUpdateMemOut_Tick(object sender, EventArgs e)
        {
            UpdateMemView();
        }

        private void textBoxMemBegin_TextChanged(object sender, EventArgs e)
        {
            UpdateMemView();
        }

        private void textBoxMemElements_TextChanged(object sender, EventArgs e)
        {
            UpdateMemView();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = textBoxBfEditor.Text;
            BFCompile bfc = new BFCompile(s, filename);
            bfc.Savecodetofile();
            //textBoxBfOutput.Text = bfc.translateToCS();
        }

        //private void label8_Click(object sender, EventArgs e)
        //{

        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

    }
}
