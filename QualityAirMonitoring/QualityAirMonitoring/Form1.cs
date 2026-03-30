using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityAirMonitoring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void afiseazaButton_Click(object sender, EventArgs e)
        {
            //string selectedCity = cityComboBox.SelectedItem?.ToString();
            //string selectedWeek = weekComboBox.SelectedItem?.ToString();

            ////var filePath = Path.GetFileNameWithoutExtension("Date.json");

            ////string filePath = "D:\\Facultate\\IA\\proiect\\QualityAirMonitoring\\QualityAirMonitoring\\Files\\Date.json";
            //string filePath = "D:\\D Drive\\Facultate\\Anul 4\\Semestrul 1\\IA\\Proiect\\QualityAirMonitoring\\QualityAirMonitoring\\Files\\Date.json";

            //try
            //{
            //    if (selectedCity != null && selectedWeek != null)
            //    {
            //        var dataReader = new DataReader(filePath);
            //        var meteoDetails = dataReader.GetMeteoDetails(selectedCity, selectedWeek);

            //        dateMeteoTextBox.Text = $"Detalii meteo pentru {selectedCity}, {selectedWeek}:{Environment.NewLine}" +
            //                                $"Temperatura: {meteoDetails.Temperatura}{Environment.NewLine}" +
            //                                $"Trafic: {meteoDetails.Trafic}{Environment.NewLine}" +
            //                                $"Vant: {meteoDetails.Vant}{Environment.NewLine}" +
            //                                $"Industrie: {meteoDetails.Industrie}{Environment.NewLine}" +
            //                                $"Umiditate: {meteoDetails.Umiditate}";
            //    }
            //    else
            //    {
            //        MessageBox.Show("Selectați orașul și săptămâna pentru a afișa detaliile meteo.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Eroare la citirea fișierului JSON: {ex.Message}");
            //}
        }

  
        private void estimateButton_Click(object sender, EventArgs e)
        {
            try
            {
                NivelPoluareMapper map = new NivelPoluareMapper();

            
                string selectedTrafic = traficComboBox.SelectedItem?.ToString();
                string selectedIndustrie = industrieComboBox.SelectedItem?.ToString();
                string selectedPoluare = poluareComboBox.SelectedItem?.ToString();
                string selectedCalitAer = aerComboBox.SelectedItem?.ToString();
                string selectedCalitApa = apaComboBox.SelectedItem?.ToString();
                string choice = probComboBox.SelectedItem?.ToString();

                double selectedTemp, selectedUmiditate, selectedVant;
                bool tempParsed = double.TryParse(tempTextBox.Text, out selectedTemp);
                bool umiditateParsed = double.TryParse(umiditateTextBox.Text, out selectedUmiditate);
                bool vantParsed = double.TryParse(vantTextBox.Text, out selectedVant);

                string tempStatus = tempParsed ? map.MapTemperatura(selectedTemp) : "Nedeterminat";
                string vantStatus = vantParsed ? map.MapVant(selectedVant) : "Nedeterminat";
                string umiditateStatus = umiditateParsed ? map.MapUmiditate(selectedUmiditate) : "Nedeterminat";


                string traficStatus = !activitateCheckBox.Checked ? (!string.IsNullOrEmpty(selectedTrafic) ? selectedTrafic : "Nedeterminat") : "Nedeterminat";
                string industrieStatus = !activitateCheckBox.Checked ? (!string.IsNullOrEmpty(selectedIndustrie) ? selectedIndustrie : "Nedeterminat") : "Nedeterminat";
                string poluareStatus = !poluareCheckBox.Checked ? (!string.IsNullOrEmpty(selectedPoluare) ? selectedPoluare : "Nedeterminat") : "Nedeterminat";
                string calitateAerStatus = !aerCheckBox.Checked ? (!string.IsNullOrEmpty(selectedCalitAer) ? selectedCalitAer : "Nedeterminat") : "Nedeterminat";
                string calitateApaStatus = !apaCheckBox.Checked ? (!string.IsNullOrEmpty(selectedCalitApa) ? selectedCalitApa : "Nedeterminat") : "Nedeterminat";
                string filePath = "D:\\D Drive\\Facultate\\Anul 4\\Semestrul 1\\IA\\Proiect\\QualityAirMonitoring\\QualityAirMonitoring\\Files\\Probabilitati.json";
                var dataReader = new DataReader(filePath);
                string filePath2 = "D:\\D Drive\\Facultate\\Anul 4\\Semestrul 1\\IA\\Proiect\\QualityAirMonitoring\\QualityAirMonitoring\\Files\\Calitate.json";
                var dataReader2 = new DataReader(filePath2);

                string selectedFactor = "";

                bool allOtherFieldsNedeterminat =
                            tempStatus == "Nedeterminat" &&
                            vantStatus == "Nedeterminat" &&
                            umiditateStatus == "Nedeterminat" &&
                            traficStatus == "Nedeterminat" &&
                            industrieStatus == "Nedeterminat" &&
                            poluareStatus == "Nedeterminat" &&
                            calitateAerStatus == "Nedeterminat" &&
                            calitateApaStatus == "Nedeterminat";


                if (checkBox1.Checked)
                {
                    selectedFactor = "Temperatura";

                    if (allOtherFieldsNedeterminat)
                    {
                        var temperatureDetails = dataReader.GetDetails(selectedFactor, choice);

                        if(choice==null)
                        {
                            MessageBox.Show("Selectați o probabilitate pentru a continua.");
                        }

                        if (temperatureDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca temperatura este: {temperatureDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in temperatureDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Temperatura.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }
                else if (vantCheckBox.Checked)
                {
                    selectedFactor = "Vant";

                    if (allOtherFieldsNedeterminat)
                    {
                        var vantDetails = dataReader.GetDetails(selectedFactor, choice);

                        if (vantDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca vantul este: {vantDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in vantDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Vant.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }
                else if (umiditateCheckBox.Checked)
                {
                    selectedFactor = "Umiditate";

                    if (allOtherFieldsNedeterminat)
                    {
                        var umiditateDetails = dataReader.GetDetails(selectedFactor,choice);

                        if (umiditateDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca umiditatea este: {umiditateDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in umiditateDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Umiditate.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }
                else if (activitateCheckBox.Checked)
                {
                    selectedFactor = "Activitate antropogenă";
                    if (allOtherFieldsNedeterminat)
                    {
                        var traficDetails = dataReader.GetDetails("Trafic", choice);
                        var industrieDetails = dataReader.GetDetails("Industrie", choice);

                        if (traficDetails != null && industrieDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca traficul este: {traficDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in traficDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();

                            sb.AppendLine($"Daca industria este: {industrieDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in industrieDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Activitate antropogenă.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }
                else if (poluareCheckBox.Checked)
                {
                    selectedFactor = "Poluare";
                }
                else if (aerCheckBox.Checked)
                {
                    selectedFactor = "Calitatea aerului";

                    if (allOtherFieldsNedeterminat)
                    {
                        var aerDetails = dataReader2.GetDetails("Aer", choice);


                        if (aerDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca calitatea aerului este: {aerDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in aerDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Calitatea aerului.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }
                else if (apaCheckBox.Checked)
                {
                    selectedFactor = "Calitatea apei";

                    if (allOtherFieldsNedeterminat)
                    {
                        var apaDetails = dataReader2.GetDetails("Apa", choice);

                        if (apaDetails != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"Daca calitatea apei este: {apaDetails.Value} atunci va avea urmatoarele probabilitati: ");

                            foreach (var probability in apaDetails.Probabilities)
                            {
                                sb.AppendLine($" {probability.Name} = {probability.Value}");
                            }

                            recomandariTextBox.Text = sb.ToString();
                        }
                        else
                        {
                            recomandariTextBox.Text = "Eroare la citirea datelor pentru Calitatea apei.";
                        }
                    }
                    else
                    {
                        recomandariTextBox.Clear();
                    }
                }


                if (!string.IsNullOrEmpty(selectedFactor))
                {
                    string predictionMessage = $"Care este probabilitatea ca factorul '{selectedFactor}' sa fie '{choice}' atunci cand urmatorii factori sunt: \r\n" +
                                               $"temperatura: {tempStatus},\r\n" +
                                               $"vant: {vantStatus},\r\n" +
                                               $"umiditate: {umiditateStatus},\r\n" +
                                               $"trafic: {traficStatus},\r\n" +
                                               $"industrie: {industrieStatus},\r\n" +
                                               $"poluare: {poluareStatus},\r\n" +
                                               $"calitate aer: {calitateAerStatus},\r\n" +
                                               $"calitate apa: {calitateApaStatus}?";

                    predictiiTextBox.Text = predictionMessage;

                }
                else
                {
                    MessageBox.Show("Selectați un factor pentru a continua.");
                }
            }
            catch
            {
                MessageBox.Show("Introduceti toate detaliile pentru a continua.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tempTextBox.Enabled = !checkBox1.Checked;
            vantCheckBox.Enabled= !checkBox1.Checked;
            umiditateCheckBox.Enabled = !checkBox1.Checked;
            activitateCheckBox.Enabled= !checkBox1.Checked;
            poluareCheckBox.Enabled = !checkBox1.Checked;
            aerCheckBox.Enabled = !checkBox1.Checked;
            apaCheckBox.Enabled = !checkBox1.Checked;
        }

        private void vantCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            vantTextBox.Enabled = !vantCheckBox.Checked;
            checkBox1.Enabled = !vantCheckBox.Checked;
            umiditateCheckBox.Enabled = !vantCheckBox.Checked;
            activitateCheckBox.Enabled = !vantCheckBox.Checked;
            poluareCheckBox.Enabled = !vantCheckBox.Checked;
            aerCheckBox.Enabled = !vantCheckBox.Checked;
            apaCheckBox.Enabled = !vantCheckBox.Checked;
        }

        private void umiditateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            umiditateTextBox.Enabled = !umiditateCheckBox.Checked;
            vantCheckBox.Enabled = !umiditateCheckBox.Checked;
            checkBox1.Enabled = !umiditateCheckBox.Checked;
            activitateCheckBox.Enabled = !umiditateCheckBox.Checked;
            poluareCheckBox.Enabled = !umiditateCheckBox.Checked;
            aerCheckBox.Enabled = !umiditateCheckBox.Checked;
            apaCheckBox.Enabled = !umiditateCheckBox.Checked;
        }

        private void activitateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            traficComboBox.Enabled = !activitateCheckBox.Checked;
            industrieComboBox.Enabled = !activitateCheckBox.Checked;
            vantCheckBox.Enabled = !activitateCheckBox.Checked;
            checkBox1.Enabled = !activitateCheckBox.Checked;
            umiditateCheckBox.Enabled = !activitateCheckBox.Checked;
            poluareCheckBox.Enabled = !activitateCheckBox.Checked;
            aerCheckBox.Enabled = !activitateCheckBox.Checked;
            apaCheckBox.Enabled = !activitateCheckBox.Checked;
        }

        private void poluareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            poluareComboBox.Enabled = !poluareCheckBox.Checked;
            vantCheckBox.Enabled = !poluareCheckBox.Checked;
            checkBox1.Enabled = !poluareCheckBox.Checked;
            umiditateCheckBox.Enabled = !poluareCheckBox.Checked;
            activitateCheckBox.Enabled = !poluareCheckBox.Checked;
            aerCheckBox.Enabled = !poluareCheckBox.Checked;
            apaCheckBox.Enabled = !poluareCheckBox.Checked;
        }

        private void aerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            aerComboBox.Enabled = !aerCheckBox.Checked;
            vantCheckBox.Enabled = !aerCheckBox.Checked;
            checkBox1.Enabled = !aerCheckBox.Checked;
            umiditateCheckBox.Enabled = !aerCheckBox.Checked;
            activitateCheckBox.Enabled = !aerCheckBox.Checked;
            poluareCheckBox.Enabled = !aerCheckBox.Checked;
            apaCheckBox.Enabled = !aerCheckBox.Checked;
        }

        private void apaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            apaComboBox.Enabled = !apaCheckBox.Checked;
            vantCheckBox.Enabled = !apaCheckBox.Checked;
            checkBox1.Enabled = !apaCheckBox.Checked;
            umiditateCheckBox.Enabled = !apaCheckBox.Checked;
            activitateCheckBox.Enabled = !apaCheckBox.Checked;
            poluareCheckBox.Enabled = !apaCheckBox.Checked;
            aerCheckBox.Enabled = !apaCheckBox.Checked;
        }

        private void despre_Click(object sender, EventArgs e)
        {
            const string copyright =
                "Inferența prin enumerare în rețele bayesiene.\r\n" +
                "Sistem de control și monitorizare a calității aerului.\r\n" +
                "Autori: Avdei Elena, Craiu Diana\r\n";

            MessageBox.Show(copyright, "Despre aplicatie");
        }

        private void iesire_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
