using SignalR.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
  //  endpoints.MapHub<MessageHub>("/message");
});
app.Run();
