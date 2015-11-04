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
    }
}
