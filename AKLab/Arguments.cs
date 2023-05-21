using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKLab {
    internal class Arguments {
        public string PathFrom{ get; set; }
        public string PathTo{ get; set; }
        public string Type{ get; set; }

        public Arguments() {
            PathFrom = "not set";
            PathTo = "not set";
            Type = "not set";
        }
    }
}
