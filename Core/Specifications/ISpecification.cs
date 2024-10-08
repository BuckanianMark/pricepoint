
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace Core.Specifications
{
    public interface ISpecification<T> 
    {
        Expression<Func<T, bool>> Criteria{get;}
        List<Expression<Func<T, object>>> Includes{get;}
        List<Expression<Func<T, object>>> ThenIncludes{get;}

        Expression<Func<T, object>>OrderBy {get;}
        Expression<Func<T, object>> OrderByDescending{get;}

        int Take{get;}
        int Skip{get;}
        bool IsPagingEnabled{get;}
    }
}