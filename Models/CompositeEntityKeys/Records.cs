using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CompositeEntityKeys
{
    public record CourseEnrollmentKey(int StudentId, int CourseId);
    public record ScheduleKey(int SectionId, int RoomId);
    public record AttendanceKey(int StudentId, int SectionId);
}
