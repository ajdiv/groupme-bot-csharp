using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IAwardsTool
    {
        public Task<string> GetAwards();
    }
}
