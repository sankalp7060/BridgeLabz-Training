using System;
using System.Collections.Generic;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;

namespace HealthCareClinicSystem.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IDoctorRepository _doctorRepository;

        public BillingService(
            IBillingRepository billingRepository,
            IDoctorRepository doctorRepository
        )
        {
            _billingRepository = billingRepository;
            _doctorRepository = doctorRepository;
        }

        public int GenerateBill(int visitId, decimal additionalCharges)
        {
            decimal consultationFee = 500;
            return _billingRepository.GenerateBill(visitId, consultationFee, additionalCharges);
        }

        public bool RecordPayment(int billId, decimal amount, string paymentMode)
        {
            return _billingRepository.RecordPayment(billId, amount, paymentMode);
        }

        public List<Bill> GetOutstandingBills()
        {
            return _billingRepository.GetOutstandingBills();
        }

        public void DisplayRevenueReport(DateTime startDate, DateTime endDate, string groupBy)
        {
            var revenue = _billingRepository.GetRevenueReport(startDate, endDate, groupBy);

            Console.WriteLine($"\nRevenue Report ({startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd})");
            Console.WriteLine($"Grouped by: {groupBy}");
            Console.WriteLine("========================================");

            decimal total = 0;
            foreach (var item in revenue)
            {
                Console.WriteLine($"{item.Key}: ${item.Value:F2}");
                total += item.Value;
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total Revenue: ${total:F2}");
        }

        public Bill GetBillByVisitId(int visitId)
        {
            return _billingRepository.GetBillByVisitId(visitId);
        }
    }
}
