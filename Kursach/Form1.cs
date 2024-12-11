using DataBases.DataContext;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form1 : Form
    {
        private Context _context;
        public Form1(Context context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Kd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (double.TryParse(Kd.Text, out double kdValue))
            {
                Kr.Text = (kdValue / 2).ToString();
            }
        }

        private void u_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var uToT1Items = new Dictionary<string, string[]>
            {
                { "1", new[] { "47", "93", "135", "180" } },
                { "1,25", new[] { "61", "95", "122", "190" } },
                { "1,4", new[] { "50", "73", "101", "145" } },
                { "1,6", new[] { "41", "55", "113", "229" } },
                { "2", new[] { "49", "69", "99", "141" } },
                { "2,5", new[] { "71", "118", "157" } },
                { "3,15", new[] { "105", "152" } },
                { "4", new[] { "145", "207" } }
            };

            if (uToT1Items.TryGetValue(u.Text, out string[] items))
            {
                T1.Items.Clear();
                T1.Items.AddRange(items);
            }
        }

        private void Kbee_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(Kbee.Text, out double Kbe) && double.TryParse(u.Text, out double uu))
            {
                double Shirr = (Kbe * uu) / (2.0 - Kbe);

                if (Shirr < 0.3)
                    Shirr = 0.2;
                else if (Shirr < 0.5)
                    Shirr = 0.4;
                else if (Shirr < 0.7)
                    Shirr = 0.6;
                else if (Shirr < 0.9)
                    Shirr = 0.8;
                else
                    Shirr = 1;

                Shir.Text = Shirr.ToString();
            }
        }

        private void Zv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (double.TryParse(Shir.Text, out double Shirr))
            {
                Khb.Text = GetKhbValue(Op.Text, Td.Text, Zv.Text, Shirr);
            }
        }

        private string GetKhbValue(string opText, string tdText, string zvText, double shirr)
        {
            if (opText == "Шариковые")
            {
                if (tdText == "HB > 350")
                {
                    if (zvText == "Прямые и тангенциальные")
                    {
                        if (shirr == 0.2) return "1,16";
                        else if (shirr == 0.4) return "1,37";
                        else if (shirr == 0.6) return "1,58";
                        else if (shirr == 0.8) return "1,80";
                        else if (shirr == 1) return "0";
                    }
                    else if (zvText == "Круглые")
                    {
                        if (shirr == 0.2) return "1,08";
                        else if (shirr == 0.4) return "1,18";
                        else if (shirr == 0.6) return "1,29";
                        else if (shirr == 0.8) return "1,40";
                        else if (shirr == 1) return "0";
                    }
                }
                else if (tdText == "HB =< 350")
                {
                    if (zvText == "Прямые и тангенциальные")
                    {
                        if (shirr == 0.2) return "1,07";
                        else if (shirr == 0.4) return "1,14";
                        else if (shirr == 0.6) return "1,23";
                        else if (shirr == 0.8) return "1,34";
                        else if (shirr == 1) return "1,0";
                    }
                    else if (zvText == "Круглые")
                    {
                        return "1";
                    }
                }
            }
            else if (opText == "Роликовые")
            {
                if (tdText == "HB > 350")
                {
                    if (zvText == "Прямые и тангенциальные")
                    {
                        if (shirr == 0.2) return "1,08";
                        else if (shirr == 0.4) return "1,20";
                        else if (shirr == 0.6) return "1,32";
                        else if (shirr == 0.8) return "1,44";
                        else if (shirr == 1) return "1,55";
                    }
                    else if (zvText == "Круглые")
                    {
                        if (shirr == 0.2) return "1,04";
                        else if (shirr == 0.4) return "1,10";
                        else if (shirr == 0.6) return "1,15";
                        else if (shirr == 0.8) return "1,22";
                        else if (shirr == 1) return "1,28";
                    }
                }
                else if (tdText == "HB =< 350")
                {
                    if (zvText == "Прямые и тангенциальные")
                    {
                        if (shirr == 0.2) return "1,04";
                        else if (shirr == 0.4) return "1,08";
                        else if (shirr == 0.6) return "1,13";
                        else if (shirr == 0.8) return "1,18";
                        else if (shirr == 1) return "1,23";
                    }
                    else if (zvText == "Круглые")
                    {
                        return "1";
                    }
                }
            }
            return "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Kr.Text, out double Krr) &&
                double.TryParse(sigmaHP.Text, out double sigma) &&
                double.TryParse(u.Text, out double uu) &&
                double.TryParse(T1.Text, out double T11) &&
                double.TryParse(Khb.Text, out double Kh) &&
                double.TryParse(Kbee.Text, out double Kb))
            {
                double pow = Math.Pow(T11 * Kh / ((1.0 - Kb) * Kb * uu * sigma), 1.0 / 3.0);
                double sqr = Math.Sqrt(uu * uu + 1.0);

                double Ree = Krr * sqr * pow;

                Re.Text = Ree.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных");
                return;
            }

            try
            {
                // Создаем объект класса vhod с заполненными свойствами
                Vhod vhodim = new Vhod
                {
                    Kd = double.TryParse(Kd.Text, out double kdValue) ? kdValue : 0.0,
                    Kr = int.TryParse(Kr.Text, out int krValue) ? krValue : 0,
                    sigmaHP = int.TryParse(sigmaHP.Text, out int sigmaHPValue) ? sigmaHPValue : 0,
                    u = float.TryParse(u.Text, out float uValue) ? uValue : 0f,
                    T1 = int.TryParse(T1.Text, out int t1Value) ? t1Value : 0,
                    Shir = float.TryParse(Shir.Text, out float shirValue) ? shirValue : 0f,
                    Kbe = float.TryParse(Kbee.Text, out float kbeValue) ? kbeValue : 0f,
                    Khb = float.TryParse(Khb.Text, out float khbValue) ? khbValue : 0f,
                    opora = Op.Text,
                    hardness = Td.Text,
                    typeshi = Zv.Text
                };

                // Сохраняем объект в базе данных
                _context.Vhods.Add(vhodim);
                _context.SaveChanges();

                // Создаем объект класса vyhod для сохранения результата
                Vyhod vyhodim = new Vyhod
                {
                    Re = float.TryParse(Re.Text, out float reValue) ? reValue : 0,
                    VhodId = vhodim.id // Устанавливаем внешний ключ
                };

                _context.Vyhods.Add(vyhodim);
                _context.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }


        private void Khb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
