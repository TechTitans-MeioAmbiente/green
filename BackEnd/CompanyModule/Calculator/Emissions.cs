namespace CompanyModule.Calculator
{
    public class Emissions
    {
        public static double DirectEmissionCars(int nCars,
            double AverageConsumption /*/ em km/litro /*/,
            double AverageDailyDistance /*/ em km para cada carro /*/)
        {
            // Fatores de emissão
            double efCo2 = 2.36; // kg/litro
            double efCh4 = 0.253; // g/litro (será convertido para kg)
            double efN2o = 1.105; // g/litro (será convertido para kg)

            // Global Warming Potential
            double gwpCh4 = 21;
            double gwpN2o = 298;

            double LittersSpent = AverageDailyDistance / AverageConsumption * 220 * 2; //Em litros

            // Calculando a emissão de apenas 1 carro
            double emission = ((LittersSpent * efCo2) / 1000) /*/toneladas de Co2/*/ +
                ((LittersSpent * efCh4 / 1000000) * gwpCh4) +
                ((LittersSpent * efN2o / 1000000) * gwpN2o);

            // Calculando a emissão de todos os carros
            double TotalCarsEmission = emission * nCars;

            return TotalCarsEmission;
        }
        public static double AirConditioningFugitiveEmission(int nDevices, int power /*/ btus - aqui temos que setar apenas 2 escolhas: 9000 ou 12000 btus pq sabemos o kg_refrigerante apenas destes 2/*/)
        {
            // Constantes utilizadas 

            // Vamos setar os ar-condicionados como sendo do tipo R410-A - isso significa que
            // o gás refrigerante (kg_refrigerante) é conhecido, bem como seu GWP (global warming potential)

            // GWP - Global Warming Potential
            double gwpAr = 2.088;

            // Taxa de vazamento -> valor necessario, caso contrario afirmariamos que todos os gases presented no ar condicionado iria para a atmosfera - o que é mentira
            double leakRate = 0.01; // 1% - que é o valor mais baixo para aplicações comerciais 

            // quantidade de gas refrigerante = unidade é em kg, uma media é que tenha 650g em aparelhos de 9000 btus sendo do tipo R410-A e
            // 775 g para 12000 btus

            double kgGas = (power == 9000) ? (650.0 / 1000) : (775.0 / 1000); // em kg 

            // estamos pensando em apenas 1 ano de emissoes, por isso  t = 1

            int t = 1;

            // Calculando a emissão de apenas 1 aparelho
            double emission = kgGas * gwpAr * t * leakRate;

            // Calculando a emissão de todos os aparelhos
            double totalAirConditioningEmission = emission * nDevices;

            return totalAirConditioningEmission;
        }
        public static double EnergyEmission(double averageMonthlyConsumption /*/em KWh/*/)
        {
            // Constantes utilizadas
            // Fator de emissão
            double efElelectricity = 0.5; // kg de CO2 eq./KWh

            //numero de meses
            int nMonths = 12;

            // Calculando a emissão para o período de 1 ano
            double annualEnergyIssuance = (averageMonthlyConsumption * efElelectricity * nMonths) / 1000; // Dividir por 1000 para obter os dados em toneladas de CO2 eq.

            return annualEnergyIssuance;
        }
    }
}
