﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DbSets
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}