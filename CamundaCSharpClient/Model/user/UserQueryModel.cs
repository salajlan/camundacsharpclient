using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.Task
{
    public class UserQueryModel
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string firstNameLike { get; set; }

        public string lastName { get; set; }

        public string lastNameLike { get; set; }

        public string email { get; set; }

        public string emailLike { get; set; }

        public string memberOfGroup { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }

        public int? firstResult { get; set; }

        public int? maxResults { get; set; }
    }
}
