using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class task : camundaBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public string assignee { get; set; }
        public string created { get; set; }
        public object due { get; set; }
        public object followUp { get; set; }
        public object delegationState { get; set; }
        public object description { get; set; }
        public string executionId { get; set; }
        public object owner { get; set; }
        public object parentTaskId { get; set; }
        public int    priority { get; set; }
        public string processDefinitionId { get; set; }
        public string processInstanceId { get; set; }
        public string taskDefinitionKey { get; set; }
        public object caseExecutionId { get; set; }
        public object caseInstanceId { get; set; }
        public object caseDefinitionId { get; set; }
    }
}
