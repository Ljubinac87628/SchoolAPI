using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class FinalRepository : IFinalRepository
    {
        private readonly SchoolDbContext _schoolDbContext;
        private Final updatedFinal;

        public FinalRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public IEnumerable<Final> AllFinals
        {
            get { return _schoolDbContext.Finals; }
        }

        public Final AddFinal(Final final)
        {
            _schoolDbContext.Finals.Add(final);
            _schoolDbContext.SaveChanges();
            return final;
        }

        public FinalRepository AddFinal(FinalRepository final)
        {
            throw new NotImplementedException();
        }

        public object AddFinal(FinalModel finalEntry)
        {
            throw new NotImplementedException();
        }

        public Final GetFinalById(int id)
        {
            Final final = _schoolDbContext.Finals.FirstOrDefault(f => f.Id == id);
            return final;
        }

        public Final GetFinalByStudentId(int studentId, int finalId)
        {
            var final = AllFinals.FirstOrDefault(f => f.Id == finalId && f.StudentId == studentId);
            return final;
        }

        public IEnumerable<Final> GetFinalsByStudentId(int studentId)
        {
            var finals = _schoolDbContext.Finals.Where(f => f.StudentId == studentId);
            return finals;
        }

        FinalRepository IFinalRepository.GetFinalById(int id)
        {
            throw new NotImplementedException();
        }
        public Final UpdateFinal(Final final)
        {
            var updateFinal = AllFinals.FirstOrDefault(f => f.Id == final.Id);
            if (updatedFinal != null)
            {
                updatedFinal.Mark = final.Mark;
                updatedFinal.Name = final.Name;

                _schoolDbContext.SaveChanges();
            }
            return updatedFinal;

        }

        public void DeleteFinal(int id)
        {
            var final = AllFinals.FirstOrDefault(f => f.Id == id);
            if (final != null)
            {
                _schoolDbContext.Finals.Remove(final);
                _schoolDbContext.SaveChanges();
            }
        }
    }
}
