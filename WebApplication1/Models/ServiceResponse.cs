namespace WebApplication1.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string Message { get; set; }
        public bool Sucess { get; set; }    
    }
}
