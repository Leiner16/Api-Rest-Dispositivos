using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Unillanos.Telematica.Dispositivos.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private static List<DispositivosDto> dispositivos = new List<DispositivosDto>();

        [HttpGet]
        [Route("listar")]
        public ActionResult<List<DispositivosDto>> Listar()
        {
            return dispositivos;
        }

        [HttpPost]
        [Route("InsertD")]
        public ActionResult<string> Insertar(DispositivosDto dispositivo)
        {
            dispositivos.Add(dispositivo);
            return CreatedAtAction(nameof(Listar), dispositivos);
        }


        [HttpPut]
        [Route("Editar/{id}")]
        public string Editar(int id, DispositivosDto dispositivo)
        {
            var index = dispositivos.FindIndex(d => d.ID == id.ToString()); // Encontrar el índice del dispositivo con el ID especificado
            if (index >= 0)
            {
                dispositivos[index] = dispositivo; // Reemplazar el dispositivo en el arreglo con el dispositivo actualizado
                return "Dispositivo editado con éxito";
            }
            else
            {
                return "Dispositivo no encontrado";
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public string Eliminar(int id)
        {
            var dispositivo = dispositivos.Find(d => d.ID == id.ToString()); // Encontrar el dispositivo con el ID especificado
            if (dispositivo != null)
            {
                dispositivos.Remove(dispositivo); // Eliminar el dispositivo del arreglo
                return "Dispositivo eliminado con éxito";
            }
            else
            {
                return "Dispositivo no encontrado";
            }
        }

        public class DispositivosDto
        {
            public string ID { get; set; }
            public string Nombre { get; set; }
            public string Precio { get; set; }
            public string Tipo { get; set; }
            public string uso { get; set; }
        }

        //Ingresar información
        //{
        //"ID": "11",
        //"Nombre": "Dispositivo 1",
        //"Precio": "100",
        //"Tipo": "Tipo 1",
        //"uso": "protoboard"
        //}
    }

}