using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel : BaseViewModel
    {
        // The search results
        public List<Job> Jobs { get; set; }


        // The search value
        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";


        public SearchJobsViewModel()
        {
            // Populate the list of all columns

            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }


        }
    }
}