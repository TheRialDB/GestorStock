namespace GestorStock.Client.Servicios
    {
    public class HttpRespuesta<T>
        {
        public T? Respuesta { get; set; }

        public bool Error { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpRespuesta(T? response, bool error, HttpResponseMessage httpResponseMessage)
            {
            this.Respuesta = response;
            this.Error = error;
            this.HttpResponseMessage = httpResponseMessage;
            }

        public async Task<string> ObtenerError()
            {
            if (!Error)
                {
                return "";
                }

            var statuscode = HttpResponseMessage.StatusCode;

            switch (statuscode)
                {
                case System.Net.HttpStatusCode.BadRequest:
                return await HttpResponseMessage.Content.ReadAsStringAsync();
                case System.Net.HttpStatusCode.Unauthorized:
                return "Error, no está logueado";
                case System.Net.HttpStatusCode.Forbidden:
                return "Error, no tiene autorización a ejecutar este proceso";
                case System.Net.HttpStatusCode.NotFound:
                return "Error, no se pudo encontrar la informacion";
                default:
                return await HttpResponseMessage.Content.ReadAsStringAsync();
                }
            }
        }
    }
