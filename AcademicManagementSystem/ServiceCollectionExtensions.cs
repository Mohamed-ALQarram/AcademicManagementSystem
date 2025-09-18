using BLL;
using Core;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicManagementSystem
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectRepositories(this IServiceCollection services)
        {
            // Generic Repositories
            services.AddScoped(typeof(ISingleKeyRepository<>), typeof(SingleKeyRepository<>));
            services.AddScoped(typeof(ICompositeKeyRepository<,>), typeof(CompositeKeyRepository<,>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Specific Repositories
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IIntakeRepository, IntakeRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();

            return services;
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<DepartmentService>();
            services.AddScoped<InstructorService>();
            services.AddScoped<CourseService>();
            services.AddScoped<AttendanceService>();
            services.AddScoped<CourseEnrollmentService>();
            services.AddScoped<IntakeService>();
            services.AddScoped<ScheduleService>();
            services.AddScoped<SectionService>();
            services.AddScoped<StudentService>();
            services.AddScoped<RoomService>();

            return services;
        }
    }
}
