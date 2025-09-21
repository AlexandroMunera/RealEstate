using System.Net;

[TestFixture]

public class APITest
{
    private HttpClient _httpClient;

    [OneTimeSetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5125");
    }

    [Test]
    public async Task GetRequest()
    {
        // Arrange
        var endpoint = "/properties";
        // Act
        var response = await _httpClient.GetAsync(endpoint);
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GetPropertyById_ShouldReturnSpecificProperty()
    {
        // Arrange
        var propertyId = "68cdf9680304ef0204e88cc0";
        var endpoint = $"/properties/{propertyId}";
        
        // Act
        var response = await _httpClient.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(content, Is.Not.Null.And.Not.Empty);
        Assert.That(content, Does.Contain("id"));
    }

    [Test]
    public async Task GetPropertyById_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidPropertyId = "68cdf9680304ef0299999999";
        var endpoint = $"/properties/{invalidPropertyId}";
        
        // Act
        var response = await _httpClient.GetAsync(endpoint);
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
    }
}