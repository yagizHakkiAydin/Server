namespace BattleOfMinds.MVC.Communication
{
    public interface IServiceCommunication
    {
        Task<T> GetResponseWithoutToken<T>(string weburl) where T : class;
        Task<List<T>> GetResponseList<T>(string weburl);
        Task<HttpResponseMessage> GetResponse(string weburl);
        Task<HttpResponseMessage> PostResponse<T>(string weburl, object data);
    }
}
