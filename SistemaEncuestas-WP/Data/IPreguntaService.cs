namespace SistemaEncuestas_WP.Data
{
    public interface IPreguntaService
    {
        public List<Preguntum> getPreguntas();
        public void CreatePreguntas(string pregunta, string nombreArea, DateTime fechaCreacion);
    }
}
