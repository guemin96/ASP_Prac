using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit_Web.Models {
    public class Note 
    {
        /// <summary>
        /// 게시물번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }
        /// <summary>
        /// 게시물 제목
        /// </summary>
        
        [Required(ErrorMessage ="게시물 제목을 입력하세요.")]
        public string NoteTitle { get; set; }
        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required(ErrorMessage = "게시물 내용을 입력하세요.")]
        public string NoteContents { get; set; }
        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; } //작성자

        //UserNo를 통해서 UserName을 가지고 오기 위해서(Join과 같은 역할)
        [ForeignKey("UserNo")]  
        public virtual User User { get; set; }
    }
}
