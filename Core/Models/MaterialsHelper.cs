using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorchun.Core.Models
{
    public static class MaterialsHelper
    {
        public static Material UpdateFrom(this Material existingElement, Material item)
        {
            existingElement.Cmax = item.Cmax;
            existingElement.Formula = item.Formula;
            existingElement.Gepatotoksichnost = item.Gepatotoksichnost;
            existingElement.Imunnogennost = item.Imunnogennost;
            existingElement.Kantserogennost = item.Kantserogennost;
            existingElement.LCt50 = item.LCt50;
            existingElement.LD50kozha = item.LD50kozha;
            existingElement.LD50Zheludok = item.LD50Zheludok;
            existingElement.Letuchest = item.Letuchest;
            existingElement.MolekuliarniyVes = item.MolekuliarniyVes;
            existingElement.Mutagennost = item.Mutagennost;
            existingElement.Naimenovanie = item.Naimenovanie;
            existingElement.PH = item.PH;
            existingElement.Plotnost = item.Plotnost;
            existingElement.PovNatiazhenie = item.PovNatiazhenie;
            existingElement.Rastvorimost = item.Rastvorimost;
            existingElement.RastvorimostVVode = item.RastvorimostVVode;
            existingElement.Teratogennost = item.Teratogennost;
            existingElement.Tkipeniya = item.Tkipeniya;
            existingElement.Tplavleniya = item.Tplavleniya;
            existingElement.Viazkost = item.Viazkost;
            return existingElement;
        }
    }
}
