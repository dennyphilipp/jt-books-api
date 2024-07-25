using book_api.Author.Controller;
using book_api.Author.Service;
using book_api.Book.Service;
using book_api.Infrastructure.Exception;
using book_api.Payment.Service;
using book_api.Persistence;
using book_api.Subject.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Defa‌​ultConnection"));

});
builder.Services.AddCors();

#region Book
builder.Services.AddScoped<CreateBookService>();
builder.Services.AddScoped<DeleteBookService>();
builder.Services.AddScoped<UpdateBookService>();
builder.Services.AddScoped<FindBookService>();

#endregion

#region Author
builder.Services.AddScoped<CreateAuthorService>();
builder.Services.AddScoped<DeleteAuthorService>();
builder.Services.AddScoped<UpdateAuthorService>();
builder.Services.AddScoped<FindAuthorService>();
#endregion

#region Payment
builder.Services.AddScoped<CreatePaymentTypeService>();
builder.Services.AddScoped<UpdatePaymentTypeService>();
builder.Services.AddScoped<DeletePaymentTypeService>();
builder.Services.AddScoped<FindPaymentTypeService>();

builder.Services.AddScoped<CreatePaymentService>();
builder.Services.AddScoped<UpdatePaymentService>();
builder.Services.AddScoped<DeletePaymentService>();
#endregion

#region Subject
builder.Services.AddScoped<CreateSubjectService>();
builder.Services.AddScoped<UpdateSubjectService>();
builder.Services.AddScoped<DeleteSubjectService>();
builder.Services.AddScoped<FindSubjectService>();

#endregion

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler();
app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials
app.Run();
