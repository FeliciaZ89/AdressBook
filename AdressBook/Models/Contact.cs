﻿using AdressBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Models;

public class Contact : IContact
{
    public int Id { get; set; } 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;


}
