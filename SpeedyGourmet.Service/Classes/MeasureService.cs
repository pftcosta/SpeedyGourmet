using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class MeasureService : IService<Measure, int>    
    {
        private readonly IRepository<Measure, int> _measureRepository;

        public MeasureService(IRepository<Measure, int> measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public Measure Create(Measure measure)
        {
            return _measureRepository.Create(measure);
        }

        public Measure GetById(int id)
        {
            return _measureRepository.GetById(id);
        }

        public List<Measure> GetAll()
        {
            return _measureRepository.GetAll();
        }

        public Measure Update(Measure measure)
        {
            return _measureRepository.Update(measure);
        }

        public void Delete(int id)
        {
            _measureRepository.Delete(id);
        }
    }
}
