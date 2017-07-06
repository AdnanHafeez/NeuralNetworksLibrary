﻿using System;
using System.Collections.Generic;

namespace NeuralNetworks.Library.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ApplyInReverse<TEntity>(
            this List<TEntity> source, 
            Action<TEntity> actions)
        {
            var sourceCount = source.Count; 
            for (var i = sourceCount - 1; i >= 0; i--)
            {
                actions.Invoke(source[i]);
            }
        }
    }
}