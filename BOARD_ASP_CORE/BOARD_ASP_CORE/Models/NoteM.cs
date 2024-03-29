﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BOARD_ASP_CORE.Models {
    public class NoteM {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public int ReadCount { get; set; }
        public DateTime PostDate { get; set; }
        [Required]
        public string Content { get; set; }
        public List<IFormFile> uploadFile { get; set; }


    }
}
