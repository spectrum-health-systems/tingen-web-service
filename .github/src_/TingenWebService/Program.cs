using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;

using TingenWebService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<ITingen, Tingen>();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.UseSoapEndpoint<ITingen>("/Tingen.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
    // Optional Alternative
    // _ = endpoints.UseSoapEndpoint<IScriptLinkService>("/ScriptLinkService.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Run();
