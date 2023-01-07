namespace RESTfull.Infrastructure
{
    public abstract class BaseRepository
    {
        protected readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BaseRepository(Context context)
        {
            _context = context;
        }
    }
}
