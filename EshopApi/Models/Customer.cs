﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EshopApi.Models;

public partial class Customer
{
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Enter FirstName")]
    [StringLength(50)]
    public string? FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Phone]
    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
