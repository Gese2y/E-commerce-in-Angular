using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }
        List<Expression<Func<T, object>>> Includes {get; }
        Expression<Func<T, object>> orderBy{get;}
        Expression<Func<T, object>> orderByDescending{get;}
        int Take {get;}
        int Skip {get;}
        bool IsPagingEnabled{get;}
    }
}