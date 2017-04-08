using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System.Linq;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job someJob = jobData.Find(id);

            return View(someJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                Location location = jobData.Locations.Find(newJobViewModel.LocationID);
                CoreCompetency skill = jobData.CoreCompetencies.Find(newJobViewModel.SkillID);
                PositionType type = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);
                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    CoreCompetency = skill,
                    Location = location,
                    PositionType = type,
                };
                jobData.Jobs.Add(newJob);
                int id = newJob.ID;
                return Redirect("/Job?id=newJob.ID");
            }
            return View(newJobViewModel);
        }
    }
}
