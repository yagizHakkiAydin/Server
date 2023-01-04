using BattleOfMinds.Models.Models;

namespace BattleOfMinds.MVC.Communication
{
    public interface IServiceCommunication
    {
        Task<T> GetResponseWithoutToken<T>(string weburl) where T : class;
        Task<List<T>> GetResponseList<T>(string weburl);
        Task<string> GetResponse(string weburl);
        Task<string> PostResponse<T>(string weburl, object data);
    }
}
