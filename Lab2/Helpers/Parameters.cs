using System.Collections.Generic;

namespace Lab2
{
    public class Parameters<T>
    {
        public string Path { get; set; }

        public List<T> Data { get; set; }

        public string PropertyName { get; set; }
    }
}