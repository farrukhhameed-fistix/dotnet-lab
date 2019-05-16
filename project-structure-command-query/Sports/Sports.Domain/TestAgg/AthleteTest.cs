using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Domain.TestAggregate
{
    public class AthleteTest
    {
        private AthleteTest()
        {

        }
        public AthleteTest(Athlete athlete, decimal distance)
        {
            this.AthleteId = athlete.Id;
            this.Athlete = athlete;
            this.Distance = distance;
            this.CalculateFitness();
        }
        public Guid Id { get; set; }
        public Guid TestId { get; private set; }
        public Guid AthleteId { get; private set; }
        public decimal Distance { get; private set; }
        public FitnessRating FitnessRating { get; private set; }
        public Athlete Athlete { get; private set; }

        public void ChangeDistance(decimal distance)
        {
            this.Distance = distance;
            this.CalculateFitness();
        }
        private void CalculateFitness()
        {
            if (this.Distance <= 1000)
            {
                this.FitnessRating = FitnessRating.BelowAverage;
            }
            else if (this.Distance > 1000 && this.Distance <= 2000)
            {
                this.FitnessRating = FitnessRating.Average;
            }
            else if (this.Distance > 2000 && this.Distance <= 3500)
            {
                this.FitnessRating = FitnessRating.Good;
            }
            else if (this.Distance > 3500)
            {
                this.FitnessRating = FitnessRating.VeryGood;
            }
        }
    }
}
