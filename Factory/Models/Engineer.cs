using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "The Engineer needs a Name. This field can't be empty!")]
    public string Name { get; set; }
    public List<EngineerMachine> JoinEntities { get; set; }
  }
}