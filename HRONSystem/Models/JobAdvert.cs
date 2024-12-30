using System;
using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class JobAdvert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Publiceringsdato")]
        public DateTime PublishingDate { get; set; }

        [Required]
        [Display(Name = "Ansøgningsfrist")]
        public DateTime ApplicationDeadline { get; set; }

        [Required]
        [Display(Name = "Jobtitel")]
        [StringLength(255)]
        public string JobTitle { get; set; }

        [Display(Name = "Medie")]
        public string Media { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Ansvarlig")]
        public string Responsible { get; set; }

        [Display(Name = "Afdeling")]
        public string Department { get; set; }

        [Display(Name = "Visninger")]
        public int Views { get; set; } = 0;

        [Display(Name = "Ansøgninger")]
        public int Applications { get; set; } = 0;

        [Display(Name = "Kommentarer")]
        public string Comments { get; set; }

        [Display(Name = "Arkiveret")]
        public bool IsArchived { get; set; } = false;

        public JobAdvert()
        {
            
        }

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

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(PublishingDate)}={PublishingDate.ToString()}, {nameof(ApplicationDeadline)}={ApplicationDeadline.ToString()}, {nameof(JobTitle)}={JobTitle}, {nameof(Media)}={Media}, {nameof(Status)}={Status}, {nameof(Responsible)}={Responsible}, {nameof(Department)}={Department}, {nameof(Views)}={Views.ToString()}, {nameof(Applications)}={Applications.ToString()}, {nameof(Comments)}={Comments}, {nameof(IsArchived)}={IsArchived.ToString()}}}";
        }
    }

}
