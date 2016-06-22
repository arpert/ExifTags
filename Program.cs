/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2016-06-13
 * Time: 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ExifTags
{
	[XmlType( typeName:"tag")]
	public class ExifTag
	{
		[XmlAttribute]
		public string idhex;

		[XmlAttribute]
		public int id;

		[XmlAttribute]
		public string IFD;

		[XmlAttribute]
		public string key;

		[XmlAttribute]
		public string type;

		[XmlElement]
		public string description;
		
		public ExifTag()
		{
			idhex = "0x0";
			id = 0;
			IFD = "IFD";
			key = "key";
			type = "type";
			description = "desc";
		}
			
	}
	
	class Program
	{
		[XmlElement(elementName:"exifTags")]
		public static ExifTag[] exifTags;
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Serialize");
			
			// TODO: Implement Functionality Here
			if (args.Length < 1)
			{
				Console.WriteLine("Podaj nazwę pliku");
			} else
			{
			
			   exifTags = new ExifTag[10];
			   for(int i = 0; i < exifTags.Length; i++)
			   {
			   	exifTags[i] = new ExifTag();
			   	exifTags[i].id = i;
			   	exifTags[i].idhex = String.Format("0x{0:X}", i);
		       }
			
			XmlSerializerFactory xsf = new XmlSerializerFactory();
			XmlSerializer xs = xsf.CreateSerializer(typeof(ExifTag[]), new XmlRootAttribute("exifTags"));
			
			StreamReader r = new StreamReader(args[0]);
			
			StreamWriter w = new StreamWriter(args[0] + ".out");
			exifTags = (ExifTag[])xs.Deserialize(r);
			   xs.Serialize(w, exifTags);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}