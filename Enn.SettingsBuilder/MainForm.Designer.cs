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
            this.trainIterationLabel = new System.Windows.Forms.Label();
            this.trainPoolLabel = new System.Windows.Forms.Label();
            this.trainAccuracyLabel = new System.Windows.Forms.Label();
            this.binaryNameLabel = new System.Windows.Forms.Label();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.useBinary = new System.Windows.Forms.CheckBox();
            this.networkMode = new System.Windows.Forms.ComboBox();
            this.binaryLocation = new System.Windows.Forms.TextBox();
            this.chooseBinary = new System.Windows.Forms.OpenFileDialog();
            this.binaryFileButton = new System.Windows.Forms.Button();
            this.className = new System.Windows.Forms.TextBox();
            this.binaryName = new System.Windows.Forms.TextBox();
            this.trainingPool = new System.Windows.Forms.TextBox();
            this.defaultInput = new System.Windows.Forms.TextBox();
            this.defaultNode = new System.Windows.Forms.TextBox();
            this.defaultOutput = new System.Windows.Forms.TextBox();
            this.defaultHidden = new System.Windows.Forms.TextBox();
            this.openSettings = new System.Windows.Forms.OpenFileDialog();
            this.saveSettings = new System.Windows.Forms.SaveFileDialog();
            this.enableTiming = new System.Windows.Forms.CheckBox();
            this.trainingIterations = new System.Windows.Forms.TextBox();
            this.trainingAccuracy = new System.Windows.Forms.TextBox();
            this.networkTypeLabel = new System.Windows.Forms.Label();
            this.networkType = new System.Windows.Forms.ComboBox();
            this.factoryLabel = new System.Windows.Forms.Label();
            this.defaultFactory = new System.Windows.Forms.TextBox();
            this.customParameters = new System.Windows.Forms.TextBox();
            this.customLabel = new System.Windows.Forms.Label();
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
            this.mainMenu.Size = new System.Drawing.Size(625, 24);
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
            this.binaryLocationLabel.Location = new System.Drawing.Point(12, 91);
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
            // trainIterationLabel
            // 
            this.trainIterationLabel.AutoSize = true;
            this.trainIterationLabel.Location = new System.Drawing.Point(250, 30);
            this.trainIterationLabel.Name = "trainIterationLabel";
            this.trainIterationLabel.Size = new System.Drawing.Size(91, 13);
            this.trainIterationLabel.TabIndex = 8;
            this.trainIterationLabel.Text = "Training Iterations";
            // 
            // trainPoolLabel
            // 
            this.trainPoolLabel.AutoSize = true;
            this.trainPoolLabel.Location = new System.Drawing.Point(269, 87);
            this.trainPoolLabel.Name = "trainPoolLabel";
            this.trainPoolLabel.Size = new System.Drawing.Size(69, 13);
            this.trainPoolLabel.TabIndex = 9;
            this.trainPoolLabel.Text = "Training Pool";
            // 
            // trainAccuracyLabel
            // 
            this.trainAccuracyLabel.AutoSize = true;
            this.trainAccuracyLabel.Location = new System.Drawing.Point(248, 60);
            this.trainAccuracyLabel.Name = "trainAccuracyLabel";
            this.trainAccuracyLabel.Size = new System.Drawing.Size(93, 13);
            this.trainAccuracyLabel.TabIndex = 10;
            this.trainAccuracyLabel.Text = "Training Accuracy";
            // 
            // binaryNameLabel
            // 
            this.binaryNameLabel.AutoSize = true;
            this.binaryNameLabel.Location = new System.Drawing.Point(50, 169);
            this.binaryNameLabel.Name = "binaryNameLabel";
            this.binaryNameLabel.Size = new System.Drawing.Size(67, 13);
            this.binaryNameLabel.TabIndex = 12;
            this.binaryNameLabel.Text = "Binary Name";
            // 
            // classNameLabel
            // 
            this.classNameLabel.AutoSize = true;
            this.classNameLabel.Location = new System.Drawing.Point(35, 143);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(82, 13);
            this.classNameLabel.TabIndex = 13;
            this.classNameLabel.Text = "Full Class Name";
            // 
            // useBinary
            // 
            this.useBinary.AutoSize = true;
            this.useBinary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useBinary.Checked = true;
            this.useBinary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useBinary.Location = new System.Drawing.Point(53, 195);
            this.useBinary.Name = "useBinary";
            this.useBinary.Size = new System.Drawing.Size(85, 17);
            this.useBinary.TabIndex = 14;
            this.useBinary.Text = "Use Binaries";
            this.useBinary.UseVisualStyleBackColor = true;
            // 
            // networkMode
            // 
            this.networkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkMode.FormattingEnabled = true;
            this.networkMode.Items.AddRange(new object[] {
            "computational",
            "training"});
            this.networkMode.Location = new System.Drawing.Point(123, 30);
            this.networkMode.Name = "networkMode";
            this.networkMode.Size = new System.Drawing.Size(100, 21);
            this.networkMode.TabIndex = 15;
            // 
            // binaryLocation
            // 
            this.binaryLocation.Location = new System.Drawing.Point(123, 88);
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
            this.binaryFileButton.Location = new System.Drawing.Point(123, 114);
            this.binaryFileButton.Name = "binaryFileButton";
            this.binaryFileButton.Size = new System.Drawing.Size(75, 23);
            this.binaryFileButton.TabIndex = 17;
            this.binaryFileButton.Text = "Choose File";
            this.binaryFileButton.UseVisualStyleBackColor = true;
            this.binaryFileButton.Click += new System.EventHandler(this.binaryFileButton_Click);
            // 
            // className
            // 
            this.className.Location = new System.Drawing.Point(123, 140);
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(100, 20);
            this.className.TabIndex = 18;
            // 
            // binaryName
            // 
            this.binaryName.Location = new System.Drawing.Point(123, 166);
            this.binaryName.Name = "binaryName";
            this.binaryName.Size = new System.Drawing.Size(100, 20);
            this.binaryName.TabIndex = 19;
            // 
            // trainingPool
            // 
            this.trainingPool.Location = new System.Drawing.Point(347, 84);
            this.trainingPool.Name = "trainingPool";
            this.trainingPool.Size = new System.Drawing.Size(100, 20);
            this.trainingPool.TabIndex = 22;
            this.trainingPool.Text = "100";
            // 
            // defaultInput
            // 
            this.defaultInput.AutoCompleteCustomSource.AddRange(new string[] {
            "BasicInputLayer"});
            this.defaultInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.defaultInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.defaultInput.Location = new System.Drawing.Point(347, 122);
            this.defaultInput.Name = "defaultInput";
            this.defaultInput.Size = new System.Drawing.Size(100, 20);
            this.defaultInput.TabIndex = 23;
            this.defaultInput.Text = "BasicInputLayer";
            // 
            // defaultNode
            // 
            this.defaultNode.AutoCompleteCustomSource.AddRange(new string[] {
            "BasicNode",
            "CustomizableNode"});
            this.defaultNode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.defaultNode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.defaultNode.Location = new System.Drawing.Point(347, 200);
            this.defaultNode.Name = "defaultNode";
            this.defaultNode.Size = new System.Drawing.Size(100, 20);
            this.defaultNode.TabIndex = 24;
            this.defaultNode.Text = "BasicNode";
            // 
            // defaultOutput
            // 
            this.defaultOutput.AutoCompleteCustomSource.AddRange(new string[] {
            "BasicOutputLayer"});
            this.defaultOutput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.defaultOutput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.defaultOutput.Location = new System.Drawing.Point(347, 174);
            this.defaultOutput.Name = "defaultOutput";
            this.defaultOutput.Size = new System.Drawing.Size(100, 20);
            this.defaultOutput.TabIndex = 25;
            this.defaultOutput.Text = "BasicOutputLayer";
            // 
            // defaultHidden
            // 
            this.defaultHidden.AutoCompleteCustomSource.AddRange(new string[] {
            "BasicLayer",
            "ThreadedHiddenLayer"});
            this.defaultHidden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.defaultHidden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.defaultHidden.Location = new System.Drawing.Point(347, 148);
            this.defaultHidden.Name = "defaultHidden";
            this.defaultHidden.Size = new System.Drawing.Size(100, 20);
            this.defaultHidden.TabIndex = 26;
            this.defaultHidden.Text = "ThreadedHiddenLayer";
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
            this.enableTiming.Location = new System.Drawing.Point(45, 218);
            this.enableTiming.Name = "enableTiming";
            this.enableTiming.Size = new System.Drawing.Size(93, 17);
            this.enableTiming.TabIndex = 27;
            this.enableTiming.Text = "Enable Timing";
            this.enableTiming.UseVisualStyleBackColor = true;
            // 
            // trainingIterations
            // 
            this.trainingIterations.Location = new System.Drawing.Point(347, 32);
            this.trainingIterations.Name = "trainingIterations";
            this.trainingIterations.Size = new System.Drawing.Size(100, 20);
            this.trainingIterations.TabIndex = 28;
            this.trainingIterations.Text = "10000";
            // 
            // trainingAccuracy
            // 
            this.trainingAccuracy.Location = new System.Drawing.Point(347, 58);
            this.trainingAccuracy.Name = "trainingAccuracy";
            this.trainingAccuracy.Size = new System.Drawing.Size(100, 20);
            this.trainingAccuracy.TabIndex = 29;
            this.trainingAccuracy.Text = "0.9";
            // 
            // networkTypeLabel
            // 
            this.networkTypeLabel.AutoSize = true;
            this.networkTypeLabel.Location = new System.Drawing.Point(43, 58);
            this.networkTypeLabel.Name = "networkTypeLabel";
            this.networkTypeLabel.Size = new System.Drawing.Size(74, 13);
            this.networkTypeLabel.TabIndex = 30;
            this.networkTypeLabel.Text = "Network Type";
            // 
            // networkType
            // 
            this.networkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkType.FormattingEnabled = true;
            this.networkType.Items.AddRange(new object[] {
            "traditional",
            "evolutionary"});
            this.networkType.Location = new System.Drawing.Point(123, 57);
            this.networkType.Name = "networkType";
            this.networkType.Size = new System.Drawing.Size(100, 21);
            this.networkType.TabIndex = 31;
            // 
            // factoryLabel
            // 
            this.factoryLabel.AutoSize = true;
            this.factoryLabel.Location = new System.Drawing.Point(262, 230);
            this.factoryLabel.Name = "factoryLabel";
            this.factoryLabel.Size = new System.Drawing.Size(79, 13);
            this.factoryLabel.TabIndex = 32;
            this.factoryLabel.Text = "Default Factory";
            // 
            // defaultFactory
            // 
            this.defaultFactory.AutoCompleteCustomSource.AddRange(new string[] {
            "standard"});
            this.defaultFactory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.defaultFactory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.defaultFactory.Location = new System.Drawing.Point(347, 227);
            this.defaultFactory.Name = "defaultFactory";
            this.defaultFactory.Size = new System.Drawing.Size(100, 20);
            this.defaultFactory.TabIndex = 33;
            this.defaultFactory.Text = "standard";
            // 
            // customParameters
            // 
            this.customParameters.Location = new System.Drawing.Point(456, 46);
            this.customParameters.Multiline = true;
            this.customParameters.Name = "customParameters";
            this.customParameters.Size = new System.Drawing.Size(157, 201);
            this.customParameters.TabIndex = 34;
            // 
            // customLabel
            // 
            this.customLabel.AutoSize = true;
            this.customLabel.Location = new System.Drawing.Point(453, 30);
            this.customLabel.Name = "customLabel";
            this.customLabel.Size = new System.Drawing.Size(98, 13);
            this.customLabel.TabIndex = 35;
            this.customLabel.Text = "Custom Parameters";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 255);
            this.Controls.Add(this.customLabel);
            this.Controls.Add(this.customParameters);
            this.Controls.Add(this.defaultFactory);
            this.Controls.Add(this.factoryLabel);
            this.Controls.Add(this.networkType);
            this.Controls.Add(this.networkTypeLabel);
            this.Controls.Add(this.trainingAccuracy);
            this.Controls.Add(this.trainingIterations);
            this.Controls.Add(this.enableTiming);
            this.Controls.Add(this.defaultHidden);
            this.Controls.Add(this.defaultOutput);
            this.Controls.Add(this.defaultNode);
            this.Controls.Add(this.defaultInput);
            this.Controls.Add(this.trainingPool);
            this.Controls.Add(this.binaryName);
            this.Controls.Add(this.className);
            this.Controls.Add(this.binaryFileButton);
            this.Controls.Add(this.binaryLocation);
            this.Controls.Add(this.networkMode);
            this.Controls.Add(this.useBinary);
            this.Controls.Add(this.classNameLabel);
            this.Controls.Add(this.binaryNameLabel);
            this.Controls.Add(this.trainAccuracyLabel);
            this.Controls.Add(this.trainPoolLabel);
            this.Controls.Add(this.trainIterationLabel);
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
        private System.Windows.Forms.Label trainIterationLabel;
        private System.Windows.Forms.Label trainPoolLabel;
        private System.Windows.Forms.Label trainAccuracyLabel;
        private System.Windows.Forms.Label binaryNameLabel;
        private System.Windows.Forms.Label classNameLabel;
        private System.Windows.Forms.CheckBox useBinary;
        private System.Windows.Forms.ComboBox networkMode;
        private System.Windows.Forms.TextBox binaryLocation;
        private System.Windows.Forms.OpenFileDialog chooseBinary;
        private System.Windows.Forms.Button binaryFileButton;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.TextBox binaryName;
        private System.Windows.Forms.TextBox trainingPool;
        private System.Windows.Forms.TextBox defaultInput;
        private System.Windows.Forms.TextBox defaultNode;
        private System.Windows.Forms.TextBox defaultOutput;
        private System.Windows.Forms.TextBox defaultHidden;
        private System.Windows.Forms.OpenFileDialog openSettings;
        private System.Windows.Forms.SaveFileDialog saveSettings;
        private System.Windows.Forms.CheckBox enableTiming;
        private System.Windows.Forms.TextBox trainingIterations;
        private System.Windows.Forms.TextBox trainingAccuracy;
        private System.Windows.Forms.Label networkTypeLabel;
        private System.Windows.Forms.ComboBox networkType;
        private System.Windows.Forms.Label factoryLabel;
        private System.Windows.Forms.TextBox defaultFactory;
        private System.Windows.Forms.TextBox customParameters;
        private System.Windows.Forms.Label customLabel;
    }
}

