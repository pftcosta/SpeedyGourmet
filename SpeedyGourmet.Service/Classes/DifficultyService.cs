﻿using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class DifficultyService : IService<Difficulty, int>
    {
        private readonly IRepository<Difficulty, int> _difficultyRepository;

        public DifficultyService(IRepository<Difficulty, int> difficultyRepository)
        {
            _difficultyRepository = difficultyRepository;
        }

        public Difficulty Create(Difficulty difficulty)
        {
           return _difficultyRepository.Create(difficulty);
        }

        public Difficulty GetById(int difficultyId)
        {
            return _difficultyRepository.GetById(difficultyId);
        }

        public List<Difficulty> GetAll()
        {
            return _difficultyRepository.GetAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return _difficultyRepository.Update(difficulty);
        }

        public void Delete(int difficultyId)
        {
            _difficultyRepository.Delete(difficultyId);
        }
    }
}
