using System.ComponentModel.DataAnnotations;

namespace Rabbit_Web.Models {
    public class User {
        //Code First 작업이기 때문에 class 모델을 만들때 key값 및 제약조건을 걸어버린다.([]를 통해 걸 수 있음)

        /// <summary>
        /// 사용자 번호 
        /// </summary>
        [Key] //PK 설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage ="사용자 이름을 입력하세요.")]  //Not Null 설정
        public string UserName { get; set; }
        
        /// <summary>
        /// 사용자 아이디
        /// </summary>
        [Required(ErrorMessage = "사용자 ID를 입력하세요.")]  //Not Null 설정
        public string UserId { get; set; }
        
        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]  //Not Null 설정
        public string UserPassword { get; set; }

    }
}
