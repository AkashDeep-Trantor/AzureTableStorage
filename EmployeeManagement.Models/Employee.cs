using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee ID")]
        public string EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "First Name must be less than 10 characters")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Last Name must be less than 20 characters")]
        public string LastName { get; set; }

        [Column("Email")]
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, ErrorMessage = "Email must be less than 30 characters")]
        public string Email { get; set; }

        [Column("Department")]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        [StringLength(30, ErrorMessage = "Department must be less than 30 characters")]
        public string Department { get; set; }

        [Column("State")]
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
    }
}
