﻿using System;
namespace TechJobsOOAutoGraded6
{
	public class PositionType : JobField
	{
        public PositionType(string value) : base(value)
        {

        }
        public override bool Equals(object? obj)
        {
            return obj is PositionType type &&
                   Id == type.Id;
        }
    }
}

