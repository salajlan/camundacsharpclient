namespace CamundaCSharpClient.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CamundaCSharpClient.Model;
    using Moq;
    using NUnit.Framework;
    using RestSharp;

    [TestFixture]
    public class ProcessInstanceTests
    {
        private const string ProcessInstanceId = "37ccd7f9-78c5-11e5-beb3-40a8f0a54b22";
        private const string ProcessDefinfitionKey = "invoice";
        private const string ProcessDefifnionId = "invoice:1:54302a7a-7736-11e5-bc04-40a8f0a54b22";
        private const string VarId = "TestVarId";
        private Mock<camundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<camundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void SingleResult_ShouldSingleReturnProcessInstance()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).SingleResult();
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenPInstanceIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).SingleResult();
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId, req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().SingleResult(); });
        }

        [Test]
        public void Delete_ShouldDeleteVariable()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).VarId(VarId).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables/" + VarId, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Delete_ShouldDeleteProcessInstance()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenPInstanceIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().Delete(); });
        }

        [Test]
        public void Variables_ShouldGetVariablesOfPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<object>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new object());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Variables<object>();
            this.mockClient.Verify(trc => trc.Execute<object>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Variables_ShouldGetVariableOfVarIdNPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<object>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new object());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).VarId(VarId).Variables<object>();
            this.mockClient.Verify(trc => trc.Execute<object>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables/" + VarId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Variables_ShouldThrowArgumentNullException_WhenBothOfPInstanceIdNVarIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<object>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new object());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Variables<object>();
            this.mockClient.Verify(trc => trc.Execute<object>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().Variables<object>(); });
        }

        [Test]
        public void Variables_ShouldModifiNDeleteVariables()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Variables<object>(new object(), new string[] { null });
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Variables_ShouldSetVariable()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).VarId(VarId).Variables<object>(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables/" + VarId, req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Variables_ShouldThrowArgumentNullException_WhenPInstanceIdOrVarIdOrVarDataIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).VarId(VarId).Variables<object>(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/variables/" + VarId, req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().Id(ProcessInstanceId).VarId(VarId).Variables<object>(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().Id(ProcessInstanceId).Variables<object>(new object()); });
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().VarId(VarId).Variables<object>(null); });
        }

        [Test]
        public void Suspend_ShouldSusbendPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).Suspended(true).Suspend();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Suspend_ShouldSusbendPDById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().ProcessDefinitionId(ProcessDefifnionId).Suspended(true).Suspend();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Suspend_ShouldSusbendPDByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().ProcessDefinitionKey(ProcessDefinfitionKey).Suspended(true).Suspend();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Suspend_ShouldThrowArgumentNullException_WhenBothOfPInstanceIdNPDIdNPDKeyOrSuspendedIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessInstance().ProcessDefinitionKey(ProcessDefinfitionKey).Suspended(true).Suspend();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().Suspended(true).Suspend(); });
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().ProcessDefinitionKey(ProcessDefinfitionKey).Suspend(); });
        }

        [Test]
        public void ActivityInstance_ShouldGetActivityInstance()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<activityInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new activityInstance());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).ActivityInstance();
            this.mockClient.Verify(trc => trc.Execute<activityInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/activity-instances", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void ActivityInstance_ShouldThrowArgumentNullException_WhenPIIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<activityInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new activityInstance());
            var client = this.mockClient.Object;
            client.ProcessInstance().Id(ProcessInstanceId).ActivityInstance();
            this.mockClient.Verify(trc => trc.Execute<activityInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/" + ProcessInstanceId + "/activity-instances", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessInstance().ActivityInstance(); });
        }

        [Test]
        public void GetList_ShouldListProcessInstance()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<processInstance>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<processInstance>());
            var client = this.mockClient.Object;
            client.ProcessInstance().Get().Active(true).MaxResults(20).list();
            this.mockClient.Verify(trc => trc.Execute<List<processInstance>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.AreEqual("active", req.Parameters.Find(x => x.Name == "active").Name);
            Assert.AreEqual("maxResults", req.Parameters.Find(x => x.Name == "maxResults").Name);
        }

        [Test]
        public void GetCount_ShouldGetCountOfProcessInstance()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.ProcessInstance().Get().Active(true).MaxResults(20).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-instance/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.AreEqual("active", req.Parameters.Find(x => x.Name == "active").Name);
            Assert.AreEqual("maxResults", req.Parameters.Find(x => x.Name == "maxResults").Name);
        }
    }
}
