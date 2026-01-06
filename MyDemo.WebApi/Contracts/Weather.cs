using System.ComponentModel.DataAnnotations;

namespace MyDemo.WebApi.Contracts;

public class UpdateWeatherLocationRequest
{
    [Required]
    [Range(-90.0, 90.0)]
    public decimal Latitude { get; set; }

    [Required]
    [Range(-180.0, 180.0)]
    public decimal Longitude { get; set; }
}
