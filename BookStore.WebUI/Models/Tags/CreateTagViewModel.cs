﻿namespace BookStore.WebUI.Models.Tags
{
    public class CreateTagViewModel
    {
        public string TagName { get; set; }
        public List<string> Errors { get; set; } = new(); 
    }
}
