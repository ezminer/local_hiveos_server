using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class EnumerableExtension
    {
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
          return  new ObservableCollection<TSource>(source);
        }

    }

