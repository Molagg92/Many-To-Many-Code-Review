using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "The machine's type can't be empty!")]
    public string Type { get; set; }
    public string RequiredLicense { get; set; }
    
    public List<EngineerMachineEntity> EngineerMachineEntities{ get; set; }

  }

}