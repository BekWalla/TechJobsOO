using System;
using System.Collections.Generic;
using TechJobs.Models;
using System.Linq;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {

        // All fields in the given column
        public IEnumerable<JobField> Fields { get; set; }

        public JobFieldType Column { get; set; }


        public JobFieldsViewModel()
        {
        
        }
    }
}
