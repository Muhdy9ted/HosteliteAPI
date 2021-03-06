﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
  public class HostelForListDto
  {
    public int ID { get; set; }

    /// <summary>
    /// The hostel name field that holds the hostel name
    /// </summary>
    /// <returns></returns>
    public string HostelName { get; set; }

    /// <summary>
    /// The hostel address field that holds a unique address for every hostel
    /// </summary>
    /// <returns></returns>
    public string HostelAddress { get; set; }

    /// <summary>
    /// The hostel location field that holds the location of the hostel 
    /// </summary>
    /// <returns></returns>
    public string HostelLocation { get; set; }

    /// <summary>
    /// The hostel type field that holds the type of rooms in the hostel
    /// </summary>
    /// <returns></returns>
    public string HostelType { get; set; }

    /// <summary>
    /// The hostel number field that holds the number of rooms in the hostel
    /// </summary>
    /// <returns></returns>
    //public int HostelNumberOfRooms { get; set; }

    /// <summary>
    /// The hostel description field that holds a detail description of the essentail facilities in the hostel
    /// </summary>
    /// <returns></returns>
    //public string HostelDescription { get; set; }

    /// <summary>
    /// The vacant room field that signifies if rooms are vacant in the hostel
    /// </summary>
    /// <returns></returns>
    public Boolean VacantRoom { get; set; }

    /// <summary>
    /// The hostel slug field that holds a concantanation of various hostel model fields for making a friendly url
    /// </summary>
    /// <returns></returns>
    //public string HostelSlug { get; set; }

    /// <summary>
    /// The rent field that holds the rent price for the rooms in the hostel
    /// </summary>
    /// <returns></returns>
    //public double RentPerRoom { get; set; }

    /// <summary>
    /// The hostel created field that holds the time and date an hostel was created and added to the db
    /// </summary>
    /// <returns></returns>
    public DateTime CreatedHostel { get; set; }


    /// <summary>
    /// The password hash field that holds the hashed value of the user's password
    /// </summary>
    /// <returns></returns>
    public string PhotoUrl { get; set; }
  }
}
