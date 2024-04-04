using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    /// <summary>
    /// A class for storing private variables and objects used in the ASE application.
    /// </summary>
    public class PrivateVariables
    {
        public int x = 0;
        public int y = 0;
        public Graphics g;
        public Pen pen;
        public Brush brush;
        public CircleDrawer circleDrawer;
        public RectangleDrawer rectangleDrawer;
        public SquareDrawer squareDrawer;
        public Dictionary<string, int> variables = new Dictionary<string, int>();
        public VariableProcessor VariableProcessor = VariableProcessor.Singleton;
        public bool IsInsideWhileBlock = false;
        public bool WhileConditionCheck = false;
        public LoopHandler whileCommandHandler;
        public string whileCondition = "";

        /// <summary>
        /// Initializes a new instance of the PrivateVariables class.
        /// </summary>
        /// <param name="pictureBox">The PictureBox control used for drawing.</param>
        public PrivateVariables(PictureBox pictureBox)
        {
            g = pictureBox.CreateGraphics();
            pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Red);
            circleDrawer = new CircleDrawer(g, pen, brush);
            rectangleDrawer = new RectangleDrawer(g, pen, brush);
            squareDrawer = new SquareDrawer(g, pen);
            whileCommandHandler = new LoopHandler(VariableProcessor);
        }
    }
}
