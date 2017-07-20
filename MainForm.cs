/*
 * Created by SharpDevelop.
 * User: Tommy
 * Date: 7/16/2017
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Net.NetworkInformation;
using System.Management;


namespace ClientIwsOP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
    		
    		//int i=0;
    		foreach(SearchResult resEnt in mySearcher.FindAll())
		    {
		        string ComputerName = resEnt.Properties["cn"][0].ToString();
		        string str_iwsstate = MainForm.PingHost(ComputerName);
		        //i++;
		        //if( i == 30 )
		        	//break;
		        
		        if (ComputerName.Contains("CK") || ComputerName.Contains("GT") || ComputerName.Contains("TSA1B"))
		        {
		        	ListViewItem item = new ListViewItem(ComputerName);
		        	item.SubItems.Add( str_iwsstate );
		        	if( str_iwsstate != "Online" )
		        		item.BackColor = System.Drawing.Color.Gray;
		        	lv_complist.Items.Add( item );  	
		        }
		    }
		
		    mySearcher.Dispose();
		    entry.Dispose();
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
		
		void Lv_complistItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			lb_test.Text = e.Item.SubItems[0].Text;
			if( e.IsSelected && e.Item.SubItems[1].Text != "Online" )
			{
				e.Item.Selected = false;
				lb_test.Text = "Client Computer is not Online";
			}
		}
		
		void Ckb_mulitselectCheckedChanged(object sender, EventArgs e)
		{
			if( ckb_mulitselect.Checked )
				lv_complist.MultiSelect = true;
			else
				lv_complist.MultiSelect = false;
		}
		
		void Bt_showvspinfoClick(object sender, EventArgs e)
		{
			string str_iws = lv_complist.SelectedItems[0].Text;

			lv_vspinfo.Items.Clear();
			try
			{
				ManagementClass vspClass = new ManagementClass( string.Format(@"\\{0}\root\default:VirtualSoftwarePackage",str_iws) );
				ManagementObjectCollection vspCollection =  vspClass.GetInstances();
				
				List<string> propertyname = new List<string>();
				
				foreach( PropertyData property in vspClass.Properties )
				{
					propertyname.Add( property.Name );
					
				}
				
				ListViewItem lvitem;
				
				foreach (ManagementObject vspObject in vspCollection)
	            {
					int index = propertyname.IndexOf("Name");
					if( index >= 0 )
					{
						lvitem = new ListViewItem( vspObject.GetPropertyValue(propertyname[index]).ToString() );
						
						index = propertyname.IndexOf("Id");
						if( index >= 0 )
							lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						else
							lvitem.SubItems.Add("None");
						
						index = propertyname.IndexOf("Active");
						if( index >= 0 )
							lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						else
							lvitem.SubItems.Add("none");
						
						index = propertyname.IndexOf("ActivatedTime");
						if( index >= 0 )
							lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						else
							lvitem.SubItems.Add("none");
						
						index = propertyname.IndexOf("ResetTime");
						if( index >= 0 )
						{
							lb_result.Text = index.ToString();
							if( vspObject.GetPropertyValue( propertyname[index]) == null )
							{
								lvitem.SubItems.Add("N/A");
							}
							else
								lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						}
						else
							lvitem.SubItems.Add("none");
						
						index = propertyname.IndexOf("CreatedTime");
						if( index >= 0 )
							lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						else
							lvitem.SubItems.Add("none");
						
						index = propertyname.IndexOf("AutoActivate");
						if( index >= 0 )
							lvitem.SubItems.Add( vspObject.GetPropertyValue( propertyname[index]).ToString() );
						else
							lvitem.SubItems.Add("none");
						
						lv_vspinfo.Items.Add( lvitem );
					}
	            }
			}
			catch( Exception ex )
			{
				lb_test.Text = "Catch error:"+ex.Message;
			}
		}
		
		void Bt_activateClick(object sender, EventArgs e)
		{
			/*string str_iws = lv_complist.SelectedItems[0].Text;
			try
			{
				ManagementClass MyClass = new ManagementClass( string.Format(@"\\{0}\root\default:VirtualSoftwarePackage",str_iws) );
				ManagementObjectCollection MyCollection =  MyClass.GetInstances();
				//ListViewItem item1 = new ListViewItem(str_iws);
				lv_vspinfo.Clear();
				
				foreach (ManagementObject MyObject in MyCollection)
	            {
					lv_vspinfo.Items.Add( "ID="+MyObject.Properties["Id"].Value.ToString() );
					lv_vspinfo.Items.Add( "Name="+MyObject.Properties["Name"].Value.ToString() );
					lv_vspinfo.Items.Add( "Active="+MyObject.Properties["Active"].Value.ToString() );
					lv_vspinfo.Items.Add( "AutoActivate="+MyObject.Properties["AutoActivate"].Value.ToString() );
					//item1.SubItems.Add( "ID="+MyObject.Properties["Id"].Value.ToString() );
					//item1.SubItems.Add( "Name="+MyObject.Properties["Name"].Value.ToString() );
	            }
				
			}
			catch( Exception ex )
			{
				lb_test.Text = "Catch error:"+ex.Message;
			}*/
		}
	}
}
