namespace testApi
{
    public class Status
    {
        public int Id { get; set; }
        public string GetStatus => status ? "�������" : "�������������";
        public bool status { get; set; }
    }
}
