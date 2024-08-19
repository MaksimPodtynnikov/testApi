namespace testApi
{
    public class Status
    {
        public int Id { get; set; }
        public string GetStatus => status ? "Активно" : "Заблокировано";
        public bool status { get; set; }
    }
}
