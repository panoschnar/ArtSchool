using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities.Enums;
using Entities.Models;
using System.Data.Entity.Migrations;

namespace DataAccessLayer.Initializers
{
    internal class MockUpInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            #region Students Seeding
            Student s1 = new Student("Panos", "Chnarakis", new DateTime(1988, 4, 4), 2500, Country.Greece);
            Student s2 = new Student("Maria", "Dourou", new DateTime(1986, 3, 14), 2800, Country.Ghana);
            Student s3 = new Student("Panagiotis", "Kontaras", new DateTime(1990, 12, 24), 3000, Country.Greece);
            Student s4 = new Student("Domna", "Kara", new DateTime(2002, 8, 12), 2000, Country.Iran);
            Student s5 = new Student("Ismini", "Papavou", new DateTime(2000, 6, 1), 2500, Country.Italy);
            Student s6 = new Student("Dwra", "Isidwrou", new DateTime(1999, 6, 1), 2500, Country.Kyrgyzstan);
            Student s7 = new Student("Kostas", "Kanelopoulos", new DateTime(1995, 6, 1), 2500, Country.Lebanon);
            Student s8 = new Student("Nikos", "Nikolaou", new DateTime(2001, 6, 1), 3000, Country.Lesotho);
            Student s9 = new Student("Stergios", "Kikoulis", new DateTime(1986, 6, 1), 2500, Country.Cyprus);
            Student s10 = new Student("Natalia", "Papathoma", new DateTime(1978, 6, 1), 5000, Country.Greece);
            Student s11 = new Student("Evi", "Lamtisa", new DateTime(2002, 6, 1), 1500, Country.Italy);
            Student s12 = new Student("Isidwros", "Thivaiou", new DateTime(1997, 6, 1), 2000, Country.Iran);
            Student s13 = new Student("Giorgos", "Krateros", new DateTime(1993, 6, 1), 4000, Country.Spain);
            Student s14 = new Student("Giannis", "Tsoumas", new DateTime(1999, 6, 1), 3000, Country.Lebanon);
            Student s15 = new Student("Pantelis", "Portokalis", new DateTime(2004, 6, 1), 2000, Country.Greece);
            Student s16 = new Student("Pinelopi", "Portokali", new DateTime(2000, 6, 1), 2000, Country.Greece);
            Student s17 = new Student("Luis", "Fonsi", new DateTime(1986, 1, 1), 2000, Country.Spain);
            Student s18 = new Student("Clery", "Claropoulou", new DateTime(1982, 6, 1), 2000, Country.Iran);
            Student s19 = new Student("Silia", "Tseli", new DateTime(2001, 11, 1), 2000, Country.Ghana);
            Student s20 = new Student("Danai", "Labena", new DateTime(1978, 7, 1), 2000, Country.Spain);
            Student s21 = new Student("Dina", "Lagiou", new DateTime(1985, 6, 1), 2000, Country.Greece);
            Student s22 = new Student("Gkilnta", "Tafelo", new DateTime(1995, 6, 1), 2000, Country.Italy);
            Student s23 = new Student("Ragnar", "Lothbrok", new DateTime(1989, 5, 1), 2000, Country.United_Kingdom);
            Student s24 = new Student("Luthor", "Gregonous", new DateTime(1900, 12, 1), 2000, Country.Lesotho);
            Student s25 = new Student("Althestain", "Kirkov", new DateTime(2003, 8, 1), 2000, Country.Russia);

            context.Students.AddOrUpdate(s => s.FirstName, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16,s17,s18,s19,s20);
            context.SaveChanges();

            #endregion

