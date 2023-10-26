using CompanyModule.Calculator.CalculatorModels;
using CompanyModule.Calculator.CalculatorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;

        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        [HttpPost("car")] 
        public async Task<ActionResult<double>> CalculateTotalCarEmissionsAsync(CarCalculatorModel model)
        {
            var calculation = _service.CalculateTotalCarEmissions(model);
            return Ok(calculation);

        }
        [HttpPost("air-conditioning")]
        public async Task<ActionResult<double>> CalculateTotalAirConditioningEmissions(AirConditioningCalculatorModel model)
        {
            var calculation = _service.CalculateTotalAirConditioningEmissions(model);
            return Ok(calculation);

        }
        [HttpPost("energy")]
        public async Task<ActionResult<double>> CalculateTotalEnergyEmission(EnergyCalculatorModel model)
        {
            var calculation = _service.CalculateTotalEnergyEmission(model);
            return Ok(calculation);

        }
    }
}
