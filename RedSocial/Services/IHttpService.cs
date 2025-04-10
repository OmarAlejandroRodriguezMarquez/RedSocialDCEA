namespace RedSocial.Services;

public interface IHttpService
{
    Task<T> GetAsync<T>();
    Task<T> GetInfo<T>(string url, T model);
}