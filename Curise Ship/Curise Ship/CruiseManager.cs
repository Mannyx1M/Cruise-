using System;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Curise_Ship
{
    public class CruiseManager
    {
        private List<Cruise> cruises; /// <summary>
        /// 
        /// </summary>
        private string xmlFilePath = "cruises.xml";

        public CruiseManager()
        {
            cruises = new List<Cruise>();/// schema 
            LoadCruisesFromXml();/// this is where we load from the xml file thatb we have saved ouer cruise from
        }

        public void AddCruise(Cruise cruise)
        {
            cruises.Add(cruise);
            SaveCruisesToXml();/// this is saving the cruise to xml
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Port saved successfully.");
            Console.ResetColor();
        }

        public void DisplayCruises()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Cruise:");
            foreach (var cruise in cruises)
            {
                Console.WriteLine($"Name: {cruise.Name}, Port: {cruise.Port}");
            }
            Console.ResetColor();
        }

        public void RemoveCruise(string cruiseName)
        {
            Cruise cruiseToRemove = cruises.Find(cruise => cruise.Name.Equals(cruiseName, StringComparison.OrdinalIgnoreCase));
            if (cruiseToRemove != null)
            {
                cruises.Remove(cruiseToRemove);
                SaveCruisesToXml();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Cruise '{cruiseName}' has benn succesfuly removed.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Cruise '{cruiseName}'not found try again.");
            }
        }

        private void SaveCruisesToXml()
        {
            using (var writer = new XmlTextWriter(xmlFilePath, null))
            {
                new XmlSerializer(typeof(List<Cruise>)).Serialize(writer, cruises);
            }
        }

        private void LoadCruisesFromXml()
        {
            if (File.Exists(xmlFilePath))
            {
                using (var reader = new XmlTextReader(xmlFilePath))
                {
                    cruises = (List<Cruise>)new XmlSerializer(typeof(List<Cruise>)).Deserialize(reader);
                }
            }
        }
    }
}
