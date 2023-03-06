namespace moviesApi.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _context;

        public GenresService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genra> Add(Genra genra)
        {
            await _context.AddAsync(genra);
            _context.SaveChanges();
            return genra;
        }

        public Genra Delete(Genra genre)
        {
            _context.Remove(genre);
            _context.SaveChanges();
            return genre;
        }

        public async Task<IEnumerable<Genra>> GetAll()
        {
            var genres = await _context.Genras.OrderBy(g => g.Name).ToListAsync();
            return genres;
        }

        public async Task<Genra> GetById(byte id)
        {
            return await _context.Genras.FirstOrDefaultAsync(g => g.Id == id);
        }

        public Task<bool> IsvaliedGenre(byte id)
        {
               return _context.Genras.AnyAsync(g => g.Id == id);
 
        }

        public Genra Update(Genra genre)
        {
            _context.Update(genre);
            _context.SaveChanges();
            return genre;
        }
    }
}
