using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Models
{
  public class ResponseModel
  {
    public RequestState state { get; set; }
    public string msg { get; set; }
    public object data { get; set; }
  }
  public enum RequestState
  {
    success = 1,
    failed = 0
  }
}
