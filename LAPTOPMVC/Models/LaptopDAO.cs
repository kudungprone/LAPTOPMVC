using System.Collections.Generic;
using System.Linq;

namespace LAPTOPMVC.Models
{
    public class LaptopDAO
    {
        public LaptopContext db = new LaptopContext();

        public List<Laptop> getList()
        {
            return db.laptop.OrderBy(l => l.name).ToList();
        }

        public int Delete(string lapid)
        {
            var ph = db.laptop.FirstOrDefault(p => p.id == lapid);
            if (ph == null)
                return 0;
            db.laptop.Remove(ph);
            return db.SaveChanges();
        }

        public int Edit(Laptop ph)
        {
            var oldph = db.laptop.FirstOrDefault(p => p.id == ph.id);
            if (oldph == null)
                return 0;
            oldph.name = ph.name;
            oldph.price = ph.price;
            oldph.cpu = ph.cpu;
            oldph.ram = ph.ram;
            oldph.storage = ph.storage;
            return db.SaveChanges();
        }
    }
}