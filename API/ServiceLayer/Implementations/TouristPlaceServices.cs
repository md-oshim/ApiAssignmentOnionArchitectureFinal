﻿using DomainLayer;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System.Linq;

namespace ServiceLayer.Implementations
{
    public class TouristPlaceServices : ITouristPlaceServices
    {
        private readonly IRepository<TouristPlace> _touristPlaceRepository;
        public TouristPlaceServices(IRepository<TouristPlace> touristPlaceRepository)
        {
            _touristPlaceRepository = touristPlaceRepository;
        }
        public async Task DeleteTouristPlaceAsync(int id)
        {
            await _touristPlaceRepository.DeleteOneAsync(id);
        }

        public async Task<IAsyncEnumerable<TouristPlace>> GetAllTouristPlacesAsync()
        {
            return await _touristPlaceRepository.GetAllAsync();
        }

        public async Task<TouristPlace> GetTouristPlaceByIdAsync(int id)
        {
            return await _touristPlaceRepository.GetOneAsync(id);
        }

        public async Task InsertTouristPlaceAsync(TouristPlace touristPlace)
        {
            await _touristPlaceRepository.InsertOneAsync(touristPlace);
        }

        public async Task UpdateTouristPlaceAsync(TouristPlace touristPlace)
        {
            await _touristPlaceRepository.UpdateOneAsync(touristPlace);
        }

        public async Task<bool> IsExistsAsync(string name, int id = -1)
        {
            var result = await _touristPlaceRepository.GeneralSearchAsync((touristPlace) => touristPlace.Name == name && touristPlace.Id != id).Result.ToListAsync();
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IAsyncEnumerable<TouristPlace>> TouristPlaceGeneralSearchAsync(string searchedText)
        {
            var result = await _touristPlaceRepository.GeneralSearchAsync((touristPlace) => touristPlace.Name.Contains(searchedText));
            return result;
        }
    }
}
