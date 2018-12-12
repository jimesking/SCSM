using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SCSMController
{
    public partial class AnaBar: UserControl
    {
        public AnaBar()
        {
            InitializeComponent();
            this.LowLimit = 0;
            this.UpperLimit = 100;

            this.H4l = 95;
            this.H3l = 90;
            this.H2l = 85;
            this.H1l = 80;

            this.L1l = 20;
            this.L2l = 15;
            this.L3l = 10;
            this.L4l = 5;
        }
        public AnaBar(double lowLimit,double upperLimit)
        {
            InitializeComponent();
            this.LowLimit = lowLimit;
            this.UpperLimit = upperLimit;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int xStart = 38;
            int xEnd = 48;
            int yStart = 330;
            int yEnd = 30;

            SolidBrush brush = new SolidBrush(Color.Black);

            int yValue = 0;
            double rate = this.progressBar1.Height / (this.UpperLimit - this.LowLimit);

            Font font = new Font("宋体", 9);

            #region 输出高低报警箭头和数值
            //高报警
            if (this.H4l != 0) {
                yValue = Convert.ToInt32( Math.Round(yStart - this.H4l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue-5), new Point(xStart, yValue+5), new Point(xEnd, yValue) });

                SizeF sizeF = g.MeasureString(this.H4l.ToString(), font);

                g.DrawString(Util.Common.NumberFormatOutputToString(this.H4l,""), font, brush, xStart - 3 - sizeF.Width, yValue - 5);
            }

            if (this.H3l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.H3l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }

            if (this.H2l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.H2l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }

            if (this.H1l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.H1l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }
            //低报警
            if (this.l1l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.l1l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }

            if (this.l2l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.l2l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }

            if (this.l3l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.l3l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }

            if (this.l4l != 0)
            {
                yValue = Convert.ToInt32(Math.Round(yStart - this.l4l * rate));
                g.FillPolygon(brush, new Point[] { new Point(xStart, yValue - 5), new Point(xStart, yValue + 5), new Point(xEnd, yValue) });
            }
            #endregion

            #region 

            #endregion
        }

        public int valueConvert(double value, double upper, double low)
        {
            if (upper <= low)
            {
                return 0;
            }
            else
            {

                double rate = 0;

                rate = 100 / (upper - low);

                return Convert.ToInt32(Math.Round(rate * (value - low)));
            }
        }

        #region Value and Q
        private double value = 0;
        private bool q = true;

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                if (value >= this.LowLimit && value <= this.UpperLimit)
                {
                    this.value = value;
                    progressBar1.Value = valueConvert(value, this.UpperLimit, this.LowLimit);
                }
            }
        }

        public bool Q
        {
            get
            {
                return q;
            }

            set
            {
                q = value;
            }
        }
        #endregion


        #region limit
        private double upperLimit = 0;
        private double lowLimit = 0;

        [Description("模拟量上限")]
        public double UpperLimit
        {
            get
            {
                return upperLimit;
            }

            set
            {
                upperLimit = value;
                label2.Text = value.ToString();
            }
        }
        [Description("模拟量下限")]
        public double LowLimit
        {
            get
            {
                return lowLimit;
            }

            set
            {
                lowLimit = value;
                label1.Text = value.ToString();
            }
        }
        #endregion

        #region alarm leval
        private double h4l = 0;
        private double h3l = 0;
        private double h2l = 0;
        private double h1l = 0;

        private double l1l = 0;
        private double l2l = 0;
        private double l3l = 0;
        private double l4l = 0;

        public double H4l
        {
            get
            {
                return h4l;
            }

            set
            {
                h4l = value;
            }
        }

        public double H3l
        {
            get
            {
                return h3l;
            }

            set
            {
                h3l = value;
            }
        }

        public double H2l
        {
            get
            {
                return h2l;
            }

            set
            {
                h2l = value;
            }
        }

        public double H1l
        {
            get
            {
                return h1l;
            }

            set
            {
                h1l = value;
            }
        }

        public double L1l
        {
            get
            {
                return l1l;
            }

            set
            {
                l1l = value;
            }
        }

        public double L2l
        {
            get
            {
                return l2l;
            }

            set
            {
                l2l = value;
            }
        }

        public double L3l
        {
            get
            {
                return l3l;
            }

            set
            {
                l3l = value;
            }
        }

        public double L4l
        {
            get
            {
                return l4l;
            }

            set
            {
                l4l = value;
            }
        }
        #endregion
    }

    class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle tangle = new Rectangle(0, 0, base.Width, base.Height);

            if (this.Value <= 35)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), tangle);
            }

            if (this.Value > 35 && this.Value <= 65)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), tangle);
            }

            if (this.Value > 65)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), tangle);
            }
        }
    }
}
