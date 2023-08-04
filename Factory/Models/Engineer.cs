using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public string MachineLicense { get; set; }
    public List<EngineerMachineEntity> EngineerMachineEntities{ get; set; }
    
  }

}