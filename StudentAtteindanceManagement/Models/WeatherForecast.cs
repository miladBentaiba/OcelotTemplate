namespace StudentAtteindanceManagement.Models
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}

//https://localhost:7264/weatherforecast
//https://localhost:7018/api/StudentAdmission
//https://localhost:7018/weatherforecast
//https://localhost:7264/api/StudentAttendance