using System; // Provides base class definitions and fundamental types.
using System.ComponentModel.DataAnnotations; // Provides attributes for data validation.

namespace HRONSystem.Models
{
    // Represents a Job Advertisement in the system.
    public class JobAdvert
    {
        [Key] // Specifies that this property is the primary key of the table.
        public int Id { get; set; } // Primary key for the JobAdvert entity.

        [Required(ErrorMessage = "Date is required")] // Ensures this property is mandatory.
        [Display(Name = "Publiceringsdato")] // Specifies the display name for this property.
        public DateTime PublishingDate { get; set; } // The date when the job was published.

        [Required(ErrorMessage = "Date is required")] // Ensures this property is mandatory.
        [Display(Name = "Ansøgningsfrist")] // Specifies the display name for this property.
        public DateTime ApplicationDeadline { get; set; } // The deadline for job applications.

        [Required(ErrorMessage = "Title is required")] // Ensures this property is mandatory.
        [Display(Name = "Jobtitel")] // Specifies the display name for this property.
        [StringLength(255)] // Specifies the maximum length for the job title.
        public string JobTitle { get; set; } // Title of the job position.

        [Required(ErrorMessage = "Media is required")] // Ensures this property is mandatory.
        [Display(Name = "Medie")] // Specifies the display name for this property.
        public string Media { get; set; } // The medium where the job was published (e.g., online, newspaper).

        [Required(ErrorMessage = "Status is required")] // Ensures this property is mandatory.
        [Display(Name = "Status")] // Specifies the display name for this property.
        public string Status { get; set; } // The current status of the job advert (e.g., open, closed).

        [Required(ErrorMessage = "Responsible is required")] // Ensures this property is mandatory.
        [Display(Name = "Ansvarlig")] // Specifies the display name for this property.
        public string Responsible { get; set; } // The person responsible for the job advert.

        [Required(ErrorMessage = "Department is required")] // Ensures this property is mandatory.
        [Display(Name = "Afdeling")] // Specifies the display name for this property.
        public string Department { get; set; } // The department the job is associated with.

        [Display(Name = "Visninger")] // Specifies the display name for this property.
        public int Views { get; set; } = 0; // The number of views the advert has received.

        [Required(ErrorMessage = "Applications is required")] // Ensures this property is mandatory.
        [Display(Name = "Ansøgninger")] // Specifies the display name for this property.
        public int Applications { get; set; } = 0; // The number of applications received.

        [Required(ErrorMessage = "Comment is required")] // Ensures this property is mandatory.
        [Display(Name = "Kommentarer")] // Specifies the display name for this property.
        public string Comments { get; set; } // Any comments related to the advert.

        [Display(Name = "Arkiveret")] // Specifies the display name for this property.
        public bool IsArchived { get; set; } = false; // Indicates whether the job advert has been archived.

        // Default constructor.
        public JobAdvert()
        {
        }

        // Parameterized constructor for initializing properties.
        public JobAdvert(int id, DateTime publishingDate, DateTime applicationDeadline, string jobTitle, string media, string status, string responsible, string department, int views, int applications, string comments, bool isArchived)
        {
            Id = id;
            PublishingDate = publishingDate;
            ApplicationDeadline = applicationDeadline;
            JobTitle = jobTitle;
            Media = media;
            Status = status;
            Responsible = responsible;
            Department = department;
            Views = views;
            Applications = applications;
            Comments = comments;
            IsArchived = isArchived;
        }

        // Overrides the default ToString method to provide a string representation of the object.
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(PublishingDate)}={PublishingDate.ToString()}, {nameof(ApplicationDeadline)}={ApplicationDeadline.ToString()}, {nameof(JobTitle)}={JobTitle}, {nameof(Media)}={Media}, {nameof(Status)}={Status}, {nameof(Responsible)}={Responsible}, {nameof(Department)}={Department}, {nameof(Views)}={Views.ToString()}, {nameof(Applications)}={Applications.ToString()}, {nameof(Comments)}={Comments}, {nameof(IsArchived)}={IsArchived.ToString()}}}";
        }
    }
}
