// See https://aka.ms/new-console-template for more information

using System;
using Day3;

string[] lines = System.IO.File.ReadAllLines("input.txt");

Console.WriteLine("PowerConsumption: " + PowerConsumption.Get(lines));
Console.WriteLine("Life support rating: " + LifeSupportRating.Get(lines));

//2981085