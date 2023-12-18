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
        public Expression<Func<T, object>> OrderBy { get;private set; }
        public Expression<Func<T, object>> OrderByDescending { get;private set; }

        public int Take{ get;private set; }

        public int Skip{ get;private set; }

        public bool IsPagingEnabled { get;private set; }

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddThenInclude(Expression<Func<T, object>> thenIncludeExpression)
        {
            ThenIncludes.Add(thenIncludeExpression);
        }
        public void AddOrderBy(Expression<Func<T,object>> orderbyExpression)
        {
            OrderBy = orderbyExpression;
        }
         public void AddOrderByDescending(Expression<Func<T, object>> orderbyDescending)
        {
            OrderByDescending = orderbyDescending;
        }

         public void AddPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}
