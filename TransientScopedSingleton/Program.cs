using TransientScopedSingleton.Services;
using TransientScopedSingleton.Services.ScopedService;
using TransientScopedSingleton.Services.SingletonService;
using TransientScopedSingleton.Services.TransientService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddTransient<ITransientService, OperationService>()
    .AddScoped<IScopedService, OperationService>()
    .AddSingleton<ISingletonService, OperationService>();

/*
 * Understanding the life cycle of Dependency Injection (DI) is very important in ASP.Net Core applications.
 * As we know, Dependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies.
 * Most often, classes will declare their dependencies via their constructor, allowing them to follow the Explicit Dependencies Principle.
 * This approach is known as "constructor injection".
 * 
 * To implement dependency injection, we need to configure a DI container with classes that is participating in DI.
 * DI Container has to decide whether to return a new instance of the service or provide an existing instance.
 * In startup class, we perform this activity on ConfigureServices method.
 * 
 * The lifetime of the service depends on when the dependency is instantiated and how long it lives.
 * And lifetime depends on how we have registered those services.
 * 
 * AddTransient
 * -------------
 * Transient lifetime services are created each time they are instantiated.
 * This lifetime works best for lightweight, stateless services.
 * Examples: email and SMS sending, unique codes for users creation, currency conversion, database migration/update processing, etc., services
 * 
 * AddScoped
 * ----------
 * Scoped lifetime services are instantiated once per request.
 * Examples: database context, expensive computations, shopping cart, user-uploaded processing, user session, etc., services
 * 
 * AddSingleton
 * -------------
 * Singleton lifetime services are instantiated the first time they are requested (or when ConfigureServices is run if you specify an instance there) 
 * and then every subsequent request will use the same instance.
 * Examples: logging, configuration, caching, message queueing, etc., services
 * 
 */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

