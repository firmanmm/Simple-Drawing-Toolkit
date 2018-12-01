using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Controller
{
    public abstract class DrawableFactory
    {
        private static Dictionary<string,Func<Dictionary<int, DrawingObject>, string[], DrawingObject>> strategyMapper;

        private static void PrepareMapper() {
            if (strategyMapper == null) {
                strategyMapper = new Dictionary<string, Func<Dictionary<int, DrawingObject>, string[], DrawingObject>>();
            }
        }

        public static void AddStrategy(string key, Func<Dictionary<int, DrawingObject>, string[], DrawingObject> strategy) {
            PrepareMapper();
            if (strategyMapper.ContainsKey(key)) {
                throw new Exception("Key already used");
            }

            strategyMapper.Add(key, strategy);
        }

        public static DrawingObject ConstructDrawable(Dictionary<int,DrawingObject> drawingPool, string[] token) {
            PrepareMapper();
            if (!strategyMapper.ContainsKey(token[0])) {
                throw new NotSupportedException("Current drawable type is not supported");
            }

            return strategyMapper[token[0]].Invoke(drawingPool, token);
        }
    }
}
