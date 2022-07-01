﻿
namespace Application.TaxCalculator
{
    public interface ITaxCalculatorService
    {
        public double GetRentTax(double grossSalary);
        public double GetCSSTax();
        public double GetTaxPercentage(string taxName, double grossSalary);
        public double GetTaxAmount(string taxName, double grossSalary);
    }
}