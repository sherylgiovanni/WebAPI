using WebAPI.Helper;
using WebAPI.Persistance;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NHibernateHelper nhHelper = new NHibernateHelper();

            IStudentRepository studentRepository = new StudentRepository(nhHelper.OpenSession());
            IProfessorRepository professorRepository = new ProfessorRepository(nhHelper.OpenSession());
            ICourseRepository courseRepository = new CourseRepository(nhHelper.OpenSession());
            ICourseProfessorRepository courseProfessorRepository = new CourseProfessorRepository(nhHelper.OpenSession());
            IEnrollmentRepository enrollmentRepository = new EnrollmentRepository(nhHelper.OpenSession());

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<NHibernateHelper>();

            builder.Services.AddScoped<NHibernate.ISession>(provider => {
                var nhHelper = provider.GetRequiredService<NHibernateHelper>();
                return nhHelper.OpenSession();
            });
            
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<ICourseProfessorRepository, CourseProfessorRepository>();

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}