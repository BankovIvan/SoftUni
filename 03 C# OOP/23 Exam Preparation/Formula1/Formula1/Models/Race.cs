namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Race : IRace
    {
        private const int RACE_NAME_MIN_LENGTH = 5;
        private const int RACE_LAPS_MIN_VALUE = 1;

        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private List<IPilot> pilots;

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < RACE_NAME_MIN_LENGTH)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value; 
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < RACE_LAPS_MIN_VALUE)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return this.tookPlace; }
            set { this.tookPlace = value; }
        }

        public ICollection<IPilot> Pilots
        {
            get { return this.pilots; }
        }

        private Race()
        {
            this.tookPlace = false;
            this.pilots = new List<IPilot>();
        }

        public Race(string raceName, int numberOfLaps) : this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("The {0} race has:", this.RaceName));
            ret.AppendLine(String.Format("Participants: {0}", this.Pilots.Count));
            ret.AppendLine(String.Format("Number of laps: {0}", this.NumberOfLaps));
            ret.AppendLine(String.Format("Took place: {0}", (this.TookPlace) ? "Yes" : "No"));

            return ret.ToString().Trim();
        }
    }
}
