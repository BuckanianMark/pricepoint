using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

       
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } 
                    = new List<Expression<Func<T, object>>>();
        public List<Expression<Func<T, object>>> ThenIncludes { get; } = new List<Expression<Func<T, object>>>();


      
        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddThenInclude(Expression<Func<T, object>> thenIncludeExpression)
        {
            ThenIncludes.Add(thenIncludeExpression);
        }
    }
}
