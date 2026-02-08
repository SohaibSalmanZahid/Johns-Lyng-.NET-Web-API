using System.ComponentModel.DataAnnotations;

namespace TodoList_Backend.DTOs.RequestDTOs;

public class UserRequestDTO
{
    [Required(ErrorMessage = "Name is Required")]
    public string name { get; set; }
}