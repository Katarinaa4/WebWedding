using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWedding.Models;

namespace WebWedding.Services
{
    public interface IMuzikaRezervisaniService
    {
        List<MuzikaRezervisani> ReadAll();
        void Create(MuzikaRezervisani mr);
        MuzikaRezervisani Read(int id);
        void Update(MuzikaRezervisani modifiedMR);
        void Delete(int id);
    }
    public class MuzikaRezervisaniService : IMuzikaRezervisaniService
    {
        private readonly WebWeddingContext _context;

        public MuzikaRezervisaniService(WebWeddingContext _db)
        {
            _context = _db;
        }
        public void Create(MuzikaRezervisani mr)
        {
            _context.MuzikaRezervisaniD.Add(mr);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            MuzikaRezervisani mr = _context.MuzikaRezervisaniD.Find(id);
            if (mr != null)
            {
                _context.MuzikaRezervisaniD.Remove(mr);
                _context.SaveChanges();
            }
        }

        public MuzikaRezervisani Read(int id)
        {
            MuzikaRezervisani mr = _context.MuzikaRezervisaniD.Include(x => x.MojaMuzika).Where(x => x.Id == id).FirstOrDefault();
            if (mr != null)
            {
                return mr;
            }
            else return null;
        }

        public List<MuzikaRezervisani> ReadAll()
        {
            return _context.MuzikaRezervisaniD.Include(x => x.MojaMuzika).ToList();
        }

        public void Update(MuzikaRezervisani modifiedMR)
        {
            MuzikaRezervisani mr = _context.MuzikaRezervisaniD.Find(modifiedMR.Id);
            if (mr != null)
            {
                mr.datum = modifiedMR.datum;
                mr.MojaMuzika = modifiedMR.MojaMuzika;
                _context.MuzikaRezervisaniD.Update(mr);
                _context.SaveChanges();
            }
        }
    }
}
