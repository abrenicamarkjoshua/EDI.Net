using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace indice.Edi.Tests
{
    public static class Helpers
    {
        private static readonly Assembly _assembly = typeof(EdiTextReaderTests).GetTypeInfo().Assembly;
        public static Stream GetResourceStream(string fileName) {
            var qualifiedResources = _assembly.GetManifestResourceNames().OrderBy(x => x).ToArray();
            Stream stream = _assembly.GetManifestResourceStream("indice.Edi.Tests.Samples." + fileName);
            return stream;
        }

        public static MemoryStream StreamFromString(string value) {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

        public static Stream GetBigSampleStream(string fileName) {
            var path = Path.Combine(Path.GetDirectoryName(_assembly.Location), "SamplesBig", fileName);
            Stream stream = File.OpenRead(path);
            return stream;
        }

        public static void format870(ref string formatted870Raw) {
            string output = formatted870Raw.Replace("\r\n", "~\n").Replace("\r", "~\r").Replace("~~", "~");
            formatted870Raw = output;
        }
    }
}
