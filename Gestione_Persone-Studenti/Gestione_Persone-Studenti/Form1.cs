using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestione_Persone_Studenti
{
    public partial class Form1 : Form
    {
        List<Persona> persone;
        public Form1()
        {
            InitializeComponent();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text, cognome = textBox2.Text, anni = textBox3.Text;

            if (!ControlloInserimento(nome) && !ControlloInserimento(cognome))
            {
                MessageBox.Show("Inserimento non valido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CancellaTextBox();
                return;
            }
            else
            {
                Persona p = new Persona(nome, cognome, anni);

                persone.Add(p);
                listBox1.Items.Add(p.Stampa());

                CancellaTextBox();
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            persone = new List<Persona>();
        }
        private bool ControlloInserimento(string stringa)
        {
            if (String.IsNullOrEmpty(stringa))
            {
                return false;
            }
            return true;
        }
        private void CancellaTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void studenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text, cognome = textBox2.Text, anni = textBox3.Text;

            if (!ControlloInserimento(nome) && !ControlloInserimento(cognome))
            {
                MessageBox.Show("Inserimento non valido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CancellaTextBox();
                return;
            }
            else
            {
                Studente p = new Studente(nome, cognome, anni);

                persone.Add(p);
                listBox1.Items.Add(p.Stampa());

                CancellaTextBox();
                return;
            }
        }
    }
}
