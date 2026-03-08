using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AmassTest.Infrastructure.Data.AppDbContext
{
    public static class DbExceptionHelper
    {
        public static bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            return ex.InnerException is SqliteException sqliteEx
                && sqliteEx.SqliteErrorCode == 19;
        }
    }
}
