﻿using Microsoft.AspNetCore.Http;

namespace ShopTARgv23.Core.Dto
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFileCollection Attachment { get; set; }
    }
}
