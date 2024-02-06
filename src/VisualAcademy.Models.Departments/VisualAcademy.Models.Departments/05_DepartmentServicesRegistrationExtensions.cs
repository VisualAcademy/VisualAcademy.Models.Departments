using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VisualAcademy.Models.Departments
{
    // 이 정적 클래스는 IServiceCollection에 대한 확장 메서드를 제공하며, 부서 관련 서비스의 등록을 담당합니다.
    public static class DepartmentServicesRegistrationExtensions
    {
        // 이 메서드는 주어진 IServiceCollection에 DepartmentAppDbContext와 IDepartmentRepository를 추가합니다.
        // dbContext는 제공된 연결 문자열로 구성되며, 그 수명주기는 transient로 설정됩니다.
        // 이는 필요할 때마다 새 인스턴스가 생성되게 함을 의미합니다.
        // 또한 IDepartmentRepository의 구현체인 DepartmentRepository도 transient로 등록되어, 필요할 때마다 새 인스턴스가 생성됩니다.
        public static void AddDependencyInjectionContainerForDepartmentApp(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DepartmentAppDbContext>(options => options.UseSqlServer(connectionString)
            //.EnableSensitiveDataLogging()
            , ServiceLifetime.Transient);
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
