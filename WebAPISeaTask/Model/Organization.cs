using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class Organization
    {
        public Organization()
        {
            Projects = new HashSet<Project>();
            UserOrganizations = new HashSet<UserOrganization>();
            UserOwners = new HashSet<UserOwner>();
        }

        public int Id { get; set; }
        public string NameShort { get; set; } = null!;
        public string? NameFull { get; set; }
        public string? AddressLegal { get; set; }
        public int? UnpInn { get; set; }
        public int? CountryId { get; set; }
        public string? EmailAddress { get; set; }
        public string? LogoPath { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
        public virtual ICollection<UserOwner> UserOwners { get; set; }
    }
}
