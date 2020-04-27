using System;
using System.Linq.Expressions;
using AutoMapper;

namespace SHT.Infrastructure.Common.Extensions
{
    public static class AutoMapperConfigurationExtensions
    {
        public static IMappingExpression<TSource, TDestination> Map<TSource, TDestination, TMember, TSourceMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationExpression,
            Expression<Func<TSource, TSourceMember>> sourceExpression)
        {
            return mappingExpression.ForMember(destinationExpression, o => o.MapFrom(sourceExpression));
        }

        public static void IgnoreAllOther<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllOtherMembers(m => m.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            params Expression<Func<TDestination, object>>[] destinationExpression)
        {
            var expr = mappingExpression;
            foreach (var expression in destinationExpression)
            {
                expr = mappingExpression.ForMember(expression, o => o.Ignore());
            }

            return expr;
        }
    }
}