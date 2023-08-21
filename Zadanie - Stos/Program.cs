
using StrukturaStos;

var s = new Stos<double>();
Console.WriteLine(s.IsEmpty);
try
{
    var x = s.Peek;
}
catch (StosEmptyException)
{
    Console.WriteLine("StosEmptyException");
}