using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class User
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? HouseNumber { get; set; }

    public string? Street { get; set; }

    public string? Area { get; set; }

    public Guid? StateId { get; set; }

    public Guid? CountryId { get; set; }

    public bool Is2Faenabeled { get; set; }

    public DateTime LastLoginDate { get; set; }

    public bool IsEnabled { get; set; }

    public string UserName { get; set; } = null!;

    public string PaswordHash { get; set; } = null!;

    public bool IsAccountVerified { get; set; }

    public Guid UserAccountTypeId { get; set; }

    public int TotalUserRequestsCompleted { get; set; }

    public int TotalProviderServicesCompleted { get; set; }

    public decimal ServiceProviderRating { get; set; }

    public decimal UserRating { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Appeal> AppealAppealForNavigations { get; set; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealAppealedByNavigations { get; set; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealCreatedByNavigations { get; set; } = new List<Appeal>();

    public virtual ICollection<AppealReason> AppealReasons { get; set; } = new List<AppealReason>();

    public virtual ICollection<Location> LocationCreatedByNavigations { get; set; } = new List<Location>();

    public virtual ICollection<Location> LocationModifiedByNavigations { get; set; } = new List<Location>();

    public virtual ICollection<Rate> RateCreatedByNavigations { get; set; } = new List<Rate>();

    public virtual ICollection<Rate> RateModifiedByNavigations { get; set; } = new List<Rate>();

    public virtual ICollection<ServiceCategory> ServiceCategoryCreatedByNavigations { get; set; } = new List<ServiceCategory>();

    public virtual ICollection<ServiceCategory> ServiceCategoryModifiedByNavigations { get; set; } = new List<ServiceCategory>();

    public virtual ICollection<Service> ServiceCreatedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceModifiedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<ServiceSubCategory> ServiceSubCategoryCreatedByNavigations { get; set; } = new List<ServiceSubCategory>();

    public virtual ICollection<ServiceSubCategory> ServiceSubCategoryModifiedByNavigations { get; set; } = new List<ServiceSubCategory>();

    public virtual ICollection<ServiceType> ServiceTypeCreatedByNavigations { get; set; } = new List<ServiceType>();

    public virtual ICollection<ServiceType> ServiceTypeModifiedByNavigations { get; set; } = new List<ServiceType>();

    public virtual ICollection<Task> TaskCreatedByNavigations { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskModifiedByNavigations { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskServiceProviderUsers { get; set; } = new List<Task>();

    public virtual ICollection<Tip> TipCustomerUsers { get; set; } = new List<Tip>();

    public virtual ICollection<Tip> TipServiceProviderUsers { get; set; } = new List<Tip>();

    public virtual ICollection<ToolBank> ToolBanks { get; set; } = new List<ToolBank>();

    public virtual UserAccountType UserAccountType { get; set; } = null!;
}
