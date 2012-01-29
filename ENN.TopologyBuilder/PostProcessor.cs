using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENN.TopologyBuilder
{
	public partial class PostProcessor : Layer
	{
		public PostProcessor()
		{
			InitializeComponent();
		}

		public override UserControl GetInformation()
		{
			BaseInformationControl info = new BaseInformationControl();
			info.SetHeader("Post Processor");
			return info;
		}
	}
}
