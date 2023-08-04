using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Type { get; set; }
    public string RequiredLicense { get; set; }
    
    public List<EngineerMachineEntity> EngineerMachineEntities{ get; set; }

  }

}