using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.WebApi.RequestModels.BookTagRequestModels;
using OnionLibrary.WebApi.ResponseModels.BookTagResponseModel;

namespace OnionLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTagController : ControllerBase
    {
        private readonly IBookTagManager _bookTagManager;
        private readonly IMapper _mapper;

        public BookTagController(IBookTagManager bookTagManager, IMapper mapper)
        {
            _bookTagManager = bookTagManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // 1. Manager'dan DTO listesini çek
            List<BookTagDto> dtos = await _bookTagManager.GetAllAsync();

            // 2. DTO'ları UI dostu ResponseModel'e çevir
            var response = _mapper.Map<List<BookTagResponseModel>>(dtos);

            return Ok(response);
        }

        // QUERY: ID'ye Göre booktag Getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // 1. Manager'dan tekil veriyi çek
            BookTagDto dto = await _bookTagManager.GetByIdAsync(id);

            // 2. DTO'yu ResponseModel'e çevir
            var response = _mapper.Map<BookTagResponseModel>(dto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookTagRequestModel model)
        {
            // 1. Gelen RequestModel'i DTO'ya dönüştür
            BookTagDto dto = _mapper.Map<BookTagDto>(model);

            // 2. Manager üzerinden veritabanına kaydet
            await _bookTagManager.CreateAsync(dto);

            return Ok("BookTag başarıyla eklendi");
        }

        // COMMAND: booktagyi Güncelle
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookTagRequestModel model)
        {
            // 1. Gelen Update modelini DTO'ya dönüştür
            BookTagDto dto = _mapper.Map<BookTagDto>(model);

            // 2. Manager üzerinden güncelleme işlemini yap
            await _bookTagManager.UpdateAsync(dto);

            return Ok("booktag başarıyla güncellendi");
        }

        // COMMAND: booktagyi Sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Manager'dan dönen string mesajı (örn: "Id'li veri silindi") direkt kullanıcıya dön
            string result = await _bookTagManager.DeleteAsync(id);
            return Ok(result);
        }
    }
}
