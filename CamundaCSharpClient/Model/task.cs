using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model
{
    public class task : CamundaBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Assignee { get; set; }

        public string Created { get; set; }

        public object Due { get; set; }

        public object FollowUp { get; set; }

        public object DelegationState { get; set; }

        public object Description { get; set; }

        public string ExecutionId { get; set; }

        public object Owner { get; set; }

        public object ParentTaskId { get; set; }

        public int Priority { get; set; }

        public string ProcessDefinitionId { get; set; }

        public string ProcessInstanceId { get; set; }

        public string TaskDefinitionKey { get; set; }

        public object CaseExecutionId { get; set; }

        public object CaseInstanceId { get; set; }

        public object CaseDefinitionId { get; set; }
    }
}
