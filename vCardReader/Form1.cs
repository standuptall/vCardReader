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

namespace vCardReader
{
    public partial class Form1 : Form
    {
        FiltroForm filtroForm; 
        string[] vCards;
        static string percorso = "C:\\Users\\Alberto\\Desktop\\Gmail Files";
        public Form1()
        {
            InitializeComponent();
            filtroForm = new FiltroForm();
            findVCards(percorso);
            listBox1.DataSource = vCards;
        }
        public void findVCards(String path){
            string[] vCardsAll = Directory.GetFiles(path,"*.vmg");
            string[] vCardsFiltered = new string[vCardsAll.Length];
            int num = 0;
            bool filtroAttivo = false;
            Filtro filtro = filtroForm.filtro;
            foreach (string vCard in vCardsAll)
            {
                vCard carta = loadInfo(vCard);
                if (!filtro.mittente.Equals(""))
                {
                    filtroAttivo = true;
                    if (carta.mittente.Contains(filtro.mittente))
                    {
                        vCardsFiltered[num] = vCard;
                        num++;
                        continue;
                    }
                }
                if (!filtro.destinatario.Equals(""))
                {
                    filtroAttivo = true;
                    if (carta.destinatario.Contains(filtro.destinatario))
                    {
                        vCardsFiltered[num] = vCard;
                        num++;
                        continue;
                    }
                }
                if (!filtro.testo.Equals(""))
                {
                    filtroAttivo = true;
                    if (carta.testo.Contains(filtro.testo))
                    {
                        vCardsFiltered[num] = vCard;
                        num++;
                        continue;
                    }
                }
                /*controllo range di date */ 
                if ((filtro.dataInizio<=carta.data)&&(filtro.dataFine>=carta.data))
                {
                    filtroAttivo = true;
                    vCardsFiltered[num] = vCard;
                    num++;
                    continue;
                }
            }
            if (filtroAttivo)
                vCards = vCardsFiltered;
            else
                vCards = vCardsAll;
            listBox1.DataSource = vCards;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string vCardstring = vCards[index];
            vCard vCardTo = loadInfo(vCardstring);
            textMittente.Text = vCardTo.mittente;
            textDestinatario.Text = vCardTo.destinatario;
            textDataOra.Text = vCardTo.data.ToString();
            richTextBox1.Text = vCardTo.testo;
        }
            
