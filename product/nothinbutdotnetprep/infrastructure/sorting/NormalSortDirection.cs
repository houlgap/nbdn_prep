using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class NormalSortDirection : SortDirection
    {
        public IComparer<T> apply_against<T>(IComparer<T> comparer)
        {
            return comparer;
        }
    }
}