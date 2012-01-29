namespace ENN.TopologyBuilder
{
	partial class PostProcessor
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
			this.mainLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainLabel
			// 
			this.mainLabel.AutoSize = true;
			this.mainLabel.Location = new System.Drawing.Point(3, 17);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(78, 13);
			this.mainLabel.TabIndex = 0;
			this.mainLabel.Text = "Post Processor";
			// 
			// PostProcessor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainLabel);
			this.Name = "PostProcessor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mainLabel;
	}
}
