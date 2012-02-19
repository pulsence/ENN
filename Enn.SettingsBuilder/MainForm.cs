/*This file is part of ENN.
* Copyright (C) 2012  Tim Eck II
* 
* ENN is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as
* published by the Free Software Foundation, version 3 of the License.
* 
* ENN is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public License
* along with ENN.  If not, see <http://www.gnu.org/licenses/>.*/using System;

using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using ENN.Framework;
using ENN.Framework.Tools;


namespace ENN.SettingsBuilder
{
    public partial class MainForm : Form
    {
        NetworkSettings settings;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            settings = new NetworkSettings();
            networkMode.SelectedIndex = 0;
            networkType.SelectedIndex = 0;
        }

		/// <summary>
		/// Handles the click event for the binaryFileButton. Adds a user binary file
		/// to the form.
		/// </summary>
        private void binaryFileButton_Click(object sender, EventArgs e)
        {
            chooseBinary.ShowDialog();
            binaryLocation.Text = chooseBinary.FileName;
            Assembly assembly = Assembly.LoadFrom(binaryLocation.Text);
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetInterface("IUserObjectFactory") != null)
                {
                    className.Text = type.FullName;
                    binaryName.Text = type.Name;
                    useBinary.Checked = true;
                    break;
                }
            }
        }

		/// <summary>
		/// Loads a settings file and then populates the form fields.
		/// </summary>
        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            openSettings.ShowDialog();
            try
            {
                settings = Settings.Load(openSettings.FileName);
                if (settings.Mode == NetworkMode.Computational)
                {
                    networkMode.SelectedIndex = 1;
                }
                else
                {
                    networkMode.SelectedIndex = 0;
                }

                if (settings.NetworkType == NetworkType.Traditional)
                {
                    networkType.SelectedIndex = 0;
                }
                else
                {
                    networkType.SelectedIndex = 1;
                }

                binaryLocation.Text = settings.UserBinaryLocation;
                className.Text = settings.UserBinaryClassName;
                binaryName.Text = settings.UserBinaryName;
                useBinary.Checked = settings.UseUserBinaries;

                defaultInput.Text = settings.DefaultInputLayer;
                defaultNode.Text = settings.DefaultNode;
                defaultHidden.Text = settings.DefaultHiddenLayer;
                defaultOutput.Text = settings.DefaultOutputLayer;

                enableTiming.Checked = settings.EnableTiming;

                trainingAccuracy.Text = settings.TrainingAccuracy.ToString();
                trainingIterations.Text = settings.TrainingIterations.ToString();
                trainingPool.Text = settings.TraininPool.ToString();

                customParameters.Text = "";
                int i = 0;
                string[] lines = new string[settings.Other.Count];
                foreach (KeyValuePair<string, string> key in settings.Other)
                {
                    lines[i] = key.Key + ":" + key.Value;
                    i++;
                }
                customParameters.Lines = lines;
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be loaded.");
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("The settings file was not properly formated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some unknown error that occured while loading the file.");
            }
        }

		/// <summary>
		/// Maps the form fields to the settings object and then saves the object to disk.
		/// </summary>
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (networkMode.SelectedIndex == 0)
                settings.Mode = NetworkMode.Computational;
            else
                settings.Mode = NetworkMode.Training;

            if (networkType.SelectedIndex == 0)
                settings.NetworkType = NetworkType.Traditional;
            else
                settings.NetworkType = NetworkType.Evolving;

            settings.UserBinaryName = binaryName.Text;
            settings.UserBinaryLocation = binaryLocation.Text;
            settings.UserBinaryClassName = className.Text;
            settings.UseUserBinaries = useBinary.Checked;

            settings.DefaultInputLayer = defaultInput.Text;
            settings.DefaultHiddenLayer = defaultHidden.Text;
            settings.DefaultOutputLayer = defaultOutput.Text;
            settings.DefaultNode = defaultNode.Text;
            settings.DefaultFactory = defaultFactory.Text;

            settings.EnableTiming = enableTiming.Checked;

            float tempF = 0;
            float.TryParse(trainingAccuracy.Text, out tempF);
            settings.TrainingAccuracy = tempF;

            int tempI = 0;
            int.TryParse(trainingIterations.Text, out tempI);
            settings.TrainingIterations = tempI;

            int.TryParse(trainingPool.Text, out tempI);
            settings.TraininPool = tempI;

            string[] line;
            foreach (string s in customParameters.Lines)
            {
                line = s.Split(':');
                if (line.Length != 2) continue;

                line[0] = line[0].Trim();
                line[1] = line[1].Trim();

                if (settings.Other.ContainsKey(line[0]))
                    settings.Other[line[0]] = line[1];
                else
                    settings.Other.Add(line[0], line[1]);
            }

            saveSettings.ShowDialog();
            try
            {
                Settings.Save(settings, saveSettings.FileName);
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some unknown error that occured while saving the file.");
            }
        }
    }
}
