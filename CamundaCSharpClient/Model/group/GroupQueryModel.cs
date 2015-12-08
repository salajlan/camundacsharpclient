using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamundaCSharpClient.Model.Group
{
    public class GroupQueryModel
    {
        public string nameLike { get; set; }

        public string name { get; set; }

        public string id { get; set; }

        public string type { get; set; }

        public string member { get; set; }

        public int? maxResults { get; set; }

        public int? firstResult { get; set; }

        public string sortBy { get; set; }

        public string sortOrder { get; set; }
    }
}
