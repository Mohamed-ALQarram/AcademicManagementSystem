using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CompositeEntityKeys
{
    public record AttendanceKey(int StudentId, int SectionId);
}
