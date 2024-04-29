using ERPSystem.API.Middleware;
using ERPSystem.Business.Abstract;
using ERPSystem.Business.Concrete;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.DataAccess.Concrete.Context;
using ERPSystem.DataAccess.Concrete.DataManagement;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ERPContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<ICompanyService,CompanyManager>();
builder.Services.AddScoped<IDepartmentService,DepartmentManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IInvoiceService,InvoiceManager>();
builder.Services.AddScoped<IOfferService,OfferManager>();
builder.Services.AddScoped<IProcessTypeService,ProcessTypeManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IRequestService,RequestManager>();
builder.Services.AddScoped<IRoleService,RoleManager>();
builder.Services.AddScoped<IStatusService,StatusManager>();
builder.Services.AddScoped<IStockService,StockManager>();
builder.Services.AddScoped<IStockDetailService,StockDetailManager>();
builder.Services.AddScoped<IUnitService,UnitManager>();
builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IUserRoleService,UserRoleManager>();

builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseGlobalExceptionMiddleware();
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseAuthorization();

app.MapControllers();

app.Run();
