using DentalManager.Api.Helpers;
using DentalManagerAPI.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DatabaseConection");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<DentalManagerDBContext>(e => e.UseSqlServer(connection));

builder.Services.AddCors(options =>
{
    options.AddPolicy("testPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IServiceTypeService, ServiceTypeService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IAppointmentPaymentService, AppointmentPaymentService>();
builder.Services.AddScoped<IAppointmentStatusService, AppointmentStatusService>();
builder.Services.AddScoped<IAppointmentService, DentalManagerAPI.Services.AppointmentService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ISalaryPaymentService, SalaryPaymentService>();
builder.Services.AddScoped<IDayService, DayService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ITimeSegmentService, TimeSegmentService>();
builder.Services.AddScoped<IAppointmentServiceService, AppointmentServiceService>();
builder.Services.AddScoped<IWorkerScheduleService, WorkerScheduleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//authenticate for some methods
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[] {}
     }
 });
});

var app = builder.Build();
app.UseCors("testPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();