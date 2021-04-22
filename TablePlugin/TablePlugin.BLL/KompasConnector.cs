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

			var ksDoc = this.KsObject.Document3D();
			ksDoc.Create(false, true);
			this.Part = ksDoc.GetPart((short)Part_Type.pTop_Part);
		}

		public KompasObject KsObject { get; set; }

		public ksPart Part { get; set; }
    }
}
