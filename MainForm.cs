/*
 * Created by SharpDevelop.
 * User: Tommy
 * Date: 7/24/2017
 * Time: 5:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Management;
using System.Net.NetworkInformation;
using System.DirectoryServices;

namespace ComparePkg
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private BackgroundWorker myWorker = new BackgroundWorker();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
		    myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
		    myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
		    myWorker.WorkerReportsProgress = true;
		    myWorker.WorkerSupportsCancellation = true;
		}
		
		protected void myWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker sendingWorker = (BackgroundWorker)sender;//Capture the BackgroundWorker that fired the event
            object[] arrObjects = (object[])e.Argument;//Collect the array of objects the we recived from the main thread
 
		}
		
		protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		
		}
		
		protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		
		}
		
		void BtcompareClick(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = string.Format(@"Compare {0} with TSA1CKB510.",lboxiwslist.SelectedItem.ToString());
			string standardiws = "tsa1ckb510";
			List<string> standardnames = new List<string>();
			
			try
			{
				ManagementClass vspClass = new ManagementClass( string.Format(@"\\{0}\root\default:VirtualSoftwarePackage",standardiws) );
				ManagementObjectCollection vspCollection =  vspClass.GetInstances();
				
				foreach (ManagementObject vspObject in vspCollection)
	            {
					standardnames.Add( vspObject.GetPropertyValue("Name").ToString() );
	            }
			}
			catch( Exception ex )
			{
				lberror.Text = "Catch error:"+ex.Message;
			}
			
			List<string> packagenames = new List<string>();
			
			try{
			foreach( DataGridViewRow row in dgvpkgname.Rows )
			{
				for( int i = 0 ; i < standardnames.Count ; i++ )
				{
					if( string.Equals( standardnames[i] , row.Cells[0].Value.ToString() , StringComparison.OrdinalIgnoreCase ) )
					{
						standardnames.RemoveAt(i); // if find the same name, reomve from list
					}
					else
					{
						if( packagenames.Count == 0 )
							packagenames.Add( row.Cells[0].Value.ToString() );
						else
						{
							foreach( string pkgname in packagenames )
							{
								if( !string.Equals( pkgname , row.Cells[0].Value.ToString() , StringComparison.OrdinalIgnoreCase ) )
								   packagenames.Add( row.Cells[0].Value.ToString() );
							}
						}
					}
				}
			}
			}catch( Exception ex )
			{
				lberror.Text = "Catch error2:"+ex.Message;
			}
			
			try{
			dgvresult.DataSource = null;
			dgvresult.Columns.Add( "iws" , "IWS Name");
			dgvresult.Columns.Add( "pkgname" , "Package Name" );
			dgvresult.Columns[1].Width = 340;
			
			foreach( string pkgname in standardnames )
			{
				this.dgvresult.Rows.Add( standardiws , pkgname );
			}
			
			foreach( string pkgname in packagenames )
			{
				this.dgvresult.Rows.Add( lboxiwslist.SelectedItem.ToString() , pkgname );
			}
			}catch( Exception ex )
			{
				lberror.Text = "Catch error3:"+ex.Message;
			}
		}
		
		private void SetbtnsEnabled()
		{
			btcompare.Enabled = false;
			btlist.Enabled = false;
		}
		
		void BtlistClick(object sender, EventArgs e)
		{
			if( !ChecklistboxSelected() )
				return;
			
			string str_iws = lboxiwslist.SelectedItem.ToString();
			
			toolStripStatusLabel1.Text = string.Format(@"Waiting {0} reply message.",str_iws);
				
			if( !string.Equals("online", MainForm.PingHost(str_iws), StringComparison.OrdinalIgnoreCase) )
			{
				toolStripStatusLabel1.Text = string.Format(@"{0} is not Online.",str_iws);
				return;
			}
			else
				toolStripStatusLabel1.Text = string.Empty;
			
			try
			{
				dgvpkgname.DataSource = null;
				
				ManagementClass vspClass = new ManagementClass( string.Format(@"\\{0}\root\default:VirtualSoftwarePackage",str_iws) );
				ManagementObjectCollection vspCollection =  vspClass.GetInstances();
				
				DataTable dtpkglist = new DataTable(str_iws);
				dtpkglist.Columns.Add("PackageName");
				//dtpkglist.Columns.Add("Id");
				DataRow drpkg;
				
				foreach (ManagementObject vspObject in vspCollection)
	            {
					drpkg = dtpkglist.NewRow();
					drpkg["PackageName"] = vspObject.GetPropertyValue("Name").ToString();
					//drpkg["Id"] = vspObject.GetPropertyValue("Id").ToString();
					dtpkglist.Rows.Add(drpkg);
	            }
				
				dgvpkgname.DataSource = dtpkglist;
				dgvpkgname.Columns[0].Width = 297;
				//dgvpkgname.Columns[0].
			}
			catch( Exception ex )
			{
				lberror.Text = "Catch error:"+ex.Message;
			}
		}
		
		private bool ChecklistboxSelected()
		{
			if( lboxiwslist.SelectedIndex == -1 )
			{
				MessageBox.Show("Please select a computer.");
				return false;
			}
			else
				return true;
		}
		
		public static string PingHost(string host)
		{
			//string to hold our return messge
			string returnMessage = string.Empty;
			
			//create a new ping instance
			Ping pingsender = new Ping();
			
			try
			{
				PingReply pingReply = pingsender.Send( host, 100 );
				
				if( pingReply.Status == IPStatus.Success )
				{
					returnMessage = "Online";
				}
				else
				{
					returnMessage = pingReply.Status.ToString();
				}
			}
			catch (PingException ex)
			{
				returnMessage = string.Format("Connection Error: {0}", ex.Message);
			}
						
			return returnMessage;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string str_ouname = "CUTE-WKS";
			string str_entry = string.Format(@"LDAP://OU={0},DC=TSA1-IROOT,DC=LOCAL",str_ouname);
		    DirectoryEntry entry = new DirectoryEntry( str_entry );    
		    DirectorySearcher mySearcher = new DirectorySearcher(entry);

		    mySearcher.Filter = (@"(objectClass=computer)");    
		    mySearcher.SizeLimit = int.MaxValue;
    		mySearcher.PageSize = int.MaxValue;

    		foreach(SearchResult resEnt in mySearcher.FindAll())
		    {
		        string ComputerName = resEnt.Properties["cn"][0].ToString();

		        if (ComputerName.Contains("CK") || ComputerName.Contains("GT") || ComputerName.Contains("TSA1B"))
		        {
		        	lboxiwslist.Items.Add( ComputerName );
		        }
		    }
		
		    mySearcher.Dispose();
		    entry.Dispose();
		}
	}
}
