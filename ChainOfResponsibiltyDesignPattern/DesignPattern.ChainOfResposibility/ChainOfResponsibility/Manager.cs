using DesignPattern.ChainOfResposibility.DAL;
using DesignPattern.ChainOfResposibility.Models;

namespace DesignPattern.ChainOfResposibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü Mehmet Ak";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteriye talep ettiği tutar ödendi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü Mehmet Ak";
                customerProcess.Description = "Para çekme tutarı Şube Müdürünün ödeyebilecegi günlük limiti aştığı için işlem Bölge Müdürüne yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
