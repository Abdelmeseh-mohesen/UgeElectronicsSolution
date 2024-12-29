using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace UgeElectronics.Core.Identity
{
    public class Address
    {
        public int Id { get; set; }
      

        //releation
        public string AppUserId { get; set; }//navgation pro
        public AppUser User { get; set; }
    }
}
