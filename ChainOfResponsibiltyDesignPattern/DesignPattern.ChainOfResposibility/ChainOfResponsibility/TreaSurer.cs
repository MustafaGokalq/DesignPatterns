using DesignPattern.ChainOfResposibility.DAL;
using DesignPattern.ChainOfResposibility.Models;

namespace DesignPattern.ChainOfResposibility.ChainOfResponsibility
{
    public class TreaSurer:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if(req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar Ayşe Çınar";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteriye talep ettiği tutar ödendi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar Ayşe Çınar";
                customerProcess.Description = "Para çekme tutarı veznedarın ödeyebilecegi günlük limiti aştığı için işlem Şube Müdür Yardımcısına yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
                
            }
        }
    }
}
