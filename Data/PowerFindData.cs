using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XRTSoft.PowerApps.PowerFind.Models;

namespace XRTSoft.PowerApps.PowerFind.Data
{
    /// <summary>
    /// Retrieves data from the connected Dataverse instance.
    /// </summary>
    internal class PowerFindData
    {
        // Constructors

        /// <summary>
        /// Default contructor.
        /// </summary>
        public PowerFindData()
        {

        }

        // Properties

        private IOrganizationService Source { get; set; }

        private ConnectionDetail SourceDetail { get; set; }

        // Methods

        internal string SourceName => SourceDetail == null ? "" : SourceDetail.ConnectionName;

        internal bool IsSourceConnected => SourceDetail != null;

        internal void SetSource(IOrganizationService source, ConnectionDetail sourceDetail)
        {
            Source = source;
            SourceDetail = sourceDetail;
        }

        internal async Task<List<SearchResult>> FindInForms(string column)
        {
            return await Task.Run(() =>
            {
                var formQuery = new QueryExpression("systemform")
                {
                    ColumnSet = new ColumnSet("name", "type", "formid", "objecttypecode")
                };
                formQuery.Criteria.AddCondition("formxml", ConditionOperator.Like, $"%{column}%");
                var results = Source.RetrieveMultiple(formQuery);

                // Forms
                var searchResults = new List<SearchResult>();
                if (results.Entities.Any())
                {
                    foreach (var e in results.Entities)
                    {
                        var id = e.Id.ToString();
                        var name = e.GetAttributeValue<string>("name");
                        var otc = e.GetAttributeValue<string>("objecttypecode");
                        var type = e.FormattedValues["type"];
                        searchResults.Add(new SearchResult
                        {
                            Display = $"{name} ({otc} {type})",
                            Type = "Form",
                            Id = id 
                        });
                    }
                }
                return searchResults;
            });
        }

        internal async Task<List<SearchResult>> FindInViews(string column)
        {
            return await Task.Run(() =>
            {
                var formQuery = new QueryExpression("savedquery")
                {
                    ColumnSet = new ColumnSet("name", "savedqueryid", "returnedtypecode")
                };
                formQuery.Criteria.AddCondition("layoutxml", ConditionOperator.Like, $"%{column}%");
                var results = Source.RetrieveMultiple(formQuery);

                // Forms
                var searchResults = new List<SearchResult>();
                if (results.Entities.Any())
                {
                    foreach (var e in results.Entities)
                    {
                        var id = e.Id.ToString();
                        var name = e.GetAttributeValue<string>("name");
                        var returnedTypeCode = e.GetAttributeValue<string>("returnedtypecode");
                        searchResults.Add(new SearchResult
                        {
                            Display = $"{name} ({returnedTypeCode})",
                            Type = "View",
                            Id = id
                        });
                    }
                }
                return searchResults;
            });
        }

        internal async Task<List<SearchResult>> FindInProcesses(string column)
        {
            return await Task.Run(() =>
            {
                var activationType = 2;
                var formQuery = new QueryExpression("workflow")
                {
                    ColumnSet = new ColumnSet("name", "workflowid", "category", "formid", "primaryentity", "type")
                };
                formQuery.Criteria.AddCondition("xaml", ConditionOperator.Like, $"%{column}%");
                formQuery.Criteria.AddCondition("type", ConditionOperator.NotEqual, activationType);
                var results = Source.RetrieveMultiple(formQuery);

                // Forms
                var searchResults = new List<SearchResult>();
                if (results.Entities.Any())
                {
                    foreach (var e in results.Entities)
                    {
                        var id = e.Id.ToString();
                        var name = e.GetAttributeValue<string>("name");
                        var cat = e.FormattedValues["category"];
                        var form = e.FormattedValues.Contains("formid") ? e.FormattedValues["formid"] : string.Empty;
                        var entity = e.GetAttributeValue<string>("primaryentity");
                        searchResults.Add(new SearchResult
                        {
                            Display = string.IsNullOrEmpty(form) ? $"{name} ({entity})" : $"{name} ({form}) ({entity})",
                            Type = cat,
                            Id = id
                        });
                    }
                }
                return searchResults;
            });
        }
    }
}
