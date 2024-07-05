using Microsoft.AspNetCore.Mvc;
using PruebaApi.Models;
using PruebaApi.Repositories;
using pruebaGestores.Models;
using System.Diagnostics;

namespace pruebaGestores.Controllers
{
    public class PagesController : Controller
    {
        private readonly BDRepository _repository;

        public PagesController(BDRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Deudores()
        {
            var deudores = await _repository.CallStoredProcedureAsyncDeudores();
            return View(deudores);
        }

        public async Task<IActionResult> AsociarDeudores()
        {
            var gestores = await _repository.CallStoredProcedureAsyncGestores();
            var deudores = await _repository.CallStoredProcedureAsyncDeudores();
            var deudoresSaldos = new List<ModeGestoresSaldos>();
            //Asginacion de los saldos a cada gestor
            var deudoresArray = deudores.ToArray();

            for (int i = 0; deudoresArray.Length > i;)
            {
                foreach (var g in gestores)
                {
                    ModeGestoresSaldos gestorEncontrado = deudoresSaldos.FirstOrDefault(p => p.id_gestor == g.id_gestor);


                    if (gestorEncontrado != null)
                    {
                        gestorEncontrado.saldo_gestor += deudoresArray[i].saldo;
                    }
                    else
                    {
                        var dataAux = new ModeGestoresSaldos();
                        dataAux.id_gestor = g.id_gestor;
                        dataAux.nombre = g.nombre;
                        dataAux.telefono = g.telefono;
                        dataAux.correo_electronico = g.correo_electronico;
                        dataAux.saldo_gestor = deudoresArray[i].saldo;
                        deudoresSaldos.Add(dataAux);
                    }

                    i++;
                }
            }

            return View(deudoresSaldos);
        }

        public async Task<IActionResult> AsociarDeudoresCalculoBD()
        {
            var deudoresSaldos = await _repository.CallStoredProcedureAsyncDeudoresSaldos();
            return View(deudoresSaldos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
