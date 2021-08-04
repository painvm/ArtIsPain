using Microsoft.EntityFrameworkCore;

namespace Server.Extensions
{
    public static class StringExtensions
    {
        public static bool Like(this string searchArea, string searchTerm)
        {
            return EF.Functions.Like(searchArea, $"%{searchTerm}%");
        }
    }
}