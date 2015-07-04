using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XmlNodePruner
{
	/// <summary>
	/// Summary description for XmlDisplay.
	/// </summary>
	public class XmlDisplay : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtXml;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private XmlDisplay()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

        public XmlDisplay( string xmlToDisplay ) : this()
        {
            txtXml.Text = xmlToDisplay;
            txtXml.Select( 0, 0 );
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtXml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtXml
            // 
            this.txtXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXml.Multiline = true;
            this.txtXml.Name = "txtXml";
            this.txtXml.ReadOnly = true;
            this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXml.Size = new System.Drawing.Size(541, 428);
            this.txtXml.TabIndex = 0;
            this.txtXml.Text = "";
            // 
            // XmlDisplay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(541, 428);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.txtXml});
            this.Name = "XmlDisplay";
            this.Text = "XmlDisplay";
            this.ResumeLayout(false);

        }
		#endregion
	}
}
