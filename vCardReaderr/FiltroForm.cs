using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vCardReader
{
    public partial class FiltroForm : Form
    {
        public Filtro filtro;
        public FiltroForm()
        {
            InitializeComponent();
            filtro = new Filtro();
            filtro.dataInizio = this.dateTimePickerInizio.Value;
            filtro.dataFine = this.dateTimePickerFine.Value;
            filtro.mittente = this.textBoxMittente.Text;
            filtro.destinatario = this.textBoxDestinatario.Text;
            filtro.testo = this.textBoxTesto.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {            
            filtro.dataInizio = this.dateTimePickerInizio.Value;
            filtro.dataFine = this.dateTimePickerFine.Value;
            filtro.mittente = this.textBoxMittente.Text;
            filtro.destinatario = this.textBoxDestinatario.Text;
            filtro.testo = this.textBoxTesto.Text;
            this.Hide();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
