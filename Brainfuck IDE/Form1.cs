﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Brainfuck_IDE
{
    public partial class Form1 : Form
    {
        BfInterpreter bfintr;

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
        }

        private void debugToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string s = textBoxBfEditor.Text;
            textBoxBfOutput.Text = "";
            int i = 0;
            //textBoxBfOutput.Text = s;
            bfintr = new BfInterpreter(s);
            while (i < bfintr.Code.Length)
            {
                if (bfintr.CharAtCP == ',')
                {
                    timerInput.Stop();
                    bfintr.Input = textBoxBfInput.Text[0];
                    textBoxBfInput.Text = textBoxBfInput.Text.Substring(1);
                }
                bfintr.InterpretBF();
                if (bfintr.IsOutput)
                {
                    textBoxBfOutput.Text += bfintr.Output;
                    bfintr.IsOutput = false;
                }
                i = bfintr.CodePtr;
            }
        }

        private void textBoxBfInput_TextChanged(object sender, EventArgs e)
        {
            //timerInput.Stop();
            timerInput.Start();
        }

        private void timerInput_Tick(object sender, EventArgs e)
        {
            timerInput.Stop();

        }

        private void timerUpdateMemOut_Tick(object sender, EventArgs e)
        {
            string s = "";
            textBoxBfMem.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (bfintr != null)
                {
                    s += string.Format("Mem[{0}] = {1}", i, bfintr.Memory[i]);
                    if (bfintr.Memory[i] != 0)
                        s += ", " + (char)bfintr.Memory[i] + "\r\n";
                    else
                        s += "\r\n";
                }
            }
            textBoxBfMem.Text = s;
        }

    }
}