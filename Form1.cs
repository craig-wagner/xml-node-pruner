using System;
using System.Drawing;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace XmlNodePruner
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnPrune;
		private System.Windows.Forms.TextBox txtFileName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnPrune = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(72, 32);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(344, 20);
			this.txtFileName.TabIndex = 0;
			this.txtFileName.Text = "txtFileName";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Xml File:";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(424, 32);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(24, 23);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnPrune
			// 
			this.btnPrune.Location = new System.Drawing.Point(195, 72);
			this.btnPrune.Name = "btnPrune";
			this.btnPrune.TabIndex = 3;
			this.btnPrune.Text = "Prune!";
			this.btnPrune.Click += new System.EventHandler(this.btnPrune_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 118);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnPrune,
																		  this.btnBrowse,
																		  this.label1,
																		  this.txtFileName});
			this.Name = "Form1";
			this.Text = "Xml Empty Node Pruner";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnPrune_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( txtFileName.Text != "" && File.Exists(txtFileName.Text) )
				{
					XmlPrunerDocument xmlpDoc = new XmlPrunerDocument();
					xmlpDoc.Load(txtFileName.Text);
					xmlpDoc.PruneEmptyNodes();

					XmlDisplay display = new XmlDisplay(xmlpDoc.InnerXml);
					display.Show();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.DefaultExt = "xml | *.xml";
			dlg.InitialDirectory = "d:\\my documents\\work\\experimental\\XmlNodePruner\\bin\\debug";
			dlg.FileName = txtFileName.Text;
			dlg.ShowDialog(this);
			txtFileName.Text = dlg.FileName;
		}
	}
}
