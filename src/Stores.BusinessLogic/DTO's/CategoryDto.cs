﻿namespace Stores.BusinessLogic.DTO_s
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryTypeDto CategoryType { get; set; }
    }
}
