using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XRTSoft.PowerApps.PowerFind.Data;
using XRTSoft.PowerApps.PowerFind.Models;

namespace XRTSoft.PowerApps.PowerFind.Controllers
{
    /// <summary>
    /// Takes care of react to form events and calling data layer to retrieve data.
    /// </summary>
    public class MainController
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="powerFind">The form that the controller is orchestrating.</param>
        /// <param name="worker">Reference to the async worker to use for data operations.</param>
        public MainController(PowerFindControl powerFind)
        {
            PowerFind = powerFind;
            Data = new PowerFindData();
        }

        // Properties

        private PowerFindControl PowerFind { get; set; }

        private PowerFindData Data { get; set; }

        private Settings AppSettings { get; set; }

        internal bool IsConnected => Data.IsSourceConnected;

        // Methods

        internal void Load(Settings appSettings)
        {
            AppSettings = appSettings;
        }

        internal void SetSource(ConnectionDetail detail, IOrganizationService newService)
        {
            Data.SetSource(newService, detail);
        }

        internal async Task Find(string column, bool forms, bool views, bool wflows)
        {
            var timer = new Stopwatch();
            timer.Start();

            // Reset
            PowerFind.Reset();
            PowerFind.Searching();

            // Validate
            if (string.IsNullOrEmpty(column))
            {
                PowerFind.ShowError("Please provide a column to search for.");
                PowerFind.NotSearching();
                return;
            }
            if (!forms && !views && !wflows)
            {
                PowerFind.ShowError("Please choose at least one component to search for.");
                PowerFind.NotSearching();
                return;
            }

            // Search - start tasks for each component
            PowerFind.SetStatus("Searching..");
            var tasks = new List<Task<List<SearchResult>>>();
            if (forms)
            {
                tasks.Add(Data.FindInForms(column));
            }
            if (views)
            {
                tasks.Add(Data.FindInViews(column));
            }
            if (wflows)
            {
                tasks.Add(Data.FindInProcesses(column));
            }

            // wait for them all
            await Task.WhenAll(tasks.ToArray());
            PowerFind.SetStatus("Finished searching");
            var allResults = new List<SearchResult>();
            foreach (var t in tasks)
            {
                var results = await t;
                allResults.AddRange(results);
            }
            allResults = allResults.OrderBy(x => x.Type).ThenBy(x => x.Display).ToList();

            //Completed the work
            timer.Stop();
            PowerFind.RecordEvent("Find", timer.ElapsedMilliseconds);
            PowerFind.SetStatus($"Completed (in {timer.ElapsedMilliseconds}ms)");
            PowerFind.NotSearching();
            PowerFind.DisplayResults(allResults);
        }
    }
}
