using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using ENN.Framework;

namespace ENN.SettingsBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void binaryFileButton_Click(object sender, EventArgs e)
        {
            chooseBinary.ShowDialog();
            binaryLocation.Text = chooseBinary.FileName;
            Assembly assembly = Assembly.LoadFrom(binaryLocation.Text);
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if(type.GetMethod("CreateUserObject") != null)
                {
                    className.Text = type.FullName;
                    binaryName.Text = type.Name;
                    useBinaryCheckBox.Checked = true;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            networkDropDown.SelectedIndex = 0;
            trainingType.SelectedIndex = 0;
            trainingMeasure.SelectedIndex = 0;
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            openSettings.ShowDialog();
            StreamReader fs = new StreamReader(openSettings.OpenFile());
            string line;
            string[] terms;
            while (!fs.EndOfStream)
            {
                line = fs.ReadLine();
                line = line.Trim();
                if (!line.StartsWith("#") || !line.StartsWith(""))
                {
                    terms = line.Split(':');

                    switch (terms[0])
                    {
                        case "networkmode":
                            if (terms[1] == "training")
                            {
                                networkDropDown.SelectedIndex = 1;
                            }
                            else
                            {
                                networkDropDown.SelectedIndex = 0;
                            }
                            break;
                        case "trainingstyle":
                            if (terms[1] == "traditional")
                            {
                                trainingType.SelectedIndex = 0;
                            }
                            else
                            {
                                trainingType.SelectedIndex = 1;
                            }
                            break;
                        case "userbinarylocation":
                            binaryLocation.Text = terms[1];
                            break;
                        case "userbinaryclassname":
                            className.Text = terms[1];
                            break;
                        case "userbinaryname":
                            binaryName.Text = terms[1];
                            break;
                        case "useusesbinary":
                            useBinaryCheckBox.Checked = 
                                (terms[1] == "True" || terms[1] == "true");
                            break;
                        case "inputlayer":
                            defaultInput.Text = terms[1];
                            break;
                        case "node":
                            defaultNode.Text = terms[1];
                            break;
                        case "nodelayer":
                            defaultHidden.Text = terms[1];
                            break;
                        case "outputlayer":
                            defaultOutput.Text = terms[1];
                            break;
                        case "enabletiming":
                            enableTiming.Checked = (terms[1].ToLower() == "true");
                            break;
                        case "trainingmeasurement":
                            if (terms[1] == "interations")
                            {
                                trainingMeasure.SelectedIndex = 0;
                            }
                            else
                            {
                                trainingMeasure.SelectedIndex = 1;
                            }
                            break;
                        case "trainingpoint":
                            trainingPoint.Text = terms[1];
                            break;
                    }
                }
            }
            fs.Close();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings.ShowDialog();
            StreamWriter writer = new StreamWriter(saveSettings.OpenFile());
            writer.WriteLine("networkmode:{0}", networkDropDown.SelectedItem);
            writer.WriteLine("userbinarylocation:{0}", binaryLocation.Text);
            writer.WriteLine("userbinaryclassname:{0}", className.Text);
            writer.WriteLine("userbinaryname:{0}", binaryName.Text);
            writer.WriteLine("useuserbinary:{0}", useBinaryCheckBox.Checked);
            writer.WriteLine("inputlayer:{0}", defaultInput.Text);
            writer.WriteLine("node:{0}", defaultNode.Text);
            writer.WriteLine("nodelayer:{0}", defaultHidden.Text);
            writer.WriteLine("outputlayer:{0}", defaultOutput.Text);
            writer.WriteLine("enabletiming:{0}", enableTiming.Checked);
            writer.WriteLine("trainingtype:{0}", trainingType.SelectedItem);
            writer.WriteLine("trainingmeasurement:{0}", trainingMeasure.SelectedItem);
            writer.WriteLine("trainingpoint:{0}", trainingPoint.Text);
            writer.Close();
        }
    }
}
