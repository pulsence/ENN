namespace ENN.TopologyBuilder.Views
{
	partial class HiddenLayerView
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
			this.nodeLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// nodeLayout
			// 
			this.nodeLayout.AutoSize = true;
			this.nodeLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.nodeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nodeLayout.Location = new System.Drawing.Point(0, 0);
			this.nodeLayout.Name = "nodeLayout";
			this.nodeLayout.Size = new System.Drawing.Size(323, 56);
			this.nodeLayout.TabIndex = 0;
			this.nodeLayout.Resize += new System.EventHandler(this.nodeLayout_Resize);
			// 
			// HiddenLayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nodeLayout);
			this.Name = "HiddenLayer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel nodeLayout;
	}
}
