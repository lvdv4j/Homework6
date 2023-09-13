using System;
using System.Collections.Generic;
using System.Linq;
using Homework.Data;
using Homework.Models;

namespace Homework.Repository
{
    public class ServiceRepository
    {
        private readonly HomeworkDbContext _context;

        public ServiceRepository(HomeworkDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service GetById(Guid id)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public void Create(Service service)
        {
            if (service != null)
            {
                service.ServiceId = Guid.NewGuid();
                _context.Services.Add(service);
                _context.SaveChanges();
            }
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            return _context.Services.Any(s => s.ServiceId == id);
        }
    }
}
