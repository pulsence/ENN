namespace ENN.TopologyBuilder.Views
{
	partial class BaseMetaDataView
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
			this.headerLabel = new System.Windows.Forms.Label();
			this.dataTypeLabel = new System.Windows.Forms.Label();
			this.dataType = new System.Windows.Forms.ComboBox();
			this.factoryLabel = new System.Windows.Forms.Label();
			this.factory = new System.Windows.Forms.ComboBox();
			this.extraFieldsLabel = new System.Windows.Forms.Label();
			this.extraFields = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// headerLabel
			// 
			this.headerLabel.AutoSize = true;
			this.headerLabel.Location = new System.Drawing.Point(0, 0);
			this.headerLabel.Name = "headerLabel";
			this.headerLabel.Size = new System.Drawing.Size(88, 13);
			this.headerLabel.TabIndex = 0;
			this.headerLabel.Text = "Basic Information";
			// 
			// dataTypeLabel
			// 
			this.dataTypeLabel.AutoSize = true;
			this.dataTypeLabel.Location = new System.Drawing.Point(3, 66);
			this.dataTypeLabel.Name = "dataTypeLabel";
			this.dataTypeLabel.Size = new System.Drawing.Size(57, 13);
			this.dataTypeLabel.TabIndex = 7;
			this.dataTypeLabel.Text = "Data Type";
			// 
			// dataType
			// 
			this.dataType.FormattingEnabled = true;
			this.dataType.Location = new System.Drawing.Point(6, 82);
			this.dataType.Name = "dataType";
			this.dataType.Size = new System.Drawing.Size(160, 21);
			this.dataType.TabIndex = 8;
			this.dataType.SelectedIndexChanged += new System.EventHandler(this.dataType_SelectedIndexChanged);
			// 
			// factoryLabel
			// 
			this.factoryLabel.AutoSize = true;
			this.factoryLabel.Location = new System.Drawing.Point(3, 26);
			this.factoryLabel.Name = "factoryLabel";
			this.factoryLabel.Size = new System.Drawing.Size(42, 13);
			this.factoryLabel.TabIndex = 5;
			this.factoryLabel.Text = "Factory";
			// 
			// factory
			// 
			this.factory.FormattingEnabled = true;
			this.factory.Location = new System.Drawing.Point(6, 42);
			this.factory.Name = "factory";
			this.factory.Size = new System.Drawing.Size(160, 21);
			this.factory.TabIndex = 6;
			this.factory.SelectedIndexChanged += new System.EventHandler(this.factory_SelectedIndexChanged);
			// 
			// extraFieldsLabel
			// 
			this.extraFieldsLabel.AutoSize = true;
			this.extraFieldsLabel.Location = new System.Drawing.Point(3, 106);
			this.extraFieldsLabel.Name = "extraFieldsLabel";
			this.extraFieldsLabel.Size = new System.Drawing.Size(61, 13);
			this.extraFieldsLabel.TabIndex = 9;
			this.extraFieldsLabel.Text = "Extra Fields";
			// 
			// extraFields
			// 
			this.extraFields.Location = new System.Drawing.Point(6, 122);
			this.extraFields.Multiline = true;
			this.extraFields.Name = "extraFields";
			this.extraFields.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.extraFields.Size = new System.Drawing.Size(160, 105);
			this.extraFields.TabIndex = 10;
			// 
			// BaseMetaDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.extraFields);
			this.Controls.Add(this.extraFieldsLabel);
			this.Controls.Add(this.dataTypeLabel);
			this.Controls.Add(this.dataType);
			this.Controls.Add(this.factoryLabel);
			this.Controls.Add(this.factory);
			this.Controls.Add(this.headerLabel);
			this.Name = "BaseMetaDataView";
			this.Size = new System.Drawing.Size(189, 406);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.Label headerLabel;
		protected System.Windows.Forms.ComboBox factory;
		protected System.Windows.Forms.ComboBox dataType;
		protected System.Windows.Forms.TextBox extraFields;
		protected System.Windows.Forms.Label extraFieldsLabel;
		protected System.Windows.Forms.Label dataTypeLabel;
		protected System.Windows.Forms.Label factoryLabel;

	}
}
