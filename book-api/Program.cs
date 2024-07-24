using book_api.Author.Service;
using book_api.Book.Service;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Defa‌​ultConnection"));

});

#region Book
builder.Services.AddScoped<CreateBookService>();
builder.Services.AddScoped<DeleteBookService>();
builder.Services.AddScoped<UpdateBookService>();
#endregion

#region Author
builder.Services.AddScoped<CreateAuthorService>();
builder.Services.AddScoped<DeleteAuthorService>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
