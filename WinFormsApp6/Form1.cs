using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        #region Properties
        public string ilkDeger { get; set; }
        public string ikinciDeger { get; set; }
        public char op { get; set; }
        public double ilkDouble { get; set; }
        public double ikinciDouble { get; set; }
        public double oncekiSonuc { get; set; } = 1;
        public double sonuc { get; set; }
        public double memory { get; set; } = 0;
        public bool ikinciIslem { get; set; }
        public bool temiz { get; set; } 
        public bool tussuz { get; set; }
        #endregion
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.Icon = HesapKitap.Properties.Resources.icoo;
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "0";
            }
            else if (textBox1.Text != "0")
            {

            }
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
        }
        #region Methods
        private void temizleyici()
        {
            if (textBox3.Text.Contains("="))
            {
                textBox3.Clear();
                textBox1.Clear();
                textBox1.Text = "0";
            }
            else if (ikinciIslem == true && temiz == false)
            {
                textBox1.Clear();
                temiz = true;
                tussuz = false;
            }
        }
        private void yazici(string x)
        {
            temizleyici();
            if (textBox1.Text == "0")
            { textBox1.Text = x; }
            else
            {
                if (textBox1.Text.Length >= 16) { }
                else
                {
                    textBox1.Text += x;
                }
            }
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
        }
        private char aritmatik(char x)
        {
            ilkDeger = textBox1.Text;
            textBox1.Clear();
            op = x;
            textBox3.Text = ilkDeger + " " + x;
            return op;
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
        }
        private void esittir(char x)
        {
            op = x;
            if (ikinciDouble == 0 && ilkDeger != null)
            {
                ikinciDeger = textBox1.Text;
                ilkDouble = Convert.ToDouble(ilkDeger);
                ikinciDouble = Convert.ToDouble(ikinciDeger);
                textBox1.Clear();
                switch (x)
                {
                    case '+':
                        sonuc = ilkDouble + ikinciDouble;
                        break;
                    case '-':
                        sonuc = ilkDouble - ikinciDouble;
                        break;
                    case 'x':
                        sonuc = ilkDouble * ikinciDouble;
                        break;
                    case '/':
                        sonuc = ilkDouble / ikinciDouble;
                        break;
                    case '^':
                        sonuc = Math.Pow(ilkDouble, ikinciDouble);
                        break;
                }
                textBox1.Text = Convert.ToString(sonuc);
                textBox3.Text = ilkDeger + " " + x + " " + ikinciDeger + " =";
                oncekiSonuc = sonuc;
            }
            else
            {
                switch (op)
                {
                    case '+':
                        sonuc = oncekiSonuc + ikinciDouble;
                        break;
                    case '-':
                        sonuc = oncekiSonuc - ikinciDouble;
                        break;
                    case 'x':
                        sonuc = oncekiSonuc * ikinciDouble;
                        break;
                    case '/':
                        sonuc = oncekiSonuc / ikinciDouble;
                        break;
                    case '^':
                        sonuc = Math.Pow(oncekiSonuc, ikinciDouble);
                        break;
                }
                textBox1.Text = Convert.ToString(sonuc);
                textBox3.Text = Convert.ToString(oncekiSonuc) + " " + op + " " + Convert.ToString(ikinciDeger) + " =";
                oncekiSonuc = sonuc;
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.TextLength;
            }
        }
        private void esittir2(char x)
        {
            op = x;
            if (ikinciIslem == false)
            {
                ikinciIslem = true;
                ikinciDeger = textBox1.Text;
                ilkDouble = Convert.ToDouble(ilkDeger);
                ikinciDouble = Convert.ToDouble(ikinciDeger);
                textBox1.Clear();

                switch (x)
                {
                    case '+':
                        sonuc = ilkDouble + ikinciDouble;
                        break;
                    case '-':
                        sonuc = ilkDouble - ikinciDouble;
                        break;
                    case 'x':
                        sonuc = ilkDouble * ikinciDouble;
                        break;
                    case '/':
                        sonuc = ilkDouble / ikinciDouble;
                        break;
                    case '^':
                        sonuc = Math.Pow(ilkDouble, ikinciDouble);
                        break;
                }
                textBox1.Text = Convert.ToString(sonuc);
                textBox3.Text = sonuc + " " + x + " ";
                oncekiSonuc = sonuc;
                tussuz = true;
            }
            else
            {
                op = x;
                ikinciDeger = textBox1.Text;
                ikinciDouble = Convert.ToDouble(ikinciDeger);
                switch (x)
                {
                    case '+':
                        sonuc = oncekiSonuc + ikinciDouble;
                        break;
                    case '-':
                        sonuc = oncekiSonuc - ikinciDouble;
                        break;
                    case 'x':
                        sonuc = oncekiSonuc * ikinciDouble;
                        break;
                    case '/':
                        sonuc = oncekiSonuc / ikinciDouble;
                        break;
                    case '^':
                        sonuc = Math.Pow(oncekiSonuc, ikinciDouble);
                        break;
                }
                textBox1.Text = Convert.ToString(sonuc);
                textBox3.Text = sonuc + " " + x + " ";
                oncekiSonuc = sonuc;
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.TextLength;
                temiz = false;
                tussuz = true;
            }
        }
        private void yuzde(char x)
        {
            double yuz = 100;
            if (ikinciDeger != null || ikinciDeger != "0")
            {
                ikinciDeger = textBox1.Text;
                if (ilkDeger != null || ilkDeger != "0" || ikinciDeger != null)
                {
                    ilkDouble = Convert.ToDouble(ilkDeger);
                    ikinciDouble = Convert.ToDouble(ikinciDeger);
                    textBox1.Clear();
                    sonuc = Convert.ToDouble(sonuc);
                    switch (x)
                    {
                        case '+':
                            sonuc = ((ilkDouble * ikinciDouble) / yuz) + ilkDouble;
                            textBox3.Text = ilkDeger + " + " + Convert.ToString((ilkDouble * ikinciDouble) / yuz) + " =";
                            textBox1.Text = Convert.ToString(sonuc);
                            break;
                        case '-':
                            sonuc = ilkDouble - ((ilkDouble * ikinciDouble) / yuz);
                            textBox3.Text = ilkDeger + " - " + Convert.ToString((ilkDouble * ikinciDouble) / yuz) + " =";
                            textBox1.Text = Convert.ToString(sonuc);
                            break;
                        case '/':
                            sonuc = (ilkDouble * 100) / ikinciDouble;
                            textBox3.Text = ilkDeger + "sayısı " + ikinciDeger + " sayısının" + " yüzde";
                            textBox1.Text = Convert.ToString(sonuc);
                            break;
                        case 'x':
                            sonuc = ((ilkDouble * ikinciDouble) / yuz);
                            textBox3.Text = ilkDeger + " x " + Convert.ToString(ikinciDouble / 100) + " =";
                            textBox1.Text = Convert.ToString(sonuc);
                            break;
                    }
                }
            }
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
        }
        #endregion
        #region Sayı Tuşları
        private void birTusu_Click(object sender, EventArgs e)
        {
            yazici("1");
        }
        private void ikiTusu_Click(object sender, EventArgs e)
        {
            yazici("2");
        }
        private void ucTusu_Click(object sender, EventArgs e)
        {
            yazici("3");
        }
        private void dortTusu_Click(object sender, EventArgs e)
        {
            yazici("4");
        }
        private void besTusu_Click(object sender, EventArgs e)
        {
            yazici("5");
        }
        private void altiTusu_Click(object sender, EventArgs e)
        {
            yazici("6");
        }
        private void yediTusu_Click(object sender, EventArgs e)
        {
            yazici("7");
        }
        private void sekizTusu_Click(object sender, EventArgs e)
        {
            yazici("8");
        }
        private void dokuzTusu_Click(object sender, EventArgs e)
        {
            yazici("9");
        }
        private void sifirTusu_Click(object sender, EventArgs e)
        {
            yazici("0");
        }
        #endregion
        #region Kontrol Tuşları
        private void silmeTusu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
        private void isaretDegistirmeTusu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.StartsWith("-"))
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            else
            {
                ilkDeger = textBox1.Text;
                textBox1.Text = "-" + ilkDeger;
            }
        }
        private void esittirTusu_Click(object sender, EventArgs e)
        {
            esittir(op);
        }
        private void virgulTusu_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }
        private void cTusu_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            ilkDeger = "";
            ikinciDeger = "";
            op = '\0';
            ilkDouble = 0.0;
            ikinciDouble = 0.0;
            sonuc = 0.0;
            oncekiSonuc = 0.0;
            ikinciIslem = false;
            temiz = false;
            tussuz = false;
        }
        private void ceTusu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(0);
            }
        }
        #endregion
        #region Aritmatik tuşlar
        private void toplamaTusu_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Contains(op))
            {
                aritmatik('+');
            }
            else if (tussuz == false) { esittir2('+'); }
        }
        private void cikarmaTusu_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Contains(op))
            {
                aritmatik('-');
            }
            else if (tussuz == false) { esittir2('-'); }
        }
        private void carpmaTusu_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Contains(op))
            {
                aritmatik('*');
            }
            else if (tussuz == false) { esittir2('*'); }

        }
        private void bolmeTusu_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Contains(op))
            {
                aritmatik('/');
            }
            else if (tussuz == false) { esittir2('/'); }
        }
        private void kareKokuTusu_Click(object sender, EventArgs e)
        {
            ilkDeger = textBox1.Text;
            textBox1.Clear();
            textBox3.Text = "√" + ilkDeger;
            double ilkDouble = Convert.ToDouble(ilkDeger);
            double ikinDouble = 0.5;
            textBox1.Text = Convert.ToString(Math.Pow(ilkDouble, ikinDouble));
        }
        private void karesiniAlmaTusu_Click(object sender, EventArgs e)
        {
            aritmatik('^');
        }
        private void bireBolmeTusu_Click(object sender, EventArgs e)
        {
            ilkDeger = textBox1.Text;
            textBox1.Clear();
            textBox3.Text += "1/(" + ilkDeger + ")";
            ilkDouble = Convert.ToDouble(ilkDeger);
            textBox1.Text = Convert.ToString(1 / ilkDouble);
        }
        private void yuzdeTusu_Click(object sender, EventArgs e)
        {
            yuzde(op);
        }
        #endregion
        #region M tuşları
        private void msTusu_Click_1(object sender, EventArgs e)
        {
            double sayi;
            if (Double.TryParse(textBox1.Text, out sayi))
            {
                memory = sayi;
                textBox1.Clear();
            }
        }
        private void mEksiTusu_Click_1(object sender, EventArgs e)
        {
            double sayi;
            if (Double.TryParse(textBox1.Text, out sayi))
            {
                memory -= sayi;
                textBox1.Clear();
            }
        }
        private void mArtiTusu_Click_1(object sender, EventArgs e)
        {
            double sayi;
            if (Double.TryParse(textBox1.Text, out sayi))
            {
                memory += sayi;
                textBox1.Clear();
            }
        }
        private void mcTusu_Click_1(object sender, EventArgs e)
        {
            memory = 0;
        }
        private void mrTusu_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = memory.ToString();
        }
        #endregion
        #region Textbox Klavye Girişi
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != ',')
            {
                temizleyici();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                esittirTusu.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                temizleyici();
                silmeTusu.PerformClick();
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {

                switch (e.KeyChar)
                {
                    case '1':
                        birTusu.PerformClick();
                        break;
                    case '2':
                        ikiTusu.PerformClick();
                        break;
                    case '3':
                        ucTusu.PerformClick();
                        break;
                    case '4':
                        dortTusu.PerformClick();
                        break;
                    case '5':
                        besTusu.PerformClick();
                        break;
                    case '6':
                        altiTusu.PerformClick();
                        break;
                    case '7':
                        yediTusu.PerformClick();
                        break;
                    case '8':
                        sekizTusu.PerformClick();
                        break;
                    case '9':
                        dokuzTusu.PerformClick();
                        break;
                    case '0':
                        sifirTusu.PerformClick();
                        break;
                }
            }
            else
            {
                switch (e.KeyChar)
                {
                    case '+':
                        toplamaTusu.PerformClick();
                        break;
                    case '-':
                        cikarmaTusu.PerformClick();
                        break;
                    case '*':
                        carpmaTusu.PerformClick();
                        break;
                    case '/':
                        bolmeTusu.PerformClick();
                        break;
                    case ',':
                        if (!textBox1.Text.Contains(","))
                        {
                            virgulTusu.PerformClick();
                        }
                        break;
                }
            }


            e.Handled = true;
        }

        #endregion
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}