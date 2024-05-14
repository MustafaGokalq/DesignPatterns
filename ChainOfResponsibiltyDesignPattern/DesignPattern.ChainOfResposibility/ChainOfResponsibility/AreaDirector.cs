using DesignPattern.ChainOfResposibility.DAL;
using DesignPattern.ChainOfResposibility.Models;

namespace DesignPattern.ChainOfResposibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü Murat Kara";
                customerProcess.Description = "Para çekme işlemi onaylandı, Müşteriye talep ettiği tutar ödendi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü Murat Kara";
                customerProcess.Description = "Para çekme tutarı Bölge Müdürünün ödeyebilecegi günlük limiti aştı, Müşterinin günlük çekebileceği maximum deger 400000TL fazlası için birden fazla gün şubeye gelmeniz gereklidir.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
