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

    [TestFixture]
    public class TaskTests
    {
        private const string TaskId = "37ccd7fe-78c5-11e5-beb3-40a8f0a54b22";
        private const string UserId = "salajlan";
        private const string CommentId = "d7a2ea89-7cae-11e5-beb3-40a8f0a54b22";
        private const string Comment = "test Comment";
        private Mock<CamundaRestClient> mockClient;
        [SetUp]
        public void Setup()
        {
            this.mockClient = new Mock<CamundaRestClient>("https://test.dev:8080", "default");
            this.mockClient.CallBase = true;
        }

        [Test]
        public void Claim_ShouldClaimTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Claim();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/claim", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Claim_ShouldThrowArgumentNullException_WhenUserIdOrTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Claim();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/claim", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().UserId(UserId).Claim(); });
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Claim(); });
        }

        [Test]
        public void Delegate_ShouldDelegateTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Delegate();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/delegate", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Delegate_ShouldThrowArgumentNullException_WhenUserIdOrTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Delegate();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/delegate", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().UserId(UserId).Delegate(); });
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Delegate(); });
        }

        [Test]
        public void Unclaim_ShouldUnclaimTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UnClaim();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/unclaim", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Unclaim_ShouldThrowArgumentNullException_WhenTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).UnClaim();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/unclaim", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().UnClaim(); });
        }

        [Test]
        public void Complete_ShouldCompleteTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Complete(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/complete", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Complete_ShouldAcceptNullArgument()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Complete(null);
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/complete", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
            Assert.AreEqual("{\"variables\":null}", req.Parameters.Find(x => x.Type == ParameterType.RequestBody).Value);
        }

        [Test]
        public void Complete_ShouldThrowArgumentNullException_WhenTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Complete(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/complete", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Complete(null); });
        }

        [Test]
        public void Resolve_ShouldResolveTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Resolve(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/resolve", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Resolve_ShouldAcceptNullArgument()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Resolve(null);
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/resolve", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
            Assert.AreEqual("{\"variables\":null}", req.Parameters.Find(x => x.Type == ParameterType.RequestBody).Value);
        }

        [Test]
        public void Resolve_ShouldThrowArgumentNullException_WhenTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Resolve(new object());
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/resolve", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Resolve(new object()); });
        }

        [Test]
        public void Assignee_ShouldAssigneeTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Assignee();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/assignee", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Assignee_ShouldThrowArgumentNullException_WhenUserIdOrTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new RestResponse());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).UserId(UserId).Assignee();
            this.mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/assignee", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Assignee(); });
            Assert.Throws<ArgumentNullException>(delegate { client.Task().UserId(UserId).Assignee(); });
        }

        [Test]
        public void Comment_ShouldReturnListOfCommentOnTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<TaskComment>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<TaskComment>());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Comment();
            this.mockClient.Verify(trc => trc.Execute<List<TaskComment>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/comment", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Comment_ShouldReturnOneCommentOnTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new TaskComment());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Comment(CommentId);
            this.mockClient.Verify(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreNotEqual("/task/" + TaskId + "/comment", req.Resource);
            Assert.AreEqual("/task/" + TaskId + "/comment/" + CommentId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Comment_ShouldThrowArgumentNullException_WhenTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<TaskComment>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<TaskComment>());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Comment();
            this.mockClient.Verify(trc => trc.Execute<List<TaskComment>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/comment", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Comment(); });
        }

        [Test]
        public void Comment_ShouldThrowArgumentNullException_WhenCommentIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new TaskComment());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Comment(CommentId);
            this.mockClient.Verify(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreNotEqual("/task/" + TaskId + "/comment", req.Resource);
            Assert.AreEqual("/task/" + TaskId + "/comment/" + CommentId, req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Comment(null); });
        }

        [Test]
        public void Create_ShouldCreateCommentOnTheTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new TaskComment());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Create(Comment);
            this.mockClient.Verify(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId + "/comment/create", req.Resource);
            Assert.AreEqual(Method.POST, req.Method);
            Assert.AreEqual(1, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException_WhenCommentMessageOrTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new TaskComment());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Create(Comment);
            this.mockClient.Verify(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/comment/create", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Create(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Create(Comment); });
        }

        [Test]
        public void SingleResult_ShouldGetOneTask()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<task>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new task());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).SingleResult();
            this.mockClient.Verify(trc => trc.Execute<task>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(req);
            Assert.AreEqual("/task/" + TaskId, req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(0, req.Parameters.Count);
            Assert.IsNull(req.Parameters.Find(x => x.Type == ParameterType.RequestBody));
        }

        [Test]
        public void SingleResult_ShouldThrowArgumentNullException_WhenCommentMessageOrTaskIdIsMissing()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new TaskComment());
            var client = this.mockClient.Object;
            client.Task().Id(TaskId).Create(Comment);
            this.mockClient.Verify(trc => trc.Execute<TaskComment>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/" + TaskId + "/comment/create", req.Resource);
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Id(TaskId).Create(null); });
            Assert.Throws<ArgumentNullException>(delegate { client.Task().Create(Comment); });
        }

        [Test]
        public void GetList_ShouldReturnListOfTasks()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<List<task>>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new List<task>());
            var client = this.mockClient.Object;
            client.Task().Get().Active(true).FollowUpDate(DateTime.Now).list();
            this.mockClient.Verify(trc => trc.Execute<List<task>>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count); 
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "active"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "followUpDate"));
        }

        [Test]
        public void GetCount_ShouldReturnCountOfTasks()
        {
            IRestRequest req = null;
            this.mockClient.Setup(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => req = request)
                .Returns(new Count());
            var client = this.mockClient.Object;
            client.Task().Get().Active(true).FollowUpDate(DateTime.Now).count();
            this.mockClient.Verify(trc => trc.Execute<Count>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.AreEqual("/task/count", req.Resource);
            Assert.AreEqual(Method.GET, req.Method);
            Assert.AreEqual(2, req.Parameters.Count);
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "active"));
            Assert.IsNotNull(req.Parameters.Find(x => x.Name == "followUpDate"));
        }
    }
}
