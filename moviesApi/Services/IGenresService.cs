namespace moviesApi.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genra>> GetAll();
        Task<Genra> GetById(Byte id);
        Task<Genra> Add(Genra genra);
        Genra Update(Genra genra);

        Genra Delete(Genra genra);

        Task<bool> IsvaliedGenre(Byte id);
    }
}
