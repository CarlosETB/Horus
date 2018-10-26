using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using UrlHistoryLibrary;


namespace UrlHistoryDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.DataGrid dataGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;

		UrlHistoryWrapperClass.STATURLEnumerator enumerator;
		UrlHistoryWrapperClass urlHistory;
		ArrayList list;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			urlHistory = new UrlHistoryWrapperClass();
			enumerator = urlHistory.GetEnumerator();
			list = new ArrayList();

			
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
            this.dataGrid = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.DataMember = "";
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(760, 542);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid_Navigate);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 542);
            this.Controls.Add(this.dataGrid);
            this.Name = "Form1";
            this.Text = "Url History Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		

		void GetHistoryItems()
		{
			list.Clear();
			list.TrimToSize();
			
			while(enumerator.MoveNext())
			{
				list.Add(enumerator.Current);
			}
			enumerator.Reset();

			//enumerator.GetUrlHistory(list);

			if(list.Count != 0)
				list.Sort(SortFileTimeAscendingHelper.SortFileTimeAscending());
		}

		

		void CreateDataGridTable()
		{

			dataGrid.DataSource = list;

			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "ArrayList";

			int colwidth = (dataGrid.ClientSize.Width - ts.RowHeaderWidth - SystemInformation.VerticalScrollBarWidth) / 5;

			
			DataGridTextBoxColumn cs = new DataGridTextBoxColumn();
			cs.MappingName = "URL"; 
			cs.HeaderText = "URL";
			cs.Width = colwidth;
			ts.GridColumnStyles.Add(cs);

			
			cs = new DataGridTextBoxColumn();
			cs.MappingName = "Title"; 
			cs.HeaderText = "Title";
			cs.Width = colwidth;
			ts.GridColumnStyles.Add(cs);

			
			cs = new DataGridTextBoxColumn();
			cs.MappingName = "LastVisited";  
			cs.HeaderText = "LastVisited";
			cs.Width = colwidth;
			ts.GridColumnStyles.Add(cs);

			
			cs = new DataGridTextBoxColumn();
			cs.MappingName = "LastUpdated"; 
			cs.HeaderText = "LastUpdated";
			cs.Width = colwidth;
			ts.GridColumnStyles.Add(cs);

			
			cs = new DataGridTextBoxColumn();
			cs.MappingName = "Expires";  
			cs.HeaderText = "Expires";
			cs.Width = colwidth;
			ts.GridColumnStyles.Add(cs);

			
			dataGrid.TableStyles.Clear();
			dataGrid.TableStyles.Add(ts);
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
			
			GetHistoryItems();
			CreateDataGridTable();
			
		}

		

		

		

		

		

		
		private void Form1_Resize(object sender, System.EventArgs e)
		{
			CreateDataGridTable();
		}

        private void dataGrid_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
