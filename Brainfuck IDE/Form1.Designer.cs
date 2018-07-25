namespace Brainfuck_IDE
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxBfEditor = new System.Windows.Forms.TextBox();
            this.textBoxBfMem = new System.Windows.Forms.TextBox();
            this.textBoxBfOutput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDia = new System.Windows.Forms.SaveFileDialog();
            this.openFileDia = new System.Windows.Forms.OpenFileDialog();
            this.textBoxBfInput = new System.Windows.Forms.TextBox();
            this.timerUpdateMemOut = new System.Windows.Forms.Timer(this.components);
            this.timerInput = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBfEditor
            // 
            this.textBoxBfEditor.AcceptsReturn = true;
            this.textBoxBfEditor.AcceptsTab = true;
            this.textBoxBfEditor.AllowDrop = true;
            this.textBoxBfEditor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxBfEditor.Location = new System.Drawing.Point(12, 27);
            this.textBoxBfEditor.MaximumSize = new System.Drawing.Size(1000, 500);
            this.textBoxBfEditor.Multiline = true;
            this.textBoxBfEditor.Name = "textBoxBfEditor";
            this.textBoxBfEditor.Size = new System.Drawing.Size(605, 284);
            this.textBoxBfEditor.TabIndex = 0;
            // 
            // textBoxBfMem
            // 
            this.textBoxBfMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBfMem.Location = new System.Drawing.Point(623, 27);
            this.textBoxBfMem.Multiline = true;
            this.textBoxBfMem.Name = "textBoxBfMem";
            this.textBoxBfMem.ReadOnly = true;
            this.textBoxBfMem.Size = new System.Drawing.Size(165, 411);
            this.textBoxBfMem.TabIndex = 1;
            // 
            // textBoxBfOutput
            // 
            this.textBoxBfOutput.Location = new System.Drawing.Point(12, 317);
            this.textBoxBfOutput.Multiline = true;
            this.textBoxBfOutput.Name = "textBoxBfOutput";
            this.textBoxBfOutput.ReadOnly = true;
            this.textBoxBfOutput.Size = new System.Drawing.Size(605, 95);
            this.textBoxBfOutput.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem1});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // debugToolStripMenuItem1
            // 
            this.debugToolStripMenuItem1.Name = "debugToolStripMenuItem1";
            this.debugToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.debugToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.debugToolStripMenuItem1.Text = "Debug";
            this.debugToolStripMenuItem1.Click += new System.EventHandler(this.debugToolStripMenuItem1_Click);
            // 
            // textBoxBfInput
            // 
            this.textBoxBfInput.Location = new System.Drawing.Point(12, 418);
            this.textBoxBfInput.Name = "textBoxBfInput";
            this.textBoxBfInput.Size = new System.Drawing.Size(605, 20);
            this.textBoxBfInput.TabIndex = 4;
            this.textBoxBfInput.TextChanged += new System.EventHandler(this.textBoxBfInput_TextChanged);
            // 
            // timerUpdateMemOut
            // 
            this.timerUpdateMemOut.Enabled = true;
            this.timerUpdateMemOut.Tick += new System.EventHandler(this.timerUpdateMemOut_Tick);
            // 
            // timerInput
            // 
            this.timerInput.Interval = 250;
            this.timerInput.Tick += new System.EventHandler(this.timerInput_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxBfInput);
            this.Controls.Add(this.textBoxBfOutput);
            this.Controls.Add(this.textBoxBfMem);
            this.Controls.Add(this.textBoxBfEditor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Brainfuck IDE";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBfEditor;
        private System.Windows.Forms.TextBox textBoxBfMem;
        private System.Windows.Forms.TextBox textBoxBfOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDia;
        private System.Windows.Forms.OpenFileDialog openFileDia;
        private System.Windows.Forms.TextBox textBoxBfInput;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem1;
        private System.Windows.Forms.Timer timerUpdateMemOut;
        private System.Windows.Forms.Timer timerInput;
    }
}

