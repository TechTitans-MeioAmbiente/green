using CompanyModule.Calculator.CalculatorModels;

namespace CompanyModule.Calculator.CalculatorServices
{
    public class CalculatorService : ICalculatorService
    {
        public double CalculateTotalCarEmissions(CarCalculatorModel model) 
        { 

            return Emissions.DirectEmissionCars(model.NumberCars, model.AverageConsumption, model.AverageDailyDistance);
        }
        public double CalculateTotalAirConditioningEmissions(AirConditioningCalculatorModel model)
        {
            return Emissions.AirConditioningFugitiveEmission(model.NumberDevices, model.Power);
        }

        public double CalculateTotalEnergyEmission(EnergyCalculatorModel model)
        {
            return Emissions.EnergyEmission(model.AverageMonthlyConsumption);
        }
    }
}
