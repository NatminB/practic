﻿using layerOne.models;

namespace layerTwo.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string InvNumber { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime YearOfPub { get; set; }
        public DateTime DateOfAdd { get; set; }
        public DateTime? DateOfCut { get; set; }
        public List<RentDTO> Rents { get; set; }
    }
}
