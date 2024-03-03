namespace Gestione_Persone_Studenti
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inserimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Nome = new System.Windows.Forms.Label();
            this.Cognome = new System.Windows.Forms.Label();
            this.Anni = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserimentoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inserimentoToolStripMenuItem
            // 
            this.inserimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personaToolStripMenuItem,
            this.studenteToolStripMenuItem});
            this.inserimentoToolStripMenuItem.Name = "inserimentoToolStripMenuItem";
            this.inserimentoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.inserimentoToolStripMenuItem.Text = "Inserimento";
            // 
            // personaToolStripMenuItem
            // 
            this.personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            this.personaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.personaToolStripMenuItem.Text = "Persona";
            this.personaToolStripMenuItem.Click += new System.EventHandler(this.personaToolStripMenuItem_Click);
            // 
            // studenteToolStripMenuItem
            // 
            this.studenteToolStripMenuItem.Name = "studenteToolStripMenuItem";
            this.studenteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.studenteToolStripMenuItem.Text = "Studente";
            this.studenteToolStripMenuItem.Click += new System.EventHandler(this.studenteToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 226);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(384, 212);
            this.listBox1.TabIndex = 1;
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(420, 226);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(35, 13);
            this.Nome.TabIndex = 2;
            this.Nome.Text = "Nome";
            // 
            // Cognome
            // 
            this.Cognome.AutoSize = true;
            this.Cognome.Location = new System.Drawing.Point(420, 279);
            this.Cognome.Name = "Cognome";
            this.Cognome.Size = new System.Drawing.Size(52, 13);
            this.Cognome.TabIndex = 3;
            this.Cognome.Text = "Cognome";
            // 
            // Anni
            // 
            this.Anni.AutoSize = true;
            this.Anni.Location = new System.Drawing.Point(420, 328);
            this.Anni.Name = "Anni";
            this.Anni.Size = new System.Drawing.Size(28, 13);
            this.Anni.TabIndex = 4;
            this.Anni.Text = "Anni";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(423, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(423, 295);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(423, 344);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Anni);
            this.Controls.Add(this.Cognome);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inserimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studenteToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label Cognome;
        private System.Windows.Forms.Label Anni;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

