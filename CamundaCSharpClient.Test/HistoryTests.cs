namespace CamundaCSharpClient.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CamundaCSharpClient.Model;
    using CamundaCSharpClient.Model.history;
    using Moq;
    using NUnit.Framework;
    using RestSharp;

    public class HistoryTests
    {
        private const string ProcessInstanceId = "37ccd7f9-78c5-11e5-beb3-40a8f0a54b22";
        private Mock<camundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<camundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void Details_ShouldGetListOfHistoricDetails()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<HistoricDetails>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<HistoricDetails>());
            var client = this.mockClient.Object;
            client.History().Details().VariableUpdates(true).ProcessInstanceId(ProcessInstanceId).list();
            this.mockClient.Verify(trc => trc.Execute<List<HistoricDetails>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/detail", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "variableUpdates"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processInstanceId"));
        }

        [Test]
        public void Details_ShouldGetCountOfHistoricDetails()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.History().Details().VariableUpdates(true).ProcessInstanceId(ProcessInstanceId).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/detail/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "variableUpdates"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processInstanceId"));
        }

        [Test]
        public void PI_ShouldGetListOfHistoricPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<HistoryProcessInstance>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<HistoryProcessInstance>());
            var client = this.mockClient.Object;
            client.History().ProcessInstance().Finished(true).StartedBefore(DateTime.Now).list();
            this.mockClient.Verify(trc => trc.Execute<List<HistoryProcessInstance>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/process-instance", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "finished"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "startedBefore"));
        }

        [Test]
        public void PI_ShouldGetCountOfHistoricPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.History().ProcessInstance().Finished(true).StartedBefore(DateTime.Now).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/process-instance/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "finished"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "startedBefore"));
        }

        [Test]
        public void PI_ShouldGetSingleHistoricPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<HistoryProcessInstance>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new HistoryProcessInstance());
            var client = this.mockClient.Object;
            client.History().ProcessInstance().ProcessInstanceId(ProcessInstanceId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<HistoryProcessInstance>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/process-instance/" + ProcessInstanceId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Task_ShouldGetListOfHistoricPI()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<HistoryTask>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<HistoryTask>());
            var client = this.mockClient.Object;
            client.History().Task().ProcessFinished(true).ProcessInstanceId(ProcessInstanceId).list();
            this.mockClient.Verify(trc => trc.Execute<List<HistoryTask>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/task", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processFinished"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processInstanceId"));
        }

        [Test]
        public void Task_ShouldGetCountOfHistoricTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.History().Task().ProcessFinished(true).ProcessInstanceId(ProcessInstanceId).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/history/task/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processFinished"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "processInstanceId"));
        }
    }
}
