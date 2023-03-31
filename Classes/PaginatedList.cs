using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace HatShopWebAppWAzureDB.Classes
{
    public class PaginatedList<T>:List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items,int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(List<T> items, int count, int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            items =  items.Skip(skip).Take(pageSize).ToList();
            return new PaginatedList<T>(items,count, pageIndex, pageSize);
        }

    }
}
