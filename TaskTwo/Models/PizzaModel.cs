namespace TaskTwo.Models
{
    public class JsonResponseViewModel
    {
        public int ResponseCode {  get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }

    public class PizzaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image {  get; set; }

        public string Ingredients { get; set; }
        public int Price { get; set; }

        public string Weight { get; set; }

    }
}
