using OOPDay2.Models;

namespace OOPDay2.Interfaces {
    public interface IPayrollService {
        decimal CalculatePayroll(Staff staff,int workingDays,int attendanceDays);
        decimal CalculateBonus(decimal basicSalary,DateTime JoinedDate);
    }
}
