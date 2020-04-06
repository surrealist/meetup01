using System;
using System.ComponentModel.DataAnnotations;

namespace Meeup01.Models
{
  public class Suspect
  { 
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(15)]
    public string MobileNo { get; set; }
    
    [Required]
    [StringLength(13)]
    public string CitizenId { get; set; }

    public Sex Sex { get; set; }

    public string Nationality { get; set; }

    public DateTime EntryDate { get; set; }
    public string Reason { get; set; }
    public string Description { get; set; }      
  }
}
