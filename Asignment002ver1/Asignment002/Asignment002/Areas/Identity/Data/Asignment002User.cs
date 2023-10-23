using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//account
namespace Asignment002.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Asignment002User class
public class Asignment002User : IdentityUser
{
    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public int Type{ get; set; }
}

