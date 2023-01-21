using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using XrmToolBox.Extensibility;
using XRTSoft.PowerApps.PowerFind.Controllers;
using XRTSoft.PowerApps.PowerFind.Models;

namespace XRTSoft.PowerApps.PowerFind
{
    /// <summary>
    /// The view layer for the control.
    /// </summary>
    public partial class PowerFindControl : PluginControlBase
    {
        // Properties

        private Settings AppSettings;
        private MainController Controller { get; set; }

        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PowerFindControl()
        {
            InitializeComponent();

            // Pass the WorkAsync helper back to the controller
            // This lets us keep data access away from the view.
            Controller = new MainController(this);

            // When the control loads, check for settings
            this.Load += delegate (object sender, EventArgs e)
            {
                if (!SettingsManager.Instance.TryLoad(GetType(), out AppSettings))
                {
                    AppSettings = new Settings();
                }
                Reset();
                Controller.Load(AppSettings);
            };

            // When the user clicks the find button, find results
            this.btnFind.Click += async delegate (object sender, EventArgs e)
            {
                // Check we are online
                ExecuteMethod(CheckWeAreConnected);

                if (!Controller.IsConnected)
                {
                    return;
                }
                var col = txtColumn.Text;
                await Controller.Find(col, chkForms.Checked, chkViews.Checked, chkWorkflows.Checked);
            };
        }

        // Methods

        /// <summary>
        /// Called when the user changes the connection - ask the controller to handle.
        /// </summary>
        /// <param name="newService">The new service that has been connected to.</param>
        /// <param name="detail">The detail of the connection made.</param>
        /// <param name="actionName">The action taken.</param>
        /// <param name="parameter">Additional parameters.</param>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            Controller.SetSource(detail, newService);
        }

        internal void Reset()
        {
            base.HideNotification();
            dgvResults.Invoke(() =>
            {
                dgvResults.DataSource = null;
                dgvResults.Hide();
            });
            tsslMain.Text = "Please provide the column and components to search for.";
        }

        internal void UpdateWorkingMessage(string msg)
        {
            SetWorkingMessage(msg);
        }

        internal void SetStatus(string status)
        {
            tsslMain.Text = status;
        }

        internal void Searching()
        {
            lblSearching.Invoke(() =>
            {
                lblSearching.Visible = true;
            });
        }

        internal void NotSearching()
        {
            lblSearching.Invoke(() =>
            {
                lblSearching.Visible = false;
            });
        }

        internal void ShowError(string msg)
        {
            base.ShowErrorNotification(msg, null, 16);
        }

        internal void DisplayResults(List<SearchResult> allResults)
        {
            dgvResults.Invoke(() =>
            {
                dgvResults.Rows.Clear();
                foreach (var r in allResults)
                {
                    var index = dgvResults.Rows.Add();
                    var newRow = dgvResults.Rows[index];
                    newRow.Cells[0].Value = r.Type;
                    newRow.Cells[1].Value = r.Display;
                    newRow.Cells[2].Value = r.Id;
                }
                dgvResults.Show();
            });
        }
        internal void CheckWeAreConnected()
        {
            // Check works without actually calling Dynamics
            // So this method is arbitrary
        }

        internal void RecordEvent(string eventName, long ms)
        {
            LogInfo($"{eventName}\t\t{ms}ms");
        }
    }
}