using MAS_projekt_s22580.Context;
using MAS_projekt_s22580.Models.Guitars;
using MAS_projekt_s22580.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MAS_projekt_s22580.Services
{
    public interface IGuitarService {
        /// <summary>
        /// Retrieves all acoustic guitars from the database.
        /// </summary>
        /// <returns>A collection of AcousticGuitar objects.</returns>
        public Task<IEnumerable<AcousticGuitar>> GetAcousticGuitars();

        /// <summary>
        /// Retrieves all electric guitars from the database.
        /// </summary>
        /// <returns>A collection of ElectricGuitar objects.</returns>
        public Task<IEnumerable<ElectricGuitar>> GetElectricGuitars();

        /// <summary>
        /// Retrieves all bass guitars from the database.
        /// </summary>
        /// <returns>A collection of BassGuitar objects.</returns>
        public Task<IEnumerable<BassGuitar>> GetBassGuitars();

        /// <summary>
        /// Retrieves a list of all guitars with basic information.
        /// </summary>
        /// <returns>A collection of GuitarForList objects.</returns>
        public Task<IEnumerable<GuitarForList>> GetAllGuitars();

        /// <summary>
        /// Adds a new guitar exemplar to the database.
        /// </summary>
        /// <param name="newGuitarExemplar">The new guitar exemplar to add.</param>
        public Task AddGuitarExemplar(GuitarExemplarPOST newGuitarExemplar);

        /// <summary>
        /// Adds a new electric guitar to the database.
        /// </summary>
        /// <param name="newGuitar">The new electric guitar to add.</param>
        public Task AddElectricGuitar(GuitarTypeElectricPOST newGuitar);

        /// <summary>
        /// Retrieves all guitar exemplars from the database.
        /// </summary>
        /// <returns>A collection of GuitarExemplar objects.</returns>
        public Task<IEnumerable<GuitarExemplar>> GetExemplars();

        /// <summary>
        /// Updates the status of a guitar.
        /// </summary>
        /// <param name="id">The ID of the guitar to update.</param>
        /// <param name="newPrice">The new price to set for the guitar.</param>
        public Task UpdateGuitarPrice(int id, double newPrice);

        /// <summary>
        /// Checks if a guitar exists by its ID.
        /// </summary>
        /// <param name="id">The ID of the guitar to check.</param>
        /// <returns>A boolean value indicating whether the guitar exists.</returns>
        Task<bool> DoesGuitarExists(int id);
    }
    public class GuitarService : IGuitarService
    {
        private readonly DatabaseContext _databaseContext;

        public GuitarService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc />
        public async Task AddElectricGuitar(GuitarTypeElectricPOST newGuitar)
        {
            var guitar = new ElectricGuitar
            {
                Model = newGuitar.Model,
                BodyMaterial = newGuitar.BodyMaterial,
                Brand = newGuitar.Brand,
                FretboardMaterial = newGuitar.FretboardMaterial,
                NumberOfStrings = newGuitar.NumberOfStrings,
                Price = newGuitar.Price,
                PickupsType = newGuitar.PickupsType
            };
            _databaseContext.GuitarTypes.Add(guitar);
            _databaseContext.ElectricGuitars.Add(guitar);
            await _databaseContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task AddGuitarExemplar(GuitarExemplarPOST newGuitarExemplar)
        {
                var guitarExemplar = new GuitarExemplar
                {
                    SerialNumber = newGuitarExemplar.SerialNumber,
                    IdGuitarType = newGuitarExemplar.IdGuitarType,
                    IdOrder = newGuitarExemplar.IdOrder
                };

                _databaseContext.GuitarExemplars.Add(guitarExemplar);
                await _databaseContext.SaveChangesAsync();
         }

        /// <inheritdoc />
        public async Task<bool> DoesGuitarExists(int id)
        {
            return _databaseContext.GuitarTypes.Any(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<AcousticGuitar>> GetAcousticGuitars()
        {
            return await _databaseContext.AcousticGuitars.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<GuitarForList>> GetAllGuitars()
        {
            return await _databaseContext.GuitarTypes
            .Select(g => new GuitarForList
            {
                Id = g.Id,
                NumberOfStrings = g.NumberOfStrings,
                FretboardMaterial = g.FretboardMaterial,
                BodyMaterial = g.BodyMaterial,
                Brand = g.Brand,
                Model = g.Model,
                Price = g.Price,
            })
            .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BassGuitar>> GetBassGuitars()
        {
            return await _databaseContext.BassGuitars.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ElectricGuitar>> GetElectricGuitars()
        {
            return await _databaseContext.ElectricGuitars.ToListAsync();
        }
        /// <inheritdoc />
        public async Task<IEnumerable<GuitarExemplar>> GetExemplars()
        {
           return await _databaseContext.GuitarExemplars.ToListAsync();
        }

        /// <inheritdoc />
        public async Task UpdateGuitarPrice(int id, double newPrice)
        {
            var guitar =  await _databaseContext.GuitarTypes.FirstOrDefaultAsync(o => o.Id == id);
            if (newPrice > guitar.Price * 1.1)
                {
                    throw new ArgumentException("Price may increase by up to 10%.");
                }
                guitar.Price = newPrice;
                _databaseContext.SaveChanges();
        }
    }
}