        public vCard loadInfo(string vCard)
        {
            string[] lines = File.ReadAllLines(vCard);
            vCard vcard = new vCard();
            try
            {
                string mittente = "";
                string destinatario = "";
                int loc = -1;
                loc = localizza(lines,"X-IRMC-BOX");
                if (loc < 0)
                    throw new Exception("Errore nel leggere l vCard");
                if (togliCaratteriNulli(lines[loc]).Contains("SENT"))
                {
                    mittente = "Inviato da te";
                    loc = localizza(lines,"BEGIN:VENV");
                    if (loc < 0)
                        throw new Exception("Errore nel leggere l vCard");
                    destinatario = togliCaratteriNulli(lines[loc+4]).Substring(4);
                    if (togliCaratteriNulli(lines[loc + 3]).Substring(2).Equals(""))
                        destinatario = destinatario + " \"" + trovaNomeRubrica(destinatario) + "\""; 
                    else
                        destinatario = destinatario + " \"" + togliCaratteriNulli(lines[loc+3]).Substring(2) + "\"";
                }
                else
                {
                    destinatario = "Ricevuto da te";
                    loc = localizza(lines, "BEGIN:VENV");
                    if (loc < 0)
                        throw new Exception("Errore nel leggere l vCard");
                    mittente = togliCaratteriNulli(lines[loc + 4]).Substring(4);
                    if (togliCaratteriNulli(lines[loc + 3]).Substring(2).Equals(""))
                        mittente = mittente + " \"" + trovaNomeRubrica(mittente) + "\"";
                    else
                        mittente = mittente + " \"" + togliCaratteriNulli(lines[loc + 3]).Substring(2) + "\"";
                }
                loc = localizza(lines, "BEGIN:VBODY");
                if (loc < 0)
                    throw new Exception("Errore nel leggere l vCard");
                string datatempo = togliCaratteriNulli(lines[loc+1]).Substring(5);
                /* processo la data */
                string data = datatempo.Split(' ')[0];
                string tempo = datatempo.Split(' ')[1];
                string giorno, mese, anno;
                giorno = data.Split('.')[0];
                mese = data.Split('.')[1];
                anno = data.Split('.')[2];
                string ore, minuti, secondi;
                ore = tempo.Split(':')[0];
                minuti = tempo.Split(':')[1];
                secondi = tempo.Split(':')[2];
                DateTime dateTime = new DateTime(Int32.Parse(anno), Int32.Parse(mese), Int32.Parse(giorno), Int32.Parse(ore), Int32.Parse(minuti), Int32.Parse(secondi));
                
                string text = togliCaratteriNulli(lines[loc+2]);
                vcard.mittente = mittente;
                vcard.destinatario = destinatario;
                vcard.testo = text;
                vcard.data = dateTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vcard;
        }
        public int localizza(string[] lines,string linea)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = togliCaratteriNulli(lines[i]);
                if (line.Contains(linea))
                {
                    return i;
                }
            }
            return -1;

        }
        public string trovaNomeRubrica(string numero)
        {
            
            string[] csvLoad = File.ReadAllLines(percorso + "\\contacts.csv");
            int i = 0;
            foreach (string line in csvLoad)
            {
                string numerorub1 = "";
                string numerorub2 = "";
                string numerorub3 = "";
                string numerorub4 = "";
                try
                {
                    numerorub1 = line.Split(',')[17];
                    numerorub2 = line.Split(',')[18];
                    numerorub3 = line.Split(',')[19];
                    numerorub4 = line.Split(',')[20];
                }
                catch (Exception ec)
                {
                }
                
                i++;
                if (i == 143)
                    i = 143;
                if (confrontaNumeri(numero, numerorub1))
                    return line.Split(',')[0] + line.Split(',')[2];
                if (confrontaNumeri(numero, numerorub2))
                    return line.Split(',')[0] + line.Split(',')[2];
                if (confrontaNumeri(numero, numerorub3))
                    return line.Split(',')[0] + line.Split(',')[2];
                if (confrontaNumeri(numero, numerorub4))
                    return line.Split(',')[0] + line.Split(',')[2];
            }
            return "";
        }
        public bool confrontaNumeri(string num1, string num2)
        {
            num1 = togliSpaziETrattini(num1);
            num2 = togliSpaziETrattini(num2);
            if (num1.Contains("+39"))
                num1 = num1.Substring(3);
            if (num2.Contains("+39"))
                num2 = num2.Substring(3);
            if (num1.Equals(num2))
                return true;
            else return false;
        }
        public string togliCaratteriNulli(string line)
        {
            char[] newLine = new char[line.Length];
            char[] arr = line.ToCharArray();
            int num = 0;
            foreach (char c in arr)
            {
                if (c != '\0')
                {
                    newLine[num] = c;
                    num++;
                }
            }
            string rit = new string(newLine, 0, num);
            return rit;
        }
        public string togliSpaziETrattini(string line)
        {
            char[] newLine = new char[line.Length];
            char[] arr = line.ToCharArray();
            int num = 0;
            foreach (char c in arr)
            {
                if ((c != ' ')&&(c != '-'))
                {
                    newLine[num] = c;
                    num++;
                }
            }
            string rit = new string(newLine, 0, num);
            return rit;
        }

        private void buttonFiltra_Click(object sender, EventArgs e)
        {
            filtroForm.ShowDialog();
            findVCards(percorso);
        }
    }
}
