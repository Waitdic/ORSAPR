using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace TablePlugin.BLL
{
    public class KompasConnector
    {
        public KompasConnector()
        {
			KsObject = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));

			KsObject.Visible = true;
			KsObject.ActivateControllerAPI();

            GetNewPart();
        }

		public KompasObject KsObject { get; set; }

        public ksPart Part { get; set; }

        public void GetNewPart()
        {
            var ksDoc = KsObject.Document3D();
            ksDoc.Create(false, true);
            Part = ksDoc.GetPart((short)Part_Type.pTop_Part);
        }
    }
}
