namespace ENN.TopologyBuilder.Views
{
	partial class TopologyMetaDataView
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
			this.nameLabel = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// factory
			// 
			this.factory.Location = new System.Drawing.Point(6, 78);
			// 
			// dataType
			// 
			this.dataType.Location = new System.Drawing.Point(6, 118);
			// 
			// extraFields
			// 
			this.extraFields.Location = new System.Drawing.Point(6, 156);
			// 
			// extraFieldsLabel
			// 
			this.extraFieldsLabel.Location = new System.Drawing.Point(3, 140);
			// 
			// dataTypeLabel
			// 
			this.dataTypeLabel.Location = new System.Drawing.Point(3, 102);
			this.dataTypeLabel.Size = new System.Drawing.Size(91, 13);
			this.dataTypeLabel.Text = "Training Algorithm";
			// 
			// factoryLabel
			// 
			this.factoryLabel.Location = new System.Drawing.Point(3, 62);
			this.factoryLabel.Size = new System.Drawing.Size(129, 13);
			this.factoryLabel.Text = "Training Algorithm Factory";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(3, 23);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(82, 13);
			this.nameLabel.TabIndex = 11;
			this.nameLabel.Text = "Topology Name";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(160, 20);
			this.textBox1.TabIndex = 12;
			// 
			// TopologyMetaDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.textBox1);
			this.Name = "TopologyMetaDataView";
			this.Controls.SetChildIndex(this.dataType, 0);
			this.Controls.SetChildIndex(this.dataTypeLabel, 0);
			this.Controls.SetChildIndex(this.textBox1, 0);
			this.Controls.SetChildIndex(this.nameLabel, 0);
			this.Controls.SetChildIndex(this.headerLabel, 0);
			this.Controls.SetChildIndex(this.factory, 0);
			this.Controls.SetChildIndex(this.factoryLabel, 0);
			this.Controls.SetChildIndex(this.extraFieldsLabel, 0);
			this.Controls.SetChildIndex(this.extraFields, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox textBox1;
	}
}
