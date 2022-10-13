using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public string NoteTitle { get; set; }
        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]
        public string NoteContents { get; set; }
        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; } //작성자

    }
}
