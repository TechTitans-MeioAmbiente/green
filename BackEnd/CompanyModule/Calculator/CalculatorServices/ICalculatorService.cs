using CompanyModule.Calculator.CalculatorModels;

namespace CompanyModule.Calculator.CalculatorServices
{
    public interface ICalculatorService
    { 
        double CalculateTotalCarEmissions(CarCalculatorModel model);
        double CalculateTotalAirConditioningEmissions(AirConditioningCalculatorModel model);
        double CalculateTotalEnergyEmission(EnergyCalculatorModel model);
    }
}
