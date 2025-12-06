using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.InnerInfrastructure.ManagerConcretes;
using OnionLibrary.WebApi.RequestModels.BookRequestModels;
using OnionLibrary.WebApi.ResponseModels.BookResponseModel;

namespace OnionLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly IMapper _mapper;

        public BookController(IBookManager bookManager, IMapper mapper)
        {
            _bookManager = bookManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookManager.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequestModel model)
        {
            BookDto book = _mapper.Map<BookDto>(model);
            await _bookManager.CreateAsync(book);
            return Ok("Veri eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BookDto value = await _bookManager.GetByIdAsync(id);
            return Ok(_mapper.Map<BookResponseModel>(value));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookRequestModel model)
        {
            BookDto dto = _mapper.Map<BookDto>(model);
            await _bookManager.UpdateAsync(dto);
            return Ok("Kitap başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await _bookManager.DeleteAsync(id);
            return Ok(result);
        }

    }
}
