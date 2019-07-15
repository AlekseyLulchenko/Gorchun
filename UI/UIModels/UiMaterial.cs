namespace Gorchun.UI.UIModels
{
	public class UiMaterial
    {
		public string Cas { get; set; }
        public string Naimenovanie { get; set; }
        public string Formula { get; set; }

        public float MolekuliarniyVes { get; set; }
        public float Tkipeniya { get; set; }
		public float Tplavleniya { get; set; }
		public float Plotnost { get; set; }
		public float Viazkost { get; set; }
		public float Letuchest { get; set; }
		public float Cmax { get; set; }
		public float RastvorimostVVode { get; set; }
		public float Rastvorimost { get; set; }
		public float PH { get; set; }
		public float PovNatiazhenie { get; set; }

		public bool? Teratogennost { get; set; }
		public bool? Kantserogennost { get; set; }
		public bool? Mutagennost { get; set; }
		public bool? Imunnogennost { get; set; }
		public bool? Gepatotoksichnost { get; set; }

		public float LD50Zheludok { get; set; }
		public float LD50kozha { get; set; }
		public float LCt50 { get; set; }
    }
}
