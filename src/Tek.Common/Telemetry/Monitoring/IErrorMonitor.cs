﻿using System;

namespace Tek.Common
{
    public interface IErrorMonitor
    {
        ReleaseSettings Release { get; }
        ErrorMonitorSettings Settings { get; }

        void Error(Exception ex);
    }
}