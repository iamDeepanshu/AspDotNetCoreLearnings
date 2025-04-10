var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// to enable XmlDataContractSerializerFormatters, for converting the XML content type to model object
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();



app.Run();
