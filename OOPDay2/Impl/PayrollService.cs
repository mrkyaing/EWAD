using OOPDay2.Interfaces;
using OOPDay2.Models;

namespace OOPDay2.Impl {
    public class PayrollService : IPayrollService {
        public decimal CalculateBonus(decimal basicSalary, DateTime JoinedDate) {
            //after 2 years basic pay 1%
            //after 3 years basic pay 1.5%
            //after 4 years basic pay 2%
            //after 5 years basic pay 3%
            //after 6 years basic pay 3.5%
            decimal bonus = 0;
            int serviceYears=Convert.ToInt32((DateTime.Now.Subtract(JoinedDate).Days)/365.25); // 2023-08-19 - 2022-08-19
            if (serviceYears >=6) {
                bonus=(basicSalary*3.5m)/ 100;
            }
          else if (serviceYears >= 5) {
                bonus = (basicSalary * 3) / 100;
            }
            else if (serviceYears >= 4) {
                bonus = (basicSalary * 2) / 100;
            }
            else if (serviceYears >= 3) {
                bonus = (basicSalary * 1.5m) / 100;
            }
            else if (serviceYears >=2) {
                bonus = (basicSalary * 1) / 100;
            }
            return  bonus;
        }
        //300000/30 =10000*30
        public decimal CalculatePayroll(Staff staff, int workingDays, int attendanceDays) {
            decimal netPay = (staff.BasicSalary / workingDays) * attendanceDays;//(300000/31)*31
            return netPay;
        }
    }
}
