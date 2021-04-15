using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace TablePlugin.BLL
{
    public class KompasConnector
    {
        public KompasConnector()
        {
			this.KsObject = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));

			this.KsObject.Visible = true;
			this.KsObject.ActivateControllerAPI();

			this.KsDoc = this.KsObject.Document3D();
			this.KsDoc.Create(false, true);
			this.Part = this.KsDoc.GetPart((short)Part_Type.pTop_Part);
		}

		private ksDocument3D KsDoc { get; }

		public KompasObject KsObject { get; set; }

		public ksPart Part { get; set; }
    }
}
