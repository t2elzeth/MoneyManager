using System;
using Infrastructure.DataTypes;

namespace MoneyManager.DataTypes.API.Site.User;

public class UserFormDTO
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public UserIdentityDocumentDTO? IdentityDocument { get; set; }

    public UserMigrationCardDTO? MigrationCard { get; set; }

    public PoliticallyExposedPersonDTO? PoliticallyExposedPerson { get; set; }

    public PoliticallyExposedPersonRelativeDTO? PoliticallyExposedPersonRelative { get; set; }
    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public bool Verified { get; set; }

    public bool IsFormSigned { get; set; }

    public string ResidenceAddress { get; set; } = null!;

    public CountryDTO? Citizenship { get; set; }

    public bool SendAdverts { get; set; }

    public DateTime? VerificationTimestamp { get; set; }

    public VerificationMethod? VerificationMethod { get; set; }

    public Date? FormFillDate { get; set; }

    public DateTime? FormUploadDate { get; set; }

    public Date? FormExpireDate { get; set; }

    public Date? DateOfBirth { get; set; }
}