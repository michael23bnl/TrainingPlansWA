using System.ComponentModel.DataAnnotations;

namespace TrainingPlansWA.Models {
    public class FeedbackFormModel {

        public int ID { get; set; }

        public int Answer { get; set; }

        [StringLength(100)]

        [Display(Name = "Как к вам обращаться?")]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string FullName { get; set; }

        [StringLength(255)]
        [Display(Name = "Ваш email")]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Email { get; set; }

        [Display(Name = "Если у Вас есть предложения, пожалуйста, сообщите нам")]
        [StringLength(1000, ErrorMessage = "Длина сообщения не должна " +
            "превышать 30 символов")]
        public string Message { get; set; }



    }
}
