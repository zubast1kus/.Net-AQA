namespace Task_4.Models
{
    public class ID 
    {
        private static long cntr = 0;
        public long Id { get; }
        public ID()
        {
            Id = cntr;
            cntr++;
        }
        public override string ToString()
        {
            return Id.ToString();
        }
        public bool Equals(long id)
        {
            return Id == id;
        }
        public long CompareTo(ID id)
        {
            return Id - id.Id;
        }
    }
}
