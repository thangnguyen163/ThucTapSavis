using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_API.Services_IServices.Servies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
// Add DI
builder.Services.AddScoped<IBillItemServies, BillItemServices>();
builder.Services.AddScoped<IBillServices, BillServices>();
builder.Services.AddScoped<ICartItemServices, CartItemServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IColorServices, ColorServices>();
builder.Services.AddScoped<IImageServices, ImageServices>();
builder.Services.AddScoped<IProductItemServices, ProductItemServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IPromotionItemServices, PromotionItemServices>();
builder.Services.AddScoped<IPromotionServices, PromotionServices>();
builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddScoped<ISizeServices, SizeServices>();
builder.Services.AddScoped<IUserServices, UserServices>();


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
