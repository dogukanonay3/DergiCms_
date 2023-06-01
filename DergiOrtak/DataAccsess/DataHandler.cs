using DergiOrtak.Entity;

namespace DergiOrtak.DataAccsess
{
    public interface IDataHandler
    {
        KategoriDataHandler Kategori { get; }
        DergiDataHandler Dergi { get; }
        SayiDataHandler Sayi { get; }
        MakaleDataHandler Makale { get; }
        void Insert(EntityBase model);
        void Update(EntityBase model);
        void Delete(EntityBase model);
    }
    public class DataHandler : DataHandlerBase, IDataHandler
    {
        private readonly DergiDbContext _dbContext;
        public DataHandler(DergiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        private DergiDataHandler _dergiDataHandler;
        public DergiDataHandler Dergi
        {
            get
            {
                if (_dergiDataHandler == null)
                    _dergiDataHandler = new DergiDataHandler(_dbContext);

                return _dergiDataHandler;
            }
        }
        private KategoriDataHandler _kategoriDataHandler;
        public KategoriDataHandler Kategori
        {
            get
            {
                if (_kategoriDataHandler == null)
                    _kategoriDataHandler = new KategoriDataHandler(_dbContext);

                return _kategoriDataHandler;
            }
        }
        private SayiDataHandler _sayiDataHandler;
        public SayiDataHandler Sayi
        {
            get
            {
                if (_sayiDataHandler == null)
                    _sayiDataHandler = new SayiDataHandler(_dbContext);

                return _sayiDataHandler;
            }
        }
        private MakaleDataHandler _makaleDataHandler;
        public MakaleDataHandler Makale
        {
            get
            {
                if (_makaleDataHandler == null)
                    _makaleDataHandler = new MakaleDataHandler(_dbContext);

                return _makaleDataHandler;
            }
        }
    }
}
