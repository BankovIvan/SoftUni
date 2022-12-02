namespace Formula1.Core
{
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Repositories.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository= new PilotRepository();
            this.raceRepository= new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = this.carRepository.FindByName(carModel);

            if (pilot == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (pilot.CanRace == true)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);

            StringBuilder ret = new StringBuilder();
            ret.AppendLine(String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel));
            return ret.ToString().Trim();
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if (pilot.CanRace == false)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if ((new List<IPilot>(race.Pilots).Find(x => x.FullName == pilotFullName)) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            StringBuilder ret = new StringBuilder();
            ret.AppendLine(String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName));
            return ret.ToString().Trim();
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(this.carRepository.FindByName(model) != null) 
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;
            
            if(type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.carRepository.Add(car);

            StringBuilder ret = new StringBuilder();
            ret.AppendLine(String.Format(OutputMessages.SuccessfullyCreateCar, type, model));
            return ret.ToString().Trim();
        }

        public string CreatePilot(string fullName)
        {
            if(this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            StringBuilder ret = new StringBuilder();

            IPilot pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);

            ret.AppendLine(String.Format(OutputMessages.SuccessfullyCreatePilot, fullName));
            return ret.ToString().Trim();
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);

            StringBuilder ret = new StringBuilder();
            ret.AppendLine(String.Format(OutputMessages.SuccessfullyCreateRace, raceName));
            return ret.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder ret = new StringBuilder();

            foreach (var v in this.pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                ret.AppendLine(v.ToString());
            }

            return ret.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder ret = new StringBuilder();

            foreach(var v in this.raceRepository.Models)
            {
                if(v.TookPlace == true)
                {
                    ret.AppendLine(v.RaceInfo());
                } 
            }

            return ret.ToString().Trim();   
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            List<IPilot> winners = race
                                    .Pilots
                                    .OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps))
                                    .Take(3)
                                    .ToList();

            winners[0].WinRace();

            StringBuilder ret = new StringBuilder();
            ret.AppendLine(String.Format(OutputMessages.PilotFirstPlace, winners[0].FullName, raceName));
            ret.AppendLine(String.Format(OutputMessages.PilotSecondPlace, winners[1].FullName, raceName));
            ret.AppendLine(String.Format(OutputMessages.PilotThirdPlace, winners[2].FullName, raceName));
            return ret.ToString().Trim();
        }
    }
}
