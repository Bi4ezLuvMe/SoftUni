using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        Dictionary<string,Flight>flightsById = new Dictionary<string,Flight>();
        Dictionary<string,Airline>airlinesById = new Dictionary<string,Airline>();
        public void AddAirline(Airline airline)
        {
            airlinesById.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!airlinesById.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }
            flightsById.Add(flight.Id, flight);
            flight.airline = airline;
            airline.flights.Add(flight);
        }

        public bool Contains(Airline airline) => airlinesById.ContainsKey(airline.Id);

        public bool Contains(Flight flight) => flightsById.ContainsKey(flight.Id);

        public void DeleteAirline(Airline airline)
        {
            if (!airlinesById.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }
            foreach (var flight in airline.flights)
            {
                flightsById.Remove(flight.Id);
            }
            airlinesById.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName() => airlinesById.Values.OrderByDescending(x => x.Rating).ThenByDescending(x => x.flights.Count).ThenBy(x => x.Name);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination) => airlinesById.Values.Where(x => getAirlinesWithFlights(x.flights,origin,destination));
        bool getAirlinesWithFlights(List<Flight> flights,string origin,string destination)
        {
            foreach (var flight in flights)
            {
                if (flight.Origin == origin && flight.Destination == destination)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<Flight> GetAllFlights() => flightsById.Values;

        public IEnumerable<Flight> GetCompletedFlights() => flightsById.Values.Where(x => x.IsCompleted == true);

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber() => flightsById.Values.OrderBy(x => x.IsCompleted).ThenBy(x => x.Number);

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!airlinesById.ContainsKey(airline.Id)||!flightsById.ContainsKey(flight.Id))
            {
                throw new ArgumentException();
            }
            flight.IsCompleted = true;
            return flight;
        }
    }
}
