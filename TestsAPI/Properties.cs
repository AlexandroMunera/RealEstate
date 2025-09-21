[TestFixture]
public class APITest
{
    private HttpClient _httpClient;

    [OneTimeSetUp]
    public void Setup()
    {
        // Initialize HttpClient
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5125"); // Replace with your API's base URL
    }

    [Test]
    public async Task Test_GetRequest()
    {
        // Arrange
        var endpoint = "/properties";
        // Act
        var response = await _httpClient.GetAsync(endpoint);
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        // Clean up HttpClient
        _httpClient.Dispose();
    }
}