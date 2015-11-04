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
    public class GroupTests
    {
        private const string GroupTestId = "testId";
        private const string GroupTestName = "testName";
        private const string GroupTestType = "testType";
        private const string GroupTestMember = "testMember";

        private Mock<camundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<camundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void SingleResult_ShouldReturnSingleGroupResult()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<group>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new group());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<group>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<group>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new group());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<group>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().singleResult(); });
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().delete(); });
        }

        [Test]
        public void Delete_ShouldDeleteMemberFromGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
        }

        [Test]
        public void Delete_ShouldDeleteGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreNotEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual("/group/" + GroupTestId, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
        }

        [Test]
        public void Create_ShouldCreateGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().create(new group());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/create", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            var par = req.Parameters.Find(x => x.Type == ParameterType.RequestBody);
            Assert.IsNotNull(par);
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().create(new group());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().create(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.group().Member(GroupTestMember).create(); });
            Assert.Throws<ArgumentNullException>(delegate { client.group().Id(GroupTestId).create(); });
        }

        [Test]
        public void Create_ShouldCreateMemberGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).create();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }

        [Test]
        public void Count_ShouldGetCountOfGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.AreEqual(GroupTestId, req.Parameters.Find(x => x.Name == "id").Value);
            Assert.AreEqual(GroupTestMember, req.Parameters.Find(x => x.Name == "member").Value);
        }

        [Test]
        public void Update_ShouldUpdateGroupInfo()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).update(new group());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId, req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenGroupIdOrGroupDataIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).update(new group());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().Id(GroupTestId).update(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.group().update(new group()); });
        }

        [Test]
        public void List_ShouldGetListOfGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<group>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<group>());
            var client = this.mockClient.Object;
            client.group().Id(GroupTestId).list();
            this.mockClient.Verify(trc => trc.Execute<List<group>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "id"));
        }
    }
}
