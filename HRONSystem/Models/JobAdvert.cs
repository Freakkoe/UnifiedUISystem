using System;
using System.ComponentModel.DataAnnotations;

namespace HRONSystem.Models
{
    public class JobAdvert
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Publiceringsdato")]
        public DateTime PublishingDate { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Ansøgningsfrist")]
        public DateTime ApplicationDeadline { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Jobtitel")]
        [StringLength(255)]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Media is required")]
        [Display(Name = "Medie")]
        public string Media { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Responsible is required")]
        [Display(Name = "Ansvarlig")]
        public string Responsible { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Afdeling")]
        public string Department { get; set; }

        [Display(Name = "Visninger")]
        public int Views { get; set; } = 0;

        [Required(ErrorMessage = "Applications is required")]
        [Display(Name = "Ansøgninger")]
        public int Applications { get; set; } = 0;

        [Required(ErrorMessage = "Comment is required")]
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
