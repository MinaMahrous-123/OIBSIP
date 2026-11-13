using AutoMapper;
using BLL.GenericRepo;
using BLL.Model;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IngredientsServices : IIngredientsServices
    {
        private readonly BaseRepository<Ingredients> _data;
        private readonly IMapper _map;

        public IngredientsServices(BaseRepository<Ingredients> data,IMapper map)
        {
            _data = data;
            _map = map;
        }
        public async Task<IngredientsDTO> Create(IngredientsDTO ingredient)
        {
            var IngredientEntity = _map.Map<Ingredients>(ingredient);
            await _data.AddAsync(IngredientEntity);
            await _data.Save();
            return _map.Map<IngredientsDTO>(IngredientEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var ingredient =await _data.GetByAsync(e=>e.Id==id);
            if (ingredient == null)
            {
                return false;
            }
            _data.Delete(ingredient);
            await _data.Save();
            return true;

        }

        public async Task<IEnumerable<IngredientsDTO>> GetAll()
        {
            IEnumerable<Ingredients> ingredients = await _data.GetAllAsync();
            return _map.Map<IEnumerable<IngredientsDTO>>(ingredients);
        }

        public async Task<IngredientsDTO> GetById(int id)
        {
            var ingredient = await _data.GetByAsync(e => e.Id == id);
            if (ingredient == null)
            {
                return null;
            }
            return _map.Map<IngredientsDTO>(ingredient);
        }

        public async Task<IngredientsDTO> Update(IngredientsDTO ingredient)
        {
          var ingredientEntity = await _data.GetByAsync(e => e.Id == ingredient.Id);
            if (ingredientEntity == null)
            {
                return null;
            }
            _map.Map(ingredient, ingredientEntity);
            _data.Update(ingredientEntity);
            await _data.Save();
            return _map.Map<IngredientsDTO>(ingredientEntity);
        }
    }

    public interface IIngredientsServices
    {
        public Task<IEnumerable<IngredientsDTO>> GetAll();
        public Task<IngredientsDTO> GetById(int id);

        public Task<IngredientsDTO> Create(IngredientsDTO ingredient);

        public Task<IngredientsDTO> Update(IngredientsDTO ingredient);

        public Task<bool> Delete(int id);
    }
}
