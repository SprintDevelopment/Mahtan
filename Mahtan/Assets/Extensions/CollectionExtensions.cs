﻿using Mahtan.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahtan.Assets.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }

        //public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        //{
        //    return list.IsNullOrEmpty() ? null :
        //        list.Select((item, i) => new { item, i })
        //            .GroupBy(g => g.i / chunkSize)
        //            .Select(g => g.Select(i => i.item));
        //}

        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, string idPropertyName, string titlePropertyName, int? selectedValue)
        {
            return items?.Select(item => new SelectListItem
            {
                Value = item.GetPropertyValue(idPropertyName),
                Text = item.GetPropertyValue(titlePropertyName),
                Selected = selectedValue != null && item.GetPropertyValue(idPropertyName).Equals(selectedValue.ToString())
            });
        }
    }
}
