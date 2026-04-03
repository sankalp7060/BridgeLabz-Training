using System;
using HealthCareClinicSystem.Interfaces;
using HealthCareClinicSystem.Models;
using HealthCareClinicSystem.Utilities;

namespace HealthCareClinicSystem.Views
{
    public class BillingMenu
    {
        private readonly IBillingService _billingService;
        private readonly IVisitService _visitService;

        public BillingMenu(IBillingService billingService, IVisitService visitService)
        {
            _billingService = billingService;
            _visitService = visitService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        BILLING & PAYMENTS");
                Console.WriteLine("========================================");
                Console.WriteLine("\n1. Generate Bill for Visit");
                Console.WriteLine("2. Record Payment");
                Console.WriteLine("3. View Outstanding Bills");
                Console.WriteLine("4. Generate Revenue Report");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("\n========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateBill();
                        break;
                    case "2":
                        RecordPayment();
                        break;
                    case "3":
                        ViewOutstandingBills();
                        break;
                    case "4":
                        GenerateRevenueReport();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GenerateBill()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        GENERATE BILL FOR VISIT");
            Console.WriteLine("========================================");

            int visitId = InputValidator.GetValidInt("Enter Visit ID: ", 1);

            var visit = _visitService.GetVisitById(visitId);
            if (visit == null)
            {
                Console.WriteLine("\nVisit not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nVisit Details:");
            Console.WriteLine($"Patient: {visit.PatientName}");
            Console.WriteLine($"Doctor: Dr. {visit.DoctorName}");
            Console.WriteLine($"Date: {visit.VisitDate:yyyy-MM-dd}");

            decimal additionalCharges = InputValidator.GetValidDecimal(
                "\nEnter Additional Charges (if any): $",
                0
            );

            int billId = _billingService.GenerateBill(visitId, additionalCharges);

            if (billId > 0)
                Console.WriteLine($"\n✓ Bill generated successfully with ID: {billId}");
            else
                Console.WriteLine("\n✗ Failed to generate bill.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void RecordPayment()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        RECORD PAYMENT");
            Console.WriteLine("========================================");

            int billId = InputValidator.GetValidInt("Enter Bill ID: ", 1);

            var bill = _billingService.GetBillByVisitId(billId);
            if (bill == null)
            {
                Console.WriteLine("\nBill not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nBill Details:");
            Console.WriteLine($"Bill ID: {bill.BillId}");
            Console.WriteLine($"Patient: {bill.PatientName}");
            Console.WriteLine($"Total Amount: ${bill.TotalAmount}");
            Console.WriteLine($"Status: {bill.PaymentStatus}");

            if (bill.PaymentStatus == "PAID")
            {
                Console.WriteLine("\nThis bill is already paid.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nPayment Modes:");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Card");
            Console.WriteLine("3. Insurance");
            Console.WriteLine("4. Online Transfer");

            int paymentChoice = InputValidator.GetValidInt("Select Payment Mode: ", 1, 4);
            string paymentMode = paymentChoice switch
            {
                1 => "Cash",
                2 => "Card",
                3 => "Insurance",
                4 => "Online Transfer",
                _ => "Cash",
            };

            decimal amount = InputValidator.GetValidDecimal(
                $"Enter Amount (Total: ${bill.TotalAmount}): $",
                0
            );

            if (_billingService.RecordPayment(billId, amount, paymentMode))
                Console.WriteLine("\n✓ Payment recorded successfully!");
            else
                Console.WriteLine("\n✗ Failed to record payment.");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewOutstandingBills()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        OUTSTANDING BILLS");
            Console.WriteLine("========================================");

            var bills = _billingService.GetOutstandingBills();

            if (bills.Count == 0)
                Console.WriteLine("\nNo outstanding bills found.");
            else
            {
                Console.WriteLine($"\nTotal Outstanding Bills: {bills.Count}");
                Console.WriteLine("========================================");

                decimal totalOutstanding = 0;
                foreach (var bill in bills)
                {
                    Console.WriteLine($"Bill ID: {bill.BillId}");
                    Console.WriteLine($"Patient: {bill.PatientName}");
                    Console.WriteLine($"Amount: ${bill.TotalAmount}");
                    Console.WriteLine($"Date: {bill.CreatedAt:yyyy-MM-dd}");
                    Console.WriteLine("------------------------");
                    totalOutstanding += bill.TotalAmount;
                }

                Console.WriteLine($"Total Outstanding Amount: ${totalOutstanding:F2}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void GenerateRevenueReport()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        GENERATE REVENUE REPORT");
            Console.WriteLine("========================================");

            DateTime startDate = InputValidator.GetValidDate("Start Date (yyyy-mm-dd): ", false);
            DateTime endDate = InputValidator.GetValidDate("End Date (yyyy-mm-dd): ", false);

            if (endDate < startDate)
            {
                Console.WriteLine("\nEnd date cannot be before start date.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nGroup By:");
            Console.WriteLine("1. Date");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Specialty");

            int groupChoice = InputValidator.GetValidInt("Select Group By: ", 1, 3);
            string groupBy = groupChoice switch
            {
                1 => "date",
                2 => "doctor",
                3 => "specialty",
                _ => "date",
            };

            _billingService.DisplayRevenueReport(startDate, endDate, groupBy);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
