﻿namespace CamundaCSharpClient.Test
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CamundaCSharpClient.Model;
    using CamundaCSharpClient.Model.processDefinition;
    using Moq;
    using NUnit.Framework;
    using RestSharp;

    [TestFixture]
    public class ProcessDefinitionTests
    {
        private const string ProcessDefinitionId = "invoice:1:54302a7a-7736-11e5-bc04-40a8f0a54b22";
        private const string ProcessDefinitionKey = "invoice";
        private Mock<camundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<camundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void List_ShouldListProcessDefinitions()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<processDefinition>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<processDefinition>());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Active(true).list();
            this.mockClient.Verify(trc => trc.Execute<List<processDefinition>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "active"));
        }

        [Test]
        public void SingleResult_ShouldGetProcessDefinitionById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinition());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void SingleResult_ShouldGetProcessDefinitionByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinition());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).singleResult();
            this.mockClient.Verify(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinition());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).singleResult();
            this.mockClient.Verify(trc => trc.Execute<processDefinition>(It.IsAny<IRestRequest>()), Times.Once);
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
            this.mockClient.Setup(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinitionXML());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).Xml();
            this.mockClient.Verify(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/" + ProcessDefinitionId + "/xml", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Xml_ShouldGetProcessDefinitionXmlByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinitionXML());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Xml();
            this.mockClient.Verify(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/xml", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Xml_ShouldThrowArgumentNullException_WhenBothOfPDIdAndKeyIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processDefinitionXML());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Xml();
            this.mockClient.Verify(trc => trc.Execute<processDefinitionXML>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/xml", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Xml(); });
        }

        [Test]
        public void Start_ShouldStartProcessInstanceByKey()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
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
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
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
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/start", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().start<object>(new object()); });
        }

        [Test]
        public void Start_ShouldThrowArgumentNullException_WhenVariablesIsNull()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new processInstance());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).start<object>(new object());
            this.mockClient.Verify(trc => trc.Execute<processInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/start", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Key(ProcessDefinitionKey).start<object>(null); });
        }

        [Test]
        public void Suspend_ShouldSusbendProcessInstanceById()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Id(ProcessDefinitionId).Suspend(new processDefinitionSuspend());
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
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new processDefinitionSuspend());
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
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new processDefinitionSuspend());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/suspended", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Suspend(new processDefinitionSuspend()); });
        }

        [Test]
        public void Suspend_ShouldThrowArgumentNullException_WhenArgumentIsNull()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(new processDefinitionSuspend());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/process-definition/key/" + ProcessDefinitionKey + "/suspended", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.ProcessDefinition().Key(ProcessDefinitionKey).Suspend(null); });
        }
    }
}