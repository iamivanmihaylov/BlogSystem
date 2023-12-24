using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BlogSystem.Data.Models
{
    public enum ReactionType
    {
        Like = 0,
        Angry = 1,
        Love = 2,
        Wow = 3,
        Congrtulations = 4,
    }
}