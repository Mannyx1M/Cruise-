using System;
using System.Xml.Serialization;

namespace Curise_Ship
{

	public class Cruise
	{
        public string Name { get; set; }
        public string Port { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

