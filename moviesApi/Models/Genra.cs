﻿
namespace moviesApi.Models
{
    public class Genra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

    }
}
