namespace RedSocial.Services;

public interface IHttpService
{
    Task<T> GetAsync<T>();
}