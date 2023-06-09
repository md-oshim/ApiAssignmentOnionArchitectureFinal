﻿using DomainLayer;

namespace ServiceLayer.Interfaces
{
    public interface ITouristPlaceServices
    {
        Task<IAsyncEnumerable<TouristPlace>> GetAllTouristPlacesAsync();
        Task<IAsyncEnumerable<TouristPlace>> TouristPlaceGeneralSearchAsync(string searchedText);
        Task<TouristPlace> GetTouristPlaceByIdAsync(int id);
        Task InsertTouristPlaceAsync(TouristPlace touristPlace);
        Task UpdateTouristPlaceAsync(TouristPlace touristPlace);
        Task DeleteTouristPlaceAsync(int id);
        Task<bool> IsExistsAsync(string name, int id = -1);
    }
}
