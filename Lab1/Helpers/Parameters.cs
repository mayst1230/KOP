namespace Lab1
{
    public class Parameters
    {
        public char finshChar { get; set; }

        public string getPtrn
        {
            get => strtChar + "[\\w\\d]+" + finshChar;
        }

        public string patrn { get; set; }

        public char strtChar { get; set; }
    }
}
