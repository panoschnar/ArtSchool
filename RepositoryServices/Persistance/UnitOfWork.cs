using DataAccessLayer;
using Entities.Queries;
using RepositoryServices.Core;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
            Courses = new CourseRepository(context);
            Students = new StudentRepository(context);
            Trainers = new TrainerRepository(context);
        }

        public ICourseRepository Courses { get; private set; }

        public IStudentRepository Students { get; private set; }

        public ITrainerRepository Trainers { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }



        public void Dispose()
        {
            context.Dispose();
        }
    }
}
