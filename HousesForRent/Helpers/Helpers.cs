using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesForRent.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<T2> ToViewModel<T1, T2>(this IEnumerable<T1> source) where T1 : class
        {
            return source.Select(c =>
            {
                return JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(c));
            });
        }

        public static T2 ToViewModelSingle<T1, T2>(this T1 source) where T1 : class
        {
            return JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(source));
        }
    }
}