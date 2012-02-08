namespace ENN.TopologyBuilder.Views
{
	partial class NodeMetaDataView
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
			this.layerName = new System.Windows.Forms.Label();
			this.combinationWeightsLabel = new System.Windows.Forms.Label();
			this.combinationWeights = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// extraFields
			// 
			this.extraFields.Location = new System.Drawing.Point(6, 183);
			// 
			// extraFieldsLabel
			// 
			this.extraFieldsLabel.Location = new System.Drawing.Point(3, 167);
			// 
			// layerName
			// 
			this.layerName.AutoSize = true;
			this.layerName.Location = new System.Drawing.Point(3, 106);
			this.layerName.Name = "layerName";
			this.layerName.Size = new System.Drawing.Size(115, 13);
			this.layerName.TabIndex = 11;
			this.layerName.Text = "Layer Name: No Name";
			// 
			// combinationWeightsLabel
			// 
			this.combinationWeightsLabel.AutoSize = true;
			this.combinationWeightsLabel.Location = new System.Drawing.Point(3, 128);
			this.combinationWeightsLabel.Name = "combinationWeightsLabel";
			this.combinationWeightsLabel.Size = new System.Drawing.Size(107, 13);
			this.combinationWeightsLabel.TabIndex = 13;
			this.combinationWeightsLabel.Text = "Combination Weights";
			// 
			// combinationWeights
			// 
			this.combinationWeights.Location = new System.Drawing.Point(6, 144);
			this.combinationWeights.Name = "combinationWeights";
			this.combinationWeights.Size = new System.Drawing.Size(160, 20);
			this.combinationWeights.TabIndex = 14;
			this.combinationWeights.TextChanged += new System.EventHandler(this.combinationWeights_TextChanged);
			// 
			// NodeMetaDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.combinationWeightsLabel);
			this.Controls.Add(this.combinationWeights);
			this.Controls.Add(this.layerName);
			this.Name = "NodeMetaDataView";
			this.Controls.SetChildIndex(this.layerName, 0);
			this.Controls.SetChildIndex(this.headerLabel, 0);
			this.Controls.SetChildIndex(this.factory, 0);
			this.Controls.SetChildIndex(this.factoryLabel, 0);
			this.Controls.SetChildIndex(this.dataType, 0);
			this.Controls.SetChildIndex(this.dataTypeLabel, 0);
			this.Controls.SetChildIndex(this.extraFieldsLabel, 0);
			this.Controls.SetChildIndex(this.extraFields, 0);
			this.Controls.SetChildIndex(this.combinationWeights, 0);
			this.Controls.SetChildIndex(this.combinationWeightsLabel, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label layerName;
		private System.Windows.Forms.Label combinationWeightsLabel;
		private System.Windows.Forms.TextBox combinationWeights;
	}
}
