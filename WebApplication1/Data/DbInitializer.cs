using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quokka_App.Model;

namespace Quokka_App.Data
{
    public class DbInitializer
    {
        public static void Initialize(LeadersAssignedContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Emotion.Any())
            {
                return;   // DB has been seeded
            }

            //var students = new LeadersAssigned[]
            //{
            //new LeadersAssigned{Id=1,userName=13131,role= "leader"},
            //new LeadersAssigned{Id=2,userName=151515,role= "student"},
            //};
            //foreach (LeadersAssigned s in students)
            //{
            //    context.LeadersAssigned.Add(s);
            //}
            //context.SaveChanges();

            var emotion = new Emotion[]
            {
            new Emotion{ID=1050,studentId= "1",feeling="sad",date = DateTime.Parse("2005-09-01"),whenToSee = "yes", description = "hey"},
            new Emotion{ID=4022,studentId= "2",feeling="happy",date = DateTime.Parse("2005-09-01"),whenToSee = "no", description = "yo" },
            new Emotion{ID=4041,studentId= "3",feeling="angry",date = DateTime.Parse("2005-09-01"),whenToSee = "not sure", description = "what's up?" },
            };
    
            foreach (Emotion e in emotion)
            {
                context.Emotion.Add(e);
            }
            context.SaveChanges();
        }
    }
}
