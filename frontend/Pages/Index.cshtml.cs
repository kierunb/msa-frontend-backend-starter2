﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages;

public class IndexModel : PageModel
{
    public WeatherForecast[] Forecasts { get; set; }
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


    public async Task OnGet([FromServices]WeatherClient client)
    {
        Forecasts = await client.GetWeatherAsync();
    }
}
