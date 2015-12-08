using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.ProcessDefinition
{
    public class ProcessDefinitionQueryModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public string nameLike { get; set; }

        public string deploymentId { get; set; }

        public string key { get; set; }

        public string keyLike { get; set; }

        public string category { get; set; }

        public string categoryLike { get; set; }

        public int? version { get; set; }

        public string latestVersion { get; set; }

        public string resourceName { get; set; }

        public string resourceNameLike { get; set; }

        public string startableBy { get; set; }

        public string active { get; set; }

        public string suspended { get; set; }

        public string incidentId { get; set; }

        public string incidentType { get; set; }

        public string incidentMessage { get; set; }

        public string incidentMessageLike { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public string caseInstanceId { get; set; }

        public string businessKey { get; set; }
    }
}
