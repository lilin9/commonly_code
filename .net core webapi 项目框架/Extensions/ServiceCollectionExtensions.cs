using api.Service;

namespace api.Extensions; 

//Service 层扩展方法
//将所有 Service 都自动注入到容器中
public static class ServiceCollectionExtensions {
    public static void AddServiceFromAssembly(this IServiceCollection services) {
        //获取所有包含服务的程序集
        var assembly = AppDomain.CurrentDomain.Load("api");
        //获取所有继承 BaseService 接口的服务
        var types = assembly.GetTypes()
            .Where(type => type.IsClass && type.GetInterfaces().Contains(typeof(IBaseService)));
        //将服务注入到容器内
        foreach (var type in types) {
            services.AddScoped(type);
        }
    }
}