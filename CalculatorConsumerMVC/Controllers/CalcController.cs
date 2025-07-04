using CalculatorConsumerMVC.Models;
using Microsoft.AspNetCore.Mvc;

public class CalcController : Controller
{
    private readonly HttpClient _httpClient;

    public CalcController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7149/"); 
    }

    [HttpPost]
    public async Task<IActionResult> Index(CalculatorInput input)
    {
        try
        {
            string endpoint = input.Operation.ToLower();
            string url = $"api/calculator/{endpoint}?num1={input.A}&num2={input.B}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                input.Result = double.Parse(result); // assuming API returns plain double
            }
            else
            {
                ViewBag.Error = $"API Error: {response.ReasonPhrase}";
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Exception: {ex.Message}";
        }

        return View(input);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new CalculatorInput());
    }
}
