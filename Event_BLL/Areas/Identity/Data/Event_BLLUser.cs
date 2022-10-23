using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Event_BLL.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Event_WebUser class
public class Event_BLLUser : IdentityUser
{
    [PersonalData]
    public string ? Name { get; set; }
    [PersonalData]
    public string ? LastName { get; set; }
}

