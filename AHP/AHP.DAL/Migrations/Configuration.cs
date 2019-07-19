namespace AHP.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AHP.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<AHP.DAL.AHPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AHP.DAL.AHPContext context)
        {
            //  This method will be called after migrating to the latest version.
            var Project = new Project
            {

                Username = "Jakov",
                ProjectName = "Odabir stana",
                Description = "Zelim kupiti stan, ne znam koji cu",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now               

            };
            var criterias = new List<Criteria>
                 {
                     new Criteria{Order=1,CriteriaName="Velicina", ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                     new Criteria{Order=2,CriteriaName="Lokacija", ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                     new Criteria{Order=3,CriteriaName="Grijanje", ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   }
                };
            var criteriaRanks = new List<CriteriaRank>
                 {
                     new CriteriaRank{Column=2,Priority=5,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                     new CriteriaRank{Column=3,Priority=4,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                     new CriteriaRank{Column=1,Priority=1/5f,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                     new CriteriaRank{Column=3,Priority=2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                     new CriteriaRank{Column=1,Priority=1/4,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                     new CriteriaRank{Column=2,Priority=1/2f,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   }
                 };
            var alternatives = new List<Alternative>
                {
                    new Alternative{Order=1,AlternativeName="Villa Len",ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new Alternative{Order=2,AlternativeName="Kuca Mar",ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new Alternative{Order=3,AlternativeName="Vikendica Pat",ProjectId=1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   }
                };
            var alternativeRanks = new List<AlternativeRank>
                {
                    //Za prvi kriterij
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=3,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now    },
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=1,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=1/3f,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=1,Alternative2=2,Preference=2,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                    new AlternativeRank{Alternative1=1,Alternative2=2,Preference=1,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=1/2f,CriteriaId = 1,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    //Za drugi kriterij
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=5,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=1,Alternative2=2,Preference=6,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                    new AlternativeRank{Alternative1=2,Alternative2=1, Preference=1/5f,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=2,Alternative2=3, Preference=2,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                    new AlternativeRank{Alternative1=3,Alternative2=1, Preference=1/6f,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=3,Alternative2=2, Preference=1/2f,CriteriaId = 2,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                     //Za treci kriterij
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=8,CriteriaId = 3 ,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=1,Alternative2=2, Preference=4,CriteriaId = 3,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now    },

                    new AlternativeRank{Alternative1=2,Alternative2=1, Preference=1/8f,CriteriaId = 3,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now    },
                    new AlternativeRank{Alternative1=2,Alternative2=3, Preference=3,CriteriaId = 3 ,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },

                    new AlternativeRank{Alternative1=3,Alternative2=1, Preference=1/4f,CriteriaId = 3 ,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   },
                    new AlternativeRank{Alternative1=3,Alternative2=2, Preference=1/3f,CriteriaId = 3 ,DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now   }
                };
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Projects.AddOrUpdate(Project);
            context.SaveChanges();
            criterias.ForEach(crit => context.Criterias.AddOrUpdate(crit));
            context.SaveChanges();
            alternatives.ForEach(alt => context.Alternatives.AddOrUpdate(alt));
            context.SaveChanges();
            alternativeRanks.ForEach(altrank => context.AlternativeRanks.AddOrUpdate(altrank));
            context.SaveChanges();
            criteriaRanks.ForEach(critrank => context.CriteriaRanks.AddOrUpdate(critrank));
            context.SaveChanges();
        }
    }
}
