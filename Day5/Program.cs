// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

string[] lines = System.IO.File.ReadAllLines("input.txt");

var numbers = lines.First()
    .Split(',')
    .Select(Int32.Parse);