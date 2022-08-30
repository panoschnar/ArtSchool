using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Queries
{
    public class TrainerFilteredSettings
    {
        public string searchName { get; set; }
        public string searchCourse { get; set; }
        public int? searchMin { get; set; }
        public int? searchMax { get; set; }
    }
}
