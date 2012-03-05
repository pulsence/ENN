namespace ENN.TopologyBuilder
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
			this.components = new System.ComponentModel.Container();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.topologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userBinariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inputLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.processorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preProcessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.postProcessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.topologyContainer = new System.Windows.Forms.SplitContainer();
			this.topologyDisplay = new System.Windows.Forms.FlowLayoutPanel();
			this.saveTopology = new System.Windows.Forms.SaveFileDialog();
			this.openTopology = new System.Windows.Forms.OpenFileDialog();
			this.topologyStatus = new System.Windows.Forms.StatusStrip();
			this.canSaveStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.inputLayerStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.outputLayerStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.preProcessorStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.postProcessorStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveStatusTimer = new System.Windows.Forms.Timer(this.components);
			this.mainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.topologyContainer)).BeginInit();
			this.topologyContainer.Panel1.SuspendLayout();
			this.topologyContainer.SuspendLayout();
			this.topologyStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.actionMenu});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(886, 24);
			this.mainMenu.TabIndex = 1;
			this.mainMenu.Text = "menuStrip";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileMenuItem,
            this.saveFileMenuItem});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "File";
			// 
			// loadFileMenuItem
			// 
			this.loadFileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topologyToolStripMenuItem,
            this.userBinariesToolStripMenuItem});
			this.loadFileMenuItem.Name = "loadFileMenuItem";
			this.loadFileMenuItem.Size = new System.Drawing.Size(100, 22);
			this.loadFileMenuItem.Text = "Load";
			// 
			// topologyToolStripMenuItem
			// 
			this.topologyToolStripMenuItem.Name = "topologyToolStripMenuItem";
			this.topologyToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.topologyToolStripMenuItem.Text = "Topology";
			this.topologyToolStripMenuItem.Click += new System.EventHandler(this.LoadTopology);
			// 
			// userBinariesToolStripMenuItem
			// 
			this.userBinariesToolStripMenuItem.Name = "userBinariesToolStripMenuItem";
			this.userBinariesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.userBinariesToolStripMenuItem.Text = "User Binaries";
			this.userBinariesToolStripMenuItem.Click += new System.EventHandler(this.LoadUserBinaries);
			// 
			// saveFileMenuItem
			// 
			this.saveFileMenuItem.Name = "saveFileMenuItem";
			this.saveFileMenuItem.Size = new System.Drawing.Size(100, 22);
			this.saveFileMenuItem.Text = "Save";
			this.saveFileMenuItem.Click += new System.EventHandler(this.SaveTopology);
			// 
			// actionMenu
			// 
			this.actionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.actionMenu.Name = "actionMenu";
			this.actionMenu.Size = new System.Drawing.Size(54, 20);
			this.actionMenu.Text = "Action";
			// 
			// createToolStripMenuItem
			// 
			this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputLayerToolStripMenuItem,
            this.nodeToolStripMenuItem,
            this.processorToolStripMenuItem});
			this.createToolStripMenuItem.Name = "createToolStripMenuItem";
			this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.createToolStripMenuItem.Text = "Create";
			// 
			// inputLayerToolStripMenuItem
			// 
			this.inputLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem,
            this.hiddenToolStripMenuItem,
            this.outputToolStripMenuItem});
			this.inputLayerToolStripMenuItem.Name = "inputLayerToolStripMenuItem";
			this.inputLayerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.inputLayerToolStripMenuItem.Text = "Layer";
			// 
			// inputToolStripMenuItem
			// 
			this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
			this.inputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
			this.inputToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.inputToolStripMenuItem.Text = "Input";
			this.inputToolStripMenuItem.Click += new System.EventHandler(this.AddInputLayer);
			// 
			// hiddenToolStripMenuItem
			// 
			this.hiddenToolStripMenuItem.Name = "hiddenToolStripMenuItem";
			this.hiddenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
			this.hiddenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.hiddenToolStripMenuItem.Text = "Hidden";
			this.hiddenToolStripMenuItem.Click += new System.EventHandler(this.AddHiddenLayer);
			// 
			// outputToolStripMenuItem
			// 
			this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
			this.outputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
			this.outputToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.outputToolStripMenuItem.Text = "Output";
			this.outputToolStripMenuItem.Click += new System.EventHandler(this.AddOutputLayer);
			// 
			// nodeToolStripMenuItem
			// 
			this.nodeToolStripMenuItem.Name = "nodeToolStripMenuItem";
			this.nodeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.nodeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.nodeToolStripMenuItem.Text = "Node";
			this.nodeToolStripMenuItem.Click += new System.EventHandler(this.AddNode);
			// 
			// processorToolStripMenuItem
			// 
			this.processorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preProcessorToolStripMenuItem,
            this.postProcessorToolStripMenuItem});
			this.processorToolStripMenuItem.Name = "processorToolStripMenuItem";
			this.processorToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.processorToolStripMenuItem.Text = "Processor";
			// 
			// preProcessorToolStripMenuItem
			// 
			this.preProcessorToolStripMenuItem.Name = "preProcessorToolStripMenuItem";
			this.preProcessorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.preProcessorToolStripMenuItem.Text = "PreProcessor";
			this.preProcessorToolStripMenuItem.Click += new System.EventHandler(this.AddPreProcessor);
			// 
			// postProcessorToolStripMenuItem
			// 
			this.postProcessorToolStripMenuItem.Name = "postProcessorToolStripMenuItem";
			this.postProcessorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.postProcessorToolStripMenuItem.Text = "PostProcessor";
			this.postProcessorToolStripMenuItem.Click += new System.EventHandler(this.AddPostProcessor);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedLayer);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.newToolStripMenuItem});
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			// 
			// selectedToolStripMenuItem
			// 
			this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
			this.selectedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.selectedToolStripMenuItem.Text = "Selected";
			this.selectedToolStripMenuItem.Click += new System.EventHandler(this.PasteLayer);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.PasteNewLayer);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteLayer);
			// 
			// topologyContainer
			// 
			this.topologyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topologyContainer.IsSplitterFixed = true;
			this.topologyContainer.Location = new System.Drawing.Point(0, 24);
			this.topologyContainer.Name = "topologyContainer";
			// 
			// topologyContainer.Panel1
			// 
			this.topologyContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.topologyContainer.Panel1.Controls.Add(this.topologyDisplay);
			this.topologyContainer.Size = new System.Drawing.Size(886, 406);
			this.topologyContainer.SplitterDistance = 693;
			this.topologyContainer.TabIndex = 2;
			// 
			// topologyDisplay
			// 
			this.topologyDisplay.AutoScroll = true;
			this.topologyDisplay.AutoSize = true;
			this.topologyDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.topologyDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
			this.topologyDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topologyDisplay.Location = new System.Drawing.Point(0, 0);
			this.topologyDisplay.Name = "topologyDisplay";
			this.topologyDisplay.Size = new System.Drawing.Size(693, 406);
			this.topologyDisplay.TabIndex = 0;
			this.topologyDisplay.Click += new System.EventHandler(this.TopologyDisplayClick);
			this.topologyDisplay.Resize += new System.EventHandler(this.ResizeTopologyDisplay);
			// 
			// topologyStatus
			// 
			this.topologyStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canSaveStatus,
            this.inputLayerStatus,
            this.outputLayerStatus,
            this.preProcessorStatus,
            this.postProcessorStatus});
			this.topologyStatus.Location = new System.Drawing.Point(0, 408);
			this.topologyStatus.Name = "topologyStatus";
			this.topologyStatus.Size = new System.Drawing.Size(886, 22);
			this.topologyStatus.TabIndex = 3;
			// 
			// canSaveStatus
			// 
			this.canSaveStatus.Name = "canSaveStatus";
			this.canSaveStatus.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.canSaveStatus.Size = new System.Drawing.Size(92, 17);
			this.canSaveStatus.Text = "Can Save: False";
			// 
			// inputLayerStatus
			// 
			this.inputLayerStatus.Name = "inputLayerStatus";
			this.inputLayerStatus.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.inputLayerStatus.Size = new System.Drawing.Size(126, 17);
			this.inputLayerStatus.Text = "Has Input Layer: False";
			// 
			// outputLayerStatus
			// 
			this.outputLayerStatus.Name = "outputLayerStatus";
			this.outputLayerStatus.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.outputLayerStatus.Size = new System.Drawing.Size(136, 17);
			this.outputLayerStatus.Text = "Has Output Layer: False";
			// 
			// preProcessorStatus
			// 
			this.preProcessorStatus.Name = "preProcessorStatus";
			this.preProcessorStatus.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.preProcessorStatus.Size = new System.Drawing.Size(138, 17);
			this.preProcessorStatus.Text = "Has Pre Processor: False";
			// 
			// postProcessorStatus
			// 
			this.postProcessorStatus.Name = "postProcessorStatus";
			this.postProcessorStatus.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.postProcessorStatus.Size = new System.Drawing.Size(144, 17);
			this.postProcessorStatus.Text = "Has Post Processor: False";
			// 
			// saveStatusTimer
			// 
			this.saveStatusTimer.Interval = 10000;
			this.saveStatusTimer.Tick += new System.EventHandler(this.SaveTimerTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 430);
			this.Controls.Add(this.topologyStatus);
			this.Controls.Add(this.topologyContainer);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Topology Builder";
			this.Load += new System.EventHandler(this.LoadMainForm);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.topologyContainer.Panel1.ResumeLayout(false);
			this.topologyContainer.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.topologyContainer)).EndInit();
			this.topologyContainer.ResumeLayout(false);
			this.topologyStatus.ResumeLayout(false);
			this.topologyStatus.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem loadFileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem actionMenu;
		private System.Windows.Forms.SplitContainer topologyContainer;
		private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inputLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hiddenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem processorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem preProcessorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem postProcessorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel topologyDisplay;
		private System.Windows.Forms.ToolStripMenuItem topologyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userBinariesToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveTopology;
		private System.Windows.Forms.OpenFileDialog openTopology;
		private System.Windows.Forms.StatusStrip topologyStatus;
		private System.Windows.Forms.ToolStripStatusLabel canSaveStatus;
		private System.Windows.Forms.ToolStripStatusLabel inputLayerStatus;
		private System.Windows.Forms.ToolStripStatusLabel outputLayerStatus;
		private System.Windows.Forms.ToolStripStatusLabel preProcessorStatus;
		private System.Windows.Forms.ToolStripStatusLabel postProcessorStatus;
		private System.Windows.Forms.Timer saveStatusTimer;
	}
}

