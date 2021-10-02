namespace Laba2View
{
    public class Cars
    {
        /// <summary>
        /// <param name="Name">Название марки автомобиля</param>
        /// </summary>
        public string NameCarBrand { get; set; }

        /// <summary>
        /// <param name="Number">Серийный номер автомобиля</param>
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// <param name="OwnerName">Имя владельца автомобиля</param>
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// <param name="YearPurchase">Дата покупки автомобиля</param>
        /// </summary>
        public int? YearPurchaseAuto { get; set; }

        /// <summary>
        /// <param name="YearPurchase">Сумма покупки автомобиля</param>
        /// </summary>
        public decimal? SumPurchaseAuto { get; set; }
    }
}
