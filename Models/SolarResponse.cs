

namespace SolarCompanyWebsite.Models
{
    public class SolarResponse
    {
        public SolarPotential solarPotential { get; set; }
    }

    public class SolarPotential
    {
        public float maxArrayAreaMeters2 { get; set; }
        public float carbonOffsetFactorKgPerMwh { get; set; }
        public FinancialAnalysis[] financialAnalyses { get; set; }
        public float yearlyEnergyDcKwh { get; set; }
    }

    public class FinancialAnalysis
    {
        public Money monthlyBill { get; set; }
        public float averageKwhPerMonth { get; set; }
        public FinancialDetails financialDetails { get; set; }
        public LeasingSavings leasingSavings { get; set; }
        public CashPurchaseSavings cashPurchaseSavings { get; set; }
        public FinancedPurchaseSavings financedPurchaseSavings { get; set; }

        public int panelConfigIndex { get; set; }
    }

    public class FinancialDetails
    {
        public float initialAcKwhPerYear { get; set; }
        public Money remainingLifetimeUtilityBill { get; set; }
        public Money federalIncentive { get; set; }
        public Money stateIncentive { get; set; }
        public Money utilityIncentive { get; set; }
        public Money costOfElectricityWithoutSolar { get; set; }
        public bool netMeteringAllowed { get; set; }
        public float solarPercentage { get; set; }
        public int percentageExportedToGrid { get; set; }
    }

    public class PurchaseSavings
    {
        public float upfrontCost { get; set; }
        public float paybackYears { get; set; }
        public SavingsOverTime savings { get; set; }  // Array for cumulative savings over time
    }

    public class RoofSegmentStats
    {
        public float areaMeters2 { get; set; }
        public float[] sunshineQuantiles { get; set; }
        public int panelsCount { get; set; }
    }

    public class Money
    {
        public string currencyCode { get; set; }
        public string units { get; set; }
        public int nanos { get; set; }
    }

    public class SavingsOverTime
    {
        public Money savingsYear1 { get; set; }
        public Money savingsYear20 { get; set; }
        public Money presentValueOfSavingsYear20 { get; set; }
        public Money savingsLifetime { get; set; }
        public Money presentValueOfSavingsLifetime { get; set; }
        public bool financiallyViable { get; set; }
    }

    public class LeasingSavings
    {
        public bool leasesAllowed { get; set; }
        public bool leasesSupported { get; set; }
        public Money annualLeasingCost { get; set; }
        public SavingsOverTime savings { get; set; }
    }

    public class FinancedPurchaseSavings
    {
        public Money annualLoanPayment { get; set; }
        public Money rebateValue { get; set; }
        public double loanInterestRate { get; set; }
        public SavingsOverTime savings { get; set; }
    }

    public class CashPurchaseSavings
    {
        public Money outOfPocketCost { get; set; }
        public Money upfrontCost { get; set; }
        public Money rebateValue { get; set; }
        public SavingsOverTime savings { get; set; }
        public double paybackYears { get; set; }
    }
}
