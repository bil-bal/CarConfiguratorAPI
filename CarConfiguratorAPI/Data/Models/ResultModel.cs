using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarConfiguratorAPI.Data.Models
{
    public class ResultModel
    {
        [Key]
        public string Id { get; set; }

        public EngineModel Engine { get; set; }
        
        public OptionalModel Optional { get; set; }
        
        public PaintModel Paint { get; set; }
        
        public WheelModel Wheel { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public double TotalPrice { get; set; }

        public bool OrderComplete { get; set; }
    }
}
