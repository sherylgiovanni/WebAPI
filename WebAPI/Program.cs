using WebAPI.Helper;
using WebAPI.Persistance;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize NHibernate
            NHibernateHelper nhHelper = new NHibernateHelper();

            // Initialize your repositories with the NHibernate session
            IStudentRepository studentRepository = new StudentRepository(nhHelper.OpenSession());

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<NHibernateHelper>();

            builder.Services.AddScoped<NHibernate.ISession>(provider => {
                var nhHelper = provider.GetRequiredService<NHibernateHelper>();
                return nhHelper.OpenSession();
            });
            
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}