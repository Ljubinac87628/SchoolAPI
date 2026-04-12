using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IFinalRepository
    {
        IEnumerable<Final> AllFinals { get; }
        FinalRepository GetFinalById(int id);
        FinalRepository AddFinal(FinalRepository final);
        IEnumerable<Final> GetFinalsByStudentId(int studentId);
        Final GetFinalByStudentId(int studentId, int id);
        object AddFinal(FinalModel finalEntry);
        Final UpdateFinal(Final final);
        void DeleteFinal(int id);
    }
}
