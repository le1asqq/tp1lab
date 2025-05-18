using System.ComponentModel.DataAnnotations;

namespace MVC_Calculator1.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Первый операнд обязателен")]
        public long Operand1 { get; set; }

        [Required(ErrorMessage = "Второй операнд обязателен")]
        [Range(typeof(float), "-1000000", "1000000", ErrorMessage = "Второй операнд должен быть числом от -1 000 000 до 1 000 000")]
        public float Operand2 { get; set; }

        public string Operation { get; set; }

        public float Result { get; set; }
    }
}
