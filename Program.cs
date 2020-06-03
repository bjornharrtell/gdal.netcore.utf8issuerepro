using MaxRev.Gdal.Core;
using OSGeo.GDAL;
using OSGeo.OSR;
using System;
using System.IO;

namespace GdalCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Working directory: " + Directory.GetCurrentDirectory());
                Console.WriteLine("Trying to configure all twice");
                GdalBase.ConfigureAll();
                GdalBase.ConfigureAll();
                Console.WriteLine("GDAL configured");

                Console.WriteLine(string.Join('\n',
                    "GDAL Version: " + Gdal.VersionInfo("RELEASE_NAME"),
                    "GDAL INFO: " + Gdal.VersionInfo("")));
                var spatialReference = new SpatialReference(null);
                spatialReference.SetWellKnownGeogCS("wgs84");

                var dataset = OSGeo.OGR.Ogr.Open("test222.shp", 0);
                var layer = dataset.GetLayerByIndex(0);
                var feature = layer.GetNextFeature();
                var field = feature.GetFieldAsString("overflade");
                Console.WriteLine("test222 overflade attribute value");
                Console.WriteLine("expected:" + "Befæstet");
                Console.WriteLine("actual:" + field);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
