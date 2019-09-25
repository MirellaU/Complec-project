using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        static public Complex Addition(Complex a, Complex b)
        {
            double c_real = a.Real + b.Real;
            double c_imag = a.Imaginary + b.Imaginary;
            Complex c = new Complex(c_real, c_imag);
            return c;
        }

        static  public Complex Subtraction(Complex a, Complex b)
        {
            double c_real = a.Real - b.Real;
            double c_imag = a.Imaginary - b.Imaginary;
            Complex c = new Complex(c_real, c_imag);
            return c;
        }

        static public Complex Multiplication(Complex a, Complex b)
        {
            double c_real = a.Real*b.Real-a.Imaginary*b.Imaginary;
            double c_imag = a.Imaginary * b.Real + a.Real * b.Imaginary;
            Complex c = new Complex(c_real, c_imag);
            return c;
        }

        static public Complex Division(Complex a, Complex b)
        {
            double c_imag = (a.Imaginary * b.Real - a.Real * b.Imaginary)/(Math.Pow(b.Real,2)+ Math.Pow(b.Imaginary,2));
            double c_real = a.Real * b.Real + a.Imaginary * b.Imaginary+c_imag/ (Math.Pow(b.Real, 2) + Math.Pow(b.Imaginary, 2));
            Complex c = new Complex(c_real, c_imag);
            return c;
        }

    }
}
