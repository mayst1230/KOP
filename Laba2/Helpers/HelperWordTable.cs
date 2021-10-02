using System.Collections.Generic;

namespace Laba2
{
    public class HelperWordTable
    {
        /// <summary>
        /// <param name="MainHeader">Основной заголовок</param>
        /// </summary>
        public string MainHeader { get; set; }

        /// <summary>
        /// <param name="AdvancedHeader">Дополнительные заголовки</param>
        /// </summary>
        public List<string> AdvancedHeader { get; set; }

        /// <summary>
        /// <param name="Width">Ширина ячеек</param>
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// <param name="Properties">Свойства заголовков</param>
        /// </summary>
        public List<string> Properties { get; set; }
    }
}
