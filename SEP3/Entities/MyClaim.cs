namespace SEP3.Entities
{
    public class MyClaim{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString() {
            return $"Name: {Name}, Value {Value}";
        }
    }
}