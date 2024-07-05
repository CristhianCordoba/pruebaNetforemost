using Microsoft.AspNetCore.Mvc;
using PruebaApi.Models;
using PruebaApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeudoresController : ControllerBase
    {
        private readonly BDRepository _repository;

        public DeudoresController(BDRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<DeudoresModel>> Get()
        {
            return await _repository.CallStoredProcedureAsyncDeudores();
        }

        public async Task<IEnumerable<ModeGestoresSaldos>> GetDeudoresSaldos()
        {
            return await _repository.CallStoredProcedureAsyncDeudoresSaldos();
        }

        public async Task<IEnumerable<ModeGestoresSaldos>> GetDeudoresCalculoBD()
        {
            return await _repository.CallStoredProcedureAsyncDeudoresSaldos();
        }
    }
}
