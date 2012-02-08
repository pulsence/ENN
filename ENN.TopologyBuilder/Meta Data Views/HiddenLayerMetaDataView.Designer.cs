namespace ENN.TopologyBuilder.Views
{
	partial class HiddenLayerMetaDataView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nodeCount = new System.Windows.Forms.Label();
			this.layerNameLabel = new System.Windows.Forms.Label();
			this.layerName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// headerLabel
			// 
			this.headerLabel.Location = new System.Drawing.Point(3, 0);
			// 
			// extraFields
			// 
			this.extraFields.Location = new System.Drawing.Point(6, 190);
			// 
			// extraFieldsLabel
			// 
			this.extraFieldsLabel.Location = new System.Drawing.Point(3, 174);
			// 
			// nodeCount
			// 
			this.nodeCount.AutoSize = true;
			this.nodeCount.Location = new System.Drawing.Point(3, 150);
			this.nodeCount.Name = "nodeCount";
			this.nodeCount.Size = new System.Drawing.Size(50, 13);
			this.nodeCount.TabIndex = 5;
			this.nodeCount.Text = "Nodes: 0";
			// 
			// layerNameLabel
			// 
			this.layerNameLabel.AutoSize = true;
			this.layerNameLabel.Location = new System.Drawing.Point(3, 111);
			this.layerNameLabel.Name = "layerNameLabel";
			this.layerNameLabel.Size = new System.Drawing.Size(64, 13);
			this.layerNameLabel.TabIndex = 6;
			this.layerNameLabel.Text = "Layer Name";
			// 
			// layerName
			// 
			this.layerName.Location = new System.Drawing.Point(6, 127);
			this.layerName.Name = "layerName";
			this.layerName.Size = new System.Drawing.Size(160, 20);
			this.layerName.TabIndex = 7;
			this.layerName.TextChanged += new System.EventHandler(this.layerName_TextChanged);
			// 
			// HiddenLayerMetaDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.layerName);
			this.Controls.Add(this.layerNameLabel);
			this.Controls.Add(this.nodeCount);
			this.Name = "HiddenLayerMetaDataView";
			this.Size = new System.Drawing.Size(189, 406);
			this.Controls.SetChildIndex(this.factoryLabel, 0);
			this.Controls.SetChildIndex(this.dataTypeLabel, 0);
			this.Controls.SetChildIndex(this.extraFieldsLabel, 0);
			this.Controls.SetChildIndex(this.factory, 0);
			this.Controls.SetChildIndex(this.dataType, 0);
			this.Controls.SetChildIndex(this.extraFields, 0);
			this.Controls.SetChildIndex(this.headerLabel, 0);
			this.Controls.SetChildIndex(this.nodeCount, 0);
			this.Controls.SetChildIndex(this.layerNameLabel, 0);
			this.Controls.SetChildIndex(this.layerName, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label nodeCount;
		private System.Windows.Forms.Label layerNameLabel;
		private System.Windows.Forms.TextBox layerName;
	}
}
