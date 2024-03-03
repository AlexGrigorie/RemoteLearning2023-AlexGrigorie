using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            return Rooms.AsQueryable().Where(r => r.MaxPersonCount == 2).ToList();
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            return Customers.AsQueryable().Where(c => c.FullName.ToLower().Contains(text.ToLower())).ToList();
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            return Reservations.AsQueryable().Where(r => r.Customer is CompanyCustomer).ToList();
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            return Customers.AsQueryable().OfType<PersonCustomer>()
                .Where(c => startTime <= c.LastAccommodation && c.LastAccommodation <= endTime && (c.Gender.ToString() == "Female")).ToList();
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            return Rooms.AsQueryable().Sum(r => r.MaxPersonCount);
        }

        /// <summary>
        /// 6) Return a single page containing a number of exactly pageSize Rooms, ordered by surface.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            return Rooms.AsQueryable().OrderBy(r => r.Surface).Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            return Rooms.AsQueryable().OrderByDescending(r => r.MaxPersonCount).ThenBy(r => r.Number).ToList();
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            return Reservations.AsQueryable().OrderByDescending(r => r.StartDate).Where(r => r.Customer.Id == customerId).ToList();
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            var orderCustomersByFullName = Customers.AsQueryable().OrderBy(ocbf => ocbf.FullName).ToList();
            return orderCustomersByFullName.AsQueryable().OrderByDescending(ocbf => ocbf.LastAccommodation.Year)
                                                         .GroupBy(g => g.LastAccommodation.Year)
                                                         .Select(s => new KeyValuePair<int, Customer[]>(s.Key, s.ToArray())).ToList();
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            return Reservations.AsQueryable().GroupBy(r => r.StartDate.Month).Average(m => m.Count());
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            IDictionary<Reservation, List<Reservation>> overBookingList = new Dictionary<Reservation, List<Reservation>>();
            var getAllReservations = Reservations.AsQueryable().ToList();

            foreach (var reservation in getAllReservations)
            {
                var conflictingReservations = getAllReservations.Where(cr => cr != reservation && cr.ConflictsWith(reservation)).ToList();

                if (conflictingReservations.Any())
                {
                    overBookingList.Add(reservation, conflictingReservations);
                }
            }
            return overBookingList;
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        /// 
        /// A similar room is a room that has the same number of maximum occupants or grater, has air conditioner if
        /// the original reserved room had, is disabled friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            var conflictingRoomNumbers = Reservations.AsQueryable()
                                                     .Where(r => r.Id != reservation.Id && r.ConflictsWith(reservation.StartDate, reservation.EndDate))
                                                     .Select(r => r.Room.Number).ToList();
            foreach (var room in Rooms)
            {
                if (room.MaxPersonCount >= reservation.Room.MaxPersonCount &&
                    room.HasAirConditioner == reservation.Room.HasAirConditioner &&
                    room.IsDisabledFriendly == reservation.Room.IsDisabledFriendly &&
                    room.HasBalcony == reservation.Room.HasBalcony && 
                    !conflictingRoomNumbers.Contains(room.Number))
                {
                    return room;
                }
            }

            return null;
        }
    }
}