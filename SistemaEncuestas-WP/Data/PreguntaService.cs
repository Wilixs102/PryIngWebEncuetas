using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace SistemaEncuestas_WP.Data
{
    public class PreguntaService : IPreguntaService
    {
        private readonly EncuestaUdlaContext _context;

        public PreguntaService(EncuestaUdlaContext context) {
            _context = context;
        }

        public List<Preguntum> getPreguntas()
        {
            List<Preguntum> list = _context.Pregunta.ToList();
            return list;
        }

        public async void CreatePreguntas(string pregunta, string nombreArea, DateTime fechaCreacion)
        {
            Preguntum question = new Preguntum();
            question.NombreArea = nombreArea;
            question.Pregunta = pregunta;
            question.FechaCreacion = fechaCreacion;
            _context.Add(question);
            await _context.SaveChangesAsync();
        }



       

    }
}
