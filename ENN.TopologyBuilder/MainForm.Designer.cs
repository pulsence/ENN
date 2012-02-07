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
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.topologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userBinariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.topologyContainer)).BeginInit();
			this.topologyContainer.Panel1.SuspendLayout();
			this.topologyContainer.SuspendLayout();
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
			this.loadFileMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadFileMenuItem.Text = "Load";
			// 
			// saveFileMenuItem
			// 
			this.saveFileMenuItem.Name = "saveFileMenuItem";
			this.saveFileMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveFileMenuItem.Text = "Save";
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
			this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
			// 
			// hiddenToolStripMenuItem
			// 
			this.hiddenToolStripMenuItem.Name = "hiddenToolStripMenuItem";
			this.hiddenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
			this.hiddenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.hiddenToolStripMenuItem.Text = "Hidden";
			this.hiddenToolStripMenuItem.Click += new System.EventHandler(this.hiddenToolStripMenuItem_Click);
			// 
			// outputToolStripMenuItem
			// 
			this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
			this.outputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
			this.outputToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.outputToolStripMenuItem.Text = "Output";
			this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputToolStripMenuItem_Click);
			// 
			// nodeToolStripMenuItem
			// 
			this.nodeToolStripMenuItem.Name = "nodeToolStripMenuItem";
			this.nodeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.nodeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.nodeToolStripMenuItem.Text = "Node";
			this.nodeToolStripMenuItem.Click += new System.EventHandler(this.nodeToolStripMenuItem_Click);
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
			this.preProcessorToolStripMenuItem.Click += new System.EventHandler(this.preProcessorToolStripMenuItem_Click);
			// 
			// postProcessorToolStripMenuItem
			// 
			this.postProcessorToolStripMenuItem.Name = "postProcessorToolStripMenuItem";
			this.postProcessorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.postProcessorToolStripMenuItem.Text = "PostProcessor";
			this.postProcessorToolStripMenuItem.Click += new System.EventHandler(this.postProcessorToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
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
			this.selectedToolStripMenuItem.Click += new System.EventHandler(this.selectedToolStripMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
			this.topologyDisplay.Resize += new System.EventHandler(this.topologyDisplay_Resize);
			// 
			// topologyToolStripMenuItem
			// 
			this.topologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.binaryToolStripMenuItem});
			this.topologyToolStripMenuItem.Name = "topologyToolStripMenuItem";
			this.topologyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.topologyToolStripMenuItem.Text = "Topology";
			// 
			// userBinariesToolStripMenuItem
			// 
			this.userBinariesToolStripMenuItem.Name = "userBinariesToolStripMenuItem";
			this.userBinariesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.userBinariesToolStripMenuItem.Text = "User Binaries";
			this.userBinariesToolStripMenuItem.Click += new System.EventHandler(this.userBinariesToolStripMenuItem_Click);
			// 
			// textToolStripMenuItem
			// 
			this.textToolStripMenuItem.Name = "textToolStripMenuItem";
			this.textToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.textToolStripMenuItem.Text = "Text";
			// 
			// binaryToolStripMenuItem
			// 
			this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
			this.binaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.binaryToolStripMenuItem.Text = "Binary";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 430);
			this.Controls.Add(this.topologyContainer);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Topology Builder";
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.topologyContainer.Panel1.ResumeLayout(false);
			this.topologyContainer.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.topologyContainer)).EndInit();
			this.topologyContainer.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userBinariesToolStripMenuItem;
	}
}

