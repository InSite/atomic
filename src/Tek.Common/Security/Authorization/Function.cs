﻿using System;

namespace Tek.Common
{
    public class Function : Model
    {
        public FunctionType ParseType()
        {
            if (Enum.TryParse(Type, out FunctionType type))
                return type;

            return FunctionType.None;
        }
    }
}