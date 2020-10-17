using Suls.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
