using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DAL.Extensions
{
    public static class ResultExtensions
    {
        public static IQueryable<Result> WithFileNameFilter(this IQueryable<Result> query, string? fileName)
        {
            if (fileName != null) return query.Where(x => x.File.NameFile == fileName);
            return query;
        }
        public static IQueryable<Result> WithAverageTimeFilter(this IQueryable<Result> query, double? timeFrom, double? timeTo)
        {
            if (timeFrom == null && timeTo != null) return query.Where(x => x.AverageTime <= timeTo);
            if (timeTo == null && timeFrom != null) return query.Where(x => x.AverageTime >= timeFrom);
            if (timeFrom != null && timeTo != null) return query.Where(x => x.AverageTime <= timeTo && x.AverageTime >= timeFrom);
            return query;
        }
        public static IQueryable<Result> WithAverageIndexFilter(this IQueryable<Result> query, double? indexFrom, double? indexTo)
        {
            if (indexFrom == null && indexTo != null) return query.Where(x => x.AverageIndex <= indexTo);
            if (indexTo == null && indexFrom != null) return query.Where(x => x.AverageIndex >= indexFrom);
            if (indexFrom != null && indexTo != null) return query.Where(x => x.AverageIndex <= indexTo && x.AverageIndex >= indexFrom);
            return query;
        }
        public static IQueryable<Result> WithFirstOperationFilter(this IQueryable<Result> query, DateTime? first, DateTime? last)
        {
            if (first == null && last != null) return query.Where(x => x.FirstOperation <= last);
            if (last == null && first != null) return query.Where(x => x.FirstOperation >= first);
            if (first != null && last != null) return query.Where(x => x.FirstOperation <= last && x.FirstOperation >= first);
            return query;
        }
    }
}