            #region Course Seeding
            Course c1 = new Course("Dance", "CD1.1", CourseType.FullTime, new DateTime(2022, 01, 01), new DateTime(2022, 04, 01));
            Course c2 = new Course("Dance", "CD1.2", CourseType.PartTime, new DateTime(2022, 01, 01), new DateTime(2022, 07, 01));
            Course c3 = new Course("Sing", "CS2.1", CourseType.FullTime, new DateTime(2022, 01, 01), new DateTime(2022, 04, 01));
            Course c4 = new Course("Sing", "CS2.2", CourseType.PartTime, new DateTime(2022, 02, 01), new DateTime(2022, 09, 01));
            Course c5 = new Course("Paint", "CP3.1", CourseType.FullTime, new DateTime(2022, 04, 01), new DateTime(2022, 07, 01));
            Course c6 = new Course("Paint", "CP3.2", CourseType.PartTime, new DateTime(2022, 04, 01), new DateTime(2022, 10, 01));

            context.Courses.AddOrUpdate(c => c.Title, c1, c2, c3, c4, c5, c6);
            context.SaveChanges();

            #endregion

            #region Trainers Seeding
            Trainer t1 = new Trainer("Hector", "Gatsos", "Advanced Skills", "https://images.generated.photos/wGB1I0eqy9RcOTLdUeBTos3fYSP36xXhtgDNW0POy9Y/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvYzViNTA0/ZDktMWJjNC00ZGY1/LWE0ODgtYzdjNmQy/MDczZmEwLmpwZw.jpg", 20000,"6979012345");
            Trainer t2 = new Trainer("Periklis", "Aidinopoulos", "Basics Skills", "https://images.generated.photos/3JyTY-zrJYCTW1_ggZrkBTvmctalowAul7TVPoOKKs0/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvN2IzYjZm/MzQtMmI5OC00YTA3/LWIxYTAtYzJkOTFm/OWE2NmM0LmpwZw.jpg", 25000, "6979987445");
            Trainer t3 = new Trainer("Nerina", "Kapoiopoulou", "Vocals Generals", "https://images.generated.photos/vE0DXSN1nKaZ3d0JRqBnGDLULwdCqkilEO4oOYAcr4c/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvYmZjMzFl/NmQtMGM3OS00MDk2/LThjNDEtYjgxMWE2/ODg5MmFjLmpwZw.jpg", 40000, "6979012345");
            Trainer t4 = new Trainer("Georgios", "Pasparakis", "Light and Shadow", "https://images.generated.photos/rkSoJEyJXP4Q1MTQaSjO2jNlkBHBw62oRAp1bf4fS2U/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvNzZhYTk1/YzAtMzA5MC00MzM3/LWFkOTUtNmRmYjA1/NWVkMzA5LmpwZw.jpg", 45000, "6996312345");
            Trainer t5 = new Trainer( "Giannis", "Efroulos", "Ballet Beginners Skills", "https://images.generated.photos/t3YwVI_6zFzX6m2Vx3Es8BaiDq9EMYohRfXh2PFrl34/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvYWQ5YWRk/MDktMmI5Ny00ZTVl/LThjN2EtNzQxZTNk/YmJkMTRmLmpwZw.jpg", 35000, "6979012345");
            Trainer t6 = new Trainer( "Maria", "Solomou", "Advanced Colors", "https://images.generated.photos/qXm5i2ZdpU4XYSO8AINbjnYtt0syv3QrqUI2_ZVaNvU/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvMzRjNzcw/YTctZmY0OS00ZTYw/LThiZGMtMmU3MGQw/ZGY0YjE0LmpwZw.jpg", 50000, "6996312345");
            Trainer t7 = new Trainer( "Katerina", "Gagaki", "Basics on Canvas", "https://images.generated.photos/DK81zXEp1jbei0YqNNlGtyyUahXVzzbJ8izr69rBZYg/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvNTViZDAx/YTktNzU1ZC00NWVh/LThkMjAtZGVlNmFk/MGUwZjQzLmpwZw.jpg", 28000, "6979987445");
            Trainer t8 = new Trainer( "Maria", "Menounos", "Basics on Art History", "https://images.generated.photos/DVZ5PWYvTCw-TPuNisg-sHtFP8IJPYIw-EMCqBpmT1w/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvMzg4ZDVj/MDEtNjAxZi00Zjli/LTlhMGMtYzQ2ZDhj/NGU3YzVmLmpwZw.jpg", 10000, "6979012345");
            Trainer t9 = new Trainer( "Spyros", "Sofroniou", "Basic Levels", "https://images.generated.photos/h9-CDgFGW5Vyw86CWvt5fx9K66OzSVX_RTilWCtM8zg/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvNzAzMTZh/MmYtODE1Yy00YjJj/LWEyOGEtNjhhMDM2/NjU5ZjY2LmpwZw.jpg", 22000, "6979012345");
            Trainer t10 = new Trainer( "Lydia", "Psoma", "Correct Pronanciation", "https://images.generated.photos/X9deu_ehy3KiK_F9_wEYfNTGhGYKzURgDdlNT-Bx3QE/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvYTBkODM5/ZDMtNTI4Ni00YTQ5/LTlmNWQtYTBiM2Ey/YmNkOTk4LmpwZw.jpg", 42000, "6979987445");
            Trainer t11 = new Trainer( "Stelios", "Kalafatis", "Basics", "https://images.generated.photos/_-CY6STJrktqM4QakTpijZmnIeCY7ADmsFZPu14UXOM/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvZDZhNjAz/OGMtYjZmNS00NzU2/LThmZDAtMzNkZDE5/NjVjZDA4LmpwZw.jpg", 38000, "6979012345");
            Trainer t12 = new Trainer( "Giwrgos", "Psilis", "Stage Preparation", "https://images.generated.photos/y6FHMe3cFcYuL6nfw3fXbpV5fkliE1y7vqkL1dBl99A/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvMjI3MDA1/OGEtNzI4Ni00YWQ0/LWJmYzktYjJlZWZi/MmExNzUyLmpwZw.jpg", 19000, "6979012345");
            Trainer t13 = new Trainer( "Panagiwta", "Tarou", "Advanced Vocal Skills", "https://images.generated.photos/atMEEqE1hVYy9sUOFdKRKRNN9wyGasgiuBnNr9JyXPQ/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvZjNhOWQ2/ZDYtYTQ3Ni00Nzhk/LWI3NzItMGUyNDBl/NzhmNzdmLmpwZw.jpg", 48000, "6996312345");
            Trainer t14 = new Trainer( "Tsexwv", "Bodounski", "Advanced Ballet Routine", "https://images.generated.photos/QR730gOwCJDj_EsfMNaOjLTwv1FBYsnWzXig2JIueAU/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvN2M2OGU0/ZmMtNDAxMS00N2M5/LTlmMjEtYjNhMzdm/NDA5OGQ1LmpwZw.jpg", 29000, "6979987445");
            Trainer t15 = new Trainer( "Panos", "Gaultier", "Art of Expressionism", "https://images.generated.photos/kZaXceBMjVHN4QyAOO_3IWoNpePNRz0sfEMNTkQVMe8/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LmNvbmQvZTBhNDVl/NjctMWM4ZS00ZDll/LTk0MjctNjUyNjY0/NjQzYjgwLmpwZw.jpg", 12000, "6996312345");
            t1.Course = c2;
            t2.Course = c3;
            t3.Course = c4;
            t4.Course = c6;
            t5.Course = c1;
            t6.Course = c5;
            t7.Course = c6;
            t8.Course = c5;
            t9.Course = c2;
            t10.Course = c4;
            t11.Course = c6;
            t12.Course = c2;
            t13.Course = c3;
            t14.Course = c1;
            t15.Course = c6;

            context.Trainers.AddOrUpdate(t => t.FirstName, t1, t2, t3, t4, t5, t6, t7,t8,t9,t10,t11,t12,t13,t14,t15);
            context.SaveChanges();

            #endregion


            base.Seed(context);
        }
    }
}
