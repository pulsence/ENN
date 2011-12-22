namespace ENN.SettingsBuilder
{
    partial class MainForm
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
            this.networkModeLabel = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryLocationLabel = new System.Windows.Forms.Label();
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.nodeLabel = new System.Windows.Forms.Label();
            this.trainTypeLabel = new System.Windows.Forms.Label();
            this.trainPointLabel = new System.Windows.Forms.Label();
            this.trainMeasureLabel = new System.Windows.Forms.Label();
            this.binaryNameLabel = new System.Windows.Forms.Label();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.useBinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.networkDropDown = new System.Windows.Forms.ComboBox();
            this.binaryLocation = new System.Windows.Forms.TextBox();
            this.chooseBinary = new System.Windows.Forms.OpenFileDialog();
            this.binaryFileButton = new System.Windows.Forms.Button();
            this.className = new System.Windows.Forms.TextBox();
            this.binaryName = new System.Windows.Forms.TextBox();
            this.trainingType = new System.Windows.Forms.ComboBox();
            this.trainingMeasure = new System.Windows.Forms.ComboBox();
            this.trainingPoint = new System.Windows.Forms.TextBox();
            this.defaultInput = new System.Windows.Forms.TextBox();
            this.defaultNode = new System.Windows.Forms.TextBox();
            this.defaultOutput = new System.Windows.Forms.TextBox();
            this.defaultHidden = new System.Windows.Forms.TextBox();
            this.openSettings = new System.Windows.Forms.OpenFileDialog();
            this.saveSettings = new System.Windows.Forms.SaveFileDialog();
            this.enableTiming = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkModeLabel
            // 
            this.networkModeLabel.AutoSize = true;
            this.networkModeLabel.Location = new System.Drawing.Point(40, 33);
            this.networkModeLabel.Name = "networkModeLabel";
            this.networkModeLabel.Size = new System.Drawing.Size(77, 13);
            this.networkModeLabel.TabIndex = 0;
            this.networkModeLabel.Text = "Network Mode";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSubMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(456, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileSubMenu
            // 
            this.fileSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem,
            this.saveMenuItem});
            this.fileSubMenu.Name = "fileSubMenu";
            this.fileSubMenu.Size = new System.Drawing.Size(37, 20);
            this.fileSubMenu.Text = "File";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadMenuItem.Text = "Load";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // binaryLocationLabel
            // 
            this.binaryLocationLabel.AutoSize = true;
            this.binaryLocationLabel.Location = new System.Drawing.Point(12, 67);
            this.binaryLocationLabel.Name = "binaryLocationLabel";
            this.binaryLocationLabel.Size = new System.Drawing.Size(105, 13);
            this.binaryLocationLabel.TabIndex = 2;
            this.binaryLocationLabel.Text = "User Binary Location";
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.Location = new System.Drawing.Point(234, 151);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Size = new System.Drawing.Size(107, 13);
            this.hiddenLabel.TabIndex = 3;
            this.hiddenLabel.Text = "Default Hidden Layer";
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(244, 125);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(97, 13);
            this.inputLabel.TabIndex = 4;
            this.inputLabel.Text = "Default Input Layer";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(236, 177);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(105, 13);
            this.outputLabel.TabIndex = 5;
            this.outputLabel.Text = "Default Output Layer";
            // 
            // nodeLabel
            // 
            this.nodeLabel.AutoSize = true;
            this.nodeLabel.Location = new System.Drawing.Point(271, 203);
            this.nodeLabel.Name = "nodeLabel";
            this.nodeLabel.Size = new System.Drawing.Size(70, 13);
            this.nodeLabel.TabIndex = 7;
            this.nodeLabel.Text = "Default Node";
            // 
            // trainTypeLabel
            // 
            this.trainTypeLabel.AutoSize = true;
            this.trainTypeLabel.Location = new System.Drawing.Point(269, 33);
            this.trainTypeLabel.Name = "trainTypeLabel";
            this.trainTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.trainTypeLabel.TabIndex = 8;
            this.trainTypeLabel.Text = "Training Type";
            // 
            // trainPointLabel
            // 
            this.trainPointLabel.AutoSize = true;
            this.trainPointLabel.Location = new System.Drawing.Point(269, 87);
            this.trainPointLabel.Name = "trainPointLabel";
            this.trainPointLabel.Size = new System.Drawing.Size(72, 13);
            this.trainPointLabel.TabIndex = 9;
            this.trainPointLabel.Text = "Training Point";
            // 
            // trainMeasureLabel
            // 
            this.trainMeasureLabel.AutoSize = true;
            this.trainMeasureLabel.Location = new System.Drawing.Point(252, 60);
            this.trainMeasureLabel.Name = "trainMeasureLabel";
            this.trainMeasureLabel.Size = new System.Drawing.Size(89, 13);
            this.trainMeasureLabel.TabIndex = 10;
            this.trainMeasureLabel.Text = "Training Measure";
            // 
            // binaryNameLabel
            // 
            this.binaryNameLabel.AutoSize = true;
            this.binaryNameLabel.Location = new System.Drawing.Point(50, 145);
            this.binaryNameLabel.Name = "binaryNameLabel";
            this.binaryNameLabel.Size = new System.Drawing.Size(67, 13);
            this.binaryNameLabel.TabIndex = 12;
            this.binaryNameLabel.Text = "Binary Name";
            // 
            // classNameLabel
            // 
            this.classNameLabel.AutoSize = true;
            this.classNameLabel.Location = new System.Drawing.Point(35, 119);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(82, 13);
            this.classNameLabel.TabIndex = 13;
            this.classNameLabel.Text = "Full Class Name";
            // 
            // useBinaryCheckBox
            // 
            this.useBinaryCheckBox.AutoSize = true;
            this.useBinaryCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useBinaryCheckBox.Location = new System.Drawing.Point(53, 171);
            this.useBinaryCheckBox.Name = "useBinaryCheckBox";
            this.useBinaryCheckBox.Size = new System.Drawing.Size(85, 17);
            this.useBinaryCheckBox.TabIndex = 14;
            this.useBinaryCheckBox.Text = "Use Binaries";
            this.useBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // networkDropDown
            // 
            this.networkDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkDropDown.FormattingEnabled = true;
            this.networkDropDown.Items.AddRange(new object[] {
            "computational",
            "training"});
            this.networkDropDown.Location = new System.Drawing.Point(123, 30);
            this.networkDropDown.Name = "networkDropDown";
            this.networkDropDown.Size = new System.Drawing.Size(100, 21);
            this.networkDropDown.TabIndex = 15;
            // 
            // binaryLocation
            // 
            this.binaryLocation.Location = new System.Drawing.Point(123, 64);
            this.binaryLocation.Name = "binaryLocation";
            this.binaryLocation.Size = new System.Drawing.Size(100, 20);
            this.binaryLocation.TabIndex = 16;
            this.binaryLocation.Text = "UserBin/";
            // 
            // chooseBinary
            // 
            this.chooseBinary.DefaultExt = "dll";
            this.chooseBinary.InitialDirectory = "UserBin/";
            this.chooseBinary.Title = "Choose Binary";
            // 
            // binaryFileButton
            // 
            this.binaryFileButton.Location = new System.Drawing.Point(123, 90);
            this.binaryFileButton.Name = "binaryFileButton";
            this.binaryFileButton.Size = new System.Drawing.Size(75, 23);
            this.binaryFileButton.TabIndex = 17;
            this.binaryFileButton.Text = "Choose File";
            this.binaryFileButton.UseVisualStyleBackColor = true;
            this.binaryFileButton.Click += new System.EventHandler(this.binaryFileButton_Click);
            // 
            // className
            // 
            this.className.Location = new System.Drawing.Point(123, 116);
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(100, 20);
            this.className.TabIndex = 18;
            // 
            // binaryName
            // 
            this.binaryName.Location = new System.Drawing.Point(123, 142);
            this.binaryName.Name = "binaryName";
            this.binaryName.Size = new System.Drawing.Size(100, 20);
            this.binaryName.TabIndex = 19;
            // 
            // trainingType
            // 
            this.trainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainingType.FormattingEnabled = true;
            this.trainingType.Items.AddRange(new object[] {
            "traditional",
            "evolving"});
            this.trainingType.Location = new System.Drawing.Point(347, 30);
            this.trainingType.Name = "trainingType";
            this.trainingType.Size = new System.Drawing.Size(100, 21);
            this.trainingType.TabIndex = 20;
            // 
            // trainingMeasure
            // 
            this.trainingMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainingMeasure.FormattingEnabled = true;
            this.trainingMeasure.Items.AddRange(new object[] {
            "iterations",
            "accuracy"});
            this.trainingMeasure.Location = new System.Drawing.Point(347, 57);
            this.trainingMeasure.Name = "trainingMeasure";
            this.trainingMeasure.Size = new System.Drawing.Size(100, 21);
            this.trainingMeasure.TabIndex = 21;
            // 
            // trainingPoint
            // 
            this.trainingPoint.Location = new System.Drawing.Point(347, 84);
            this.trainingPoint.Name = "trainingPoint";
            this.trainingPoint.Size = new System.Drawing.Size(100, 20);
            this.trainingPoint.TabIndex = 22;
            // 
            // defaultInput
            // 
            this.defaultInput.Location = new System.Drawing.Point(347, 122);
            this.defaultInput.Name = "defaultInput";
            this.defaultInput.Size = new System.Drawing.Size(100, 20);
            this.defaultInput.TabIndex = 23;
            // 
            // defaultNode
            // 
            this.defaultNode.Location = new System.Drawing.Point(347, 200);
            this.defaultNode.Name = "defaultNode";
            this.defaultNode.Size = new System.Drawing.Size(100, 20);
            this.defaultNode.TabIndex = 24;
            // 
            // defaultOutput
            // 
            this.defaultOutput.Location = new System.Drawing.Point(347, 174);
            this.defaultOutput.Name = "defaultOutput";
            this.defaultOutput.Size = new System.Drawing.Size(100, 20);
            this.defaultOutput.TabIndex = 25;
            // 
            // defaultHidden
            // 
            this.defaultHidden.Location = new System.Drawing.Point(347, 148);
            this.defaultHidden.Name = "defaultHidden";
            this.defaultHidden.Size = new System.Drawing.Size(100, 20);
            this.defaultHidden.TabIndex = 26;
            // 
            // openSettings
            // 
            this.openSettings.DefaultExt = "nns";
            this.openSettings.InitialDirectory = "Settings/";
            this.openSettings.Title = "Open Settings";
            // 
            // saveSettings
            // 
            this.saveSettings.DefaultExt = "nns";
            this.saveSettings.InitialDirectory = "Settings/";
            this.saveSettings.Title = "Save Settings";
            // 
            // enableTiming
            // 
            this.enableTiming.AutoSize = true;
            this.enableTiming.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.enableTiming.Location = new System.Drawing.Point(45, 194);
            this.enableTiming.Name = "enableTiming";
            this.enableTiming.Size = new System.Drawing.Size(93, 17);
            this.enableTiming.TabIndex = 27;
            this.enableTiming.Text = "Enable Timing";
            this.enableTiming.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 224);
            this.Controls.Add(this.enableTiming);
            this.Controls.Add(this.defaultHidden);
            this.Controls.Add(this.defaultOutput);
            this.Controls.Add(this.defaultNode);
            this.Controls.Add(this.defaultInput);
            this.Controls.Add(this.trainingPoint);
            this.Controls.Add(this.trainingMeasure);
            this.Controls.Add(this.trainingType);
            this.Controls.Add(this.binaryName);
            this.Controls.Add(this.className);
            this.Controls.Add(this.binaryFileButton);
            this.Controls.Add(this.binaryLocation);
            this.Controls.Add(this.networkDropDown);
            this.Controls.Add(this.useBinaryCheckBox);
            this.Controls.Add(this.classNameLabel);
            this.Controls.Add(this.binaryNameLabel);
            this.Controls.Add(this.trainMeasureLabel);
            this.Controls.Add(this.trainPointLabel);
            this.Controls.Add(this.trainTypeLabel);
            this.Controls.Add(this.nodeLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.hiddenLabel);
            this.Controls.Add(this.binaryLocationLabel);
            this.Controls.Add(this.networkModeLabel);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Settings Builder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label networkModeLabel;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSubMenu;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.Label binaryLocationLabel;
        private System.Windows.Forms.Label hiddenLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label nodeLabel;
        private System.Windows.Forms.Label trainTypeLabel;
        private System.Windows.Forms.Label trainPointLabel;
        private System.Windows.Forms.Label trainMeasureLabel;
        private System.Windows.Forms.Label binaryNameLabel;
        private System.Windows.Forms.Label classNameLabel;
        private System.Windows.Forms.CheckBox useBinaryCheckBox;
        private System.Windows.Forms.ComboBox networkDropDown;
        private System.Windows.Forms.TextBox binaryLocation;
        private System.Windows.Forms.OpenFileDialog chooseBinary;
        private System.Windows.Forms.Button binaryFileButton;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.TextBox binaryName;
        private System.Windows.Forms.ComboBox trainingType;
        private System.Windows.Forms.ComboBox trainingMeasure;
        private System.Windows.Forms.TextBox trainingPoint;
        private System.Windows.Forms.TextBox defaultInput;
        private System.Windows.Forms.TextBox defaultNode;
        private System.Windows.Forms.TextBox defaultOutput;
        private System.Windows.Forms.TextBox defaultHidden;
        private System.Windows.Forms.OpenFileDialog openSettings;
        private System.Windows.Forms.SaveFileDialog saveSettings;
        private System.Windows.Forms.CheckBox enableTiming;
    }
}

