using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Submissions
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public int Percantage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);
    }
}
