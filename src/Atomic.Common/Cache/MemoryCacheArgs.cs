﻿using System;

namespace Atomic.Common
{
    public class MemoryCacheArgs<TKey, TData> : EventArgs
    {
        public TKey Key { get; }
        public TData Data { get; }

        public MemoryCacheArgs(TKey key, TData data)
        {
            Key = key;
            Data = data;
        }
    }
}