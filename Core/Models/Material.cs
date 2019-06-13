using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gorchun.Core.Models
{
    public class Material
    {
        public Material()
        {
            Teratogennost = false;
            Kantserogennost = false;
            Mutagennost = false;
            Imunnogennost = false;
            Gepatotoksichnost = false;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cas { get; set; }
        public string Naimenovanie { get; set; }
        public string Formula { get; set; }
        public decimal MolekuliarniyVes { get; set; }
        public decimal Tkipeniya { get; set; }
        public decimal Tplavleniya { get; set; }
        public decimal Plotnost { get; set; }
        public decimal Viazkost { get; set; }
        public decimal Letuchest { get; set; }
        public decimal Cmax { get; set; }
        public decimal RastvorimostVVode { get; set; }
        public decimal Rastvorimost { get; set; }
        public decimal PH { get; set; }
        public decimal PovNatiazhenie { get; set; }
        public bool? Teratogennost { get; set; }
        public bool? Kantserogennost { get; set; }
        public bool? Mutagennost { get; set; }
        public bool? Imunnogennost { get; set; }
        public bool? Gepatotoksichnost { get; set; }
        public decimal LD50Zheludok { get; set; }
        public decimal LD50kozha { get; set; }
        public decimal LCt50 { get; set; }
    }
}
