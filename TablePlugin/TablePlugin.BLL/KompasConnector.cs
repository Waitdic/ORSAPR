using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace TablePlugin.BLL
{
    /// <summary>
    /// Класс для подключения к КОМПАС3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KompasConnector"/> class.
        /// </summary
        public KompasConnector()
        {
			KsObject = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));

			KsObject.Visible = true;
			KsObject.ActivateControllerAPI();

            GetNewPart();
        }

        /// <summary>
        /// Интерфейс API Компаc3D.
        /// </summary>
		public KompasObject KsObject { get; set; }

        /// <summary>
        /// Интерфейс компонента Компас3D.
        /// </summary>
        public ksPart Part { get; set; }

        /// <summary>
        /// Метод для создания нового компонента в Компас3D.
        /// </summary>
        public void GetNewPart()
        {
            var ksDoc = KsObject.Document3D();
            ksDoc.Create(false, true);
            Part = ksDoc.GetPart((short)Part_Type.pTop_Part);
        }
    }
}
