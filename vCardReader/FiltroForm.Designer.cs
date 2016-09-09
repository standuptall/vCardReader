namespace vCardReader
{
    partial class FiltroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.dateTimePickerInizio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFine = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMittente = new System.Windows.Forms.TextBox();
            this.textBoxDestinatario = new System.Windows.Forms.TextBox();
            this.textBoxTesto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(282, 190);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dateTimePickerInizio
            // 
            this.dateTimePickerInizio.Location = new System.Drawing.Point(78, 12);
            this.dateTimePickerInizio.Name = "dateTimePickerInizio";
            this.dateTimePickerInizio.Size = new System.Drawing.Size(279, 20);
            this.dateTimePickerInizio.TabIndex = 1;
            this.dateTimePickerInizio.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerFine
            // 
            this.dateTimePickerFine.Location = new System.Drawing.Point(78, 38);
            this.dateTimePickerFine.Name = "dateTimePickerFine";
            this.dateTimePickerFine.Size = new System.Drawing.Size(279, 20);
            this.dateTimePickerFine.TabIndex = 2;
            this.dateTimePickerFine.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFine.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data Inizio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data Fine:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mittente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Destinatario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Testo";
            // 
            // textBoxMittente
            // 
            this.textBoxMittente.Location = new System.Drawing.Point(78, 66);
            this.textBoxMittente.Name = "textBoxMittente";
            this.textBoxMittente.Size = new System.Drawing.Size(279, 20);
            this.textBoxMittente.TabIndex = 8;
            // 
            // textBoxDestinatario
            // 
            this.textBoxDestinatario.Location = new System.Drawing.Point(78, 92);
            this.textBoxDestinatario.Name = "textBoxDestinatario";
            this.textBoxDestinatario.Size = new System.Drawing.Size(279, 20);
            this.textBoxDestinatario.TabIndex = 9;
            // 
            // textBoxTesto
            // 
            this.textBoxTesto.Location = new System.Drawing.Point(78, 118);
            this.textBoxTesto.Name = "textBoxTesto";
            this.textBoxTesto.Size = new System.Drawing.Size(279, 20);
            this.textBoxTesto.TabIndex = 10;
            // 
            // FiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 225);
            this.Controls.Add(this.textBoxTesto);
            this.Controls.Add(this.textBoxDestinatario);
            this.Controls.Add(this.textBoxMittente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFine);
            this.Controls.Add(this.dateTimePickerInizio);
            this.Controls.Add(this.buttonOK);
            this.Name = "FiltroForm";
            this.Text = "FiltroForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dateTimePickerInizio;
        public System.Windows.Forms.DateTimePicker dateTimePickerFine;
        public System.Windows.Forms.TextBox textBoxMittente;
        public System.Windows.Forms.TextBox textBoxDestinatario;
        public System.Windows.Forms.TextBox textBoxTesto;
    }
}