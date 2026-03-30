using Microsoft.EntityFrameworkCore;
using THSDotNetCore.Database.Models;

namespace THSDotNetCore.Domain.Features
{
    public class BlogService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public List<TblBlog> GetBlogs()
        {
            var lst = _db.TblBlogs
                .AsNoTracking()
                .Where(x => x.DeleteFlag == false)
                .ToList();
            return lst;
        }

        public TblBlog GetBlog(int id)
        {
            var item = _db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id && x.DeleteFlag == false);
            return item;
        }

        public int CreateBlog(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            int result = _db.SaveChanges();
            return result;
        }

        public int UpdateBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.DeleteFlag = true;
            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();
            return result;
        }
    }
}

