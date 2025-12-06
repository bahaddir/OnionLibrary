using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.WebApi.RequestModels.AuthorRequestModels;
using OnionLibrary.WebApi.ResponseModels.AuthorResponseModel;

namespace OnionLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorManager authorManager, IMapper mapper)
        {
            _authorManager = authorManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Manager'dan DTO listesi al
            List<AuthorDto> dtos = await _authorManager.GetAllAsync();

            // DTO -> ResponseModel çevir
            var response = _mapper.Map<List<AuthorResponseModel>>(dtos);

            return Ok(response);
        }

        // QUERY: ID'ye Göre Getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Manager'dan tekil DTO al
            AuthorDto dto = await _authorManager.GetByIdAsync(id);

            // DTO -> ResponseModel çevir
            var response = _mapper.Map<AuthorResponseModel>(dto);

            return Ok(response);
        }

        // COMMAND: Ekleme
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorRequestModel model)
        {
            // RequestModel -> DTO çevir
            AuthorDto dto = _mapper.Map<AuthorDto>(model);

            // Manager'a işi yaptır
            await _authorManager.CreateAsync(dto);

            return Ok("Yazar başarıyla eklendi");
        }

        // COMMAND: Güncelleme
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorRequestModel model)
        {
            // RequestModel -> DTO çevir
            AuthorDto dto = _mapper.Map<AuthorDto>(model);

            // Manager'a işi yaptır
            await _authorManager.UpdateAsync(dto);

            return Ok("Yazar başarıyla güncellendi");
        }

        // COMMAND: Silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Manager string döndüğü için direkt onu basıyoruz
            string result = await _authorManager.DeleteAsync(id);
            return Ok(result);
        }
    }
}
