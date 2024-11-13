using System.ComponentModel.DataAnnotations;

namespace WebMinimalApi;

public class Person
{
    public int Id {get; internal set;}
    
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "The first name should be at most 50 characters")]
    public string  Name {get; set;}
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "The last name should be at most 50 characters")]
    public string LastName {get; set;}
    
    [Required(ErrorMessage = "Birth date is required")]
    [IsPastDate(ErrorMessage = "The birth date must be before the current date")]
    public DateTime BirthDate {get; set;}
    
    [Required(ErrorMessage = "Address is required")]
    [MinLength(2, ErrorMessage = "The address must be at least 3 characters long")]
    public string? Address {get; set;}
}

public class IsPastDate : ValidationAttribute
{
    public override bool IsValid(object value)
    {   
        DateTime birthDate = (DateTime)value;
        return birthDate <= DateTime.Now;
    }
}
