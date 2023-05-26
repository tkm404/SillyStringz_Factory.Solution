using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Designation { get; set; }
    public List<EngineerMachine> JoinEntities { get; set; }
  }
}