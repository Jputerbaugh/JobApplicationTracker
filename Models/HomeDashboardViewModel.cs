namespace JobApplicationTracker.Models
{
    public class HomeDashboardViewModel
    {
        public int TotalApplications { get; set; }

        public int AdvancedApplications { get; set; }

        public int InterviewOrBetterApplications { get; set; }

        public int MultipleInterviewApplications { get; set; }

        public int OfferApplications { get; set; }

        public int AcceptedApplications { get; set; }

        public double AdvancementRate =>
            CalculateRate(AdvancedApplications);

        public double InterviewOrBetterRate =>
            CalculateRate(InterviewOrBetterApplications);

        public double MultipleInterviewRate =>
            CalculateRate(MultipleInterviewApplications);

        public double OfferRate =>
            CalculateRate(OfferApplications);

        public double AcceptanceRate =>
            CalculateRate(AcceptedApplications);

        private double CalculateRate(int count)
        {
            if (TotalApplications == 0)
            {
                return 0;
            }

            return (double)count / TotalApplications * 100;
        }
    }
}