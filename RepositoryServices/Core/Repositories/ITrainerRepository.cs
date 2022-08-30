using Entities.Models;
using Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        List<Trainer> GetAllWithCourses();
        Trainer GetTrainerFull(int? id);
        void DeleteTrainer(Trainer trainer);
        void UpdateTrainer(Trainer trainer);
        List<Trainer> Filter(TrainerFilteredSettings filterSettings, out (int? minSalary, int? maxSalary) trainerSalaryRange);
    }
}
