﻿using System;
using System.Collections.Generic;

namespace PTDW.Models;

public partial class TblAccount
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string? LastLogin { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();
}
