﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace PBL3.GUI_CCH
{
    public class RJButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;

        [Category("RJ Code Advance")]
        public int BorderSize { get => borderSize; set { borderSize = value;   this.Invalidate(); } }


        [Category("RJ Code Advance")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }

        [Category("RJ Code Advance")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value;}
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }


        //Constructor
        public RJButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150,40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }

        //Method 
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect.X,            rect.Y,             radius, radius, 180, 90);
            graphicsPath.AddArc(rect.Width-radius, rect.Y,             radius, radius, 270, 90);
            graphicsPath.AddArc(rect.Width-radius, rect.Height-radius, radius, radius, 0,   90);
            graphicsPath.AddArc(rect.X,            rect.Height-radius, radius, radius, 90,  90);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0,0,this.Width,this.Height);
            RectangleF rectBorder = new RectangleF(1,1,this.Width - 0.8F,this.Height - 1);

            if(borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius)) 
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface =  new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button Surface 
                    this.Region = new Region(pathSurface);
                    //Draw Surface border for HD result
                    pevent.Graphics.DrawPath(penSurface,pathSurface);
                    //Draw control border 

                    //Button border
                    if(borderSize>=1)
                    {   //Draw control border
                        pevent.Graphics.DrawPath(penBorder,pathBorder);
                    }    

                }    
            }
            else // normal button
            {
                this.Region = new Region(rectSurface);
                if(borderSize >=1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder,0,0,this.Width-1,this.Height-1);
                    }    
                }    
            }
            //base.OnPaint(pevent);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if(this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
