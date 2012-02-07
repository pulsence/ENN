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
			this.factoryLabel = new System.Windows.Forms.Label();
			this.factory = new System.Windows.Forms.ComboBox();
			this.dataTypeLabel = new System.Windows.Forms.Label();
			this.dataType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// headerLabel
			// 
			this.headerLabel.Location = new System.Drawing.Point(3, 0);
			// 
			// factoryLabel
			// 
			this.factoryLabel.AutoSize = true;
			this.factoryLabel.Location = new System.Drawing.Point(3, 31);
			this.factoryLabel.Name = "factoryLabel";
			this.factoryLabel.Size = new System.Drawing.Size(42, 13);
			this.factoryLabel.TabIndex = 1;
			this.factoryLabel.Text = "Factory";
			// 
			// factory
			// 
			this.factory.FormattingEnabled = true;
			this.factory.Location = new System.Drawing.Point(6, 47);
			this.factory.Name = "factory";
			this.factory.Size = new System.Drawing.Size(121, 21);
			this.factory.TabIndex = 2;
			this.factory.SelectedIndexChanged += new System.EventHandler(this.factory_SelectedIndexChanged);
			// 
			// dataTypeLabel
			// 
			this.dataTypeLabel.AutoSize = true;
			this.dataTypeLabel.Location = new System.Drawing.Point(3, 71);
			this.dataTypeLabel.Name = "dataTypeLabel";
			this.dataTypeLabel.Size = new System.Drawing.Size(57, 13);
			this.dataTypeLabel.TabIndex = 3;
			this.dataTypeLabel.Text = "Data Type";
			// 
			// dataType
			// 
			this.dataType.FormattingEnabled = true;
			this.dataType.Location = new System.Drawing.Point(6, 87);
			this.dataType.Name = "dataType";
			this.dataType.Size = new System.Drawing.Size(121, 21);
			this.dataType.TabIndex = 4;
			this.dataType.SelectedIndexChanged += new System.EventHandler(this.dataType_SelectedIndexChanged);
			// 
			// HiddenLayerInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.dataTypeLabel);
			this.Controls.Add(this.dataType);
			this.Controls.Add(this.factoryLabel);
			this.Controls.Add(this.factory);
			this.Name = "HiddenLayerInformation";
			this.Size = new System.Drawing.Size(141, 225);
			this.Controls.SetChildIndex(this.factory, 0);
			this.Controls.SetChildIndex(this.headerLabel, 0);
			this.Controls.SetChildIndex(this.factoryLabel, 0);
			this.Controls.SetChildIndex(this.dataType, 0);
			this.Controls.SetChildIndex(this.dataTypeLabel, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label factoryLabel;
		private System.Windows.Forms.ComboBox factory;
		private System.Windows.Forms.Label dataTypeLabel;
		private System.Windows.Forms.ComboBox dataType;
	}
}
