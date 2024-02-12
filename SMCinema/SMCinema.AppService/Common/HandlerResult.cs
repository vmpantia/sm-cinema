namespace SMCinema.AppService.Common
{
    public class HandlerResult<TData>
    {
        public bool Success { get; set; }
        public TData? Data { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
