namespace TodoApi.Models {
    public class TodoItem {
        public long Id { get; set; }
        public string Status { get; set; }
        public bool IsBattery { get; set; }
        public bool IsElevator { get; set; }
        public bool IsComplete { get; set; }
    }
}
