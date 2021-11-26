using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IThesaurusTool
    {
        Task<string> ThesaurizeLastMessage();
    }
}
