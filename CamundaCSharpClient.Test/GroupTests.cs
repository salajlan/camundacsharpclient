using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using CamundaCSharpClient.Model;
using Moq;

namespace CamundaCSharpClient.Test
{
    [TestFixture]
    class GroupTests
    {
        const string GroupTestId = "testId";
        const string GroupTestName = "testName";
        const string GroupTestType = "testType";
        const string GroupTestMember = "testMember";

        const string SecondGroupTestId = "SecondTestId";
        const string SecondGroupTestName = "SecondTestName";
        const string SecondGroupTestType = "SecondTestType";
        const string SecondGroupTestMember = "SecondTestMember";


        private Mock<camundaRestClient> mockClient;
        private group g1;
        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<camundaRestClient>("https://test.dev:8080", "default");
            g1 = new group() { id = GroupTestId, name = GroupTestName, type = GroupTestType };
            mockClient.CallBase = true;
        }
        [Test]
        public void SingleResult_ShouldReturnSingleGroupResult()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute<group>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(g1);
            var client = mockClient.Object;
            client.group().Id(GroupTestId).singleResult();
            mockClient.Verify(trc => trc.Execute<group>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(GroupTestId, client.Execute<group>(req).id);
            Assert.AreEqual(GroupTestType, client.Execute<group>(req).type);
            Assert.AreEqual(GroupTestName, client.Execute<group>(req).name);
        }
        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute<group>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(g1);
            var client = mockClient.Object;
            client.group().Id(GroupTestId).singleResult();
            mockClient.Verify(trc => trc.Execute<group>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().singleResult(); });
        }
        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().Id(GroupTestId).delete();
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().delete(); });
        }
        [Test]
        public void Delete_ShouldDeleteMemberFromGroup()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).delete();
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
        }
        [Test]
        public void Delete_ShouldDeleteGroup()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().Id(GroupTestId).delete();
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreNotEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual("/group/" + GroupTestId , req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
        }
        [Test]
        public void Create_ShouldCreateGroup()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().create(g1);
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
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
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().create(g1);
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.group().create(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.group().Member(GroupTestMember).create(); });
            Assert.Throws<ArgumentNullException>(delegate { client.group().Id(GroupTestId).create(); });
        }
        [Test]
        public void Create_ShouldCreateMemberGroup()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).create();
            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId + "/members/" + GroupTestMember, req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
        }
        [Test]
        public void Count_ShouldGetCountOfGroup()
        {
            IRestRequest req = null;
            mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = mockClient.Object;
            client.group().Id(GroupTestId).Member(GroupTestMember).count();
            mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.AreEqual(GroupTestId, req.Parameters.Find(x => x.Name == "id").Value);
            Assert.AreEqual(GroupTestMember, req.Parameters.Find(x => x.Name == "member").Value);
        }
    }
}
