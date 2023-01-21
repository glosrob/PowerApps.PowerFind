using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XRTSoft.PowerApps.PowerFind
{
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Power Find"),
        ExportMetadata("Description", "Search for any field across forms, views, workflows and Power Automates."),
        ExportMetadata(
            "SmallImageBase64",
            "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAVRSURBVFhHtZdrTFRHFIDPnXt5CYjyUKEqiAEpoAVsFU0bEYka+0p4adWqNWmatn9MfcA/f9lUCIlpjP+Kfdj6gjbpj0abWkpigmhrSiuFWipSpIUuq7xx2b13es7cYeHu3gW0+BH2njmzO3PmPGbmKjBD3j57KmJuwqL1nPNXOEC6wtgCVEeavdDPDaOXKUoTyl8P9jgaT5W+NWJ2Tc20BpT/UJtoKMoBUJQ3sBllaqfFCZx/pBjGh8c3FndJnS0BDSi7ciGcq2o5MHYAmxGm9pEZVDg/xnX9REV+iUvqLNgaUP79xSRD02pQXG1q/iec16M3dqI3/pYaL34GlNfVZBuqeglFivHswaED86egMq+wTWoEFgPK6mqS0e3XUIwzNbNOO/N4nv8gv8TrCSaf8N635+ZyxmpRfFKTE8swtOcOXT4bLNsTBmjBQUcx07Nk85FQ8C8xMhrCtCCpmZIXWGjIQSmbIUDXp6Prb6IYQu1HZc2iRChKyYabPX/B+ds0zLT0g9u9smJTaafwALqeLHqsyYmsuMXi6Xw4LJ4zIErRtHdJYAe/Ox+Drt8l1AFYHhUL25ZlwBzNGzov0aFzIBn7dW5Ak6MLvxMEW5PSYcX8qYsId9M3D1+5EMK0oKAt2A64+tR5cbAvYx1sWJwCadELpXaC5xYmov0KdA48AMfoECydGw0bl6TC3vRcyJaesUVRopmmFTCD85ekyo8UnHxvRi4Eqyq09/fCLec/sseEEmhV3FNCbuy+K553+nqh9X43qIxB6YrVsCo2QejtwLm34vmhpMq2hdR5C2APrkJjqhj0dPM1GNM9steEQhMbFgFuXcdJe4RuzNDhs5br0OrsBhwcXkt7NqAn8EBLJgP8TCS3v56+1rvyT1saweUzObFSrv6X3i4Y8YwJmfAYBnzeegNahBEMilNz4JlY87s+pDFMBku2LImcD3uk27uHB6D6VgOMetyydwLqz16wRMhNjnviORnyxBn0BHlPw3DsQE9QSCeDB1UklaF3MyJ6MZHuDT4QckxYOCyLihGyL5kxCRCiatDnGoXbfQ6ptZIQESX+iY4BJ3TKcSehMrTC8mta7enmBuH6IIw/hSLNpqRy5Op/6unAww796MNS9OT+zHUQimV5B8eiHHroE0auKIMMP/yOSBcm1cf4g3Ejdj1tNSImNByWz4sVMtW+L7Qt789cj1tzsBjjk2b7HEJ+Z9yj/ykbFshasvpuv1PEezd6Ig4znsiIiRfJ1YF9PSODQjdONBq3D3OIzoV27DdX7p9DBF7j2hhT2Tey7QdZXY3haHvgEAcOJRNtOrnxSaK/CbPfF/oO7QFm6TYEWrkAS7BeOXj5i3g1LKwT26qp9ofqOQLdOeB2idi+k7UBPBimY9cv2VYIfXcUV63b5MYkBvnYWDyr2rKTtje6BwQEdywxOUGlRztgC+52dpMTQ7gnTDM5+p+fqSzYPmyWoK5X4WdgX02ia6hPlOrVLtvUmSmjXDdOkuC9kpXVf1mNFUFX7ycOln7l8Q2FR0j2bkIe19hhfJgnypOE82bX8MhR2ZowoGrzDicYRgmKM75VPAb/4uqLT2zbPSrb1m24Iq/oR0XXX0axz9TMKg7M5leP5xW1yrbAYgCBLw91+CazGcUOUzMrtOLC8iryCunKb8HPAKJyY/EN8HhyMF7V2NRN7WPhwTFOcrd7DS7sN6mzYHkxseNIXe163IkO4Rb4Ijb9L4X2PMSJv8LyrsB3wp+lzpZpDRgHr+4LsUy3o7gWX1iz8ZmM/+IuiYPQq/gf3OC/Yppf1Qzj4vv5Jfepb2oA/gPUEPp3y7pXbwAAAABJRU5ErkJggg=="),
        ExportMetadata(
            "BigImageBase64",
            "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"),
        ExportMetadata("BackgroundColor", "LightGray"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "White")]
    public class PowerFind : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PowerFindControl();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PowerFind()
        {

        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));
            var refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();
            if (refAssembly != null)
            {
                var dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                var folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);
                var assmbPath = Path.Combine(dir, $"{argName}.dll");
                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }
            return loadAssembly;
        }
    }
}