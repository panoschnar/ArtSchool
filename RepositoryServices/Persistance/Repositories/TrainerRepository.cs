using DataAccessLayer;
using Entities.Queries;
using Entities.Models;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Trainer> Filter(TrainerFilteredSettings filterSettings, out (int? minSalary, int? maxSalary) trainerSalaryRange)
        {
            List<Trainer> trainers = GetAllWithCourses();


            int? minSalary = (int?)(trainers?.Min(x => x?.Salary));
            int? maxSalary = (int?)(trainers?.Max(x => x?.Salary));
            trainerSalaryRange = (minSalary, maxSalary);


            //Filtering....
            if (!string.IsNullOrWhiteSpace(filterSettings.searchName)) //null or "" or "     "
            {
                //employees = employees.Where(x=>x.Name.ToUpper() == searchName.ToUpper()).ToList();

                trainers = trainers.Where(x => x.FullName.ToUpper().Contains(filterSettings.searchName.ToUpper())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filterSettings.searchCourse))
            {
                trainers = trainers.Where(x => x.Course.Title == filterSettings.searchCourse).ToList();
            }

            if (!(filterSettings.searchMin is null))
            {
                trainers = trainers.Where(x => x.Salary >= filterSettings.searchMin).ToList();
            }

            if (!(filterSettings.searchMax is null))
            {
                trainers = trainers.Where(x => x.Salary <= filterSettings.searchMax).ToList();
            }

            return trainers;

        }

        public void DeleteTrainer(Trainer trainer)
        {
            table.Remove(trainer);
        }

        public List<Trainer> GetAllWithCourses() => table.Include(x => x.Course).ToList();

        public Trainer GetTrainerFull(int? id)=> table.Include(x => x.Course).SingleOrDefault(x => x.TrainerId == id);
        
        public void UpdateTrainer(Trainer trainer)
        {
            if (trainer == null)
            {
                throw new ArgumentException("Wrong Employee!");
            }
            //Vima 1 vres apo ti vasi ton employee me ola ta stoixeia tou
            var trainerEdited = GetTrainerFull(trainer.TrainerId);

            //Guard closes
            if (trainerEdited == null)
            {
                throw new ArgumentException("Employee NOT found!");
            }


            //Mapping
            trainerEdited.FirstName = trainer.FirstName;
            trainerEdited.LastName = trainer.LastName;
            trainerEdited.Subject = trainer.Subject;
            trainerEdited.Salary = trainer.Salary;
            trainerEdited.CourseId = trainer.CourseId;
            trainerEdited.PhotoUrl = trainer.PhotoUrl;
            trainerEdited.Phone = trainer.Phone;

            db.Entry(trainerEdited).State = EntityState.Modified;
            db.SaveChanges();
        }
    }

        //public IEnumerable<Trainer> GetAllWithCourses(Expression<Func<Trainer, bool>> expression) => table.Include(expression).ToList();
    
}
