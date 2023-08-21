

using System;
using System.Collections.Generic;

interface IFigura
{
    Prostokat GetBoundingRectangle();
}

class Punkt : IFigura
{
    private int x;
    private int y;

    public Punkt(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Prostokat GetBoundingRectangle()
    {
        return new Prostokat(x, y, x, y);
    }
}

class Kolo : IFigura
{
    private Punkt srodek;
    private int promien;

    public Kolo(Punkt srodek, int promien)
    {
        this.srodek = srodek;
        this.promien = promien;
    }

    public Prostokat GetBoundingRectangle()
    {
        int x1 = srodek.GetBoundingRectangle().GetX1() - promien;
        int y1 = srodek.GetBoundingRectangle().GetY1() - promien;
        int x2 = srodek.GetBoundingRectangle().GetX2() + promien;
        int y2 = srodek.GetBoundingRectangle().GetY2() + promien;

        return new Prostokat(x1, y1, x2, y2);
    }
}

class Odcinek : IFigura
{
    private Punkt p1;
    private Punkt p2;

    public Odcinek(Punkt p1, Punkt p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }

    public Prostokat GetBoundingRectangle()
    {
        int x1 = Math.Min(p1.GetBoundingRectangle().GetX1(), p2.GetBoundingRectangle().GetX1());
        int y1 = Math.Min(p1.GetBoundingRectangle().GetY1(), p2.GetBoundingRectangle().GetY1());
        int x2 = Math.Max(p1.GetBoundingRectangle().GetX2(), p2.GetBoundingRectangle().GetX2());
        int y2 = Math.Max(p1.GetBoundingRectangle().GetY2(), p2.GetBoundingRectangle().GetY2());

        return new Prostokat(x1, y1, x2, y2);
    }
}

class Prostokat : IFigura
{
    private int x1;
    private int y1;
    private int x2;
    private int y2;

    public Prostokat(int x1, int y1, int x2, int y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public int GetX1()
    {
        return x1;
    }

    public int GetY1()
    {
        return y1;
    }

    public int GetX2()
    {
        return x2;
    }

    public int GetY2()
    {
        return y2;
    }

    public Prostokat GetBoundingRectangle()
    {
        return this;
    }
}

class Program
{
    static Prostokat MinimumBoundingRectangle(IList<IFigura> listaFigur)
    {
        int x1 = int.MaxValue;
        int y1 = int.MaxValue;
        int x2 = int.MinValue;
        int y2 = int.MinValue;

        foreach (IFigura figura in listaFigur)
        {
            Prostokat prostokat = figura.GetBoundingRectangle();
            x1 = Math.Min(x1, prostokat.GetX1());
            y1 = Math.Min(y1, prostokat.GetY1());
            x2 = Math.Max(x2, prostokat.GetX2());
            y2 = Math.Max(y2, prostokat.GetY2());
        }

        return new Prostokat(x1, y1, x2, y2);
    }
}
