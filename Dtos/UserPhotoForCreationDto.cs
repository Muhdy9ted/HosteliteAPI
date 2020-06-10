using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
  public class UserPhotoForCreationDto
  {
    public string Url { get; set; }
    public IFormFile File { get; set; }
    public DateTime DateAdded { get; set; }

    public string PublicID { get; set; }

    public UserPhotoForCreationDto()
    {
      DateAdded = DateTime.Now;
    }

  }
}
