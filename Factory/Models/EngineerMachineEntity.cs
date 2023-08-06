using System.Collections.Generic;
namespace Factory.Models;

public class EngineerMachineEntity
{
   public int EngineerMachineEntityId { get; set; }
  public int EngineerId { get; set; }
  public Engineer Engineer { get; set; }
  public int MachineId { get; set; }
  public Machine Machine { get; set; }
}