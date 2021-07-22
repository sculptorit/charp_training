using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
        public string ProjectName { get; set; }
        public string ProjectDescribe { get; set; }


        public int CompareTo(ProjectData another)
        {
            if (Object.ReferenceEquals(another, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(another.ProjectName);
        }

        public bool Equals(ProjectData another)
        {
            if (Object.ReferenceEquals(another, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, another))
            {
                return true;
            }
            return ProjectName == another.ProjectName;
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + ProjectName;
        }
    }
}
