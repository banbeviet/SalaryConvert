using System;
using System.Data;

public class SalaryInfor
{
    public double Salary { get; set; }
    public double Income { get; set; }
    public int RegionCode { get; set; }
    public double InsuranceSalar { get; set; }
    public int TotalDependentPersion { get; set; }

}
public class SalaryDetail
{
    public double GrossSalary { get; set; }
    public double SocialInsurance  { get; set; }
    public double HealthInsurance { get; set; }
    public double UnemploymentInsurance { get; set; }
    public double IncomeBeforeTax { get; set; }
    public double PersionalSituation { get; set; }
    public double DependentSituation { get; set; }
    public double IncomeTaxes { get; set; }
    public double PersionalIncomeTax { get; set; }
    public double NetSalary { get; set; }
}
class EmployersPaymentInfor
{
    public double GrossSalary { get; set; }
    public double SocialInsurance { get; set; }
    public double AccidentInsurance { get; set; }
    public double HealthInsurance { get; set; }
    public double UnemploymentInsurance { get; set; }
    public double TotalPayment { get; set; }
}

class Region
{

}

namespace SalaryConverting
{
    internal class Program
    {
        static SalaryInfor InputInfor()
        {
            SalaryInfor salaryInfor = new SalaryInfor();
            //income
            Console.WriteLine("Nhap vao muc thu nhap : ");
            int Income = int.Parse(Console.ReadLine());
            salaryInfor.Income = Income;

            //ChoseInsuranceSalar
            Console.WriteLine("Muc luong dong bao hiem : ");
            Console.WriteLine("0 .  Muc luong dong bao hiem voi so khac ");
            Console.WriteLine("1 .  Muc luong dong bao hiem tren luong chinh thuc");
            double ChoseInsuranceSalar = 0;
            while (true)
            {
                ChoseInsuranceSalar = double.Parse(Console.ReadLine());
                try
                {
                    if (ChoseInsuranceSalar == 1)
                    {
                        salaryInfor.InsuranceSalar = salaryInfor.Income;
                        break;
                    }
                    else if (ChoseInsuranceSalar == 0)
                    {
                        Console.WriteLine("Nhap muc luong dong bao hiem voi so khac : ");
                        salaryInfor.InsuranceSalar = int.Parse(Console.ReadLine());
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui long nhap lai lua chon cua ban ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            //Region
            Console.WriteLine("Vùng : ");
            Console.WriteLine("1 . Vung 1 \n2 . Vung 2 \n3 . Vung 3 \n4 . Vung 4");
            int RegionCode = 0;
            while (true)
            {
                try
                {
                    RegionCode = int.Parse(Console.ReadLine());
                    if (RegionCode > 0 && RegionCode <= 4)
                    {
                        salaryInfor.RegionCode = RegionCode;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui long nhap lai lua chon cua ban ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            //TotalDependentPersion
            Console.WriteLine("So nguoi phu thuoc : ");
            int TotalDependentPersion = int.Parse(Console.ReadLine());
            salaryInfor.TotalDependentPersion = TotalDependentPersion;
            return salaryInfor;
        }
        //Caculate Personal Income Tax salary
        public static double CaculatePersionalIncomeTax(double incomeTaxes)
        {
            double PersionalIncomeTax = 0;
            //Step 1
            if (incomeTaxes > 0 && incomeTaxes < 5000000)
            {
                PersionalIncomeTax = incomeTaxes * 0.05;
            }
            //Step2
            else if (incomeTaxes > 5000000 && incomeTaxes < 10000000)
            {
                PersionalIncomeTax = (incomeTaxes - 5000000) * 0.1 + 250000;
            }
            //Step3
            else if (incomeTaxes > 10000000 && incomeTaxes < 18000000)
            {
                PersionalIncomeTax = (incomeTaxes - 10000000) * 0.15 + 750000;
            }
            //Step4
            else if (incomeTaxes > 18000000 && incomeTaxes < 32000000)
            {
                PersionalIncomeTax = (incomeTaxes - 18000000) * 0.2 + 1950000;
            }
            //Step5
            else if (incomeTaxes > 32000000 && incomeTaxes < 52000000)
            {
                PersionalIncomeTax = (incomeTaxes - 32000000) * 0.25 + 4750000;
            }
            //Step6
            else if (incomeTaxes > 52000000 && incomeTaxes < 80000000)
            {
                PersionalIncomeTax = (incomeTaxes - 52000000) * 0.3 + 9750000;
            }
            //Step7
            else if (incomeTaxes > 80000000)
            {
                PersionalIncomeTax = (incomeTaxes - 80000000) * 0.35 + 18150000;
            }
            return PersionalIncomeTax;
        }
        public static SalaryDetail GrossToNetCaculate(SalaryInfor salaryInfor)
        {
            SalaryDetail salaryDetail = new SalaryDetail();

            salaryDetail.GrossSalary = salaryInfor.Income;
            salaryDetail.SocialInsurance = salaryDetail.GrossSalary * 8 / 100;
            salaryDetail.HealthInsurance = salaryDetail.GrossSalary * 1.5 / 100;
            salaryDetail.UnemploymentInsurance = salaryDetail.GrossSalary * 1 / 100;
            salaryDetail.IncomeBeforeTax = salaryInfor.Income -  salaryDetail.SocialInsurance - salaryDetail.UnemploymentInsurance - salaryDetail.HealthInsurance;
            salaryDetail.PersionalSituation = 11000000;
            salaryDetail.DependentSituation = salaryInfor.TotalDependentPersion * 4400000;
            salaryDetail.IncomeTaxes = salaryDetail.IncomeBeforeTax - salaryDetail.PersionalSituation - salaryDetail.DependentSituation;
            if(salaryDetail.IncomeTaxes <= 0)
            {
                salaryDetail.IncomeTaxes = 0;
            }
            salaryDetail.PersionalIncomeTax = CaculatePersionalIncomeTax(salaryDetail.IncomeTaxes);
            salaryDetail.NetSalary = salaryDetail.IncomeBeforeTax - salaryDetail.PersionalIncomeTax;
            return salaryDetail;
        }
        public static SalaryDetail NetToGrossCaculate(SalaryInfor salaryInfor)
        {
            SalaryDetail salaryDetail = new SalaryDetail();

            salaryDetail.GrossSalary = salaryInfor.Income / (1-0.08-0.015-0.01) ;
            salaryDetail.SocialInsurance = salaryDetail.GrossSalary * 8 / 100;
            salaryDetail.HealthInsurance = salaryDetail.GrossSalary * 1.5 / 100;
            salaryDetail.UnemploymentInsurance = salaryDetail.GrossSalary * 1 / 100;
            salaryDetail.IncomeBeforeTax = salaryInfor.Income;
            salaryDetail.PersionalSituation = 11000000;
            salaryDetail.DependentSituation = salaryInfor.TotalDependentPersion * 4400000;
            salaryDetail.IncomeTaxes = salaryDetail.IncomeBeforeTax - salaryDetail.PersionalSituation - salaryDetail.DependentSituation;
            if (salaryDetail.IncomeTaxes <= 0)
            {
                salaryDetail.IncomeTaxes = 0;
            }
            salaryDetail.PersionalIncomeTax = CaculatePersionalIncomeTax(salaryDetail.IncomeTaxes);
            salaryDetail.NetSalary = salaryInfor.Income;

            return salaryDetail;
        }

        public static EmployersPaymentInfor CaculateEmployersPayment(SalaryDetail salaryDetail)
        {
            EmployersPaymentInfor employersPaymentInfor = new EmployersPaymentInfor();
            employersPaymentInfor.GrossSalary = salaryDetail.GrossSalary;
            employersPaymentInfor.SocialInsurance = employersPaymentInfor.GrossSalary * 17 / 100;
            employersPaymentInfor.AccidentInsurance = employersPaymentInfor.GrossSalary * 0.5 / 100;
            employersPaymentInfor.HealthInsurance = employersPaymentInfor.GrossSalary * 3 / 100;
            employersPaymentInfor.UnemploymentInsurance = employersPaymentInfor.GrossSalary * 1 / 100;
            employersPaymentInfor.TotalPayment = employersPaymentInfor.GrossSalary + employersPaymentInfor.SocialInsurance + employersPaymentInfor.AccidentInsurance
                                                 + employersPaymentInfor.HealthInsurance + employersPaymentInfor.UnemploymentInsurance;
            return employersPaymentInfor;
        }
        public static void ShowSalaryDetails(SalaryDetail salaryDetail)
        {
            Console.WriteLine("Dien giai chi tiet (VNĐ) \n");
            Console.WriteLine($"Luong Gross :{salaryDetail.GrossSalary:n0}\nBao hiem xa hoi (8%): {salaryDetail.SocialInsurance:n0}" +
                $"\nBao hiem Y te (1.5%): {salaryDetail.HealthInsurance:n0}\nBao hiem that nghiep (1%): {salaryDetail.UnemploymentInsurance:n0}" +
                $"\nThu nhap truoc thue : {salaryDetail.IncomeBeforeTax:n0}\nGiam tru gia canh ban than : {salaryDetail.PersionalSituation:n0}" +
                $"\nGiam tru gia canh nguoi phu thuoc : {salaryDetail.DependentSituation:n0}" +
                $"\nThu nhap chiu thue : {salaryDetail.IncomeTaxes:n0}\nThue thu nhap ca nhan : {salaryDetail.PersionalIncomeTax:n0}\nLuong Net : {salaryDetail.NetSalary:n0}\n");
            Console.ResetColor();
        }

        public static void ShowEmployersPayment(EmployersPaymentInfor employersPaymentInfor)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nguoi su dung lao dong tra (VNĐ) \n");
            Console.WriteLine($"Luong Gross :{employersPaymentInfor.GrossSalary:n0}\nBao hiem xa hoi (17%): {employersPaymentInfor.SocialInsurance:n0}" +
                $"\nBao hiem tai nan lao dong  (0.5%): {employersPaymentInfor.AccidentInsurance:n0}\nBao hiem that nghiep  (1%): {employersPaymentInfor.UnemploymentInsurance:n0}" +
                $"\nBao hiem y te  (3%): {employersPaymentInfor.HealthInsurance:n0}");
            Console.ResetColor();
        }



        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Công cu tính lương Gross sang Net / Net sang Gross");
            Console.ResetColor();
            while (true)
            {
                try
                {
                    SalaryInfor salaryInfor = InputInfor();
                    //Select Mode
                    Console.ForegroundColor = ConsoleColor.Green;
                    int selection = 0;
                    Console.WriteLine("Lua chon chuyen doi \n");
                    Console.WriteLine("0 . Gross -----> Net \n");
                    Console.WriteLine("1 . Net -----> Gross \n");
                    Console.ResetColor();
                    selection = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n ------------------------------------------------------- \n");
                    if (selection == 0)
                    {
                        Console.WriteLine("Ban dang thuc hien tinh luon Gross -----> Net \n");
                        SalaryDetail salaryDetail = GrossToNetCaculate(salaryInfor);
                        ShowSalaryDetails(salaryDetail);
                        EmployersPaymentInfor employersPaymentInfor = CaculateEmployersPayment(salaryDetail);
                        ShowEmployersPayment(employersPaymentInfor);

                    }
                    else if(selection == 1) 
                    {
                        Console.WriteLine("Ban dang thuc hien tinh luon Net -----> Gross \n");
                        SalaryDetail salaryDetail = NetToGrossCaculate(salaryInfor);
                        ShowSalaryDetails(salaryDetail);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        EmployersPaymentInfor employersPaymentInfor = CaculateEmployersPayment(salaryDetail);
                        ShowEmployersPayment(employersPaymentInfor);
                    }
                    else
                    {
                        Console.WriteLine("Xin moi nhap lai lua chon \n");
                    }

                    Console.WriteLine("\n\n *************************************************** \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            
        }
    }
}

