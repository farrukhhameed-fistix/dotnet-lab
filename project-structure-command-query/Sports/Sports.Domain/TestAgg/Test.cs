using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Domain.TestAggregate
{
    public class Test
    {
        public Test()
        {

        }
        public Guid Id { get; set; }
        public TestType Type { get; set; }
        public DateTime Date { get; set; }
        public List<AthleteTest> Athletes { get; private set; }

        public void AddAthleteToTest(Athlete athlete, decimal distance)
        {
            this.Athletes.Add(new AthleteTest(athlete, distance));
        }

        public void RemoveAthleteFromTest(Guid athleteId)
        {
            var athlete = this.Athletes.FirstOrDefault(x => x.AthleteId == athleteId);
            if (athlete != null)
            {
                this.Athletes.Remove(athlete);
            }
        }

        public void UpdateDistanceOfAthlete(Athlete athlete, decimal distance)
        {
            var athleteTest = this.Athletes.FirstOrDefault(x => x.AthleteId == athlete.Id);
            if (athleteTest != null)
            {
                athleteTest.ChangeDistance(distance);
            }
        }
    }
}
