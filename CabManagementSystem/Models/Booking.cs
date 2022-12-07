namespace CabServiceManagement.Models
{
    public enum CarModel
    {
        Auto,
        Sedan,
        CUV,
        SUV
    }
    public enum Location
    {
        
        Edappally,
        Kaloor,
        Thiruvankulam,
        Kakkanad,
        Aluva,
        Angamaly,
        Perumbavur,
        [Display(Name = "Marine Drive")]
        MarineDrive,
        [Display(Name = "Marine Drive")]
        FortKochi,
        Karingachira
    }

    public class Booking
    {
        public int Id { get; set; }



        [Required]
        [Display(Name = "Pick Up")]
        public Location From { get; set; }



        [Required]
        [Display(Name = "Destination")]
        public Location To { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        public CarModel CarModel { get; set; }
    }
}