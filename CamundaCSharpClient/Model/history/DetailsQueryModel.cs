using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.History
{
    public class DetailsQueryModel
    {
        public string processInstanceId { get; set; }

        public string activityInstanceId { get; set; }

        public string executionId { get; set; }

        public string caseInstanceId { get; set; }

        public string caseExecutionId { get; set; }

        public string variableInstanceId { get; set; }

        public string formFields { get; set; }

        public string variableUpdates { get; set; }

        public string excludeTaskDetails { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }
    }
}
