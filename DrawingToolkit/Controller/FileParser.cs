using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Controller
{
    public class FileParser
    {
        public string[] Pack(List<DrawingObject> drawingObjects) {

            drawingObjects.Sort((lhs, rhs) => {
                return lhs.Id.CompareTo(rhs.Id);
            });

            string[] result = new string[drawingObjects.Count];
            List<List<string>> tokens = new List<List<string>>(drawingObjects.Count);
            for (int i = 0; i < drawingObjects.Count; i++) {
                tokens.Add(drawingObjects[i].ToTokenString());
                result[i] = FormatTokenAsString(tokens[i]);
            }   
            return result;
        }

        private string FormatTokenAsString(List<string> tokens) {
            string result = "";
            foreach (string token in tokens) {
                result += token + " ";
            }
            return result;
        }

        public IEnumerable<DrawingObject> Parse(string[] content){
            Dictionary<int, DrawingObject> drawables = new Dictionary<int, DrawingObject>();
            for (int i=0;i<content.Length;i++) {
                string[] token = content[i].Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
                DrawingObject result = DrawableFactory.ConstructDrawable(drawables, token);
                result.SetState(IdleState.GetState());
                drawables.Add(result.Id, result);
            }
            List<DrawingObject> finalDrawable = new List<DrawingObject>();
            foreach (DrawingObject drawable in drawables.Values) {
                finalDrawable.Add(drawable);
            }
            return finalDrawable;
        }
    }
}
