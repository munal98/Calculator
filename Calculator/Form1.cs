using System;
using System.Globalization;
using System.Windows.Forms;

namespace _028_4_WindowsForms_Calculator
{
    public partial class Form1 : Form
    {
        const string tanimsiz = "Tanımsız"; // const: constant, sabit: kodda hiç bir şekilde değeri değiştirlemez
        const string usIslemi = "üs"; 
        const string kareKokIslemi = "kare kök";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LabellariTemizle();
        }

        private void b0_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "0";
        }

        private void b1_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "2";
        }

        private void b3_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "3";
        }

        private void b4_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "4";
        }

        private void b5_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "5";
        }

        private void b6_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "6";
        }

        private void b7_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "7";
        }

        private void b8_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            tbSonuc.Text += "9";
        }

        private void bArti_Click(object sender, EventArgs e)
        {
            IslemKontrol("+");
        }

        private void bEksi_Click(object sender, EventArgs e)
        {
            IslemKontrol("-");
        }

        private void bCarpi_Click(object sender, EventArgs e)
        {
            IslemKontrol("*");
        }

        private void bBolu_Click(object sender, EventArgs e)
        {
            IslemKontrol("/");
        }

        private void bYuzde_Click(object sender, EventArgs e)
        {
            IslemKontrol("%");
        }

        private void bUs_Click(object sender, EventArgs e)
        {
            IslemKontrol(usIslemi);
        }

        private void bKareKok_Click(object sender, EventArgs e)
        {
            IslemKontrol(kareKokIslemi);
            Hesapla(false);
        }

        private void bIsaret_Click(object sender, EventArgs e)
        {
            IsaretKontrol();
        }

        private void bVirgul_Click(object sender, EventArgs e)
        {
            VirgulKontrol();
        }

        private void bEsit_Click(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            if (tbSonuc.Text != "")
            {
                tbSonuc.Text = tbSonuc.Text.Remove(tbSonuc.Text.Length - 1);
            }
        }

        private void bCe_Click(object sender, EventArgs e)
        {
            if (tbSonuc.Text != "")
            {
                tbSonuc.Text = "";
            }
            else
            {
                if (lSayi1.Text != "")
                {
                    LabellariTemizle();
                }
            }
        }

        private void bC_Click(object sender, EventArgs e)
        {
            tbSonuc.Text = "";
            LabellariTemizle();
        }

        void IsaretKontrol()
        {
            if (tbSonuc.Text != "")
            {
                if (tbSonuc.Text[0] == '-')
                {
                    tbSonuc.Text = tbSonuc.Text.Remove(0, 1);
                }
                else
                {
                    tbSonuc.Text = "-" + tbSonuc.Text;
                }
            }
            else
            {
                tbSonuc.Text = "-";
            }
        }

        void VirgulKontrol(bool islemMi = false)
        {
            if (!islemMi)
            {
                if (tbSonuc.Text == "")
                {
                    tbSonuc.Text = "0,";
                }
                else
                {
                    if (!tbSonuc.Text.Contains(","))
                    {
                        tbSonuc.Text += ",";
                    }
                }
            }
            else
            {
                if (tbSonuc.Text != "")
                {
                    if (tbSonuc.Text.Substring(tbSonuc.Text.Length - 1) == ",")
                    {
                        tbSonuc.Text += "0";
                    }
                }
            }
        }

        void IslemKontrol(string islem)
        {
            if (tbSonuc.Text != "" && !NanSonsuzTanimsizKontrol())
            {
                lIslem.Text = islem;
                VirgulKontrol(true);
                lSayi1.Text = tbSonuc.Text;
                tbSonuc.Text = "";
            }
            else
            {
                tbSonuc.Text = "";
                MessageBox.Show("Lütfen geçerli giriş yapınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void LabellariTemizle()
        {
            lSayi1.Text = "";
            lSayi2.Text = "";
            lIslem.Text = "";
        }

        bool NanSonsuzTanimsizKontrol()
        {
            return tbSonuc.Text.Contains("NaN") || tbSonuc.Text.Contains("∞") || tbSonuc.Text.Contains(tanimsiz);
        }

        void Hesapla(bool uyariGoster = true)
        {
            try
            {
                if (lSayi1.Text != "" && lIslem.Text != "")
                {
                    if (!lSayi1.Text.Contains(tanimsiz) && !tbSonuc.Text.Contains(tanimsiz))
                    {
                        VirgulKontrol(true);
                        if (lIslem.Text != kareKokIslemi)
                        {
                            lSayi2.Text = tbSonuc.Text;
                        }
                        else
                        {
                            lSayi2.Text = lSayi1.Text;
                        }
                        if (lSayi2.Text != "")
                        {
                            double sayi1 = Convert.ToDouble(lSayi1.Text, new CultureInfo("tr"));
                            double sayi2 = Convert.ToDouble(lSayi2.Text, new CultureInfo("tr"));
                            double sonuc = 0;
                            switch (lIslem.Text)
                            {
                                case "+":
                                    sonuc = sayi1 + sayi2;
                                    break;
                                case "-":
                                    sonuc = sayi1 - sayi2;
                                    break;
                                case "*":
                                    sonuc = sayi1 * sayi2;
                                    break;
                                case "/":
                                    sonuc = sayi1 / sayi2;
                                    break;
                                case "%":
                                    sonuc = sayi1 % sayi2;
                                    break;
                                case usIslemi:
                                    sonuc = Math.Pow(sayi1, sayi2);
                                    break;
                                default:
                                    sonuc = Math.Sqrt(sayi1);
                                    break;
                            }
                            tbSonuc.Text = sonuc.ToString(new CultureInfo("tr"));
                            if (NanSonsuzTanimsizKontrol())
                            {
                                tbSonuc.Text = tanimsiz;
                            }
                            LabellariTemizle();
                        }
                        else
                        {
                            if (uyariGoster)
                            {
                                tbSonuc.Text = "";
                                MessageBox.Show("Lütfen geçerli giriş yapınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        if (uyariGoster)
                        {
                            tbSonuc.Text = "";
                            MessageBox.Show("Lütfen geçerli giriş yapınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    if (uyariGoster)
                    {
                        tbSonuc.Text = "";
                        MessageBox.Show("Lütfen geçerli giriş yapınız...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
