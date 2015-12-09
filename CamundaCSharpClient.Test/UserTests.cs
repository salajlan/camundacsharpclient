namespace CamundaCSharpClient.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CamundaCSharpClient;
    using CamundaCSharpClient.Model;
    using Moq;
    using NUnit.Framework;
    using RestSharp;
    using CamundaCSharpClient.Model.Task;

    [TestFixture]
    public class UserTests
    {
        private UserModel userInfo = new UserModel() { email = "test@test.com", firstName = "Sulaiman", id = "salajlan", lastName = "Alajlan" };
        private Mock<CamundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<CamundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void Delete_ShouldDeleteUser()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenUserIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Delete();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id, req.Resource);
            Assert.AreEqual(Method.DELETE, req.Method);
            Assert.Throws<ArgumentNullException>(delegate { client.User().Delete(); });
        }

        [Test]
        public void Profile_ShouldGetProfileUser()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<UserModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new UserModel());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Profile();
            this.mockClient.Verify(trc => trc.Execute<UserModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id + "/profile", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Profile_ShouldThrowArgumentNullException_WhenUserIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<UserModel>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new UserModel());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Profile();
            this.mockClient.Verify(trc => trc.Execute<UserModel>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id + "/profile", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.Throws<ArgumentNullException>(delegate { client.User().Profile(); });
        }

        [Test]
        public void List_ShouldGetListOfUsers()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<UserModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<UserModel>());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).FirstName(this.userInfo.firstName).list();
            this.mockClient.Verify(trc => trc.Execute<List<UserModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.GetOrPost));
        }

        [Test]
        public void List_ShouldGetListOfUsersWithOrder()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<UserModel>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<UserModel>());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).FirstName(this.userInfo.firstName).sortByNSortOrder(UserQueryModel.SortByValue.email, "desc").list();
            this.mockClient.Verify(trc => trc.Execute<List<UserModel>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(4, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.GetOrPost));
            Assert.AreEqual(req.Parameters.Find(x => x.Name == "sortBy").Value, "email");
        }

        [Test]
        public void Count_ShouldGetCountOfUsers()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).MaxResults(5).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.GetOrPost));
        }

        [Test]
        public void Create_ShouldCreateNewUser()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Create(this.userInfo, "paswordAsString");
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/create", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException_WhenUserDataOrPasswordIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Create(this.userInfo, "paswordAsString");
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/create", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.Throws<ArgumentNullException>(delegate { client.User().Create(null, null); });
            Assert.Throws<ArgumentNullException>(delegate { client.User().Create(null, "s3ecret"); });
            Assert.Throws<ArgumentNullException>(delegate { client.User().Create(this.userInfo, null); });
        }

        [Test]
        public void Update_ShouldUpdateUser()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Update(this.userInfo);
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id + "/profile", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenUserIdOrUserInfoIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.User().Id(this.userInfo.id).Update(this.userInfo);
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/user/" + this.userInfo.id + "/profile", req.Resource);
            Assert.AreEqual(Method.PUT, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
            Assert.Throws<ArgumentNullException>(delegate { client.User().Id(this.userInfo.id).Update(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.User().Update(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.User().Id(null).Update(this.userInfo); });
        }
    }
}
