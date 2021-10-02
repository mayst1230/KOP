namespace ViewLab1
{
    public class Cars
    {
        private int numberCar;

        public string Company
        {
            get;
            set;
        }

        public int NumberCar
        {
            get
            {
                return numberCar;
            }
            set
            {
                numberCar = value > 0 ? value : 0;
            }
        }
    }
}
