/*
 * Created by SharpDevelop.
 * User: Tommy
 * Date: 7/16/2017
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientIwsOP
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lv_complist = new System.Windows.Forms.ListView();
			this.ch_IWS = new System.Windows.Forms.ColumnHeader();
			this.ch_Status = new System.Windows.Forms.ColumnHeader();
			this.lb_test = new System.Windows.Forms.Label();
			this.ckb_mulitselect = new System.Windows.Forms.CheckBox();
			this.bt_showvspinfo = new System.Windows.Forms.Button();
			this.lv_vspinfo = new System.Windows.Forms.ListView();
			this.layername = new System.Windows.Forms.ColumnHeader();
			this.guid = new System.Windows.Forms.ColumnHeader();
			this.active = new System.Windows.Forms.ColumnHeader();
			this.activatetime = new System.Windows.Forms.ColumnHeader();
			this.resettime = new System.Windows.Forms.ColumnHeader();
			this.createdtime = new System.Windows.Forms.ColumnHeader();
			this.bt_activate = new System.Windows.Forms.Button();
			this.bt_Deactivate = new System.Windows.Forms.Button();
			this.bt_reset = new System.Windows.Forms.Button();
			this.lb_result = new System.Windows.Forms.Label();
			this.AutoActivated = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lv_complist
			// 
			this.lv_complist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.ch_IWS,
									this.ch_Status});
			this.lv_complist.FullRowSelect = true;
			this.lv_complist.GridLines = true;
			this.lv_complist.Location = new System.Drawing.Point(17, 39);
			this.lv_complist.MultiSelect = false;
			this.lv_complist.Name = "lv_complist";
			this.lv_complist.Size = new System.Drawing.Size(213, 485);
			this.lv_complist.TabIndex = 1;
			this.lv_complist.UseCompatibleStateImageBehavior = false;
			this.lv_complist.View = System.Windows.Forms.View.Details;
			this.lv_complist.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Lv_complistItemSelectionChanged);
			// 
			// ch_IWS
			// 
			this.ch_IWS.Text = "IWS";
			this.ch_IWS.Width = 101;
			// 
			// ch_Status
			// 
			this.ch_Status.Text = "Status";
			this.ch_Status.Width = 104;
			// 
			// lb_test
			// 
			this.lb_test.Location = new System.Drawing.Point(13, 13);
			this.lb_test.Name = "lb_test";
			this.lb_test.Size = new System.Drawing.Size(328, 23);
			this.lb_test.TabIndex = 2;
			this.lb_test.Text = "label1";
			// 
			// ckb_mulitselect
			// 
			this.ckb_mulitselect.Location = new System.Drawing.Point(237, 39);
			this.ckb_mulitselect.Name = "ckb_mulitselect";
			this.ckb_mulitselect.Size = new System.Drawing.Size(104, 24);
			this.ckb_mulitselect.TabIndex = 3;
			this.ckb_mulitselect.Text = "Multiple Select";
			this.ckb_mulitselect.UseVisualStyleBackColor = true;
			this.ckb_mulitselect.CheckedChanged += new System.EventHandler(this.Ckb_mulitselectCheckedChanged);
			// 
			// bt_showvspinfo
			// 
			this.bt_showvspinfo.Location = new System.Drawing.Point(237, 70);
			this.bt_showvspinfo.Name = "bt_showvspinfo";
			this.bt_showvspinfo.Size = new System.Drawing.Size(104, 23);
			this.bt_showvspinfo.TabIndex = 4;
			this.bt_showvspinfo.Text = "Package Info";
			this.bt_showvspinfo.UseVisualStyleBackColor = true;
			this.bt_showvspinfo.Click += new System.EventHandler(this.Bt_showvspinfoClick);
			// 
			// lv_vspinfo
			// 
			this.lv_vspinfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.layername,
									this.guid,
									this.active,
									this.activatetime,
									this.resettime,
									this.createdtime,
									this.AutoActivated});
			this.lv_vspinfo.FullRowSelect = true;
			this.lv_vspinfo.GridLines = true;
			this.lv_vspinfo.Location = new System.Drawing.Point(347, 31);
			this.lv_vspinfo.Name = "lv_vspinfo";
			this.lv_vspinfo.Size = new System.Drawing.Size(601, 504);
			this.lv_vspinfo.TabIndex = 0;
			this.lv_vspinfo.UseCompatibleStateImageBehavior = false;
			this.lv_vspinfo.View = System.Windows.Forms.View.Details;
			// 
			// layername
			// 
			this.layername.Text = "Name";
			this.layername.Width = 130;
			// 
			// guid
			// 
			this.guid.Text = "ID";
			this.guid.Width = 50;
			// 
			// active
			// 
			this.active.Text = "active";
			this.active.Width = 45;
			// 
			// activatetime
			// 
			this.activatetime.Text = "ActivateTime";
			this.activatetime.Width = 100;
			// 
			// resettime
			// 
			this.resettime.Text = "ResetTime";
			this.resettime.Width = 100;
			// 
			// createdtime
			// 
			this.createdtime.Text = "CreatedTime";
			this.createdtime.Width = 100;
			// 
			// bt_activate
			// 
			this.bt_activate.Location = new System.Drawing.Point(237, 100);
			this.bt_activate.Name = "bt_activate";
			this.bt_activate.Size = new System.Drawing.Size(75, 23);
			this.bt_activate.TabIndex = 5;
			this.bt_activate.Text = "Activate";
			this.bt_activate.UseVisualStyleBackColor = true;
			this.bt_activate.Click += new System.EventHandler(this.Bt_activateClick);
			// 
			// bt_Deactivate
			// 
			this.bt_Deactivate.Location = new System.Drawing.Point(237, 130);
			this.bt_Deactivate.Name = "bt_Deactivate";
			this.bt_Deactivate.Size = new System.Drawing.Size(75, 23);
			this.bt_Deactivate.TabIndex = 6;
			this.bt_Deactivate.Text = "Deactivate";
			this.bt_Deactivate.UseVisualStyleBackColor = true;
			// 
			// bt_reset
			// 
			this.bt_reset.Location = new System.Drawing.Point(237, 160);
			this.bt_reset.Name = "bt_reset";
			this.bt_reset.Size = new System.Drawing.Size(75, 23);
			this.bt_reset.TabIndex = 7;
			this.bt_reset.Text = "Reset";
			this.bt_reset.UseVisualStyleBackColor = true;
			// 
			// lb_result
			// 
			this.lb_result.Location = new System.Drawing.Point(237, 190);
			this.lb_result.Name = "lb_result";
			this.lb_result.Size = new System.Drawing.Size(100, 334);
			this.lb_result.TabIndex = 8;
			this.lb_result.Text = "label1";
			// 
			// AutoActivated
			// 
			this.AutoActivated.Text = "AutoActivated";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 547);
			this.Controls.Add(this.lv_vspinfo);
			this.Controls.Add(this.lb_result);
			this.Controls.Add(this.bt_reset);
			this.Controls.Add(this.bt_Deactivate);
			this.Controls.Add(this.bt_activate);
			this.Controls.Add(this.bt_showvspinfo);
			this.Controls.Add(this.ckb_mulitselect);
			this.Controls.Add(this.lv_complist);
			this.Controls.Add(this.lb_test);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "ClientIwsOP";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader AutoActivated;
		private System.Windows.Forms.Label lb_result;
		private System.Windows.Forms.ColumnHeader createdtime;
		private System.Windows.Forms.ColumnHeader resettime;
		private System.Windows.Forms.ColumnHeader activatetime;
		private System.Windows.Forms.ColumnHeader active;
		private System.Windows.Forms.ColumnHeader layername;
		private System.Windows.Forms.Button bt_reset;
		private System.Windows.Forms.Button bt_Deactivate;
		private System.Windows.Forms.Button bt_activate;
		private System.Windows.Forms.ColumnHeader guid;
		private System.Windows.Forms.ListView lv_vspinfo;
		private System.Windows.Forms.Button bt_showvspinfo;
		private System.Windows.Forms.CheckBox ckb_mulitselect;
		private System.Windows.Forms.Label lb_test;
		private System.Windows.Forms.ColumnHeader ch_Status;
		private System.Windows.Forms.ColumnHeader ch_IWS;
		private System.Windows.Forms.ListView lv_complist;
	}
}
