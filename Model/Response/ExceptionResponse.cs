using Model.Helper;


namespace Model.Response
{
    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ExceptionResponse(Exception ex)
        {
            Message = ex.Message;
            StatusCode = 500;
            if (ex is HttpException httpExeption)
            {
                StatusCode = (int)httpExeption.Status;
            }
        }
    }
}
