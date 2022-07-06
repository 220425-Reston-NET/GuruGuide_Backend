using GuruGuideBL;
using GuruGuideDL;
using GuruGuideModels;
using GuruGuideModles;

var builder = WebApplication.CreateBuilder(args);

//Adding CORS
builder.Services.AddCors(
    (options) => {
        options.AddDefaultPolicy(origin => {
            origin.AllowAnyOrigin();
            origin.AllowAnyMethod();
            origin.AllowAnyHeader();
        });
    }
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Appointments>, SQLAppointmentsRepository>(repo => new SQLAppointmentsRepository(builder.Configuration.GetConnectionString("Maaz Umer Store")));
builder.Services.AddScoped<IAppointmentsBL, AppointmentsBL>();
builder.Services.AddScoped<IRepository<Customers>, SQLCustomersRepository>(repo => new SQLCustomersRepository(builder.Configuration.GetConnectionString("Maaz Umer Store")));
builder.Services.AddScoped<ICustomersBL, CustomersBL>();
builder.Services.AddScoped<IRepository<Coaches>, SQLCoachesRepository>(repo => new SQLCoachesRepository(builder.Configuration.GetConnectionString("Maaz Umer Store")));
builder.Services.AddScoped<ICoachesBL, CoachesBL>();
// builder.Services.AddScoped<IRepository<Store>, SQLStoreRepository>(repo => new SQLStoreRepository(builder.Configuration.GetConnectionString("Maaz Umer Store")));
// builder.Services.AddScoped<IStoreBL, StoreBL>();

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
