using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.PostgreSQL.EF;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.PostgreSQL.Repository
{
    public class BlogEntryRepository : ISelectRepository<BlogEntry>
    {
        private readonly BlogContext _context;

        public BlogEntryRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogEntry>> GetAllAsync(Expression<Func<BlogEntry, bool>> predicate = null)
        {
            return predicate != null
                ? await _context.BlogEntries.Where(predicate).ToListAsync()
                : await _context.BlogEntries.AsNoTracking().ToListAsync();
        }

        private IQueryable<BlogEntry> GetAllIncludingProperties(Expression<Func<BlogEntry, object>>[] includeProperties)
        {
            var queryable = _context.BlogEntries.AsNoTracking();

            return includeProperties.Aggregate(queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<BlogEntry> GetAsync(int id, params Expression<Func<BlogEntry, object>>[] includeProperties)
        {
            return await GetAllIncludingProperties(includeProperties).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}