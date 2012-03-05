namespace ENN.TopologyBuilder
{
	partial class LoadUserBinaries
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
			this.fileLabel = new System.Windows.Forms.Label();
			this.fileLocation = new System.Windows.Forms.TextBox();
			this.openBinary = new System.Windows.Forms.OpenFileDialog();
			this.findFile = new System.Windows.Forms.Button();
			this.loadFile = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.factoryNameLabel = new System.Windows.Forms.Label();
			this.factoryName = new System.Windows.Forms.TextBox();
			this.inputLabel = new System.Windows.Forms.Label();
			this.hiddenLayersLabel = new System.Windows.Forms.Label();
			this.outputLayerLabel = new System.Windows.Forms.Label();
			this.postProcessorLabel = new System.Windows.Forms.Label();
			this.preProcessorLabel = new System.Windows.Forms.Label();
			this.nodeLabel = new System.Windows.Forms.Label();
			this.input = new System.Windows.Forms.ComboBox();
			this.hidden = new System.Windows.Forms.ComboBox();
			this.preProcessor = new System.Windows.Forms.ComboBox();
			this.postProcessor = new System.Windows.Forms.ComboBox();
			this.node = new System.Windows.Forms.ComboBox();
			this.output = new System.Windows.Forms.ComboBox();
			this.clear = new System.Windows.Forms.Button();
			this.trainingAlgorithmLabel = new System.Windows.Forms.Label();
			this.trainingAlgorithm = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// fileLabel
			// 
			this.fileLabel.AutoSize = true;
			this.fileLabel.Location = new System.Drawing.Point(12, 9);
			this.fileLabel.Name = "fileLabel";
			this.fileLabel.Size = new System.Drawing.Size(23, 13);
			this.fileLabel.TabIndex = 0;
			this.fileLabel.Text = "File";
			// 
			// fileLocation
			// 
			this.fileLocation.Location = new System.Drawing.Point(41, 6);
			this.fileLocation.Name = "fileLocation";
			this.fileLocation.Size = new System.Drawing.Size(127, 20);
			this.fileLocation.TabIndex = 1;
			// 
			// openBinary
			// 
			this.openBinary.DefaultExt = "dll";
			// 
			// findFile
			// 
			this.findFile.Location = new System.Drawing.Point(12, 32);
			this.findFile.Name = "findFile";
			this.findFile.Size = new System.Drawing.Size(75, 23);
			this.findFile.TabIndex = 2;
			this.findFile.Text = "Choose File";
			this.findFile.UseVisualStyleBackColor = true;
			this.findFile.Click += new System.EventHandler(this.ChooseFile);
			// 
			// loadFile
			// 
			this.loadFile.Location = new System.Drawing.Point(93, 32);
			this.loadFile.Name = "loadFile";
			this.loadFile.Size = new System.Drawing.Size(75, 23);
			this.loadFile.TabIndex = 3;
			this.loadFile.Text = "Load File";
			this.loadFile.UseVisualStyleBackColor = true;
			this.loadFile.Click += new System.EventHandler(this.LoadFile);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(413, 12);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 4;
			this.addButton.Text = "Add";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddDataTypes);
			// 
			// factoryNameLabel
			// 
			this.factoryNameLabel.AutoSize = true;
			this.factoryNameLabel.Location = new System.Drawing.Point(9, 78);
			this.factoryNameLabel.Name = "factoryNameLabel";
			this.factoryNameLabel.Size = new System.Drawing.Size(107, 13);
			this.factoryNameLabel.TabIndex = 5;
			this.factoryNameLabel.Text = "Object Factory Name";
			// 
			// factoryName
			// 
			this.factoryName.Location = new System.Drawing.Point(122, 75);
			this.factoryName.Name = "factoryName";
			this.factoryName.Size = new System.Drawing.Size(121, 20);
			this.factoryName.TabIndex = 6;
			// 
			// inputLabel
			// 
			this.inputLabel.AutoSize = true;
			this.inputLabel.Location = new System.Drawing.Point(51, 104);
			this.inputLabel.Name = "inputLabel";
			this.inputLabel.Size = new System.Drawing.Size(65, 13);
			this.inputLabel.TabIndex = 7;
			this.inputLabel.Text = "Input Layers";
			// 
			// hiddenLayersLabel
			// 
			this.hiddenLayersLabel.AutoSize = true;
			this.hiddenLayersLabel.Location = new System.Drawing.Point(41, 132);
			this.hiddenLayersLabel.Name = "hiddenLayersLabel";
			this.hiddenLayersLabel.Size = new System.Drawing.Size(75, 13);
			this.hiddenLayersLabel.TabIndex = 8;
			this.hiddenLayersLabel.Text = "Hidden Layers";
			// 
			// outputLayerLabel
			// 
			this.outputLayerLabel.AutoSize = true;
			this.outputLayerLabel.Location = new System.Drawing.Point(43, 158);
			this.outputLayerLabel.Name = "outputLayerLabel";
			this.outputLayerLabel.Size = new System.Drawing.Size(73, 13);
			this.outputLayerLabel.TabIndex = 9;
			this.outputLayerLabel.Text = "Output Layers";
			// 
			// postProcessorLabel
			// 
			this.postProcessorLabel.AutoSize = true;
			this.postProcessorLabel.Location = new System.Drawing.Point(278, 131);
			this.postProcessorLabel.Name = "postProcessorLabel";
			this.postProcessorLabel.Size = new System.Drawing.Size(83, 13);
			this.postProcessorLabel.TabIndex = 11;
			this.postProcessorLabel.Text = "Post Processors";
			// 
			// preProcessorLabel
			// 
			this.preProcessorLabel.AutoSize = true;
			this.preProcessorLabel.Location = new System.Drawing.Point(283, 104);
			this.preProcessorLabel.Name = "preProcessorLabel";
			this.preProcessorLabel.Size = new System.Drawing.Size(78, 13);
			this.preProcessorLabel.TabIndex = 12;
			this.preProcessorLabel.Text = "Pre Processors";
			// 
			// nodeLabel
			// 
			this.nodeLabel.AutoSize = true;
			this.nodeLabel.Location = new System.Drawing.Point(323, 77);
			this.nodeLabel.Name = "nodeLabel";
			this.nodeLabel.Size = new System.Drawing.Size(38, 13);
			this.nodeLabel.TabIndex = 13;
			this.nodeLabel.Text = "Nodes";
			// 
			// input
			// 
			this.input.Location = new System.Drawing.Point(122, 101);
			this.input.Name = "input";
			this.input.Size = new System.Drawing.Size(121, 21);
			this.input.TabIndex = 14;
			// 
			// hidden
			// 
			this.hidden.Location = new System.Drawing.Point(122, 128);
			this.hidden.Name = "hidden";
			this.hidden.Size = new System.Drawing.Size(121, 21);
			this.hidden.TabIndex = 15;
			// 
			// preProcessor
			// 
			this.preProcessor.Location = new System.Drawing.Point(367, 102);
			this.preProcessor.Name = "preProcessor";
			this.preProcessor.Size = new System.Drawing.Size(121, 21);
			this.preProcessor.TabIndex = 16;
			// 
			// postProcessor
			// 
			this.postProcessor.Location = new System.Drawing.Point(367, 129);
			this.postProcessor.Name = "postProcessor";
			this.postProcessor.Size = new System.Drawing.Size(121, 21);
			this.postProcessor.TabIndex = 17;
			// 
			// node
			// 
			this.node.Location = new System.Drawing.Point(367, 75);
			this.node.Name = "node";
			this.node.Size = new System.Drawing.Size(121, 21);
			this.node.TabIndex = 18;
			// 
			// output
			// 
			this.output.Location = new System.Drawing.Point(122, 155);
			this.output.Name = "output";
			this.output.Size = new System.Drawing.Size(121, 21);
			this.output.TabIndex = 19;
			// 
			// clear
			// 
			this.clear.Location = new System.Drawing.Point(332, 12);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(75, 23);
			this.clear.TabIndex = 20;
			this.clear.Text = "Clear";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.ClearForm);
			// 
			// trainingAlgorithmLabel
			// 
			this.trainingAlgorithmLabel.AutoSize = true;
			this.trainingAlgorithmLabel.Location = new System.Drawing.Point(265, 158);
			this.trainingAlgorithmLabel.Name = "trainingAlgorithmLabel";
			this.trainingAlgorithmLabel.Size = new System.Drawing.Size(96, 13);
			this.trainingAlgorithmLabel.TabIndex = 21;
			this.trainingAlgorithmLabel.Text = "Training Algorithms";
			// 
			// trainingAlgorithm
			// 
			this.trainingAlgorithm.FormattingEnabled = true;
			this.trainingAlgorithm.Location = new System.Drawing.Point(367, 156);
			this.trainingAlgorithm.Name = "trainingAlgorithm";
			this.trainingAlgorithm.Size = new System.Drawing.Size(121, 21);
			this.trainingAlgorithm.TabIndex = 22;
			// 
			// LoadUserBinaries
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 185);
			this.Controls.Add(this.trainingAlgorithm);
			this.Controls.Add(this.trainingAlgorithmLabel);
			this.Controls.Add(this.clear);
			this.Controls.Add(this.output);
			this.Controls.Add(this.node);
			this.Controls.Add(this.postProcessor);
			this.Controls.Add(this.preProcessor);
			this.Controls.Add(this.hidden);
			this.Controls.Add(this.input);
			this.Controls.Add(this.nodeLabel);
			this.Controls.Add(this.preProcessorLabel);
			this.Controls.Add(this.postProcessorLabel);
			this.Controls.Add(this.outputLayerLabel);
			this.Controls.Add(this.hiddenLayersLabel);
			this.Controls.Add(this.inputLabel);
			this.Controls.Add(this.factoryName);
			this.Controls.Add(this.factoryNameLabel);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.loadFile);
			this.Controls.Add(this.findFile);
			this.Controls.Add(this.fileLocation);
			this.Controls.Add(this.fileLabel);
			this.Name = "LoadUserBinaries";
			this.Text = "Load User Binary";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label fileLabel;
		private System.Windows.Forms.TextBox fileLocation;
		private System.Windows.Forms.OpenFileDialog openBinary;
		private System.Windows.Forms.Button findFile;
		private System.Windows.Forms.Button loadFile;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label factoryNameLabel;
		private System.Windows.Forms.TextBox factoryName;
		private System.Windows.Forms.Label inputLabel;
		private System.Windows.Forms.Label hiddenLayersLabel;
		private System.Windows.Forms.Label outputLayerLabel;
		private System.Windows.Forms.Label postProcessorLabel;
		private System.Windows.Forms.Label preProcessorLabel;
		private System.Windows.Forms.Label nodeLabel;
		private System.Windows.Forms.ComboBox input;
		private System.Windows.Forms.ComboBox hidden;
		private System.Windows.Forms.ComboBox preProcessor;
		private System.Windows.Forms.ComboBox postProcessor;
		private System.Windows.Forms.ComboBox node;
		private System.Windows.Forms.ComboBox output;
		private System.Windows.Forms.Button clear;
		private System.Windows.Forms.Label trainingAlgorithmLabel;
		private System.Windows.Forms.ComboBox trainingAlgorithm;
	}
}