﻿namespace FrontToBackFlower.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageURL { get; set; }
        public string? Descriptions { get; set; }
        public Category? Category { get; set; }

    }
}
