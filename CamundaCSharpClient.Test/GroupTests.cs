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
    using CamundaCSharpClient.Model.Group;    

    [TestFixture]
    public class GroupTests
    {
        private const string GroupTestId = "testId";
        private const string GroupTestName = "testName";
        private const string GroupTestType = "testType";
        private const string GroupTestMember = "testMember";

        private Mock<CamundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<CamundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void SingleResult_ShouldReturnSingleGroupResult()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<GroupModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new GroupModel());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<GroupModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group/" + GroupTestId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<GroupModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new GroupModel());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).singleResult();
            this.mockClient.Verify(trc => trc.Execute<GroupModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.Group().singleResult(); });
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenGroupIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Delete(); });
        }

        [Test]
        public void Delete_ShouldDeleteMemberFromGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).Member(GroupTestMember).Delete();
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
            client.Group().Id(GroupTestId).Delete();
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
            client.Group().Create(new GroupModel());
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
            client.Group().Create(new GroupModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Create(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Member(GroupTestMember).Create(); });
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Id(GroupTestId).Create(); });
        }

        [Test]
        public void Create_ShouldCreateMemberGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).Member(GroupTestMember).Create();
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
            client.Group().Id(GroupTestId).Member(GroupTestMember).Count();
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
            client.Group().Id(GroupTestId).Update(new GroupModel());
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
            client.Group().Id(GroupTestId).Update(new GroupModel());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Id(GroupTestId).Update(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.Group().Update(new GroupModel()); });
        }

        [Test]
        public void List_ShouldGetListOfGroup()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<GroupModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<GroupModel>());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).list();
            this.mockClient.Verify(trc => trc.Execute<List<GroupModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "id"));
        }

        [Test]
        public void List_ShouldGetListOfGroupWithOrder()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<GroupModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<GroupModel>());
            var client = this.mockClient.Object;
            client.Group().Id(GroupTestId).SortByAndSortOrder(GroupQueryModel.SortByValues.name, "desc").list();
            this.mockClient.Verify(trc => trc.Execute<List<GroupModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/group", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(3, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "id"));
            Assert.AreEqual(req.Parameters.Find(x => x.Name == "sortBy").Value, "name");
        }
    }
}
