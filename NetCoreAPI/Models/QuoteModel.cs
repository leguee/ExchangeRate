namespace ExchangeRate.Models
{
    /// <summary>
    /// Modelo que almacena los datos devuelto por la api externa del tipo de cambio actual
    /// </summary>
    public class QuoteModel
    {
        public QuoteModel()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
        public string Status { get; set; }
    }

    public class Result
    {
        public Result() { }

        public string Updated { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Value { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
    }
}
