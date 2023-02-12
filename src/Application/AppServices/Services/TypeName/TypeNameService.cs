using AppServices.IRepository;
using AutoMapper;
using Contracts.AnimalType;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.AnimalType
{
    public class TypeNameService : ITypeNameService
    {
        public readonly ITypeNameRepository _typeRepository;
        public readonly IMapper _mapper;

        public TypeNameService(ITypeNameRepository typeRepository, IMapper mapper) 
        {
            _typeRepository = typeRepository; 
            _mapper = mapper;
        }

        public async  Task<InfoTypeNameResponse> AddType(AddOrUpdateTypeRequest requestType)
        {
            var newType = _mapper.Map<Domain.TypeName>(requestType);
            await _typeRepository.AddTypeName(newType);

            return _mapper.Map<InfoTypeNameResponse>(newType);
        }

        public async Task DeleteType(long id)
        {
            var existingType = await _typeRepository.GetTypeNameById(id);

            await _typeRepository.DeleteTypeName(existingType);
        }

        public async Task<InfoTypeNameResponse> EditType(long Id, AddOrUpdateTypeRequest requestType)
        {
            var existingType = await _typeRepository.GetTypeNameById(Id);

            await _typeRepository.EditTypeName(_mapper.Map(requestType, existingType));

            return _mapper.Map<InfoTypeNameResponse>(requestType);
        }

        public async Task<InfoTypeNameResponse> GetInfoAnimalType(long id)
        {
            var animalType = await _typeRepository.GetTypeNameById(id);

            InfoTypeNameResponse typeRes= null;
            if (animalType == null)
                return typeRes;

            return _mapper.Map<InfoTypeNameResponse>(animalType);      
        }
    }
}
