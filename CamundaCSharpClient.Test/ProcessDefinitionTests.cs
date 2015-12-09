namespace CamundaCSharpClient.Test
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CamundaCSharpClient.Model;
    using CamundaCSharpClient.Model.ProcessDefinition;
    using Moq;
    using NUnit.Framework;
    using RestSharp;
    using CamundaCSharpClient.Model.ProcessInstance;

    [TestFixture]
    public class ProcessDefinitionTests
    {
        private const string ProcessDefinitionId = "invoice:1:54302a7a-7736-11e5-bc04-40a8f0a54b22";
        private const string ProcessDefinitionKey = "invoice";
        private Mock<CamundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<CamundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void List_ShouldListProcessDefinitions()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<ProcessDefinitionModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<ProcessDefinitionModel>());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Active(true).list();
            this.mockClient.Verify(trc => trc.Execute<List<ProcessDefinitionModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "active"));
        }

        [Test]
        public void List_ShouldListProcessDefinitionsWithOrder()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<ProcessDefinitionModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<ProcessDefinitionModel>());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Active(true).SortByNSortOrder(ProcessDefinitionQueryModel.SortByValue.deploymentId, "desc").list();
            this.mockClient.Verify(trc => trc.Execute<List<ProcessDefinitionModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(3, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "active"));
            Assert.AreEqual(req.Parameters.Find(x => x.Name == "sortBy").Value, "deploymentId");
        }

        [Test]
        public void SingleResult_ShouldGetProcessDefinitionById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void SingleResult_ShouldGetProcessDefinitionByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).singleResult();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).singleResult();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey, req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().singleResult(); });
        }

        [Test]
        public void Count_ShouldGetProcessDefinitionsCount()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "key"));
        }

        [Test]
        public void Xml_ShouldGetProcessDefinitionXmlById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionXMLModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).Xml();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId + "/xml", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Xml_ShouldGetProcessDefinitionXmlByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionXMLModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Xml();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/xml", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Xml_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new ProcessDefinitionXMLModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Xml();
            this.mockClient.Verify(trc => trc.Execute<ProcessDefinitionXMLModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/xml", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Xml(); });
        }

        [Test]
        public void Start_ShouldStartProcessInstanceByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstanceModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/start", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Start_ShouldStartProcessInstanceById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstanceModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).Start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId + "/start", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Start_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstanceModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/start", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Start<object>(new object()); });
        }

        [Test]
        public void Start_ShouldThrowArgumentNullException_WhenVariablesIsNull()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstanceModel());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstanceModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/start", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Key(ProcessDefinitionKey).Start<object>(null); });
        }

        [Test]
        public void Suspend_ShouldSusbendProcessInstanceById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).Suspend(new ProcessDefinitionSuspendModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId + "/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Suspend_ShouldSusbendProcessInstanceByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new ProcessDefinitionSuspendModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/suspended", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Suspend_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new ProcessDefinitionSuspendModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/suspended", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Suspend(new ProcessDefinitionSuspendModel()); });
        }

        [Test]
        public void Suspend_ShouldThrowArgumentNullException_WhenArgumentIsNull()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new ProcessDefinitionSuspendModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/suspended", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(null); });
        }
    }
}
