using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DrawingToolkit.Controller
{
    public class FileManager
    {

        private readonly FileParser parser;
        private readonly string currentPath;

        public FileManager() {
            parser = new FileParser();
            currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
            Console.WriteLine(currentPath);
        }

        public IEnumerable<DrawingObject> Load(string name) {
            string targetPath = currentPath + name;
            if (File.Exists(targetPath)) {
                string[] text = File.ReadAllLines(targetPath);
                return parser.Parse(text);
            }
            throw new FileNotFoundException(targetPath);
        }

        public bool Save(IEnumerable<DrawingObject> drawingObjects, string name) {
            List<DrawingObject> decomposedDrawable = new List<DrawingObject>(drawingObjects);

            for (int i = 0; i < decomposedDrawable.Count; i++) {
                IEnumerable<DrawingObject> child = decomposedDrawable[i].GetChilds();
                if (child != null) {
                    decomposedDrawable.AddRange(child);
                }
            }

            string[] result = parser.Pack(decomposedDrawable);
            File.WriteAllLines(currentPath + name, result);
            return true;
        }
    }
}
