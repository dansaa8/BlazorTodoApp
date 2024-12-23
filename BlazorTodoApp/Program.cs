using BlazorTodoApp.Components;
using BlazorTodoApp.Contracts;
using BlazorTodoApp.Contracts.Services;
using BlazorTodoApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<TodoAppDbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<ITodoService, ITodoService>();
builder.Services.AddScoped<ITodoRepository, ITodoRepository>();

//builder.Services.AddScoped<ApplicationState>(); // Försök få in appstate
//builder.Services.AddSingleton(IHttpContextAccessor, HttpContextAccessor()); Wut is this?

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
