﻿namespace APIBook.Dtos
{ 
    public class StaffViewDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }//0:DDANG LAM,1:NGHI VIEC
        public Guid JobID { get; set; }

        public string? CreatedByUserName { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedByUserName { get; set; }
        public string JobName { get; set; }
    }
}
