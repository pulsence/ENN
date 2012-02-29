namespace ENN.TopologyBuilder.Views
{
	partial class InputLayerMetaDataView
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
			this.inputCountLabel = new System.Windows.Forms.Label();
			this.inputCount = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// extraFields
			// 
			this.extraFields.Location = new System.Drawing.Point(6, 169);
			// 
			// extraFieldsLabel
			// 
			this.extraFieldsLabel.Location = new System.Drawing.Point(3, 153);
			// 
			// inputCountLabel
			// 
			this.inputCountLabel.AutoSize = true;
			this.inputCountLabel.Location = new System.Drawing.Point(3, 106);
			this.inputCountLabel.Name = "inputCountLabel";
			this.inputCountLabel.Size = new System.Drawing.Size(88, 13);
			this.inputCountLabel.TabIndex = 11;
			this.inputCountLabel.Text = "Number of Inputs";
			// 
			// inputCount
			// 
			this.inputCount.Location = new System.Drawing.Point(6, 122);
			this.inputCount.Name = "inputCount";
			this.inputCount.Size = new System.Drawing.Size(160, 20);
			this.inputCount.TabIndex = 12;
			this.inputCount.Text = "0";
			this.inputCount.TextChanged += new System.EventHandler(this.inputCount_TextChanged);
			// 
			// InputLayerMetaDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.inputCountLabel);
			this.Controls.Add(this.inputCount);
			this.Name = "InputLayerMetaDataView";
			this.Size = new System.Drawing.Size(179, 321);
			this.Controls.SetChildIndex(this.inputCount, 0);
			this.Controls.SetChildIndex(this.inputCountLabel, 0);
			this.Controls.SetChildIndex(this.headerLabel, 0);
			this.Controls.SetChildIndex(this.factory, 0);
			this.Controls.SetChildIndex(this.factoryLabel, 0);
			this.Controls.SetChildIndex(this.dataType, 0);
			this.Controls.SetChildIndex(this.dataTypeLabel, 0);
			this.Controls.SetChildIndex(this.extraFieldsLabel, 0);
			this.Controls.SetChildIndex(this.extraFields, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label inputCountLabel;
		private System.Windows.Forms.TextBox inputCount;

	}
}
