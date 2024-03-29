using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Testing;
using test;

public class ManagerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ManagerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(
            new WebApplicationFactoryClientOptions { AllowAutoRedirect = false }
        );
    }

    [Fact]
    public async void Get_WhenEmpty_ReturnEmptyList()
    {
        var act = await _client.GetAsync("/api/Blacklist");

        Assert.True(act.IsSuccessStatusCode);
        var json = JsonSerializer.Deserialize<string[]>(await act.Content.ReadAsStringAsync());

        Assert.Empty(json);
    }

    [Fact]
    public async void Get_WhenNotEmpty_ReturnNotEmptyList()
    {
        const string word = "Slowo";
        const string URL = "/api/Blacklist?word=" + word;
        await _client.PostAsync(URL, null);
        var act = await _client.GetAsync("/api/Blacklist");

        Assert.True(act.IsSuccessStatusCode);
        var json = JsonSerializer.Deserialize<string[]>(await act.Content.ReadAsStringAsync());
        Assert.Contains(word, json);
    }
}