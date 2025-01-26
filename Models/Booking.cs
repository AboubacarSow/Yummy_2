using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yummy_2.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Name {  get; set; }   
        public string Email {  get; set; }  
        public string PhoneNumber {  get; set; }    
        public DateTime BookingDate { get; set; }
        [NotMapped]
        public double Time {  get; set; }   
        public int PersoneCount {get; set; }
        public string MessageContent {  get; set; }
        public bool IsApproved {  get; set; }  =false;
    }
}