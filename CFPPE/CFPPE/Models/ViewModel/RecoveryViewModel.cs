﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CFPPE.Models.ViewModel
{
    public class RecoveryViewModel
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
    }